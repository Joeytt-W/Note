# Codex

## 安装

[Codex | AI 编程智能体](https://chatgpt.com/zh-Hans-CN/codex/?openaicom_referred=true)

### apiKey

[API keys - OpenAI API](https://platform.openai.com/api-keys)

我的：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

![image-20260505230946302](images/CodeX/image-20260505230946302.png)

管理员秘钥：

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

## Skills

### Superpowers

[obra/superpowers: An agentic skills framework & software development methodology that works.](https://github.com/obra/superpowers)

Installation differs by harness. If you use more than one, install Superpowers separately for each one.

#### Claude Code

Superpowers is available via the [official Claude plugin marketplace](https://claude.com/plugins/superpowers)

##### Official Marketplace

- Install the plugin from Anthropic's official marketplace:

  ```
  /plugin install superpowers@claude-plugins-official
  ```

##### Superpowers Marketplace

The Superpowers marketplace provides Superpowers and some other related plugins for Claude Code.

- Register the marketplace:

  ```
  /plugin marketplace add obra/superpowers-marketplace
  ```

  

- Install the plugin from this marketplace:

  ```
  /plugin install superpowers@superpowers-marketplace
  ```

#### Codex CLI

Superpowers is available via the [official Codex plugin marketplace](https://github.com/openai/plugins).

- Open the plugin search interface:

  ```
  /plugins
  ```

- Search for Superpowers:

  ```
  superpowers
  ```

- Select `Install Plugin`.

  ![image-20260608170046183](images/CodeX/image-20260608170046183.png)

#### Codex App

Superpowers is available via the [official Codex plugin marketplace](https://github.com/openai/plugins).

- In the Codex app, click on Plugins in the sidebar.
- You should see `Superpowers` in the Coding section.
- Click the `+` next to Superpowers and follow the prompts.

#### Factory Droid

- Register the marketplace:

  ```
  droid plugin marketplace add https://github.com/obra/superpowers
  ```

- Install the plugin:

  ```
  droid plugin install superpowers@superpowers
  ```

#### Gemini CLI

- Install the extension:

  ```
  gemini extensions install https://github.com/obra/superpowers
  ```

- Update later:

  ```
  gemini extensions update superpowers
  ```

#### OpenCode

OpenCode uses its own plugin install; install Superpowers separately even if you already use it in another harness.

- Tell OpenCode:

  ```
  Fetch and follow instructions from https://raw.githubusercontent.com/obra/superpowers/refs/heads/main/.opencode/INSTALL.md
  ```

- Detailed docs: [docs/README.opencode.md](https://github.com/obra/superpowers/blob/main/docs/README.opencode.md)

#### Cursor

- In Cursor Agent chat, install from marketplace:

  ```text
  /add-plugin superpowers
  ```

- Or search for "superpowers" in the plugin marketplace.

#### GitHub Copilot CLI

- Register the marketplace:

  ```
  copilot plugin marketplace add obra/superpowers-marketplace
  ```

- Install the plugin:

  ```
  copilot plugin install superpowers@superpowers-marketplace
  ```



​	