# Dapr 使用手册

> Dapr（Distributed Application Runtime，分布式应用运行时）是微软开源的、与语言无关的微服务构建框架。它以 **Sidecar** 形式运行在应用旁，把「服务调用、状态管理、发布订阅、密钥、可观测性」等分布式难题下沉到运行时，让开发者专注业务。本手册覆盖架构、构建块、组件、.NET 集成、部署与排障。

## 目录

1. [Dapr 简介与核心概念](#一dapr-简介与核心概念)
2. [架构与 Sidecar 模型](#二架构与-sidecar-模型)
3. [安装与环境搭建](#三安装与环境搭建)
4. [构建块总览](#四构建块总览)
5. [服务调用（Service Invocation）](#五服务调用service-invocation)
6. [状态管理（State Management）](#六状态管理state-management)
7. [发布订阅（Pub/Sub）](#七发布订阅pubsub)
8. [绑定（Bindings）](#八绑定bindings)
9. [密钥管理（Secrets）](#九密钥管理secrets)
10. [配置管理（Configuration）](#十配置管理configuration)
11. [Actor 模型](#十一actor-模型)
12. [工作流（Workflow）](#十二工作流workflow)
13. [组件（Components）详解](#十三组件components详解)
14. [与 .NET 集成（Dapr .NET SDK）](#十四与-net-集成dapr-net-sdk)
15. [部署模式](#十五部署模式)
16. [可观测性](#十六可观测性)
17. [故障排查](#十七故障排查)
18. [常用命令速查](#十八常用命令速查)
19. [最佳实践](#十九最佳实践)

---

## 一、Dapr 简介与核心概念

### 1.1 Dapr 解决什么问题

微服务架构下，每个服务都要自己处理大量「非业务」的分布式难题：

- 服务发现与调用（谁在哪、怎么调、超时重试熔断）
- 状态存储（数据存哪、如何一致）
- 消息通信（发布订阅、消息路由）
- 密钥与配置管理
- 可观测性（日志、指标、链路追踪）
- 分布式锁、工作流、Actor

**Dapr 把这些能力统一封装**，通过 HTTP/gRPC API 提供给任意语言的应用，用可插拔的「组件」对接不同中间件。

### 1.2 Dapr 的核心价值

| 特性 | 说明 |
|------|------|
| **语言无关** | 任何语言通过 HTTP/gRPC 调用，官方提供 .NET/Java/Go/JS/Python SDK |
| **中间件无关** | 换 Redis → SQL Server → 云服务，只改组件配置，不改代码 |
| **可移植** | 同一套代码可跑在本地、VM、K8s、云 |
| **Sidecar 模式** | 不改应用部署形态，旁挂一个进程 |

### 1.3 Dapr 与你的技术栈

你的 ERP/MES 架构（.NET 8 + Redis + RabbitMQ + SQL Server + MinIO + K8s）可以这样映射到 Dapr：

| 你的技术栈 | Dapr 构建块 | 对应组件 |
|------|------|------|
| 服务间 HTTP 调用 | Service Invocation | 内置（无需组件） |
| Redis 缓存/会话 | State Management | `state.redis` |
| RabbitMQ 消息 | Pub/Sub | `pubsub.rabbitmq` |
| SQL Server 持久化 | State Management | `state.sqlserver` |
| MinIO 对象存储 | Bindings | `bindings.s3` |
| 定时任务 | Bindings | `bindings.cron` |
| 敏感配置 | Secrets | `secretstores.*` |

---

## 二、架构与 Sidecar 模型

### 2.1 Sidecar 架构

Dapr 的核心理念是 **Sidecar（边车）**：每个应用实例旁都部署一个 `daprd` 进程，应用只和它通信，分布式能力全部由 sidecar 完成。

```
┌─────────────────────────── 应用 Pod / 主机 ───────────────────────────┐
│                                                                        │
│   ┌──────────────┐        HTTP(3500)/gRPC(50001)      ┌───────────┐   │
│   │   你的应用     │ ◀──────────────────────────────▶ │  daprd    │   │
│   │ (.NET/任意)   │         (localhost)               │ (Sidecar) │   │
│   └──────────────┘                                    └─────┬─────┘   │
│                                                              │        │
└──────────────────────────────────────────────────────────────┼────────┘
                                                               │
              ┌────────────────────┬─────────────┬─────────────┤
              ▼                    ▼             ▼             ▼
        ┌──────────┐        ┌──────────┐   ┌──────────┐  ┌──────────┐
        │  Redis   │        │ RabbitMQ │   │ SQL Server│  │  其他    │
        │ (状态/锁) │        │ (Pub/Sub)│   │ (状态)    │  │  组件    │
        └──────────┘        └──────────┘   └──────────┘  └──────────┘
```

### 2.2 应用与 Sidecar 的交互

- 应用通过 **localhost** 与自己的 sidecar 通信（不跨网络）
- 应用无需知道其他服务在哪，只需知道「目标 app-id」
- 组件（Redis、RabbitMQ 等）的连接细节全部在 sidecar 侧配置

### 2.3 关键环境变量

| 环境变量 | 说明 | 默认值 |
|------|------|------|
| `DAPR_HTTP_PORT` | sidecar HTTP 端口 | 3500 |
| `DAPR_GRPC_PORT` | sidecar gRPC 端口 | 50001 |
| `DAPR_APP_ID` | 应用唯一标识（服务调用、pub/sub 都靠它） | 必填 |
| `DAPR_APP_PORT` | 应用监听端口（sidecar 回调用） | — |
| `DAPR_COMPONENTS_PATH` | 组件 YAML 目录 | 自托管默认 `./components` |

---

## 三、安装与环境搭建

### 3.1 安装 Dapr CLI

```bash
# Windows（PowerShell）
iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex

# Linux / macOS
curl -fsSL https://raw.githubusercontent.com/dapr/cli/master/install/install.sh | /bin/bash

# 验证
dapr --version
```

### 3.2 初始化本地环境（自托管模式）

```bash
# 初始化（会自动起 Redis、Zipkin、placement 等容器，需 Docker）
dapr init

# 查看状态
dapr status

# 卸载
dapr uninstall
```

> 自托管模式用 Docker 运行 sidecar 和默认组件；生产用 K8s 模式（`dapr init -k`）。

### 3.3 快速体验

```bash
# 启动一个应用，sidecar 自动拉起
dapr run --app-id myapp --app-port 5000 -- dotnet run

# 查看运行中的应用
dapr list

# 打开 Dapr 控制台（查看组件、配置、追踪）
dapr dashboard
```

---

## 四、构建块总览

Dapr 的能力按「构建块（Building Blocks）」组织：

| 构建块 | 用途 | 对应 API 前缀 |
|------|------|------|
| **服务调用** | 服务间同步调用、重试、熔断 | `/v1.0/invoke/...` |
| **状态管理** | 键值状态读写、事务、并发控制 | `/v1.0/state/...` |
| **发布订阅** | 异步消息、事件驱动 | `/v1.0/publish` + 订阅回调 |
| **绑定** | 对接外部系统（定时、存储、消息） | `/v1.0/bindings/...` |
| **密钥管理** | 安全获取密钥 | `/v1.0/secrets/...` |
| **配置管理** | 动态配置获取与订阅 | `/v1.0/configuration/...` |
| **Actor** | 有状态虚拟 actor | `/v1.0/actors/...` |
| **工作流** | 持久化编排、长流程 | `/v1.0-beta1/workflows/...` |
| **分布式锁** | 跨实例互斥 | `/v1.0-alpha1/lock/...` |

---

## 五、服务调用（Service Invocation）

服务调用让服务间通过 **app-id** 互相调用，内置服务发现、重试、超时、熔断、mTLS。

### 5.1 HTTP 调用方式

```bash
# 调用目标 app-id 为 "order-service" 的服务
# 格式：http://localhost:3500/v1.0/invoke/<app-id>/method/<方法路径>
curl http://localhost:3500/v1.0/invoke/order-service/method/orders
curl -X POST http://localhost:3500/v1.0/invoke/order-service/method/orders \
  -H "Content-Type: application/json" \
  -d '{"productId": 1001, "qty": 2}'
```

### 5.2 gRPC 调用方式

Dapr sidecar 也暴露 gRPC 接口，用于服务间高性能调用（端口 50001）。

### 5.3 .NET SDK 调用

```csharp
// 使用 DaprClient（依赖 Dapr.Client NuGet 包）
public class OrderService
{
    private readonly DaprClient _dapr;

    public OrderService(DaprClient dapr) => _dapr = dapr;

    public async Task<Product> GetProductAsync(int id)
    {
        // 通过 app-id 调用 product-service
        return await _dapr.InvokeMethodAsync<Product>(
            HttpMethod.Get,
            "product-service",        // 目标 app-id
            $"products/{id}");
    }
}
```

### 5.4 重试与熔断策略

通过 Resiliency（弹性策略）配置重试、超时、熔断：

```yaml
apiVersion: dapr.io/v1alpha1
kind: Resiliency
metadata:
  name: myresiliency
spec:
  policies:
    retries:
      retryFast:
        policy: constant
        duration: 200ms
        maxRetries: 3
    timeouts:
      fast:
        timeout: 2s
    circuitBreakers:
      cb:
        maxRequests: 1
        interval: 8s
        trip: consecutiveFailures >= 5
  targets:
    apps:
      product-service:
        retry: retryFast
        timeout: fast
        circuitBreaker: cb
```

---

## 六、状态管理（State Management）

状态管理提供键值存储，支持并发控制（乐观/悲观）、批量操作、事务。

### 6.1 组件配置（Redis 为例）

```yaml
# components/statestore.yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore            # 状态存储名称，代码里引用它
spec:
  type: state.redis           # 组件类型：Redis 状态存储
  version: v1
  metadata:
    - name: redisHost
      value: localhost:6379
    - name: redisPassword
      value: ""
```

### 6.2 HTTP API

```bash
# 保存状态（POST）
curl -X POST http://localhost:3500/v1.0/state/statestore \
  -H "Content-Type: application/json" \
  -d '[{"key": "order-1001", "value": {"id": 1001, "status": "paid"}}]'

# 读取状态（GET）
curl http://localhost:3500/v1.0/state/statestore/order-1001

# 删除状态（DELETE）
curl -X DELETE http://localhost:3500/v1.0/state/statestore/order-1001
```

### 6.3 .NET SDK 操作

```csharp
public class CartService
{
    private readonly DaprClient _dapr;
    public CartService(DaprClient dapr) => _dapr = dapr;

    public async Task SaveAsync(string key, object value)
    {
        // 保存状态（last-write-wins 默认）
        await _dapr.SaveStateAsync("statestore", key, value);
    }

    public async Task<Cart> GetAsync(string key)
    {
        // 读取状态
        return await _dapr.GetStateAsync<Cart>("statestore", key);
    }

    public async Task SaveWithEtagAsync(string key, Cart value)
    {
        // 乐观并发控制：基于 ETag（版本号）
        var state = await _dapr.GetStateAndETagAsync<Cart>("statestore", key);
        value.Version = state.etag;
        await _dapr.TrySaveStateAsync("statestore", key, value, state.etag);
    }
}
```

### 6.4 状态操作选项（StateOptions）

| 选项 | 说明 |
|------|------|
| `Consistency.Strong` | 强一致（默认） |
| `Consistency.Eventual` | 最终一致（更快） |
| `Concurrency.LastWrite` | 最后写入胜（默认） |
| `Concurrency.FirstWrite` | 首次写入胜（配合 ETag 实现乐观锁） |

### 6.5 支持的状态存储组件

| 组件类型 | 说明 |
|------|------|
| `state.redis` | Redis（最常用，性能好） |
| `state.sqlserver` | SQL Server（你现有技术栈） |
| `state.mysql` / `state.postgresql` | MySQL / PostgreSQL |
| `state.mongodb` | MongoDB |
| `state.azure.*` | Azure 系列 |

---

## 七、发布订阅（Pub/Sub）

Pub/Sub 实现服务间**异步、解耦**的消息通信，支持至少一次投递（At-least-once）。

### 7.1 组件配置（RabbitMQ 为例）

```yaml
# components/pubsub.yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: messagebus            # pub/sub 名称
spec:
  type: pubsub.rabbitmq       # RabbitMQ
  version: v1
  metadata:
    - name: host
      value: "amqp://localhost:5672"
    - name: consumerID
      value: "orders-subscriber"
    - name: durable
      value: "true"
```

### 7.2 发布消息

```bash
# 发布到 topic "orders"
curl -X POST http://localhost:3500/v1.0/publish/messagebus/orders \
  -H "Content-Type: application/json" \
  -d '{"orderId": 1001, "amount": 99.5}'
```

```csharp
// .NET SDK 发布
await _dapr.PublishEventAsync("messagebus", "orders", new { orderId = 1001, amount = 99.5 });
```

### 7.3 订阅消息

**方式一：声明式订阅（YAML，推荐）**

```yaml
# components/subscription.yaml
apiVersion: dapr.io/v1alpha1
kind: Subscription
metadata:
  name: orders-subscription
spec:
  topic: orders                 # 订阅的 topic
  route: /orders/handler        # 消息转发到的应用路由
  pubsubname: messagebus
scopes:
  - order-service               # 只对指定 app 生效
```

应用侧接收（.NET）：

```csharp
// 订阅回调：sidecar 会把消息 POST 到 /orders/handler
app.MapPost("/orders/handler", async (CloudEvent<Order> ce) =>
{
    var order = ce.Data;
    // 处理订单...
    return Results.Ok();
});
```

**方式二：编程式订阅（.NET SDK）**

```csharp
app.MapSubscribeHandler();   // 启用订阅处理

app.MapPost("/orders/handler", [Topic("messagebus", "orders")] async (Order order) =>
{
    // 处理订单
    return Results.Ok();
});
```

### 7.4 消息格式（CloudEvents）

Dapr Pub/Sub 默认使用 **CloudEvents** 规范封装消息：

```json
{
  "specversion": "1.0",
  "type": "com.example.order.created",
  "source": "order-service",
  "id": "xxxx-xxxx",
  "data": { "orderId": 1001, "amount": 99.5 }
}
```

> 若想接收原始消息（不带 CloudEvent 包装），可在组件元数据中加 `rawPayload: true`。

### 7.5 支持的 Pub/Sub 组件

| 组件 | 说明 |
|------|------|
| `pubsub.rabbitmq` | RabbitMQ（你现有技术栈） |
| `pubsub.redis` | Redis Streams |
| `pubsub.kafka` | Kafka（高吞吐） |
| `pubsub.azure.servicebus` | Azure Service Bus |

---

## 八、绑定（Bindings）

绑定用于**对接外部系统**，分为**输入绑定**（外部触发应用）和**输出绑定**（应用触发外部）。

### 8.1 常见绑定

| 绑定类型 | 用途 |
|------|------|
| `bindings.cron` | 定时触发（输入） |
| `bindings.kafka` | 消息队列 |
| `bindings.s3` | 对象存储（MinIO/S3 兼容，输出/输入） |
| `bindings.rabbitmq` | RabbitMQ |
| `bindings.azure.storagequeues` | Azure 队列 |
| `bindings.http` | HTTP 调用（输出） |

### 8.2 输入绑定（定时任务为例）

```yaml
# components/cron.yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: schedule
spec:
  type: bindings.cron
  version: v1
  metadata:
    - name: schedule
      value: "@every 30m"        # 每 30 分钟触发
```

应用侧接收：

```csharp
// sidecar 定时把事件 POST 到 /cron
app.MapPost("/cron", () => {
    // 执行定时任务：如生成报表、同步数据
    return Results.Ok();
});
```

### 8.3 输出绑定（写文件/对象存储为例）

```bash
# 触发输出绑定（写对象存储）
curl -X POST http://localhost:3500/v1.0/bindings/objectstore \
  -H "Content-Type: application/json" \
  -d '{"operation": "create", "data": "文件内容", "metadata": {"key": "report.txt"}}'
```

```csharp
// .NET SDK 输出绑定
await _dapr.InvokeBindingAsync("objectstore", "create", "文件内容",
    new Dictionary<string, string> { ["key"] = "report.txt" });
```

---

## 九、密钥管理（Secrets）

密钥管理让应用**安全获取敏感信息**，密钥本身不落代码、不落配置文件。

### 9.1 组件配置（本地文件 / K8s 为例）

```yaml
# components/secretstore.yaml（本地文件存储）
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: secretstore
spec:
  type: secretstores.local.file
  version: v1
  metadata:
    - name: secretsFile
      value: ./secrets.json     # 密钥文件路径
```

`secrets.json` 内容：

```json
{
  "dbPassword": "MyS3cret!",
  "apiKey": "sk-xxxx"
}
```

### 9.2 获取密钥

```bash
# HTTP 获取
curl http://localhost:3500/v1.0/secrets/secretstore/dbPassword
```

```csharp
// .NET SDK
var secret = await _dapr.GetSecretAsync("secretstore", "dbPassword");
var password = secret["dbPassword"];
```

### 9.3 组件引用密钥

密钥可直接被其他组件引用，避免在组件 YAML 里写明文密码：

```yaml
spec:
  type: state.redis
  metadata:
    - name: redisHost
      value: localhost:6379
    - name: redisPassword
      secretKeyRef:              # 引用密钥，而非明文
        name: redisPassword
        key: redisPassword
auth:
  secretStore: secretstore       # 指定密钥来源
```

### 9.4 支持的密钥组件

| 组件 | 说明 |
|------|------|
| `secretstores.local.file` | 本地文件（开发） |
| `secretstores.kubernetes` | K8s Secret |
| `secretstores.hashicorp.vault` | HashiCorp Vault |
| `secretstores.azure.keyvault` | Azure Key Vault |
| `secretstores.aws.secretmanager` | AWS Secrets Manager |

---

## 十、配置管理（Configuration）

配置管理（Dapr 1.10+）提供**动态配置**的获取与订阅，配置变更可实时推送。

```yaml
# components/configstore.yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: configstore
spec:
  type: configuration.redis
  version: v1
  metadata:
    - name: redisHost
      value: localhost:6379
```

```csharp
// 获取配置
var config = await _dapr.GetConfiguration("configstore", new[] { "featureFlag", "rateLimit" });

// 订阅配置变更
var watch = await _dapr.GetConfiguration("configstore", new[] { "featureFlag" });
// 可监听变更事件
```

---

## 十一、Actor 模型

Dapr Actor 提供**有状态、单线程、可寻址**的虚拟 actor，适合游戏、IoT、订单等需要维护实体状态的场景。

### 11.1 Actor 特性

| 特性 | 说明 |
|------|------|
| 虚拟化 | Actor 按需激活，空闲后自动回收 |
| 单线程 | 同一 Actor 内方法串行执行，天然无锁 |
| 有状态 | 状态自动持久化到状态存储 |
| 可寻址 | 通过 ActorType + ActorId 定位 |
| 定时器/提醒 | 支持 timer 和 reminder |

### 11.2 .NET Actor 示例

```csharp
// 定义 Actor 接口
public interface IOrderActor : IActor
{
    Task AddItemAsync(string item);
    Task<List<string>> GetItemsAsync();
}

// 实现 Actor
public class OrderActor : Actor, IOrderActor
{
    public OrderActor(ActorHost host) : base(host) { }

    public async Task AddItemAsync(string item)
    {
        var items = await StateManager.GetStateAsync<List<string>>("items") ?? new();
        items.Add(item);
        await StateManager.SetStateAsync("items", items);
    }

    public async Task<List<string>> GetItemsAsync()
        => await StateManager.GetStateAsync<List<string>>("items") ?? new();
}

// 使用 Actor
var actorId = new ActorId("order-1001");
var proxy = ActorProxy.Create<IOrderActor>(actorId, "OrderActor");
await proxy.AddItemAsync("商品A");
var items = await proxy.GetItemsAsync();
```

> 注意：Actor 状态需要配置一个 `statestore` 组件作为 `dapr.io` 的 `ActorStateStore`。

---

## 十二、工作流（Workflow）

工作流（Dapr 1.10+）提供**持久化、可恢复**的流程编排，适合长事务、审批流、订单履约等场景。

```csharp
// 定义工作流
public class OrderWorkflow : Workflow<Order, OrderResult>
{
    public override async Task<OrderResult> RunAsync(WorkflowContext context, Order input)
    {
        // 调用活动：校验库存
        var valid = await context.CallActivityAsync<bool>("ValidateStock", input);

        if (!valid)
            return new OrderResult { Success = false, Reason = "库存不足" };

        // 调用活动：创建订单
        var orderId = await context.CallActivityAsync<string>("CreateOrder", input);

        // 等待外部事件（如支付回调），支持持久化暂停/恢复
        await context.WaitForExternalEventAsync("PaymentReceived");

        return new OrderResult { Success = true, OrderId = orderId };
    }
}
```

---

## 十三、组件（Components）详解

### 13.1 组件是什么

组件是 Dapr 的「可插拔中间件适配器」，把 Redis、RabbitMQ、SQL Server 等接入构建块。**换中间件 = 改组件 YAML，不改业务代码**。

### 13.2 组件 YAML 结构

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: <组件名称>          # 代码里引用的名字
  namespace: default
spec:
  type: <组件类型>          # 如 state.redis / pubsub.rabbitmq
  version: v1
  initTimeout: 5s
  metadata:                 # 组件专属配置
    - name: <key>
      value: <value>        # 或 secretKeyRef 引用密钥
  auth:
    secretStore: <密钥存储名>
  scopes:                   # 限定哪些 app 可使用
    - app-id-1
```

### 13.3 组件类型速查

| 类别 | 组件类型示例 |
|------|------|
| 状态存储 | `state.redis` / `state.sqlserver` / `state.mysql` / `state.postgresql` |
| 发布订阅 | `pubsub.rabbitmq` / `pubsub.redis` / `pubsub.kafka` |
| 输入/输出绑定 | `bindings.cron` / `bindings.s3` / `bindings.kafka` / `bindings.rabbitmq` |
| 密钥 | `secretstores.local.file` / `secretstores.kubernetes` / `secretstores.hashicorp.vault` |
| 配置 | `configuration.redis` |
| 中间件 | `middleware.ratelimit` / `middleware.oauth2` |

### 13.4 常用组件配置示例

```yaml
# SQL Server 状态存储（贴合你的技术栈）
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: sqlstore
spec:
  type: state.sqlserver
  version: v1
  metadata:
    - name: connectionString
      value: "Server=localhost;Database=dapr;User Id=sa;Password=xxx;"
    - name: tableName
      value: "StateTable"
```

```yaml
# MinIO / S3 绑定（贴合你的对象存储）
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: objectstore
spec:
  type: bindings.s3
  version: v1
  metadata:
    - name: bucket
      value: "my-bucket"
    - name: endpoint
      value: "http://localhost:9000"
    - name: accessKey
      value: "minioadmin"
    - name: secretKey
      value: "minioadmin"
    - name: region
      value: "us-east-1"
```

### 13.5 查看组件

```bash
dapr components --app-id myapp    # 查看某应用的组件
kubectl get components            # K8s 模式查看组件
```

---

## 十四、与 .NET 集成（Dapr .NET SDK）

### 14.1 安装 SDK

```bash
dotnet add package Dapr.Client
dotnet add package Dapr.AspNetCore   # 含 MVC 集成、订阅特性
```

### 14.2 注册 Dapr 服务

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

// 注册 DaprClient
builder.Services.AddDaprClient();

var app = builder.Build();

// 启用订阅特性支持
app.MapSubscribeHandler();

app.MapGet("/", () => "Hello Dapr!");
app.Run();
```

### 14.3 DaprClient 能力一览

| 方法 | 用途 |
|------|------|
| `InvokeMethodAsync` | 服务调用 |
| `SaveStateAsync` / `GetStateAsync` / `DeleteStateAsync` | 状态管理 |
| `PublishEventAsync` | 发布消息 |
| `InvokeBindingAsync` | 调用绑定 |
| `GetSecretAsync` | 获取密钥 |
| `GetConfiguration` | 获取配置 |

### 14.4 完整示例：订单服务调用库存服务

```csharp
public class OrderController : ControllerBase
{
    private readonly DaprClient _dapr;
    public OrderController(DaprClient dapr) => _dapr = dapr;

    [HttpPost("orders")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
    {
        // 1. 服务调用：检查库存
        var stock = await _dapr.InvokeMethodAsync<StockResult>(
            HttpMethod.Get, "inventory-service", $"stock/{dto.ProductId}");

        if (stock.Quantity < dto.Qty)
            return BadRequest("库存不足");

        // 2. 保存订单状态
        await _dapr.SaveStateAsync("statestore", $"order-{dto.OrderId}", dto);

        // 3. 发布「订单已创建」事件
        await _dapr.PublishEventAsync("messagebus", "order-created", dto);

        return Ok(dto);
    }
}
```

---

## 十五、部署模式

### 15.1 自托管模式（本地开发）

```bash
# 用 dapr run 启动应用，sidecar 自动拉起
dapr run \
  --app-id order-service \
  --app-port 5000 \
  --components-path ./components \
  -- dotnet run

# 查看
dapr list
dapr stop order-service
```

### 15.2 Kubernetes 模式

```bash
# 1. 初始化 Dapr 到 K8s
dapr init -k

# 2. 部署时给 Pod 加 sidecar 注解（自动注入）
```

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: order-service
spec:
  replicas: 2
  selector:
    matchLabels:
      app: order-service
  template:
    metadata:
      labels:
        app: order-service
      annotations:
        dapr.io/enabled: "true"        # 启用 sidecar 注入
        dapr.io/app-id: "order-service" # app-id
        dapr.io/app-port: "5000"
    spec:
      containers:
        - name: app
          image: myrepo/order-service:1.0
          ports:
            - containerPort: 5000
```

### 15.3 Docker Compose 模式

```yaml
services:
  order-service:
    build: .
    ports:
      - "5000:5000"
  order-service-dapr:            # sidecar 作为独立容器
    image: "daprio/daprd:latest"
    command: ["./daprd", "-app-id", "order-service", "-app-port", "5000"]
    depends_on:
      - order-service
    network_mode: "service:order-service"   # 共享网络命名空间
```

---

## 十六、可观测性

Dapr 内置日志、指标、链路追踪三大可观测能力，默认开启。

### 16.1 日志

```bash
# 自托管查看 sidecar 日志
dapr logs --app-id myapp

# K8s 查看 sidecar 日志
kubectl logs <pod> -c daprd
```

### 16.2 指标（Prometheus）

Dapr sidecar 默认在 `9090` 端口暴露 Prometheus 指标：

```bash
curl http://localhost:9090/metrics
```

### 16.3 链路追踪（Zipkin）

`dapr init` 默认安装 Zipkin，访问 `http://localhost:9411` 查看调用链路。

### 16.4 日志级别配置

```bash
# 通过环境变量设置日志级别
DAPR_LOG_LEVEL=debug dapr run --app-id myapp -- dotnet run
```

---

## 十七、故障排查

| 问题 | 排查方法 |
|------|------|
| sidecar 起不来 | `dapr logs --app-id x` 看日志，检查端口占用 |
| 服务调用失败 | 检查 app-id 是否正确、目标服务是否注册 |
| 组件连接失败 | `dapr dashboard` 看组件状态，检查元数据配置 |
| 状态存取异常 | 确认状态存储组件已加载、中间件可达 |
| 订阅收不到消息 | 检查订阅 YAML 的 topic 和 pubsubname、route 是否匹配 |
| 密钥获取失败 | 检查密钥文件/密钥存储配置 |
| 端口冲突 | sidecar 默认 3500/50001，应用端口别冲突 |

**常用诊断命令：**

```bash
dapr list                       # 运行中的应用
dapr status                     # Dapr 运行环境状态
dapr components --app-id x      # 应用加载的组件
dapr dashboard                  # 可视化控制台
dapr logs --app-id x            # 应用日志
```

---

## 十八、常用命令速查

### CLI 命令

```bash
dapr init                   # 初始化（自托管）
dapr init -k                # 初始化 K8s
dapr uninstall              # 卸载
dapr run --app-id x ...     # 启动应用 + sidecar
dapr list                   # 列出运行中的应用
dapr stop x                 # 停止应用
dapr status                 # 状态
dapr components --app-id x  # 查看组件
dapr logs --app-id x        # 查看日志
dapr dashboard              # 控制台
```

### HTTP API 速查

```bash
# 服务调用
curl http://localhost:3500/v1.0/invoke/<app-id>/method/<path>

# 状态
curl -X POST http://localhost:3500/v1.0/state/<store> -d '[...]'
curl http://localhost:3500/v1.0/state/<store>/<key>

# 发布
curl -X POST http://localhost:3500/v1.0/publish/<pubsub>/<topic> -d '...'

# 密钥
curl http://localhost:3500/v1.0/secrets/<store>/<key>
```

---

## 十九、最佳实践

1. **app-id 命名规范**：统一小写、短横线分隔（如 `order-service`），全局唯一
2. **组件命名语义化**：`statestore`、`messagebus`、`secretstore` 等固定名，方便复用
3. **密钥永远走 Secret 组件**：组件 YAML 用 `secretKeyRef` 引用，不写明文密码
4. **配置用配置管理**：动态开关、限流阈值等放 `configuration` 组件，支持热更新
5. **消息用 CloudEvents**：保持默认 CloudEvents 格式，便于跨服务、跨云追踪
6. **状态操作加并发控制**：多实例写同一 key 时用 ETag 乐观锁
7. **生产用 K8s 模式**：sidecar 自动注入、自动扩缩容
8. **可观测性全开**：指标接 Prometheus + Grafana，追踪接 Zipkin/Jaeger
9. **弹性策略提前配**：为关键服务调用配重试、超时、熔断
10. **先本地 `dapr run` 验证，再上 K8s**：自托管模式调试最快

---

## 附：核心概念速记

| 概念 | 一句话 |
|------|------|
| **Sidecar** | 每个应用旁挂的 `daprd` 进程，分布式能力都在它身上 |
| **app-id** | 应用的唯一标识，服务调用/订阅都靠它 |
| **Building Block** | Dapr 的能力单元（服务调用、状态、Pub/Sub 等） |
| **Component** | 可插拔中间件适配器（Redis、RabbitMQ、SQL Server 等） |
| **状态存储** | 键值存储，支持并发控制与事务 |
| **Pub/Sub** | 异步事件通信，默认 CloudEvents 格式 |
| **Binding** | 对接外部系统（定时、对象存储、消息） |
| **Resiliency** | 重试、超时、熔断策略 |
