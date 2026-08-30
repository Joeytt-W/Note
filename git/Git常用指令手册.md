# Git 常用指令手册

> 面向日常开发的 Git 速查手册，按使用场景分类，附常用命令与说明。

## 目录

1. [基础配置](#一基础配置)
2. [仓库初始化与克隆](#二仓库初始化与克隆)
3. [日常提交流程](#三日常提交流程)
4. [分支管理](#四分支管理)
5. [查看与对比](#五查看与对比)
6. [撤销与回退](#六撤销与回退)
7. [远程仓库](#七远程仓库)
8. [标签管理](#八标签管理)
9. [暂存与恢复（stash）](#九暂存与恢复stash)
10. [合并与变基](#十合并与变基)
11. [日志与历史](#十一日志与历史)
12. [常见场景速查](#十二常见场景速查)

---

## 一、基础配置

```bash
# 查看当前配置
git config --list

# 设置用户信息（全局）
git config --global user.name "你的名字"
git config --global user.email "you@example.com"

# 设置用户信息（仅当前仓库）
git config user.name "你的名字"
git config user.email "you@example.com"

# 设置默认编辑器
git config --global core.editor "code --wait"

# 设置换行符处理（Windows 常用）
git config --global core.autocrlf true

# 为命令设置别名
git config --global alias.st status
git config --global alias.co checkout
git config --global alias.br branch
```

---

## 二、仓库初始化与克隆

```bash
# 在当前目录初始化仓库
git init

# 克隆远程仓库
git clone <url>

# 克隆指定分支
git clone -b <branch-name> <url>

# 浅克隆（仅最近一次提交，节省空间）
git clone --depth 1 <url>
```

---

## 三、日常提交流程

```bash
# 查看工作区状态
git status
git status -s          # 精简输出

# 添加文件到暂存区
git add <file>         # 添加指定文件
git add .              # 添加当前目录所有变更
git add -A             # 添加所有变更（含删除）
git add -p             # 交互式分块添加

# 提交
git commit -m "提交说明"
git commit -am "提交说明"   # 跳过 add，直接提交已跟踪文件的修改

# 修改最近一次提交（未推送前）
git commit --amend -m "新的提交说明"
git commit --amend --no-edit   # 追加内容但不改说明
```

---

## 四、分支管理

```bash
# 查看分支
git branch                 # 本地分支
git branch -a              # 所有分支（含远程）
git branch -v              # 显示各分支最新提交

# 创建分支
git branch <branch-name>              # 仅创建
git checkout -b <branch-name>         # 创建并切换
git switch -c <branch-name>           # 新语法：创建并切换

# 切换分支
git checkout <branch-name>
git switch <branch-name>              # 新语法

# 删除分支
git branch -d <branch-name>           # 安全删除（已合并）
git branch -D <branch-name>           # 强制删除（未合并）

# 重命名分支
git branch -m <old-name> <new-name>

# 合并分支
git merge <branch-name>               # 将指定分支合并到当前分支
```

---

## 五、查看与对比

```bash
# 查看工作区与暂存区的差异
git diff

# 查看暂存区与最近一次提交的差异
git diff --cached
git diff --staged

# 查看指定文件的差异
git diff <file>

# 对比两个分支
git diff <branch-a> <branch-b>

# 查看某次提交的变更内容
git show <commit-id>
git show <commit-id> --stat
```

---

## 六、撤销与回退

```bash
# 撤销工作区修改（恢复到暂存区/仓库版本）
git checkout -- <file>
git restore <file>                    # 新语法

# 撤销暂存区（取消 add，保留工作区修改）
git reset HEAD <file>
git restore --staged <file>           # 新语法

# 回退提交（保留修改到工作区）
git reset --soft HEAD~1               # 保留暂存区
git reset --mixed HEAD~1              # 默认，保留工作区
git reset --hard HEAD~1               # 完全回退，丢弃修改（危险）

# 回退到指定提交
git reset --hard <commit-id>          # 危险操作，慎用

# 反向提交（生成新提交来撤销，适合已推送的提交）
git revert <commit-id>
```

---

## 七、远程仓库

```bash
# 查看远程仓库
git remote -v

# 添加远程仓库
git remote add origin <url>

# 修改远程仓库地址
git remote set-url origin <new-url>

# 删除远程仓库
git remote remove origin

# 拉取远程更新（不合并）
git fetch origin

# 拉取并合并到当前分支
git pull
git pull origin <branch-name>

# 拉取并变基（保持提交历史线性）
git pull --rebase

# 推送
git push
git push origin <branch-name>

# 首次推送并建立跟踪关系
git push -u origin <branch-name>

# 强制推送（危险）
git push --force
git push --force-with-lease   # 更安全的强推
```

---

## 八、标签管理

```bash
# 查看标签
git tag
git tag -l "v1.*"            # 模糊匹配

# 创建标签
git tag v1.0.0                              # 轻量标签
git tag -a v1.0.0 -m "版本说明"              # 附注标签

# 为历史提交打标签
git tag -a v1.0.0 <commit-id> -m "说明"

# 推送标签
git push origin v1.0.0        # 单个标签
git push origin --tags        # 所有标签

# 删除标签
git tag -d v1.0.0                     # 本地
git push origin :refs/tags/v1.0.0     # 远程
```

---

## 九、暂存与恢复（stash）

```bash
# 暂存当前修改（不提交）
git stash
git stash save "说明"

# 查看暂存列表
git stash list

# 恢复暂存（保留 stash 记录）
git stash apply
git stash apply stash@{0}

# 恢复暂存并删除记录
git stash pop

# 查看某次 stash 内容
git stash show -p stash@{0}

# 删除 stash
git stash drop stash@{0}
git stash clear              # 清空所有 stash
```

---

## 十、合并与变基

```bash
# 合并（保留分支历史）
git merge <branch-name>
git merge --no-ff <branch-name>   # 禁用快进，保留合并节点

# 变基（线性化历史）
git rebase <branch-name>

# 变基到远程主分支最新
git rebase origin/main

# 交互式变基（合并提交、改说明等）
git rebase -i HEAD~3

# 变基冲突时中止
git rebase --abort

# 解决冲突后继续
git rebase --continue
```

---

## 十一、日志与历史

```bash
# 查看提交历史
git log

# 单行精简显示
git log --oneline

# 图形化显示分支
git log --graph --oneline --all

# 显示最近 N 条
git log -5

# 查看某个文件的提交历史
git log -- <file>
git log -p <file>            # 显示每次变更内容

# 按作者/关键字筛选
git log --author="名字"
git log --grep="关键字"

# 查看谁改动了某行代码
git blame <file>
```

---

## 十二、常见场景速查

| 场景 | 命令 |
|------|------|
| 撤销未提交的修改 | `git checkout -- <file>` |
| 撤销 git add | `git reset HEAD <file>` |
| 回退最近一次提交（保留修改） | `git reset --soft HEAD~1` |
| 回退已推送的提交 | `git revert <commit-id>` |
| 临时切分支处理紧急任务 | `git stash` → 处理 → `git stash pop` |
| 拉取远程新分支 | `git fetch origin` → `git checkout -b <branch> origin/<branch>` |
| 本地分支推送到远程 | `git push -u origin <branch>` |
| 清理已合并的本地分支 | `git branch --merged \| grep -v main \| xargs git branch -d` |
| 找回误删的提交 | `git reflog` → `git reset --hard <commit-id>` |
| 合并多个提交 | `git rebase -i HEAD~N` |

---

## 附：核心概念速记

| 概念 | 说明 |
|------|------|
| **工作区** | 本地文件目录，你正在编辑的内容 |
| **暂存区（Index）** | `git add` 后的区域，准备提交的内容 |
| **本地仓库** | `git commit` 后的历史记录 |
| **远程仓库** | GitHub/GitLab/CNB 等远端托管 |

**数据流转方向：**

```
工作区 ──git add──▶ 暂存区 ──git commit──▶ 本地仓库 ──git push──▶ 远程仓库
  ▲                                                                      │
  └─────────────────────── git checkout / pull ◀──────────────────────────┘
```

---

> 提示：`git reset --hard`、`git push --force` 等命令具有破坏性，执行前请务必确认。建议在操作前通过 `git log`、`git reflog` 了解当前状态。
