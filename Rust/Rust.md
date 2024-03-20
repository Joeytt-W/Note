# Rust
- 官网 https://www.rust-lang.org/zh-CN/
## 安装
- 如果您是 ``Windows`` 的 ``Linux`` 子系统``（WSL）``用户，要安装 ``Rust``，请在终端中运行以下命令，然后遵循屏幕上的指示。
``` powershell
curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh
```
- 如果您曾经安装过 ``rustup``，可以执行 ``rustup update`` 来升级 Rust
- 在任何时候如果您想卸载 ``Rust``，您可以运行 ``rustup self uninstall``
- 安装验证
``` powershell
rustc --version
```
- 查看本地安装文档
``` powershell
rustup doc
```
## 编写Rust程序
- 程序文件名后缀：``rs``
- 文件命名规范：``hello_world.cs``
- 编译：``rustc main.rs``
- 运行：
```powershell
windows:.\main.exe
Linux/mac:./main
```
## Cargo
- ``Cargo``是``Rust``的构建系统和包管理工具
- 判断``Cargo``是否正确安装
```powershell
cargo --version
```
### 使用Cargo创建项目
``` powershell
cargo new hello_cargo
```

![](images/1.png)

#### 创建的项目结构

![](images/2.png)

- ``Cargo.toml``
```toml
[package]
name = "hello_cargo"
version = "0.1.0"
edition = "2021"

# See more keys and their definitions at https://doc.rust-lang.org/cargo/reference/manifest.html

[dependencies]
```
### cargo build
- 创建可执行文件
### cargo build --release
- 为发布构建，会进行优化，代码运行更快，但编译时间更长
### cargo run
- 编译产生并执行可执行文件
### cargo check
- 检查代码确保编译通过，不产生可执行文件，该指令比``cargo build``快，写程序过程中用这个指令检查提高效率

