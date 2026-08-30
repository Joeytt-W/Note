# Docker 容器使用手册

> 面向开发与运维的 Docker 全面速查手册，覆盖镜像、容器、网络、数据卷、Dockerfile、Compose 及生产实践。核心命令均附详细参数说明，便于查阅。

## 目录

1. [Docker 简介与核心概念](#一docker-简介与核心概念)
2. [安装与环境验证](#二安装与环境验证)
3. [镜像管理（Images）](#三镜像管理images)
4. [容器生命周期（Containers）](#四容器生命周期containers)
5. [容器与宿主机交互](#五容器与宿主机交互)
6. [数据卷与持久化（Volumes）](#六数据卷与持久化volumes)
7. [网络管理（Networks）](#七网络管理networks)
8. [Dockerfile 编写](#八dockerfile-编写)
9. [Docker Compose 编排](#九docker-compose-编排)
10. [日志与监控](#十日志与监控)
11. [资源限制](#十一资源限制)
12. [镜像仓库与分发](#十二镜像仓库与分发)
13. [生产环境最佳实践](#十三生产环境最佳实践)
14. [常用命令速查表](#十四常用命令速查表)
15. [常见故障排查](#十五常见故障排查)

---

## 一、Docker 简介与核心概念

Docker 是一个开源的应用容器引擎，让开发者可以将应用及依赖打包成轻量、可移植的容器，实现「一次构建，到处运行」。

### 核心概念

| 概念 | 说明 | 类比 |
|------|------|------|
| **镜像（Image）** | 只读模板，包含运行应用所需的代码、运行时、库、配置 | 类（Class） |
| **容器（Container）** | 镜像的运行实例，可启动、停止、删除 | 对象（Object） |
| **仓库（Registry）** | 存放镜像的地方，如 Docker Hub、私有 Harbor | 代码仓库 |
| **Dockerfile** | 构建镜像的脚本文件，定义镜像内容 | 构建脚本 |
| **数据卷（Volume）** | 持久化容器数据的独立存储 | 外挂硬盘 |
| **网络（Network）** | 容器间、容器与宿主机间的通信通道 | 局域网 |
| **Compose** | 多容器编排工具，用 YAML 定义 | 部署清单 |

### 与传统虚拟机的区别

| 维度 | Docker 容器 | 虚拟机（VM） |
|------|------|------|
| 启动速度 | 秒级 | 分钟级 |
| 资源占用 | MB 级 | GB 级 |
| 隔离级别 | 进程级（共享内核） | 硬件级（独立 OS） |
| 性能 | 接近原生 | 有虚拟化损耗 |
| 镜像大小 | 几十 MB 起 | 数 GB 起 |

---

## 二、安装与环境验证

### Linux（以 Ubuntu 为例）

```bash
# 使用官方脚本安装
curl -fsSL https://get.docker.com | sh

# 将当前用户加入 docker 组（免 sudo）
sudo usermod -aG docker $USER
# 重新登录后生效

# 启动并设置开机自启
sudo systemctl enable --now docker
```

### Windows / macOS

- **Windows**：安装 Docker Desktop，需开启 WSL2 或 Hyper-V
- **macOS**：安装 Docker Desktop（Intel 用原生，Apple Silicon 用 ARM 版）

### 验证安装

```bash
docker --version          # 查看版本
docker version            # 查看客户端与服务端版本
docker info               # 查看 Docker 引擎信息
docker run hello-world    # 运行测试镜像
```

### 镜像加速（中国大陆常用）

编辑 `/etc/docker/daemon.json`：

```json
{
  "registry-mirrors": [
    "https://docker.mirrors.ustc.edu.cn",
    "https://hub-mirror.c.163.com"
  ]
}
```

```bash
sudo systemctl daemon-reload
sudo systemctl restart docker
```

---

## 三、镜像管理（Images）

### 搜索与拉取

```bash
docker search nginx                 # 搜索镜像
docker pull nginx                   # 拉取最新版本
docker pull nginx:1.25              # 拉取指定标签
docker pull nginx:1.25-alpine       # 拉取精简版
```

**`docker pull` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `<image>:<tag>` | 镜像名 + 标签，省略 tag 默认 `latest` | `nginx:1.25` |
| `--platform` | 指定目标平台/架构 | `--platform linux/amd64` |
| `-a` / `--all-tags` | 拉取所有标签 | `docker pull -a nginx` |
| `-q` / `--quiet` | 静默模式，只输出镜像 ID | `docker pull -q nginx` |

> 标签（tag）命名习惯：`latest` 最新、`1.25` 主次版本、`1.25-alpine` 精简版、`1.25-slim` 瘦身版。

### 查看镜像

```bash
docker images                       # 列出本地镜像
docker images -a                    # 含中间层镜像
docker images nginx                 # 按名称过滤
docker image inspect nginx:latest   # 查看镜像详情
docker history nginx:latest         # 查看镜像构建历史（分层）
```

**`docker images` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-a` / `--all` | 显示所有镜像（含中间层） | `docker images -a` |
| `-q` / `--quiet` | 只显示镜像 ID | `docker images -q` |
| `-f` / `--filter` | 按条件过滤 | `docker images -f "dangling=true"` |
| `--format` | 自定义输出格式 | `docker images --format "{{.Repository}}:{{.Tag}}"` |
| `[name]` | 按名称匹配过滤 | `docker images nginx` |

### 删除镜像

```bash
docker rmi nginx:latest             # 删除镜像
docker rmi -f nginx:latest          # 强制删除
docker image prune                  # 清理无标签镜像（悬空镜像）
docker image prune -a               # 清理所有未使用的镜像（谨慎）
```

**参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-f` / `--force` | 强制删除（即使有容器在用） | `docker rmi -f nginx` |
| `--no-prune` | 不删除未打标签的父镜像 | `docker rmi --no-prune nginx` |

`docker image prune` 参数：

| 参数 | 说明 |
|------|------|
| `-a` / `--all` | 删除所有未被容器使用的镜像（不只是悬空镜像） |
| `-f` / `--force` | 跳过确认提示 |
| `--filter` | 按条件过滤，如 `--filter "until=24h"` 删除 24 小时前创建的 |

### 导入导出与保存

```bash
# 保存镜像为 tar 文件（离线迁移）
docker save -o nginx.tar nginx:latest
# 从 tar 文件加载镜像
docker load -i nginx.tar
# 导出运行中容器为镜像
docker commit <container-id> myimage:v1
# 打标签
docker tag nginx:latest myrepo/nginx:v1
```

**参数详解：**

| 命令 | 参数 | 说明 |
|------|------|------|
| `docker save` | `-o` / `--output` | 输出到指定 tar 文件 |
| `docker load` | `-i` / `--input` | 从指定 tar 文件读取 |
| `docker load` | `-q` / `--quiet` | 不输出加载信息 |
| `docker commit` | `-m` | 提交说明信息 |
| `docker commit` | `-c` | 应用 Dockerfile 指令（如 `-c "EXPOSE 8080"`） |
| `docker tag` | `<源> <目标>` | 为镜像打新标签，不复制数据 |

---

## 四、容器生命周期（Containers）

### 创建与运行

```bash
# 最常用：创建并启动容器
docker run -d --name web -p 8080:80 nginx
```

### `docker run` 参数详解（重点）

`docker run` 是 Docker 最核心、参数最多的命令，格式：

```
docker run [选项] 镜像[:标签] [命令] [参数...]
```

#### 运行模式

| 参数 | 说明 | 示例 |
|------|------|------|
| `-d` / `--detach` | 后台运行（守护模式），启动后返回容器 ID | `-d` |
| `-i` / `--interactive` | 保持 STDIN 打开，即使未附加 | `-i` |
| `-t` / `--tty` | 分配一个伪终端（TTY） | `-t` |
| `-it` | 交互模式（组合使用，进入容器交互必备） | `-it` |
| `--rm` | 容器退出后自动删除（适合临时/一次性任务） | `--rm` |

#### 命名与标识

| 参数 | 说明 | 示例 |
|------|------|------|
| `--name` | 指定容器名称（不指定则随机生成） | `--name web` |
| `-h` / `--hostname` | 设置容器内主机名 | `-h myserver` |
| `--label` / `-l` | 设置元数据标签 | `--label version=1.0` |

#### 端口映射

| 参数 | 说明 | 示例 |
|------|------|------|
| `-p` / `--publish` | 端口映射 `宿主机:容器` | `-p 8080:80` |
| `-p ip:host:container` | 指定宿主机 IP 的映射 | `-p 127.0.0.1:8080:80` |
| `-p host:container/udp` | 指定协议（默认 tcp） | `-p 53:53/udp` |
| `-P` / `--publish-all` | 随机映射镜像所有 EXPOSE 端口 | `-P` |

#### 环境变量

| 参数 | 说明 | 示例 |
|------|------|------|
| `-e` / `--env` | 设置环境变量（可多次） | `-e MYSQL_ROOT_PASSWORD=123456` |
| `--env-file` | 从文件批量读取环境变量 | `--env-file .env` |

#### 挂载与存储

| 参数 | 说明 | 示例 |
|------|------|------|
| `-v` / `--volume` | 挂载卷或目录 `宿主机:容器` | `-v /data:/var/lib/mysql` |
| `--mount` | 更详细的挂载语法（推荐生产使用） | `--mount type=volume,src=data,dst=/data` |
| `-w` / `--workdir` | 设置容器内工作目录 | `-w /app` |

#### 重启策略（--restart）

| 取值 | 说明 |
|------|------|
| `no` | 默认值，容器不自动重启 |
| `on-failure[:N]` | 仅当非零退出码时重启，`N` 为最大重试次数（如 `on-failure:5`） |
| `always` | 总是重启，Docker 守护进程启动时也会拉起 |
| `unless-stopped` | 除非手动 `docker stop`，否则总是重启（推荐） |

```bash
docker run -d --restart=unless-stopped --name redis redis:7
```

#### 网络

| 参数 | 说明 | 示例 |
|------|------|------|
| `--network` | 指定容器接入的网络 | `--network mynet` |
| `--network-alias` | 网络别名（其他容器可用别名访问） | `--network-alias db` |
| `--link` | 连接其他容器（已过时，用自定义网络替代） | `--link mysql:db` |

#### 资源限制

| 参数 | 说明 | 示例 |
|------|------|------|
| `-m` / `--memory` | 内存上限（单位 b/k/m/g） | `-m 512m` |
| `--memory-swap` | 内存 + swap 总上限 | `--memory-swap 1g` |
| `--cpus` | CPU 核数上限（可为小数） | `--cpus 0.5` |
| `--cpuset-cpus` | 绑定具体 CPU 核心 | `--cpuset-cpus="0,1"` |

#### 其他常用

| 参数 | 说明 | 示例 |
|------|------|------|
| `-u` / `--user` | 指定运行用户（UID:UID 或 用户名） | `-u 1000:1000` |
| `--entrypoint` | 覆盖镜像默认入口命令 | `--entrypoint /bin/sh` |
| `--log-driver` | 指定日志驱动 | `--log-driver json-file` |
| `--log-opt` | 日志驱动选项 | `--log-opt max-size=10m` |
| `--cap-add` / `--cap-drop` | 添加/移除内核能力 | `--cap-add NET_ADMIN` |
| `--privileged` | 特权模式（几乎等同宿主机权限，慎用） | `--privileged` |
| `--pull` | 启动前拉取策略：`always`/`missing`/`never` | `--pull always` |

### 常用启动示例

```bash
# 交互式运行（进入 bash）
docker run -it --name test ubuntu:22.04 bash

# 运行一次性任务（执行完退出并自动删除）
docker run --rm alpine echo "hello"

# 设置环境变量
docker run -d -e MYSQL_ROOT_PASSWORD=123456 --name mysql mysql:8

# 设置自动重启（常驻服务必备）
docker run -d --restart=unless-stopped --name redis redis:7

# 挂载目录 + 端口映射 + 环境变量（完整示例）
docker run -d \
  --name myapp \
  -p 8080:8080 \
  -v /opt/myapp/logs:/app/logs \
  -e TZ=Asia/Shanghai \
  --restart=unless-stopped \
  myapp:v1
```

### 查看容器

```bash
docker ps                    # 查看运行中的容器
docker ps -a                 # 查看所有容器（含已停止）
docker ps -q                 # 只显示容器 ID
docker inspect <container>   # 查看容器详细配置
docker stats                 # 实时查看容器资源占用
docker top <container>       # 查看容器内进程
```

**`docker ps` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-a` / `--all` | 显示所有容器（默认只显示运行中） | `docker ps -a` |
| `-q` / `--quiet` | 只显示容器 ID | `docker ps -aq` |
| `-l` / `--latest` | 显示最近创建的容器 | `docker ps -l` |
| `-n` / `--last` | 显示最近 N 个容器 | `docker ps -n 5` |
| `-s` / `--size` | 显示容器大小 | `docker ps -s` |
| `-f` / `--filter` | 按条件过滤 | `docker ps -f "status=exited"` |
| `--format` | 自定义输出格式 | `docker ps --format "{{.Names}}: {{.Status}}"` |

### 启停与删除

```bash
docker start <container>     # 启动已存在的容器
docker stop <container>      # 停止容器（优雅停止，发 SIGTERM）
docker restart <container>   # 重启容器
docker kill <container>      # 强制停止（发 SIGKILL）

docker rm <container>        # 删除已停止的容器
docker rm -f <container>     # 强制删除运行中的容器
docker rm $(docker ps -aq)   # 删除所有容器（谨慎）
docker container prune       # 清理所有已停止的容器
```

**`docker stop` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-t` / `--time` | 停止前等待的秒数（默认 10 秒，超时强制 kill） | `docker stop -t 5 web` |

**`docker rm` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-f` / `--force` | 强制删除运行中的容器 | `docker rm -f web` |
| `-v` / `--volumes` | 同时删除容器关联的匿名卷 | `docker rm -v web` |
| `-l` / `--link` | 删除容器间的链接 | `docker rm -l web` |

### 进入容器

```bash
docker exec -it <container> bash     # 进入容器执行命令（推荐）
docker exec -it <container> sh       # 精简镜像用 sh
docker exec <container> ls /         # 执行单条命令不进入
```

**`docker exec` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-i` / `--interactive` | 保持 STDIN 打开 | `-i` |
| `-t` / `--tty` | 分配伪终端 | `-t` |
| `-d` / `--detach` | 后台执行命令 | `-d` |
| `-e` / `--env` | 设置环境变量 | `-e KEY=value` |
| `-u` / `--user` | 指定执行用户 | `-u root` |
| `-w` / `--workdir` | 指定工作目录 | `-w /app` |

### 退出与后台

```bash
# 容器内操作
exit                  # 退出容器（容器继续运行）
Ctrl + P, Ctrl + Q    # 退出但保持容器运行

# 宿主机操作
docker attach <container>   # 重新附加到容器
```

---

## 五、容器与宿主机交互

### 端口映射（-p / -P）

```bash
-p 8080:80          # 宿主机 8080 → 容器 80
-p 127.0.0.1:8080:80  # 仅本机可访问
-p 8080:80/udp      # 指定协议（默认 tcp）
-p 8080-8090:80     # 端口范围映射
-P                  # 随机映射所有 EXPOSE 端口
```

| 格式 | 说明 |
|------|------|
| `hostPort:containerPort` | 标准映射 |
| `ip:hostPort:containerPort` | 绑定指定宿主机 IP |
| `hostPort:containerPort/protocol` | 指定协议 tcp/udp |
| `hostPortStart-hostPortEnd:containerPort` | 端口范围 |

### 环境变量（-e）

```bash
-e MYSQL_ROOT_PASSWORD=123456       # 单个环境变量
-e TZ=Asia/Shanghai                 # 设置时区（重要）
-e KEY1=v1 -e KEY2=v2               # 多个环境变量
--env-file .env                     # 从文件批量读取
```

`.env` 文件格式（每行一个 `KEY=value`）：

```
MYSQL_ROOT_PASSWORD=123456
TZ=Asia/Shanghai
```

### 文件挂载（-v / --mount）

```bash
-v /宿主机/绝对路径:/容器/路径        # 绑定挂载目录（宿主机路径必须为绝对路径）
-v /宿主机/文件:/容器/文件            # 挂载单个文件
-v 卷名:/容器/路径                    # 挂载命名卷
-v /容器/路径                         # 仅指定容器路径（匿名卷）
```

**`--mount` 语法（更明确，生产推荐）：**

```bash
# 挂载命名卷
--mount type=volume,src=卷名,dst=/容器路径

# 绑定挂载目录
--mount type=bind,src=/宿主机路径,dst=/容器路径

# 只读挂载
--mount type=volume,src=卷名,dst=/容器路径,readonly
```

> 以上仅为挂载语法速览。**数据持久化的完整原理、三种挂载方式的选型、卷的生命周期与备份**，详见 [第六章 数据卷与持久化](#六数据卷与持久化volumes)。

---

## 六、数据卷与持久化（Volumes）

### 6.1 为什么容器数据会丢失

理解这一点，才能明白「持久化」到底在解决什么问题。

Docker 容器的文件系统是 **分层叠加** 的：

```
┌─────────────────────────────┐
│  容器可写层（Container Layer）│  ← 运行时的修改写在这里，是临时的
├─────────────────────────────┤
│  镜像层 3（Image Layer）      │  ← 只读
├─────────────────────────────┤
│  镜像层 2（Image Layer）      │  ← 只读
├─────────────────────────────┤
│  镜像层 1（基础镜像）          │  ← 只读
└─────────────────────────────┘
```

- **镜像层**是只读的，由 `docker build` 固化。
- **容器可写层**（Copy-on-Write）承载运行时的一切写入：日志、数据库文件、用户上传等。
- 一旦执行 `docker rm` 删除容器，**可写层随容器一起消失**，其中的数据无法找回。

所以结论是：**凡是要长期保留的数据，绝不能只写在容器内部，必须「挂载」到容器之外的存储上**。这就是数据卷存在的意义。

### 6.2 三种挂载方式对比

Docker 提供三种把「容器外存储」接入容器的方式：

| 方式 | 数据存放位置 | 由谁管理 | 是否随容器删除 | 典型场景 |
|------|------|------|------|------|
| **Volume（卷）** | 宿主机 `/var/lib/docker/volumes/<卷名>/_data` | Docker 托管 | **不删**，独立存在 | 生产环境数据库、持久数据 |
| **Bind Mount（绑定挂载）** | 宿主机任意指定路径（如 `/opt/data`） | 用户自己管 | **不删**（宿主机目录仍在） | 开发热更新、挂配置文件 |
| **tmpfs（内存挂载）** | 仅存在内存中 | Docker 托管 | **必删**（容器停止即清空） | 临时/敏感数据（密钥、缓存） |

**一句话选型：**

- 数据要长期保存、且不希望关心具体存在宿主机哪个目录 → 用 **Volume**
- 需要实时把宿主机某目录/文件同步进容器（改代码立刻生效）→ 用 **Bind Mount**
- 数据是临时的、不想落盘 → 用 **tmpfs**

### 6.3 Volume（卷）—— 生产推荐

卷由 Docker 统一管理，存在宿主机 `/var/lib/docker/volumes/` 下，与容器生命周期解耦。

**命名卷 vs 匿名卷：**

| 类型 | 写法 | 卷名 | 特点 |
|------|------|------|------|
| **命名卷** | `-v 卷名:/容器路径` | 你指定的名字（如 `mysql-data`） | 可复用、可跨容器共享、易管理 |
| **匿名卷** | `-v /容器路径`（只写容器路径） | Docker 生成随机哈希名 | 难识别、易堆积，仅临时用 |

```bash
# 命名卷（推荐）：明确命名，便于复用和备份
docker run -d -v mysql-data:/var/lib/mysql --name mysql mysql:8

# 匿名卷（不推荐）：卷名是随机哈希，过后难以辨认
docker run -d -v /var/lib/mysql --name mysql mysql:8
```

> 部分镜像（如 MySQL、Redis）的 Dockerfile 里已声明了 `VOLUME`，即便你不写 `-v`，Docker 也会自动创建匿名卷。这就是为什么建议**显式使用命名卷**，避免产生一堆无主匿名卷。

### 6.4 Bind Mount（绑定挂载）—— 开发常用

把宿主机任意目录或文件直接挂进容器，宿主机改、容器立即同步（双向）。

```bash
# 挂载目录：开发时改代码，容器内立即生效（热更新）
docker run -d -v /home/dev/myapp:/app --name myapp node:20

# 挂载单个文件：给容器注入配置文件
docker run -d -v /opt/nginx/nginx.conf:/etc/nginx/nginx.conf:ro nginx
```

**Bind Mount 要点：**

- 源路径必须是**宿主机绝对路径**（如 `/home/xxx`，Windows 下如 `C:\data:/data`）
- 末尾加 `:ro` 表示**只读**，防止容器误改宿主机文件
- 权限问题：容器内用户需对挂载目录有读写权限（UID/GID 要对得上）

### 6.5 `-v` 与 `--mount` 语法对比

两者功能相同，`--mount` 是更明确、更推荐的新语法。

```bash
# -v 语法：靠位置判断类型（字段间用冒号分隔）
-v 卷名:/容器路径              # 第一段无斜杠 → 当作卷
-v /宿主机/路径:/容器路径       # 第一段有斜杠 → 当作 bind mount

# --mount 语法：显式声明 type，无歧义（推荐）
--mount type=volume,src=卷名,dst=/容器路径
--mount type=bind,src=/宿主机路径,dst=/容器路径
--mount type=tmpfs,dst=/容器路径
```

> 为什么推荐 `--mount`？`-v` 在源路径带冒号、带特殊字符时容易出错，且「第一段有没有斜杠」这种隐式判断让人困惑。`--mount` 用 `type=` 一目了然。

### 6.6 卷管理命令

```bash
docker volume create mydata          # 创建命名卷
docker volume ls                     # 列出所有卷
docker volume inspect mydata         # 查看卷详情（含宿主机真实路径）
docker volume rm mydata              # 删除卷（须先停用相关容器）
docker volume prune                  # 清理未被任何容器使用的卷（谨慎）
```

**`docker volume` 参数详解：**

| 子命令 | 参数 | 说明 |
|------|------|------|
| `create` | `-d` / `--driver` | 指定卷驱动（默认 `local`，可接 NFS 等插件） |
| `create` | `-o` / `--opt` | 驱动选项（如 `-o type=nfs`） |
| `ls` | `-q` / `--quiet` | 只显示卷名 |
| `ls` | `-f` / `--filter` | 过滤（如 `-f "dangling=true"` 显示无主卷） |
| `inspect` | `--format` | 自定义输出格式 |
| `rm` | `-f` / `--force` | 强制删除（含正在使用的卷） |
| `prune` | `-f` / `--force` | 跳过确认提示 |

### 6.7 卷的生命周期（易混淆点）

很多人误以为「删除容器 = 删除数据」，其实要看挂载方式和删除方式：

| 操作 | 命名卷 | 匿名卷 | Bind Mount |
|------|------|------|------|
| `docker rm 容器` | 卷保留 ✅ | 卷保留（成为无主卷）⚠️ | 宿主机目录保留 ✅ |
| `docker rm -v 容器` | 卷保留 ✅ | **卷被删除** ❌ | 宿主机目录保留 ✅ |
| `docker run --rm 容器` | 卷保留 ✅ | **卷随容器删除** ❌ | 宿主机目录保留 ✅ |

**结论：**

- 想数据安全 → 用**命名卷**，它几乎在任何删除方式下都会保留。
- 匿名卷 + `--rm` / `rm -v` 是数据丢失的高发组合，务必留意。

### 6.8 实战案例

**① 数据库持久化（生产）**

```bash
# MySQL 数据落在命名卷，删容器/升级镜像数据都不丢
docker run -d \
  --name mysql \
  -v mysql-data:/var/lib/mysql \
  -e MYSQL_ROOT_PASSWORD=123456 \
  --restart=unless-stopped \
  mysql:8
```

**② 开发环境热更新（Bind Mount）**

```bash
# 宿主机代码目录实时同步进容器，改代码无需重新构建
docker run -d \
  --name dev \
  -v /home/dev/myapp:/app \
  -p 3000:3000 \
  node:20
```

**③ 多容器共享同一份数据**

```bash
# 两个容器挂同一个命名卷，共享文件
docker run -d -v shared-data:/data --name app1 nginx
docker run -d -v shared-data:/data --name app2 nginx
```

### 6.9 备份与恢复

```bash
# 备份：启动一个临时容器，同时挂载「数据卷」和「宿主机备份目录」，打包
docker run --rm \
  -v mysql-data:/data \
  -v $(pwd):/backup \
  alpine tar czf /backup/mysql-backup.tar.gz -C /data .

# 恢复：反向解包回数据卷
docker run --rm \
  -v mysql-data:/data \
  -v $(pwd):/backup \
  alpine tar xzf /backup/mysql-backup.tar.gz -C /data
```

> 备份命令原理：`--rm` 临时容器跑完即删，但因为它只把命名卷 `mysql-data` 当「源」读取、把 `$(pwd)` 当「目标」写入，所以打包出的 tar 文件落在宿主机当前目录，数据卷本身不受影响。

---

## 七、网络管理（Networks）

### 网络类型

| 类型 | 说明 | 用途 |
|------|------|------|
| **bridge** | 默认网络，容器间通过 IP 互通 | 单机容器通信 |
| **host** | 共享宿主机网络栈 | 高性能场景 |
| **none** | 无网络 | 隔离场景 |
| **overlay** | 跨主机网络（Swarm） | 集群场景 |
| **macvlan** | 为容器分配物理网卡 MAC 地址 | 直连物理网络 |

### 常用命令

```bash
docker network ls                    # 列出网络
docker network create mynet          # 创建自定义网络
docker network inspect mynet         # 查看网络详情
docker network rm mynet              # 删除网络
```

**`docker network` 参数详解：**

| 子命令 | 参数 | 说明 |
|------|------|------|
| `create` | `-d` / `--driver` | 网络驱动（bridge/overlay/macvlan 等） |
| `create` | `--subnet` | 指定子网（如 `--subnet 172.20.0.0/16`） |
| `create` | `--gateway` | 指定网关 |
| `create` | `--ip-range` | 指定 IP 分配范围 |
| `ls` | `-q` / `--quiet` | 只显示网络 ID |
| `ls` | `-f` / `--filter` | 过滤（如 `-f "driver=bridge"`） |
| `rm` | 无 | 删除网络（须先断开所有容器） |

### 容器互联

```bash
# 将容器加入自定义网络（同网络下可用容器名互访）
docker network create mynet
docker run -d --name app1 --network mynet nginx
docker run -d --name app2 --network mynet redis
# app1 内可直接访问 redis:6379（用容器名解析）

# 连接/断开已有容器
docker network connect mynet <container>
docker network disconnect mynet <container>
```

**`docker network connect` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `--ip` | 指定容器在该网络的 IP | `--ip 172.20.0.10` |
| `--alias` | 添加网络别名 | `--alias db` |

> 关键技巧：同一自定义网络下的容器可直接通过 **容器名** 互相访问，无需记 IP。

---

## 八、Dockerfile 编写

Dockerfile 是构建镜像的脚本，定义镜像的每一层。

### 常用指令

| 指令 | 说明 | 示例 |
|------|------|------|
| `FROM` | 指定基础镜像（必须是首条指令） | `FROM node:20-alpine` |
| `WORKDIR` | 设置工作目录（不存在则自动创建） | `WORKDIR /app` |
| `COPY` | 复制宿主机文件到镜像（推荐） | `COPY . /app` |
| `ADD` | 复制文件，支持远程 URL 和解压 tar | `ADD app.tar.gz /app` |
| `RUN` | 构建时执行命令 | `RUN npm install` |
| `ENV` | 设置环境变量（构建和运行时都生效） | `ENV NODE_ENV=production` |
| `ARG` | 构建参数（仅构建时可用） | `ARG VERSION=1.0` |
| `EXPOSE` | 声明容器监听端口（文档性质） | `EXPOSE 8080` |
| `CMD` | 容器启动时默认执行的命令 | `CMD ["node", "server.js"]` |
| `ENTRYPOINT` | 容器启动入口（可与 CMD 组合） | `ENTRYPOINT ["dotnet"]` |
| `VOLUME` | 声明挂载点 | `VOLUME /data` |
| `USER` | 指定运行用户 | `USER node` |
| `HEALTHCHECK` | 健康检查 | `HEALTHCHECK CMD curl -f ...` |

### `CMD` vs `ENTRYPOINT` 区别

| 维度 | `CMD` | `ENTRYPOINT` |
|------|------|------|
| 作用 | 提供默认命令和参数 | 定义固定入口 |
| 能否被 `docker run` 覆盖 | 可以被命令行参数覆盖 | 默认不可覆盖（需 `--entrypoint`） |
| 组合用法 | `ENTRYPOINT ["dotnet"]` + `CMD ["MyApp.dll"]` |

### 示例：.NET 8 Web 应用

```dockerfile
# 构建阶段
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 运行阶段
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "MyApp.dll"]
```

### 示例：Node.js 应用

```dockerfile
FROM node:20-alpine
WORKDIR /app
COPY package*.json ./
RUN npm install --production
COPY . .
EXPOSE 3000
CMD ["node", "server.js"]
```

### 构建与运行

```bash
docker build -t myapp:v1 .            # 构建镜像（-t 指定标签）
docker build -f Dockerfile.dev -t myapp:dev .   # 指定 Dockerfile
docker build --no-cache -t myapp:v1 .          # 不使用缓存构建
docker build --build-arg VERSION=1.0 -t myapp . # 传入构建参数
```

**`docker build` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-t` / `--tag` | 指定镜像名:标签（可多次） | `-t myapp:v1` |
| `-f` / `--file` | 指定 Dockerfile 路径 | `-f Dockerfile.dev` |
| `--no-cache` | 不使用构建缓存 | `--no-cache` |
| `--build-arg` | 传入构建参数（配合 ARG 指令） | `--build-arg VERSION=1.0` |
| `--target` | 多阶段构建时指定目标阶段 | `--target build` |
| `--pull` | 强制拉取最新基础镜像 | `--pull` |
| `.` | 构建上下文路径（`.` 表示当前目录） | `.` |

### 编写最佳实践

- 使用 **多阶段构建**，减小最终镜像体积
- 优先使用 **alpine/slim** 等精简基础镜像
- 将变动频繁的层放后面（充分利用构建缓存）
- `COPY` 优于 `ADD`（除非需要解压/远程拉取）
- 合并 `RUN` 命令，减少镜像层数
- 用 `.dockerignore` 排除不需要的文件（node_modules、bin、obj 等）

**.dockerignore 示例：**

```
node_modules
bin/
obj/
.git
*.log
```

---

## 九、Docker Compose 编排

Compose 用于定义和运行多容器应用，用 YAML 文件描述服务、网络、卷。

### docker-compose.yml 示例

```yaml
version: "3.8"

services:
  web:
    build: .                    # 从当前目录 Dockerfile 构建
    ports:
      - "8080:8080"
    environment:
      - TZ=Asia/Shanghai
    depends_on:
      - db
    restart: always
    networks:
      - appnet

  db:
    image: mysql:8
    environment:
      MYSQL_ROOT_PASSWORD: 123456
      MYSQL_DATABASE: myapp
    volumes:
      - dbdata:/var/lib/mysql
    ports:
      - "3306:3306"
    restart: always
    networks:
      - appnet

  redis:
    image: redis:7-alpine
    restart: always
    networks:
      - appnet

volumes:
  dbdata:

networks:
  appnet:
```

### Compose 配置项详解

| 配置项 | 说明 |
|------|------|
| `image` | 使用的镜像 |
| `build` | 从 Dockerfile 构建（可指定 context 和 dockerfile） |
| `ports` | 端口映射 `"宿主机:容器"` |
| `expose` | 仅容器间暴露端口（不映射到宿主机） |
| `environment` | 环境变量（列表或字典两种写法） |
| `env_file` | 从外部文件读取环境变量 |
| `volumes` | 卷挂载 |
| `depends_on` | 服务依赖（决定启动顺序） |
| `restart` | 重启策略（no/always/on-failure/unless-stopped） |
| `networks` | 加入的网络 |
| `command` | 覆盖默认启动命令 |
| `entrypoint` | 覆盖入口 |
| `healthcheck` | 健康检查 |
| `deploy.resources.limits` | 资源限制（内存/CPU） |

### Compose 常用命令

```bash
docker compose up -d           # 启动所有服务（后台）
docker compose up -d --build   # 重新构建并启动
docker compose down            # 停止并删除容器（保留卷）
docker compose down -v         # 停止并删除容器和卷（谨慎）
docker compose ps              # 查看服务状态
docker compose logs -f web     # 查看指定服务日志
docker compose restart web     # 重启指定服务
docker compose exec web bash   # 进入指定服务容器
docker compose pull            # 拉取最新镜像
docker compose config          # 校验 compose 文件语法
```

**`docker compose` 子命令参数详解：**

| 子命令 | 参数 | 说明 |
|------|------|------|
| `up` | `-d` / `--detach` | 后台运行 |
| `up` | `--build` | 启动前重新构建镜像 |
| `up` | `--force-recreate` | 强制重新创建容器 |
| `up` | `--scale` | 扩展服务实例数（如 `--scale web=3`） |
| `down` | `-v` / `--volumes` | 同时删除卷 |
| `down` | `--rmi` | 同时删除镜像（`all`/`local`） |
| `logs` | `-f` / `--follow` | 实时跟踪 |
| `logs` | `--tail` | 显示最后 N 行 |
| `ps` | `-a` / `--all` | 显示所有服务（含停止） |
| `exec` | `-it` | 交互模式进入 |

> 新版 Docker 已合并 `docker compose`（V2，无连字符）替代旧 `docker-compose`。

---

## 十、日志与监控

### 日志查看

```bash
docker logs <container>              # 查看日志
docker logs -f <container>           # 实时跟踪日志
docker logs --tail 100 <container>   # 查看最后 100 行
docker logs --since 1h <container>   # 查看最近 1 小时
docker logs -t <container>           # 显示时间戳
```

**`docker logs` 参数详解：**

| 参数 | 说明 | 示例 |
|------|------|------|
| `-f` / `--follow` | 实时跟踪日志输出（Ctrl+C 退出） | `-f` |
| `--tail` | 从末尾显示 N 行 | `--tail 100` |
| `-t` / `--timestamps` | 显示时间戳 | `-t` |
| `--since` | 显示某时间之后（如 `1h`、`2024-01-01`） | `--since 1h` |
| `--until` | 显示某时间之前 | `--until 30m` |
| `--details` | 显示额外细节 | `--details` |

### 资源监控

```bash
docker stats                     # 实时查看所有容器资源占用
docker stats <container>         # 查看单个容器
docker stats --no-stream         # 只输出一次快照（不持续刷新）
docker inspect -f '{{.State.Status}}' <container>  # 查看容器状态
```

**`docker stats` 参数详解：**

| 参数 | 说明 |
|------|------|
| `--no-stream` | 只输出一次，不持续刷新（适合脚本） |
| `--format` | 自定义输出格式 |
| `-a` / `--all` | 显示所有容器（含停止） |

### 日志驱动配置

```bash
# 限制单个容器日志大小（防止日志撑爆磁盘）
docker run -d --log-driver json-file \
  --log-opt max-size=10m \
  --log-opt max-file=3 \
  nginx
```

**日志驱动选项（`--log-opt`）：**

| 选项 | 说明 |
|------|------|
| `max-size` | 单个日志文件最大大小（如 `10m`） |
| `max-file` | 保留的日志文件数量 |
| `mode` | 写模式（blocking/non-blocking） |

---

## 十一、资源限制

```bash
# 限制内存
docker run -d -m 512m --name app nginx

# 限制 CPU（0.5 = 半个核心）
docker run -d --cpus 0.5 --name app nginx

# 绑定 CPU 核心
docker run -d --cpuset-cpus="0,1" --name app nginx

# 内存 + CPU 综合限制
docker run -d -m 1g --cpus 2 --name app nginx
```

**资源限制参数详解：**

| 参数 | 说明 | 取值示例 |
|------|------|----------|
| `-m` / `--memory` | 内存上限 | `512m`、`1g` |
| `--memory-swap` | 内存 + swap 上限 | `1g`（-1 表示不限 swap） |
| `--memory-reservation` | 内存软限制（预留） | `256m` |
| `--cpus` | CPU 核数（可小数） | `0.5`、`2` |
| `--cpuset-cpus` | 绑定 CPU 核心 | `"0,1"`、`"0-3"` |
| `--cpu-shares` | CPU 相对权重（默认 1024） | `512` |
| `--pids-limit` | 限制进程数 | `100` |

### 动态调整资源（运行中容器）

```bash
# 调整已运行容器的内存限制
docker update -m 1g --cpus 2 <container>

# 查看当前限制
docker inspect -f '{{.HostConfig.Memory}} {{.HostConfig.NanoCpus}}' <container>
```

> 生产环境强烈建议为每个容器设置内存/CPU 限制，避免单容器耗尽宿主机资源。

---

## 十二、镜像仓库与分发

### Docker Hub

```bash
docker login                          # 登录
docker logout                         # 退出登录
docker push myuser/myapp:v1           # 推送镜像
docker pull myuser/myapp:v1           # 拉取镜像
docker tag myapp:v1 myuser/myapp:v1   # 打标签后推送
```

**参数详解：**

| 命令 | 参数 | 说明 |
|------|------|------|
| `docker login` | `-u` / `--username` | 指定用户名 |
| `docker login` | `-p` / `--password` | 指定密码（不推荐明文，会提示交互输入） |
| `docker login` | `<registry>` | 指定仓库地址（默认 Docker Hub） |
| `docker logout` | `<registry>` | 指定退出哪个仓库 |
| `docker push` | `-a` / `--all-tags` | 推送所有标签 |

### 私有仓库（Harbor / Registry）

```bash
# 登录私有仓库
docker login harbor.example.com

# 推送到私有仓库
docker tag myapp:v1 harbor.example.com/project/myapp:v1
docker push harbor.example.com/project/myapp:v1

# 拉取
docker pull harbor.example.com/project/myapp:v1
```

> 若私有仓库使用 HTTP（非 HTTPS），需在 `/etc/docker/daemon.json` 添加 `"insecure-registries": ["harbor.example.com"]`。

---

## 十三、生产环境最佳实践

### 安全

- 容器内使用 **非 root 用户** 运行（`USER` 指令）
- 镜像扫描漏洞（`docker scan` / Trivy）
- 敏感信息用 **secrets** 而非环境变量明文
- 定期更新基础镜像
- 避免使用 `--privileged` 特权模式

### 性能与稳定

- 为容器设置 `--restart=unless-stopped` 和资源限制
- 配置日志轮转，防止磁盘写满
- 数据库等有状态服务用数据卷持久化
- 使用多阶段构建减小镜像体积

### 编排

- 生产环境推荐用 **Kubernetes** 或 Docker Swarm 编排
- 用 Compose 管理多容器应用的开发/测试环境
- 做好容器健康检查（HEALTHCHECK）

### Dockerfile 健康检查示例

```dockerfile
HEALTHCHECK --interval=30s --timeout=3s --retries=3 \
  CMD curl -f http://localhost:8080/health || exit 1
```

**HEALTHCHECK 参数详解：**

| 参数 | 说明 |
|------|------|
| `--interval` | 检查间隔（默认 30s） |
| `--timeout` | 单次检查超时（默认 30s） |
| `--start-period` | 启动宽限期 |
| `--retries` | 连续失败 N 次后判定不健康 |

---

## 十四、常用命令速查表

### 容器操作

| 命令 | 作用 |
|------|------|
| `docker run -d --name n -p 80:80 img` | 创建并后台运行容器 |
| `docker ps -a` | 查看所有容器 |
| `docker start/stop/restart n` | 启动/停止/重启 |
| `docker exec -it n bash` | 进入容器 |
| `docker rm -f n` | 删除容器 |
| `docker logs -f n` | 跟踪日志 |
| `docker inspect n` | 查看详情 |
| `docker stats` | 资源监控 |
| `docker cp n:/path host` | 从容器复制文件到宿主机 |

### 镜像操作

| 命令 | 作用 |
|------|------|
| `docker pull img:tag` | 拉取镜像 |
| `docker build -t img .` | 构建镜像 |
| `docker images` | 列出镜像 |
| `docker rmi img` | 删除镜像 |
| `docker tag src dst` | 打标签 |
| `docker push img` | 推送镜像 |

### 清理（谨慎使用）

```bash
docker system df                      # 查看磁盘占用
docker system prune                   # 清理未使用的资源
docker system prune -a --volumes      # 全面清理（危险）
docker image prune                    # 清理悬空镜像
docker container prune                # 清理停止的容器
docker volume prune                   # 清理未使用的卷
```

---

## 十五、常见故障排查

| 问题 | 排查方法 |
|------|----------|
| 容器启动后立即退出 | `docker logs <container>` 查看退出原因 |
| 端口被占用 | `docker ps` 检查端口映射，`netstat -tlnp` 查看占用 |
| 容器无法访问网络 | `docker exec <container> ping 8.8.8.8` 测试连通性 |
| 容器间无法通信 | 检查是否在同一自定义网络，用容器名而非 IP |
| 镜像拉取缓慢/失败 | 配置镜像加速器，或更换镜像源 |
| 数据丢失 | 检查是否忘记挂载数据卷（`docker inspect` 看 Mounts） |
| 磁盘空间不足 | `docker system df` 排查，清理无用镜像/卷/日志 |
| 权限错误 | 检查容器内用户权限，或 `docker exec` 调整 |
| 时区不对 | 启动时加 `-e TZ=Asia/Shanghai` |
| 容器无响应 | `docker stats` 看资源，`docker logs` 看日志 |

### 常用诊断命令

```bash
docker inspect <container>            # 查看完整配置（网络、挂载、环境变量）
docker logs --tail 50 <container>     # 查看日志
docker exec -it <container> sh        # 进入容器排查
docker events                         # 实时查看 Docker 事件
docker system df                      # 磁盘占用分析
```

---

## 附：核心工作流

```
┌─────────────┐   build   ┌─────────┐   run    ┌──────────┐
│ Dockerfile  │ ────────▶ │  镜像    │ ───────▶ │  容器     │
└─────────────┘           │ (Image) │          │(Container)│
                          └────┬────┘          └────┬─────┘
                               │ push / pull        │ exec / logs
                               ▼                    ▼
                          ┌─────────┐         ┌──────────┐
                          │  仓库    │         │ 数据卷/网络 │
                          │(Registry)│         │(Volume/Net)│
                          └─────────┘         └──────────┘
```

**典型流程：** 编写 Dockerfile → `docker build` 构建镜像 → `docker run` 启动容器 → 用 Compose 编排多容器 → 推送到仓库分发。
