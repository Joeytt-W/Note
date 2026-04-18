## Ubuntu安装

1. 官网下载压缩包

2. 确保有gcc环境（gcc --version） 

   sudo apt-get install -y gcc

   sudo apt-get install -y g++

3. cd redis-7.xxx执行make(make MALLOC=libc)

4. sudo make install

5. cd src

6. ./redis-server 启动redis服务  

## docker使用redis

### 安装

1. docker pull redis
2. docker run -itd --name redis-wms -p 6379:6379 -d redis --requirepass “password”

### 启动cmd交互窗口

docker exec -t containerid /bin/bash

## redis数据类型

![images](images\001.png)



