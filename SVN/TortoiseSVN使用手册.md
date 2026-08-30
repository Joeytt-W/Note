# TortoiseSVN 使用手册

> TortoiseSVN 是 Windows 平台上最流行的 Subversion（SVN）版本控制客户端，以资源管理器右键菜单的形式集成，操作直观。本手册覆盖日常开发常用操作，并附命令行对照。

## 目录

1. [简介与安装](#一简介与安装)
2. [核心概念](#二核心概念)
3. [检出（Checkout）](#三检出checkout)
4. [日常操作：更新与提交](#四日常操作更新与提交)
5. [文件状态与图标](#五文件状态与图标)
6. [添加、删除、重命名](#六添加删除重命名)
7. [查看修改（Diff）](#七查看修改diff)
8. [查看历史（Log）](#八查看历史log)
9. [撤销修改（Revert）](#九撤销修改revert)
10. [解决冲突](#十解决冲突)
11. [分支与合并](#十一分支与合并)
12. [标签（Tag）](#十二标签tag)
13. [文件锁定（Lock）](#十三文件锁定lock)
14. [常用设置](#十四常用设置)
15. [命令行速查](#十五命令行速查)
16. [常见场景速查](#十六常见场景速查)

---

## 一、简介与安装

**TortoiseSVN 特点：**

- 与 Windows 资源管理器深度集成，通过 **右键菜单** 操作
- 文件/文件夹图标实时反映版本状态
- 支持 SSH、https 等多种协议访问版本库
- 内置差异对比、冲突解决、日志查看等工具

**安装：**

1. 从官网下载安装包：<https://tortoisesvn.net/downloads.html>
2. 双击安装，一路 Next 完成
3. 安装后 **重启资源管理器**（或注销/重启），右键菜单即可生效

> 注意：TortoiseSVN 与 Git（git-svn 等）不同，是集中式版本控制，需要连接中央版本库才能提交。

---

## 二、核心概念

| 概念 | 说明 |
|------|------|
| **版本库（Repository）** | 中央服务器上存储所有版本历史的地方 |
| **工作副本（Working Copy）** | 检出到本地的文件目录，你在此编辑 |
| **提交（Commit）** | 将本地修改上传到版本库 |
| **更新（Update）** | 从版本库拉取最新内容到工作副本 |
| **修订号（Revision）** | 版本库的全局递增版本号，每次提交 +1 |

**与 Git 的核心区别：**

| 维度 | SVN（TortoiseSVN） | Git |
|------|------|------|
| 架构 | 集中式（单一中央库） | 分布式（每个克隆都是完整库） |
| 版本号 | 全局递增的修订号（r123） | 提交哈希（commit hash） |
| 提交 | 直接提交到中央库 | 先本地 commit，再 push |
| 离线操作 | 受限（提交需联网） | 大部分可离线 |

---

## 三、检出（Checkout）

**场景：** 第一次从版本库获取代码。

**操作步骤：**

1. 在目标位置（如 `D:\projects`）右键空白处
2. 选择 **SVN Checkout…**
3. 填写版本库 URL（如 `https://svn.example.com/repo/trunk`）
4. 选择检出目录
5. 点击 **OK** 开始检出

**命令行对照：**

```bash
svn checkout <url> [本地目录]
svn checkout https://svn.example.com/repo/trunk D:\projects\myproject
```

---

## 四、日常操作：更新与提交

### 更新（Update）

获取他人最新提交，**建议每次开始工作前先更新**。

- 右键目标文件夹 → **SVN Update**
- 更新后查看结果窗口，关注冲突（红色标记）

```bash
svn update
```

### 提交（Commit）

将本地修改上传到版本库。

1. 右键目标文件夹 → **SVN Commit…**
2. 在提交窗口勾选要提交的文件
3. **填写提交说明（Message）** —— 必填，建议写清楚改了什么、为什么
4. 点击 **OK** 提交

```bash
svn commit -m "提交说明"
```

> 提示：提交前建议先 Update，避免因版本落后导致提交失败或冲突。

---

## 五、文件状态与图标

TortoiseSVN 通过 **文件图标叠加层** 直观显示状态：

| 图标 | 状态 | 含义 |
|------|------|------|
| ✅ 绿色对勾 | Normal | 与版本库一致，无修改 |
| ❗ 红色感叹号 | Modified | 本地已修改，未提交 |
| ➕ 蓝色加号 | Added | 新增文件，已计划加入 |
| ❌ 红色叉号 | Missing | 文件被删除或丢失 |
| 🔒 锁图标 | Locked | 文件被锁定 |
| ⚠️ 黄色感叹号 | Conflict | 存在冲突，需解决 |
| ❓ 问号 | Unversioned | 未被版本控制 |

> 若图标不显示，检查：右键 → TortoiseSVN → Settings → Icon Overlays，或检查是否被其他软件（如 Dropbox、OneDrive）的叠加层挤占。

---

## 六、添加、删除、重命名

### 添加新文件（Add）

1. 右键新文件/文件夹 → **TortoiseSVN → Add…**
2. 确认后文件图标变为蓝色加号（已标记添加）
3. 执行 **Commit** 才真正进入版本库

```bash
svn add <file>
```

### 删除文件（Delete）

1. 右键文件 → **TortoiseSVN → Delete**
2. 文件会从本地移除并标记删除
3. 执行 **Commit** 才在版本库中删除

```bash
svn delete <file>
```

### 重命名/移动（Rename）

**务必使用 SVN 的重命名，而非资源管理器直接改名**，否则会丢失历史：

1. 右键文件 → **TortoiseSVN → Rename**
2. 输入新名称
3. 执行 **Commit**

```bash
svn rename <old-name> <new-name>
```

---

## 七、查看修改（Diff）

对比本地修改与版本库的差异。

- 右键文件 → **TortoiseSVN → Diff**
- 默认用 TortoiseMerge 打开对比窗口
- 也可对比两个修订号：右键 → **TortoiseSVN → Diff with Previous Version**

```bash
svn diff              # 工作副本与最新版本对比
svn diff -r 100:101   # 两个修订号之间对比
```

---

## 八、查看历史（Log）

查看文件/目录的提交历史。

1. 右键文件/文件夹 → **TortoiseSVN → Show Log**
2. 窗口上方列出所有提交记录（作者、时间、说明）
3. 下方显示每次提交改动的文件
4. 可右键某条记录查看该版本的 Diff、恢复到该版本等

```bash
svn log              # 查看当前目录日志
svn log -v           # 显示改动的文件列表
svn log -l 10        # 最近 10 条
```

---

## 九、撤销修改（Revert）

丢弃本地修改，恢复到版本库最新版本。

1. 右键文件/文件夹 → **TortoiseSVN → Revert…**
2. 勾选要撤销的文件
3. 点击 **OK**

```bash
svn revert <file>
svn revert -R .      # 递归撤销当前目录所有修改
```

> ⚠️ Revert 会 **永久丢弃本地修改**，且 SVN 无「撤销的撤销」，操作前请确认。

---

## 十、解决冲突

**冲突产生原因：** 你和他人同时修改了同一文件的同一区域，更新或提交时触发。

### 解决流程

1. 更新时发现冲突，文件状态变为黄色感叹号
2. 右键冲突文件 → **TortoiseSVN → Edit Conflicts**
3. TortoiseMerge 打开三方合并视图：
   - **Theirs**：版本库中的版本
   - **Mine**：你的版本
   - **Merged**：合并结果
4. 手动选择保留哪一方，或编辑合并结果
5. 保存后，右键文件 → **TortoiseSVN → Resolved**
6. 确认无误后 **Commit**

```bash
svn resolve --accept working <file>   # 标记已解决（采用当前工作副本）
svn resolve --accept theirs-full <file>  # 采用版本库版本
svn resolve --accept mine-full <file>    # 采用本地版本
```

---

## 十一、分支与合并

### 创建分支（Branch）

1. 在版本库中右键目标目录（通常是 trunk）→ **TortoiseSVN → Branch/Tag…**
2. 填写分支目标路径（如 `/branches/feature-xxx`）
3. 填写日志说明，点击 OK

```bash
svn copy https://svn.example.com/repo/trunk \
         https://svn.example.com/repo/branches/feature-xxx \
         -m "创建 feature-xxx 分支"
```

### 合并（Merge）

将分支改动合并回主干：

1. 在主干工作副本上右键 → **TortoiseSVN → Merge…**
2. 选择合并类型（如「Merge a range of revisions」）
3. 指定源分支 URL 和修订号范围
4. 预览、合并，解决冲突后 **Commit**

```bash
# 将分支的修改合并到当前工作副本
svn merge https://svn.example.com/repo/branches/feature-xxx
```

---

## 十二、标签（Tag）

标签是某一版本的快照，用于标记发布版本，通常存放在 `/tags` 目录。

1. 右键 trunk 或某修订 → **TortoiseSVN → Branch/Tag…**
2. 目标路径填写 `/tags/v1.0.0`
3. 填写说明后创建

```bash
svn copy https://svn.example.com/repo/trunk \
         https://svn.example.com/repo/tags/v1.0.0 \
         -m "发布 v1.0.0"
```

> 约定俗成：`trunk`（主干）、`branches`（分支）、`tags`（标签）是 SVN 的标准目录结构。

---

## 十三、文件锁定（Lock）

对二进制文件（如图片、文档）等不适合合并的文件，可加锁防止他人同时修改。

- 右键文件 → **TortoiseSVN → Get Lock…**
- 填写锁定说明，点击 OK

- 解除锁定：右键 → **TortoiseSVN → Release Lock**

```bash
svn lock <file> -m "锁定说明"
svn unlock <file>
```

> 需版本库启用锁定功能（`needs-lock` 属性），否则锁定为「建议性」而非强制。

---

## 十四、常用设置

右键任意目录 → **TortoiseSVN → Settings**，常用配置：

| 设置项 | 路径 | 说明 |
|------|------|------|
| 语言 | General → Language | 切换界面语言（需下载语言包） |
| 图标叠加 | Icon Overlays | 调整状态图标显示 |
| 忽略文件 | 右键文件 → Ignore | 忽略不需要版本控制的文件 |
| 差异工具 | Diff Viewer | 自定义对比工具（如 Beyond Compare） |
| 全局忽略 | Settings → General → Global ignore pattern | 忽略 `*.tmp`、`*.log` 等 |

### 忽略文件（Ignore）

1. 右键文件/文件夹 → **TortoiseSVN → Add to Ignore List**
2. 选择忽略该文件或同类型（`*.ext`）

```bash
svn propedit svn:ignore .   # 编辑忽略属性
```

---

## 十五、命令行速查

TortoiseSVN 附带 `svn.exe` 命令行工具，适合脚本化操作：

| 命令 | 作用 |
|------|------|
| `svn checkout <url>` | 检出工作副本 |
| `svn update` | 更新到最新版本 |
| `svn commit -m "msg"` | 提交修改 |
| `svn add <file>` | 添加文件 |
| `svn delete <file>` | 删除文件 |
| `svn status` | 查看状态 |
| `svn diff` | 查看差异 |
| `svn log` | 查看日志 |
| `svn revert <file>` | 撤销修改 |
| `svn info` | 查看工作副本信息 |
| `svn copy <src> <dst> -m "msg"` | 创建分支/标签 |
| `svn merge <url>` | 合并分支 |
| `svn lock/unlock <file>` | 锁定/解锁 |

---

## 十六、常见场景速查

| 场景 | 操作 |
|------|------|
| 第一次获取代码 | 右键 → SVN Checkout |
| 开始一天工作 | 右键 → SVN Update |
| 提交修改 | 右键 → SVN Commit（务必写说明） |
| 撤销单个文件修改 | 右键 → TortoiseSVN → Revert |
| 查看文件改动历史 | 右键 → TortoiseSVN → Show Log |
| 对比本次修改 | 右键 → TortoiseSVN → Diff |
| 新增文件忘记 Add | 提交窗口会自动列出未版本化文件，勾选即可 |
| 提交时提示版本过期 | 先 Update，解决冲突后再 Commit |
| 冲突解决 | 右键 → Edit Conflicts → Resolved → Commit |
| 发布版本 | 创建 Tag（Branch/Tag） |

---

## 附：核心工作流

```
                 ┌──────────────┐
    Checkout ──▶ │   工作副本    │ ◀── Update（获取他人修改）
                 │ (本地文件目录) │
                 └──────┬───────┘
                        │ Commit（上传修改）
                        ▼
                 ┌──────────────┐
                 │   中央版本库   │
                 │ (Repository)  │
                 └──────────────┘
```

**标准开发循环：** Update → 修改 → （Add/Delete/Rename）→ Commit

---

> 提示：`Revert` 会永久丢弃本地修改，`Commit` 一旦成功会进入版本库历史。遇到不确定的操作（如合并、回退历史版本），建议先在测试目录验证，或咨询版本库管理员。
