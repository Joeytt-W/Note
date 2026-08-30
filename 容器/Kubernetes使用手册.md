# Kubernetes 使用手册

> 面向开发与运维的 Kubernetes 全面手册，覆盖架构原理、核心对象、工作负载、网络、存储、调度、安全、监控与故障排查，附大量可直接套用的 YAML 示例与命令速查。

## 目录

1. [Kubernetes 概述与架构](#一kubernetes-概述与架构)
2. [核心概念与对象模型](#二核心概念与对象模型)
3. [环境搭建与 kubectl](#三环境搭建与-kubectl)
4. [Pod 详解](#四pod-详解)
5. [工作负载（Workloads）](#五工作负载workloads)
6. [Service 与网络](#六service-与网络)
7. [Ingress 与网关](#七ingress-与网关)
8. [配置与密钥（ConfigMap / Secret）](#八配置与密钥configmap--secret)
9. [存储（Volume / PV / PVC / StorageClass）](#九存储volume--pv--pvc--storageclass)
10. [调度与资源管理](#十调度与资源管理)
11. [命名空间与资源配额](#十一命名空间与资源配额)
12. [安全与 RBAC](#十二安全与-rbac)
13. [滚动更新与回滚](#十三滚动更新与回滚)
14. [监控与日志](#十四监控与日志)
15. [常用命令速查](#十五常用命令速查)
16. [故障排查](#十六故障排查)

---

## 一、Kubernetes 概述与架构

### 1.1 什么是 Kubernetes

Kubernetes（简称 K8s）是一个开源的**容器编排平台**，用于自动化部署、扩展和管理容器化应用。它由 Google 基于 Borg 经验设计，现由 CNCF 托管。

**它解决的核心问题：**

- **部署**：把容器按声明式配置部署到多台机器
- **自愈**：容器挂掉自动重启、节点故障自动迁移
- **扩缩容**：按负载手动/自动增减副本
- **服务发现与负载均衡**：应用间通过服务名互通
- **滚动更新**：零停机发布新版本，失败可回滚
- **配置与密钥管理**：统一管理环境配置、敏感信息

### 1.2 集群架构

一个 K8s 集群由 **控制平面（Control Plane）** 和 **工作节点（Node）** 组成。

```
┌─────────────────────────── 控制平面 Control Plane ───────────────────────────┐
│  kube-apiserver   etcd   kube-scheduler   kube-controller-manager            │
└──────────────────────────────────┬─────────────────────────────────────────────┘
                                   │
          ┌────────────────────────┼────────────────────────┐
          │                        │                        │
┌─────────▼─────────┐    ┌────────▼─────────┐    ┌─────────▼─────────┐
│     Node 1        │    │     Node 2        │    │     Node 3        │
│  kubelet          │    │  kubelet          │    │  kubelet          │
│  kube-proxy       │    │  kube-proxy       │    │  kube-proxy       │
│  容器运行时        │    │  容器运行时        │    │  容器运行时        │
│  ┌───┐ ┌───┐      │    │  ┌───┐ ┌───┐      │    │  ┌───┐ ┌───┐      │
│  │Pod│ │Pod│      │    │  │Pod│ │Pod│      │    │  │Pod│ │Pod│      │
│  └───┘ └───┘      │    │  └───┘ └───┘      │    │  └───┘ └───┘      │
└───────────────────┘    └──────────────────┘    └───────────────────┘
```

### 1.3 控制平面组件

| 组件 | 职责 |
|------|------|
| **kube-apiserver** | 集群统一入口，所有操作都通过它；REST API 形式对外 |
| **etcd** | 分布式键值存储，保存集群所有状态数据（唯一的「真实数据源」） |
| **kube-scheduler** | 调度器，决定 Pod 落到哪个节点 |
| **kube-controller-manager** | 控制器集合，维护集群期望状态（副本数、节点健康等） |
| **cloud-controller-manager** | 对接云厂商（负载均衡、磁盘等），自建集群可无 |

### 1.4 工作节点组件

| 组件 | 职责 |
|------|------|
| **kubelet** | 每个节点上的「管家」，接收 API Server 指令，管理 Pod 生命周期 |
| **kube-proxy** | 维护网络规则，实现 Service 的负载均衡与转发 |
| **容器运行时** | 运行容器的引擎（containerd、CRI-O 等） |

---

## 二、核心概念与对象模型

### 2.1 核心对象一览

| 对象 | 类型 | 作用 |
|------|------|------|
| **Pod** | 最小调度单元 | 一个或多个容器的组合，共享网络与存储 |
| **Deployment** | 工作负载 | 无状态应用的声明式部署与滚动更新 |
| **StatefulSet** | 工作负载 | 有状态应用（稳定网络标识、持久存储） |
| **DaemonSet** | 工作负载 | 每个节点运行一个副本（日志采集、监控） |
| **Job / CronJob** | 工作负载 | 一次性任务 / 定时任务 |
| **Service** | 网络 | 为一组 Pod 提供稳定的访问入口与负载均衡 |
| **Ingress** | 网络 | HTTP(S) 七层路由与域名规则 |
| **ConfigMap** | 配置 | 非敏感配置的存储与注入 |
| **Secret** | 配置 | 敏感信息（密码、令牌、证书）的存储 |
| **Volume / PV / PVC** | 存储 | 持久化存储的抽象与申请 |
| **Namespace** | 隔离 | 逻辑分组与资源隔离 |
| **ServiceAccount** | 安全 | Pod 访问 API Server 的身份 |

### 2.2 声明式 vs 命令式

K8s 的核心哲学是 **声明式（Declarative）**：你描述「期望状态」，K8s 负责让实际状态向期望状态靠拢。

```bash
# 命令式：直接下命令（简单，但不可追溯、不推荐生产）
kubectl run nginx --image=nginx
kubectl scale deployment nginx --replicas=3

# 声明式：写 YAML 描述期望状态，然后 apply（推荐）
kubectl apply -f deployment.yaml
```

### 2.3 Label 与 Selector

**Label** 是打在对象上的键值对标签，**Selector** 用于按标签筛选关联对象，是 K8s 对象间松耦合关联的基石。

```yaml
metadata:
  labels:
    app: myapp
    tier: backend
    version: v1
```

```bash
# 按标签筛选
kubectl get pods -l app=myapp
kubectl get pods -l "tier in (backend,frontend)"
```

---

## 三、环境搭建与 kubectl

### 3.1 本地学习环境

```bash
# Minikube（单机 K8s，适合本地学习）
minikube start
minikube status
minikube dashboard           # 打开 Web 控制台
minikube stop

# kind（Docker 内的 K8s，适合 CI 测试）
kind create cluster
```

### 3.2 生产集群（kubeadm）

```bash
# 1. 安装容器运行时 + kubeadm/kubelet/kubectl（三台机器通用）
# 2. 初始化控制平面（在 master 节点执行）
sudo kubeadm init --pod-network-cidr=10.244.0.0/16

# 3. 配置 kubectl（普通用户）
mkdir -p $HOME/.kube
sudo cp -i /etc/kubernetes/admin.conf $HOME/.kube/config
sudo chown $(id -u):$(id -g) $HOME/.kube/config

# 4. 安装网络插件（如 Calico / Flannel）
kubectl apply -f https://docs.projectcalico.org/manifests/calico.yaml

# 5. 加入工作节点（在 node 节点执行 init 输出的命令）
kubeadm join <master-ip>:6443 --token <token> --discovery-token-ca-cert-hash <hash>
```

### 3.3 kubectl 配置与上下文

```bash
kubectl version                    # 查看版本
kubectl config view                # 查看 kubeconfig
kubectl config get-contexts        # 列出上下文
kubectl config use-context ctx     # 切换上下文
kubectl cluster-info               # 查看集群信息
kubectl get nodes                  # 查看节点
```

### 3.4 kubectl 通用参数

| 参数 | 说明 | 示例 |
|------|------|------|
| `-n` / `--namespace` | 指定命名空间 | `-n kube-system` |
| `-o` / `--output` | 输出格式（wide/yaml/json） | `-o wide`、`-o yaml` |
| `--all-namespaces` / `-A` | 所有命名空间 | `-A` |
| `-f` / `--filename` | 从文件创建/更新 | `-f deploy.yaml` |
| `-l` / `--selector` | 按标签筛选 | `-l app=nginx` |
| `-w` / `--watch` | 持续监听变化 | `-w` |

---

## 四、Pod 详解

Pod 是 K8s 的最小调度单元，是**一个或多个容器的组合**，容器间共享网络命名空间和存储卷。

### 4.1 Pod 基本 YAML

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: myapp-pod
  labels:
    app: myapp
spec:
  containers:
    - name: app
      image: myapp:v1
      ports:
        - containerPort: 8080
      env:
        - name: TZ
          value: "Asia/Shanghai"
      resources:
        requests:
          cpu: "250m"
          memory: "128Mi"
        limits:
          cpu: "500m"
          memory: "256Mi"
```

### 4.2 多容器 Pod（Sidecar 模式）

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: app-with-log
spec:
  containers:
    - name: app
      image: myapp:v1
      volumeMounts:
        - name: logs
          mountPath: /app/logs
    - name: log-collector          # Sidecar：负责采集日志
      image: fluentd:latest
      volumeMounts:
        - name: logs
          mountPath: /app/logs
  volumes:
    - name: logs
      emptyDir: {}
```

### 4.3 容器状态与 Pod 阶段

**Pod 生命周期阶段（Phase）：**

| 阶段 | 含义 |
|------|------|
| `Pending` | 已创建，但容器尚未就绪（拉镜像中、调度中） |
| `Running` | 至少一个容器在运行 |
| `Succeeded` | 所有容器正常退出（Job 常见） |
| `Failed` | 至少一个容器异常退出 |
| `Unknown` | 无法获取状态（节点通信问题） |

**容器状态（State）：**

| 状态 | 含义 |
|------|------|
| `Waiting` | 等待中（拉镜像、等待依赖） |
| `Running` | 运行中 |
| `Terminated` | 已终止（含退出码） |

### 4.4 健康检查探针

| 探针 | 作用 | 失败后果 |
|------|------|----------|
| **livenessProbe** | 检测容器是否「活着」 | 失败则**重启容器** |
| **readinessProbe** | 检测容器是否「就绪接收流量」 | 失败则**从 Service 摘除**（不重启） |
| **startupProbe** | 检测是否「启动完成」 | 失败则重启；成功后才启用前两个探针 |

```yaml
spec:
  containers:
    - name: app
      image: myapp:v1
      startupProbe:              # 启动探针：给慢启动应用足够时间
        httpGet:
          path: /health
          port: 8080
        failureThreshold: 30     # 最多失败 30 次
        periodSeconds: 10
      livenessProbe:             # 存活探针：挂死自动重启
        httpGet:
          path: /health
          port: 8080
        initialDelaySeconds: 5
        periodSeconds: 10
        timeoutSeconds: 3
        failureThreshold: 3
      readinessProbe:            # 就绪探针：就绪后才接入流量
        httpGet:
          path: /ready
          port: 8080
        periodSeconds: 5
        successThreshold: 1
```

**三种探针类型：**

| 类型 | 说明 | 示例 |
|------|------|------|
| `httpGet` | HTTP 请求探测 | `path: /health` `port: 8080` |
| `tcpSocket` | TCP 端口探测 | `port: 3306` |
| `exec` | 容器内执行命令探测 | `command: ["cat", "/tmp/healthy"]` |

### 4.5 重启策略（restartPolicy）

| 取值 | 说明 | 适用对象 |
|------|------|----------|
| `Always` | 总是重启（默认） | Deployment、DaemonSet |
| `OnFailure` | 失败时重启 | Job |
| `Never` | 从不重启 | 一次性 Pod |

---

## 五、工作负载（Workloads）

### 5.1 Deployment（无状态应用）

Deployment 是最常用的控制器，管理无状态应用，支持滚动更新和回滚。它通过 ReplicaSet 管理 Pod 副本。

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: myapp-deployment
  labels:
    app: myapp
spec:
  replicas: 3                       # 副本数
  selector:
    matchLabels:
      app: myapp                    # 必须与 template 的 label 匹配
  strategy:
    type: RollingUpdate             # 滚动更新策略
    rollingUpdate:
      maxSurge: 1                   # 更新时最多多出 1 个 Pod
      maxUnavailable: 0             # 更新时最多不可用 0 个（零停机）
  template:
    metadata:
      labels:
        app: myapp
    spec:
      containers:
        - name: app
          image: myapp:v2
          ports:
            - containerPort: 8080
          resources:
            requests:
              cpu: "250m"
              memory: "128Mi"
            limits:
              cpu: "500m"
              memory: "256Mi"
```

**Deployment 常用命令：**

```bash
kubectl create deployment nginx --image=nginx          # 快速创建
kubectl get deployments                                 # 查看
kubectl describe deployment myapp-deployment           # 查看详情
kubectl scale deployment myapp-deployment --replicas=5 # 扩缩容
kubectl set image deployment/myapp-deployment app=myapp:v3  # 更新镜像
kubectl rollout status deployment/myapp-deployment     # 查看更新进度
kubectl rollout history deployment/myapp-deployment    # 查看历史版本
kubectl rollout undo deployment/myapp-deployment       # 回滚上一版本
kubectl rollout undo deployment/myapp-deployment --to-revision=2  # 回滚到指定版本
```

### 5.2 ReplicaSet

ReplicaSet 保证指定数量的 Pod 副本始终运行。通常由 Deployment 自动管理，很少直接创建。

```yaml
apiVersion: apps/v1
kind: ReplicaSet
metadata:
  name: myapp-rs
spec:
  replicas: 3
  selector:
    matchLabels:
      app: myapp
  template:
    metadata:
      labels:
        app: myapp
    spec:
      containers:
        - name: app
          image: myapp:v1
```

### 5.3 StatefulSet（有状态应用）

适合数据库、消息队列等需要**稳定网络标识**和**持久存储**的应用（MySQL、Redis、Kafka、RabbitMQ）。

**特点：**

- 每个 Pod 有**稳定的名字**：`<名称>-0`、`<名称>-1`、`<名称>-2`（顺序创建）
- 每个 Pod 有**稳定的网络标识**（Headless Service + 稳定 DNS）
- 每个 Pod 绑定**独立的持久卷**（PVC）
- 按顺序启动、逆序停止，滚动更新也是逐个进行

```yaml
apiVersion: v1
kind: Service
metadata:
  name: mysql
  labels:
    app: mysql
spec:
  clusterIP: None                    # Headless Service，为每个 Pod 提供稳定 DNS
  selector:
    app: mysql
  ports:
    - port: 3306
      name: mysql
---
apiVersion: apps/v1
kind: StatefulSet
metadata:
  name: mysql
spec:
  serviceName: mysql                 # 必须关联 Headless Service
  replicas: 3
  selector:
    matchLabels:
      app: mysql
  template:
    metadata:
      labels:
        app: mysql
    spec:
      containers:
        - name: mysql
          image: mysql:8
          ports:
            - containerPort: 3306
          env:
            - name: MYSQL_ROOT_PASSWORD
              value: "123456"
          volumeMounts:
            - name: data
              mountPath: /var/lib/mysql
  volumeClaimTemplates:              # 每个 Pod 自动创建独立 PVC
    - metadata:
        name: data
      spec:
        accessModes: ["ReadWriteOnce"]
        storageClassName: standard
        resources:
          requests:
            storage: 10Gi
```

### 5.4 DaemonSet（每节点一个）

在每个节点运行一个 Pod 副本，适合日志采集、监控、网络插件。

```yaml
apiVersion: apps/v1
kind: DaemonSet
metadata:
  name: fluentd
spec:
  selector:
    matchLabels:
      name: fluentd
  template:
    metadata:
      labels:
        name: fluentd
    spec:
      containers:
        - name: fluentd
          image: fluentd:latest
          volumeMounts:
            - name: varlog
              mountPath: /var/log
      volumes:
        - name: varlog
          hostPath:
            path: /var/log
```

### 5.5 Job 与 CronJob

**Job**：一次性任务，运行到成功结束。

```yaml
apiVersion: batch/v1
kind: Job
metadata:
  name: data-migration
spec:
  backoffLimit: 4          # 失败重试次数上限
  completions: 1           # 成功完成的 Pod 数
  parallelism: 1           # 并行执行的 Pod 数
  template:
    spec:
      restartPolicy: OnFailure
      containers:
        - name: migrate
          image: migrate-tool:v1
```

**CronJob**：定时任务（如数据备份、报表生成）。

```yaml
apiVersion: batch/v1
kind: CronJob
metadata:
  name: daily-backup
spec:
  schedule: "0 2 * * *"        # 每天凌晨 2 点（分 时 日 月 周）
  concurrencyPolicy: Forbid    # 禁止并发（Allow/Forbid/Replace）
  successfulJobsHistoryLimit: 3
  jobTemplate:
    spec:
      template:
        spec:
          restartPolicy: OnFailure
          containers:
            - name: backup
              image: backup-tool:v1
```

---

## 六、Service 与网络

### 6.1 为什么需要 Service

Pod 的 IP 是动态且易变的（重启、重建都会变），Service 提供**稳定的虚拟 IP 和 DNS 名**，将流量负载均衡到一组后端 Pod。

### 6.2 Service 四种类型

| 类型 | 说明 | 访问方式 | 场景 |
|------|------|----------|------|
| **ClusterIP** | 默认，集群内部虚拟 IP | 仅集群内可访问 | 内部服务互调 |
| **NodePort** | 在每个节点开放固定端口 | `节点IP:NodePort` | 开发调试、简单对外 |
| **LoadBalancer** | 云厂商负载均衡器 | 公网/内网 LB 地址 | 生产对外服务（云环境） |
| **ExternalName** | 映射到外部 DNS 名 | 通过服务名访问外部 | 对接集群外服务 |

### 6.3 ClusterIP Service

```yaml
apiVersion: v1
kind: Service
metadata:
  name: myapp-svc
spec:
  type: ClusterIP
  selector:
    app: myapp                # 通过 label 关联后端 Pod
  ports:
    - name: http
      port: 80                # Service 对外端口
      targetPort: 8080        # 后端 Pod 容器端口
      protocol: TCP
```

> 集群内访问方式：`myapp-svc.default.svc.cluster.local`（完整 DNS）或直接 `myapp-svc`（同命名空间内）。

### 6.4 NodePort Service

```yaml
apiVersion: v1
kind: Service
metadata:
  name: myapp-nodeport
spec:
  type: NodePort
  selector:
    app: myapp
  ports:
    - port: 80
      targetPort: 8080
      nodePort: 30080         # 固定节点端口（范围 30000-32767，可省略自动分配）
```

### 6.5 LoadBalancer Service

```yaml
apiVersion: v1
kind: Service
metadata:
  name: myapp-lb
spec:
  type: LoadBalancer
  selector:
    app: myapp
  ports:
    - port: 80
      targetPort: 8080
```

### 6.6 端口字段辨析

| 字段 | 含义 |
|------|------|
| `port` | Service 自身的端口 |
| `targetPort` | 后端 Pod 容器监听的端口 |
| `nodePort` | 映射到节点上的端口（仅 NodePort 类型） |

---

## 七、Ingress 与网关

Ingress 提供 **HTTP/HTTPS 七层路由**能力：根据域名、路径将请求转发到不同 Service，支持 TLS、重写等。

### 7.1 安装 Ingress Controller

Ingress 只是规则定义，还需要部署 Ingress Controller（如 Nginx Ingress）来真正处理流量。

```bash
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/main/deploy/static/provider/cloud/deploy.yaml
```

### 7.2 Ingress 规则示例

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: myapp-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /    # 路径重写
spec:
  ingressClassName: nginx
  rules:
    - host: api.example.com              # 按域名路由
      http:
        paths:
          - path: /api
            pathType: Prefix
            backend:
              service:
                name: api-svc
                port:
                  number: 80
          - path: /
            pathType: Prefix
            backend:
              service:
                name: web-svc
                port:
                  number: 80
  tls:
    - hosts:
        - api.example.com
      secretName: api-tls-secret         # 关联 TLS 证书
```

---

## 八、配置与密钥（ConfigMap / Secret）

### 8.1 ConfigMap（非敏感配置）

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: app-config
data:
  APP_ENV: "production"
  LOG_LEVEL: "info"
  appsettings.json: |                    # 也可存整个配置文件
    {
      "ConnectionStrings": {
        "Default": "Server=db;Database=erp"
      }
    }
```

**三种使用方式：**

```yaml
# ① 作为环境变量
spec:
  containers:
    - name: app
      image: myapp:v1
      envFrom:
        - configMapRef:
            name: app-config

# ② 单独引用某个 key 作为环境变量
      env:
        - name: LOG_LEVEL
          valueFrom:
            configMapKeyRef:
              name: app-config
              key: LOG_LEVEL

# ③ 挂载为文件
      volumeMounts:
        - name: config
          mountPath: /app/config
  volumes:
    - name: config
      configMap:
        name: app-config
```

### 8.2 Secret（敏感信息）

Secret 用于存储密码、令牌、证书等，内容 base64 编码（注意：并非加密）。

```yaml
apiVersion: v1
kind: Secret
metadata:
  name: db-secret
type: Opaque
data:
  username: YWRtaW4=          # echo -n "admin" | base64
  password: MTIzNDU2          # echo -n "123456" | base64
```

**使用方式（同 ConfigMap）：**

```yaml
spec:
  containers:
    - name: app
      image: myapp:v1
      env:
        - name: DB_PASSWORD
          valueFrom:
            secretKeyRef:
              name: db-secret
              key: password
```

**命令行快速创建：**

```bash
kubectl create secret generic db-secret \
  --from-literal=username=admin \
  --from-literal=password=123456

kubectl create secret tls api-tls \
  --cert=cert.pem --key=key.pem        # 创建 TLS 证书 Secret
```

---

## 九、存储（Volume / PV / PVC / StorageClass）

### 9.1 存储抽象层次

| 对象 | 角色 | 类比 |
|------|------|------|
| **Volume** | Pod 内挂载的卷（临时或引用 PVC） | 挂载点 |
| **PersistentVolume（PV）** | 集群级存储资源（管理员提供） | 存储池 |
| **PersistentVolumeClaim（PVC）** | 用户对存储的申请（大小、读写模式） | 存储申请单 |
| **StorageClass** | 动态供应的模板（自动创建 PV） | 自动化供应规则 |

### 9.2 临时卷（emptyDir / hostPath）

```yaml
volumes:
  - name: cache
    emptyDir: {}              # 临时目录，随 Pod 生命周期

  - name: host-data
    hostPath:
      path: /data             # 挂载宿主机目录（不建议生产用）
```

### 9.3 StorageClass + PVC 动态供应

```yaml
# StorageClass：定义如何动态创建 PV
apiVersion: storage.k8s.io/v1
kind: StorageClass
metadata:
  name: fast-ssd
provisioner: kubernetes.io/aws-ebs   # 云厂商 provisioner
parameters:
  type: gp3
reclaimPolicy: Delete
allowVolumeExpansion: true
---
# PVC：申请 10Gi 存储
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: mysql-data
spec:
  storageClassName: fast-ssd
  accessModes:
    - ReadWriteOnce             # RWO：单节点读写
  resources:
    requests:
      storage: 10Gi
---
# 在 Pod 中使用 PVC
apiVersion: v1
kind: Pod
metadata:
  name: mysql
spec:
  containers:
    - name: mysql
      image: mysql:8
      volumeMounts:
        - name: data
          mountPath: /var/lib/mysql
  volumes:
    - name: data
      persistentVolumeClaim:
        claimName: mysql-data
```

### 9.4 accessModes 与 reclaimPolicy

**访问模式（accessModes）：**

| 模式 | 说明 |
|------|------|
| `ReadWriteOnce (RWO)` | 单节点读写（最常用） |
| `ReadOnlyMany (ROX)` | 多节点只读 |
| `ReadWriteMany (RWX)` | 多节点读写（需共享文件系统如 NFS） |

**回收策略（reclaimPolicy）：**

| 策略 | 说明 |
|------|------|
| `Retain` | PVC 删除后 PV 保留（需手动清理） |
| `Delete` | PVC 删除后 PV 一并删除（默认） |
| `Recycle` | 已废弃 |

---

## 十、调度与资源管理

### 10.1 资源请求与限制

```yaml
spec:
  containers:
    - name: app
      image: myapp:v1
      resources:
        requests:              # 调度依据：保证的最低资源
          cpu: "250m"          # 0.25 核
          memory: "256Mi"
        limits:                # 硬上限：超出会被限制/OOM
          cpu: "1"             # 1 核
          memory: "512Mi"
```

**关键区别：**

| 概念 | 作用 |
|------|------|
| `requests` | 调度器据此分配节点；是「保证」 |
| `limits` | 容器资源「上限」；内存超限触发 OOM Kill |

> 最佳实践：**必须设置 requests 和 limits**，否则影响调度、可能拖垮节点。

### 10.2 nodeSelector（简单节点选择）

```yaml
spec:
  nodeSelector:
    disktype: ssd            # 只调度到带此标签的节点
```

```bash
kubectl label nodes node1 disktype=ssd    # 给节点打标签
```

### 10.3 亲和性（Affinity）

更灵活的选择规则，支持硬性（required）和软性（preferred）。

```yaml
spec:
  affinity:
    nodeAffinity:
      requiredDuringSchedulingIgnoredDuringExecution:
        nodeSelectorTerms:
          - matchExpressions:
              - key: disktype
                operator: In
                values: ["ssd"]
      preferredDuringSchedulingIgnoredDuringExecution:
        - weight: 1
          preference:
            matchExpressions:
              - key: zone
                operator: In
                values: ["zone-a"]
    podAntiAffinity:                       # 反亲和：让副本分散到不同节点
      requiredDuringSchedulingIgnoredDuringExecution:
        - labelSelector:
            matchLabels:
              app: myapp
          topologyKey: kubernetes.io/hostname
```

### 10.4 污点与容忍（Taints / Tolerations）

**污点（Taint）**打在节点上，阻止 Pod 调度上去；**容忍（Toleration）**打在 Pod 上，允许其调度到有对应污点的节点。

```bash
# 给节点打污点：key=value:effect
kubectl taint nodes node1 dedicated=gpu:NoSchedule

# 移除污点
kubectl taint nodes node1 dedicated=gpu:NoSchedule-
```

```yaml
# Pod 声明容忍
spec:
  tolerations:
    - key: "dedicated"
      operator: "Equal"
      value: "gpu"
      effect: "NoSchedule"
```

**三种 effect：**

| 效果 | 说明 |
|------|------|
| `NoSchedule` | 不调度新 Pod（已在运行的保留） |
| `PreferNoSchedule` | 尽量不调度（软性） |
| `NoExecute` | 不调度且驱逐已运行的 Pod |

---

## 十一、命名空间与资源配额

### 11.1 Namespace

命名空间用于逻辑隔离资源，适合区分团队、环境（dev/test/prod）。

```bash
kubectl create namespace dev
kubectl get namespaces
kubectl get pods -n dev
```

### 11.2 ResourceQuota（资源配额）

限制命名空间的资源总量，防止某个团队耗尽集群。

```yaml
apiVersion: v1
kind: ResourceQuota
metadata:
  name: team-quota
  namespace: dev
spec:
  hard:
    requests.cpu: "10"        # CPU 请求总量
    requests.memory: "20Gi"   # 内存请求总量
    limits.cpu: "20"
    limits.memory: "40Gi"
    pods: "50"                # Pod 数量上限
```

### 11.3 LimitRange

为命名空间内的 Pod 设置默认资源限制。

```yaml
apiVersion: v1
kind: LimitRange
metadata:
  name: default-limits
  namespace: dev
spec:
  limits:
    - default:               # 未指定 limit 时的默认值
        cpu: "500m"
        memory: "512Mi"
      defaultRequest:        # 未指定 request 时的默认值
        cpu: "250m"
        memory: "256Mi"
      type: Container
```

---

## 十二、安全与 RBAC

### 12.1 认证（Authentication）

- **用户**：证书、令牌、OIDC 等
- **ServiceAccount**：Pod 访问 API Server 的身份（每个命名空间有默认 SA）

```bash
kubectl get serviceaccounts
kubectl create serviceaccount myapp-sa
```

### 12.2 授权（RBAC）

RBAC 通过「角色 + 绑定」控制权限。

```yaml
# Role：定义权限（作用于单个命名空间）
apiVersion: rbac.authorization.k8s.io/v1
kind: Role
metadata:
  namespace: dev
  name: pod-reader
rules:
  - apiGroups: [""]
    resources: ["pods"]
    verbs: ["get", "list", "watch"]
---
# RoleBinding：将角色绑定到用户/ServiceAccount
apiVersion: rbac.authorization.k8s.io/v1
kind: RoleBinding
metadata:
  namespace: dev
  name: read-pods
subjects:
  - kind: ServiceAccount
    name: myapp-sa
    namespace: dev
roleRef:
  kind: Role
  name: pod-reader
  apiGroup: rbac.authorization.k8s.io
```

> `ClusterRole` / `ClusterRoleBinding` 是集群级版本，作用于所有命名空间。

---

## 十三、滚动更新与回滚

### 13.1 更新策略

```yaml
spec:
  strategy:
    type: RollingUpdate
    rollingUpdate:
      maxSurge: 1           # 更新时可多出的 Pod 数（百分比或绝对数）
      maxUnavailable: 0     # 更新时最多不可用 Pod 数
```

| 策略 | 说明 |
|------|------|
| `RollingUpdate` | 滚动更新（默认），逐步替换，零停机 |
| `Recreate` | 先全部删除再创建（有短暂停机） |

### 13.2 更新与回滚命令

```bash
# 更新镜像
kubectl set image deployment/myapp app=myapp:v2

# 或修改 YAML 后 apply
kubectl apply -f deployment.yaml

# 查看更新状态
kubectl rollout status deployment/myapp

# 查看历史版本
kubectl rollout history deployment/myapp

# 回滚
kubectl rollout undo deployment/myapp              # 回滚到上一版本
kubectl rollout undo deployment/myapp --to-revision=2

# 暂停/恢复（多次修改后一次性发布）
kubectl rollout pause deployment/myapp
kubectl rollout resume deployment/myapp
```

### 13.3 金丝雀发布（Canary）

通过调整副本数实现渐进式发布：

```bash
# 假设 myapp 现有 10 副本（v1），新建金丝雀 Deployment（v2）1 副本
kubectl scale deployment myapp --replicas=9
kubectl scale deployment myapp-canary --replicas=1   # 10% 流量到 v2

# 验证通过后，将 v1 全量更新为 v2，删除 canary
```

---

## 十四、监控与日志

### 14.1 查看日志

```bash
kubectl logs <pod>                     # 查看 Pod 日志
kubectl logs -f <pod>                  # 实时跟踪
kubectl logs <pod> -c <container>      # 指定容器（多容器 Pod）
kubectl logs <pod> --tail=100          # 最后 100 行
kubectl logs <pod> --previous          # 查看上一次崩溃的日志
```

### 14.2 查看资源与事件

```bash
kubectl describe pod <pod>             # 查看详情（含事件）
kubectl get events --sort-by=.metadata.creationTimestamp   # 查看事件
kubectl top nodes                      # 查看节点资源（需 metrics-server）
kubectl top pods                       # 查看 Pod 资源
```

### 14.3 监控栈

| 组件 | 用途 |
|------|------|
| **metrics-server** | 提供 CPU/内存指标（kubectl top 依赖它） |
| **Prometheus + Grafana** | 完整监控告警栈（社区标准） |
| **Loki / EFK** | 日志收集分析（Loki 轻量，EFK 经典） |

---

## 十五、常用命令速查

### 查看类

```bash
kubectl get pods / services / deployments / nodes
kubectl get all -n dev                      # 查看某命名空间所有资源
kubectl describe pod <pod>                  # 查看详情
kubectl logs -f <pod>                       # 跟踪日志
kubectl top nodes / pods                    # 资源占用
kubectl get events -w                       # 实时事件
```

### 创建/更新类

```bash
kubectl apply -f xxx.yaml                   # 声明式创建/更新（推荐）
kubectl create -f xxx.yaml                  # 创建（已存在则报错）
kubectl delete -f xxx.yaml                  # 删除文件定义的资源
kubectl run nginx --image=nginx             # 快速跑一个 Pod
kubectl create configmap my-cm --from-file=config.properties
kubectl create secret generic my-secret --from-literal=key=value
```

### 交互类

```bash
kubectl exec -it <pod> -- bash              # 进入容器
kubectl port-forward <pod> 8080:80          # 端口转发（本地调试）
kubectl cp <pod>:/path ./local              # 复制文件
kubectl delete pod <pod>                    # 删除 Pod（Deployment 会自动重建）
```

### 编辑类

```bash
kubectl edit deployment myapp               # 在线编辑
kubectl scale deployment myapp --replicas=5 # 扩缩容
kubectl set image deployment/myapp app=v2   # 更新镜像
kubectl label nodes node1 disktype=ssd      # 打标签
kubectl taint nodes node1 key=value:NoSchedule  # 打污点
```

### 排障类

```bash
kubectl get pods --field-selector=status.phase=Failed
kubectl describe node node1                 # 节点状态
kubectl api-resources                       # 查看所有资源类型
kubectl explain pod.spec.containers         # 查看字段文档
```

---

## 十六、故障排查

### 16.1 常见问题排查流程

| 问题 | 排查命令/方法 |
|------|---------------|
| Pod 一直 Pending | `kubectl describe pod` 看事件（资源不足/调度失败） |
| Pod 一直 CrashLoopBackOff | `kubectl logs <pod> --previous` 看崩溃日志 |
| Pod 一直 ImagePullBackOff | 检查镜像名/仓库权限/网络 |
| 服务访问不到 | `kubectl get svc` + `kubectl get endpoints` 看后端是否挂上 |
| 就绪探针一直失败 | `kubectl describe pod` 看 readiness 失败原因 |
| 节点 NotReady | `kubectl describe node` + 检查 kubelet 状态 |

### 16.2 关键诊断命令

```bash
# 1. 看 Pod 状态和事件（排查第一站）
kubectl describe pod <pod>

# 2. 看日志
kubectl logs <pod> --tail=100 --previous

# 3. 看 Service 是否关联到后端 Pod
kubectl get endpoints <svc>

# 4. 进入容器调试
kubectl exec -it <pod> -- sh

# 5. 端口转发到本地调试
kubectl port-forward <pod> 8080:8080

# 6. 看集群事件
kubectl get events --sort-by=.lastTimestamp -A
```

### 16.3 常见状态码含义

| 状态 | 含义 | 常见原因 |
|------|------|----------|
| `CrashLoopBackOff` | 反复崩溃重启 | 应用启动失败、探针失败 |
| `ImagePullBackOff` | 镜像拉取失败 | 镜像不存在、仓库认证、网络 |
| `Pending` | 调度/资源等待 | 资源不足、节点不可用、PVC 未绑定 |
| `Evicted` | 被驱逐 | 内存超限、节点资源紧张 |
| `OOMKilled` | 内存被杀 | 超过 memory limit |
| `Terminating` | 删除中 | 优雅退出超时 |

---

## 附：.NET 8 应用部署完整示例

以下是一个 .NET 8 Web API + Redis 的完整部署示例，可直接参考套用。

```yaml
# 1. ConfigMap
apiVersion: v1
kind: ConfigMap
metadata:
  name: erp-config
data:
  ASPNETCORE_ENVIRONMENT: "Production"
  ConnectionStrings__Default: "Server=mssql;Database=erp;User Id=sa;Password=YourPassword"
---
# 2. Secret
apiVersion: v1
kind: Secret
metadata:
  name: erp-secret
type: Opaque
stringData:
  db-password: "YourStrongPassword"
---
# 3. Deployment
apiVersion: apps/v1
kind: Deployment
metadata:
  name: erp-api
spec:
  replicas: 3
  selector:
    matchLabels:
      app: erp-api
  template:
    metadata:
      labels:
        app: erp-api
    spec:
      containers:
        - name: erp-api
          image: registry.example.com/erp-api:1.0.0
          ports:
            - containerPort: 8080
          envFrom:
            - configMapRef:
                name: erp-config
          env:
            - name: ASPNETCORE_URLS
              value: "http://+:8080"
          resources:
            requests:
              cpu: "250m"
              memory: "256Mi"
            limits:
              cpu: "1"
              memory: "1Gi"
          livenessProbe:
            httpGet:
              path: /health
              port: 8080
            periodSeconds: 15
          readinessProbe:
            httpGet:
              path: /ready
              port: 8080
            periodSeconds: 5
---
# 4. Service
apiVersion: v1
kind: Service
metadata:
  name: erp-api-svc
spec:
  selector:
    app: erp-api
  ports:
    - port: 80
      targetPort: 8080
---
# 5. Ingress
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: erp-ingress
spec:
  ingressClassName: nginx
  rules:
    - host: erp.example.com
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: erp-api-svc
                port:
                  number: 80
```

> 提示：有状态组件（SQL Server、RabbitMQ、MinIO）建议使用 StatefulSet + PVC 部署，并配置持久化存储，而非上面的无状态 Deployment。
