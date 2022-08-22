## 基于Docker安装

查找RabbitMQ镜像

```undefined
docker search rabbitmq
```

拉取RabbitMQ镜像

```css
docker pull rabbitmq (镜像未配有管理页面)
docker pull rabbitmq:management (镜像配有管理页面)
```

安装 RabbitMQ

```go
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=wa rabbitmq:management
```

停止 RabbitMQ 容器

```undefined
  docker stop rabbitmq
```

启动 RabbitMQ 容器

```undefined
  docker start rabbitmq
```

重启 RabbitMQ 容器

```undefined
  docker restart rabbitmq
```

查看 RabbitMQ 容器进程信息

```undefined
  docker top rabbitmq
```

## Windows安装

### 安装ErLang环境

下载地址：http://www.erlang.org/downloads 

![](images/01.png)

设置环境变量

![](images/02.png)

检查Erlang是否安装成功,打开 cmd ,输入 erl 后回车，如果看到如下的信息，表明安装成功

![](images/03.png)

### 安装RabbitMQ服务端

[Messaging that just works — RabbitMQ](https://www.rabbitmq.com/#getstarted)

![](images/04.png)

![](images/06.png)

安装完之后

运行cmd，进入rabbitMQ服务安装目录的sbin目录下，运行如下三条命令：

```text
rabbitmq-service install
rabbitmq-service enable
rabbitmq-service start
```

![](images/05.png)

假如显示node没有连接上，需要到C:\Windows目录下，将.erlang.cookie文件，拷贝到用户目录下 C:\Users\{用户名}，这是Erlang的Cookie文件，允许与Erlang进行交互。

**使用命令查看用户：**

```text
rabbitmqctl list_users
```

![](images/07.png)

RabbitMQ会为我们创建默认的用户名guest和密码guest，guest默认拥有RabbitMQ的所有权限。

　　一般的，我们需要新建一个我们自己的用户，设置密码，并授予权限，并将其设置为管理员，可以使用下面的命令来执行这一操作：

```text
rabbitmqctl  add_user  admin wang0705   //创建用户admin密码为wang0705
rabbitmqctl  set_permissions  admin ".*"  ".*"  ".*"    //赋予admin读写所有消息队列的权限
rabbitmqctl  set_user_tags admin administrator    //分配用户组
```

**修改admin密码为123：**

```text
 rabbitmqctl change_password admin 123
```

**删除用户admin：**

```text
 rabbitmqctl delete_user  admin
```

### RabbitMQ客户端

使用客户端dll写代码

### RabbitMQ-Management

rabbitmq提供了一个图形的管理界面，用于管理、监控rabbitmq的运行情况，它是以插件的形式提供的，如果要启用需要启用插件

同样启动cmd，进入rabbitMQ服务安装目录的sbin目录下，运行如下命令

```text
rabbitmq-plugins enable rabbitmq_management
```

然后重启服务（右键点击重启）

![](images/08.png)

rabbitmq_management默认地址为：127.0.0.1:15672

![](images/09.png)

## Ubuntu安装

### 安装erlang[#](https://www.cnblogs.com/FleetingAstral/p/16025737.html#安装erlang)

由于RabbitMq需要erlang语言的支持，在安装RabbitMq之前需要安装erlang

```
sudo apt-get install erlang-nox  //sudo apt-get install erlang -y
```

### 安装RabbitMq[#](https://www.cnblogs.com/FleetingAstral/p/16025737.html#安装rabbitmq)

1. 更新源
   `sudo apt-get update`

2. 安装

   `sudo apt-get install rabbitmq-server`

3. 以应用方式

```Bash
sudo rabbitmq-server         # 启动
sudo rabbitmqctl stop       # 停止
sudo rabbitmqctl status     # 查看状态
```

1. 以服务方式启动（安装完之后在任务管理器中服务一栏能看到RabbtiMq）

```Bash
sudo rabbitmq-service install        # 安装服务
sudo rabbitmq-service start          # 开始服务
sudo rabbitmq-service stop           # 停止服务
sudo rabbitmq-service enable         # 使服务有效
sudo rabbitmq-service disable        # 使服务无效
sudo rabbitmq-service help           # 帮助
# 当rabbitmq-service install之后默认服务是enable的，如果这时设置服务为disable的话，rabbitmq-service start就会报错。
# 当rabbitmq-service start正常启动服务之后，使用disable是没有效果的
sudo rabbitmqctl stop                # 关闭服务
```

1. RabbitMq 管理插件启动，可视化界面

```Bash
sudo rabbitmq-plugins enable rabbitmq_management       # 启动
sudo rabbitmq-plugins disable rabbitmq_management      # 关闭
```

1. RabbitMq节点管理方式

```Bash
rabbitmqctl
```

### 添加admin，并赋予administrator权限[#](https://www.cnblogs.com/FleetingAstral/p/16025737.html#添加admin并赋予administrator权限)

1. 添加admin用户，密码设置为wang0705

   `sudo rabbitmqctl add_user admin wang0705`

2. 赋予权限

   `sudo rabbitmqctl set_user_tags admin administrator`

3. 赋予virtual host中所有资源的配置、写、读权限以便管理其中的资源

   `sudo rabbitmqctl set_permissions -p / admin '.`*`' '.`*`' '.*'`

### 设置开机自启动

1. 编辑service文件

> vim /lib/systemd/system/**rabbitmq-server.service**

![](images/10.png)

2. 设置开机启动

> systemctl enable rabbitmq-server.service

