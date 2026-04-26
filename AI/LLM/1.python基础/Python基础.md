# 第一部分：基础入门

## 1. Python 知识体系思维导图

```
┌─────────────────────────────────────────────────────────────────┐
│                        Python 知识体系                           │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐     │
│  │  基础语法    │  │  数据结构   │  │  函数式编程        │     │
│  ├─────────────┤  ├─────────────┤  ├─────────────────────┤     │
│  │ • 变量类型  │  │ • 列表 list │  │ • lambda           │     │
│  │ • 运算符    │  │ • 元组 tuple│  │ • 高阶函数          │     │
│  │ • 流程控制  │  │ • 字典 dict │  │ • 闭包              │     │
│  │ • 字符串    │  │ • 集合 set  │  │ • 装饰器            │     │
│  │ • 输入输出  │  │ • 推导式    │  │ • 生成器            │     │
│  └─────────────┘  └─────────────┘  └─────────────────────┘     │
│                                                                 │
│  ┌─────────────────────┐  ┌─────────────────────┐               │
│  │   面向对象编程 OOP   │  │    进阶特性         │               │
│  ├─────────────────────┤  ├─────────────────────┤               │
│  │ • 类与对象          │  │ • 迭代器/生成器     │               │
│  │ • 继承/多态/封装    │  │ • 装饰器            │               │
│  │ • 魔术方法          │  │ • 上下文管理器      │               │
│  │ • 数据类 dataclass │  │ • 元类 metaclass   │               │
│  │ • 抽象基类 ABC     │  │ • 描述符            │               │
│  └─────────────────────┘  └─────────────────────┘               │
│                                                                 │
│  ┌─────────────────────┐  ┌─────────────────────┐               │
│  │   并发与异步        │  │    工具与生态       │               │
│  ├─────────────────────┤  ├─────────────────────┤               │
│  │ • threading        │  │ • NumPy/Pandas      │               │
│  │ • multiprocessing  │  │ • Matplotlib        │               │
│  │ • asyncio          │  │ • Requests           │               │
│  │ • concurrent.future│  │ • Flask/FastAPI     │               │
│  └─────────────────────┘  └─────────────────────┘               │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

**详细知识点地图：**

```
Python 全体系
│
├── 基础
│   ├── 变量/常量/命名规范
│   ├── 内置类型（int/float/str/bool/None）
│   ├── 运算符（算术/比较/逻辑/位/赋值）
│   ├── 类型转换
│   ├── 输入输出 input/print/格式化
│   ├── 流程控制 if/for/while/match-case
│   └── 推导式 [x for x in ...]
│
├── 数据结构
│   ├── 序列类型
│   │   ├── list - 可变有序列表
│   │   ├── tuple - 不可变有序
│   │   └── range - 整数序列
│   ├── 映射类型
│   │   └── dict - 键值对字典
│   ├── 集合类型
│   │   ├── set - 无序不重复集合
│   │   └── frozenset - 不可变集合
│   └── 字符串操作（切片/方法/格式化）
│
├── 函数
│   ├── def 定义/默认参数/*args/**kwargs
│   ├── lambda 匿名函数
│   ├── 闭包/ nonlocal
│   ├── 高阶函数 map/filter/reduce
│   ├── 装饰器 @decorator
│   ├── 生成器 yield
│   ├── 递归/尾递归
│   └── 类型注解 Type Hints
│
├── OOP
│   ├── class 定义类
│   ├── __init__/__str__/__repr__
│   ├── 实例方法/类方法/@classmethod
│   ├── 静态方法/@staticmethod
│   ├── 属性/@property
│   ├── 继承/多继承/MRO
│   ├── 抽象类/@abstractmethod
│   ├── 数据类/@dataclass
│   └── 魔术方法全解
│
├── 异常
│   ├── try/except/finally
│   ├── raise 抛出异常
│   ├── 自定义异常类
│   ├── 异常链 from
│   └── 常见异常类型
│
├── 文件/IO
│   ├── open/close/read/write
│   ├── with 上下文管理器
│   ├── json.load/dump
│   ├── csv.reader/writer
│   ├── pathlib.Path
│   └── os 模块常用
│
├── 进阶
│   ├── 迭代器协议 __iter__/__next__
│   ├── 生成器 yield/send
│   ├── 装饰器（函数/类）
│   ├── 上下文管理器 @contextmanager
│   ├── 元类 type() 创建类
│   ├── 描述符 __get__/__set__
│   ├── 协程 async/await
│   ├── 插槽 __slots__
│   └── 内存管理/GC
│
├── 并发
│   ├── threading（线程）
│   ├── multiprocessing（进程）
│   ├── asyncio（异步IO）
│   ├── concurrent.futures
│   └── 锁/信号量/队列
│
├── 网络
│   ├── socket 编程
│   ├── http.client
│   ├── requests
│   └── http.server
│
├── 数据库
│   ├── sqlite3
│   ├── SQLAlchemy
│   ├── PyMySQL
│   └── Redis
│
├── Web
│   ├── Flask
│   ├── FastAPI
│   ├── Django
│   └── aiohttp
│
├── 数据科学
│   ├── NumPy - 数值计算
│   ├── Pandas - 数据分析
│   ├── Matplotlib - 可视化
│   ├── Scikit-learn - 机器学习
│   └── PyTorch/TensorFlow - 深度学习
│
└── 测试/工程
    ├── pytest/unittest
    ├── logging
    ├── argparse
    ├── pathlib
    ├── dataclasses
    ├── typing
    └── typing_extensions
```

---

## 2. 环境搭建

```python
# ==========================================
# Python 安装与版本
# ==========================================

# 查看版本（命令行执行）
# python --version  # Python 3.11.x
# python3 --version # Linux/macOS

# 运行 Python 代码（命令行）
# python -c "print('Hello')"
# python script.py

# 交互式模式
# python -i script.py  # 运行脚本后进入交互

# ==========================================
# pip 包管理
# ==========================================

# pip install package          # 安装
# pip install package==1.2.3   # 指定版本
# pip install package>=1.0,<2.0  # 版本范围
# pip install -U package       # 升级
# pip uninstall package         # 卸载
# pip list                     # 列出已安装
# pip freeze > requirements.txt # 导出依赖
# pip install -r requirements.txt  # 从文件安装
# pip show package             # 查看包信息
# pip search package           # 搜索包（已禁用）

# pip 镜像源（国内加速）
# pip install package -i https://pypi.tuna.tsinghua.edu.cn/simple
# pip config set global.index-url https://pypi.tuna.tsinghua.edu.cn/simple

# ==========================================
# 虚拟环境
# ==========================================

# --- venv（内置）---
# python -m venv myenv              # 创建
# source myenv/bin/activate         # 激活（Linux/macOS）
# myenv\Scripts\activate            # 激活（Windows）
# pip install ...                    # 安装包
# deactivate                         # 退出

# --- conda ---
# conda create -n myenv python=3.11  # 创建
# conda activate myenv              # 激活
# conda deactivate                   # 退出
# conda env list                    # 列出环境

# ==========================================
# IDE 推荐
# ==========================================
# • VS Code + Python 扩展
# • PyCharm（社区版/专业版）
# • Jupyter Notebook / JupyterLab
# • Cursor / Claude Code（AI辅助）
```

---

## 3. 变量与数据类型

```python
# ==========================================
# 变量赋值
# ==========================================

# 基本赋值
name = "Alice"
age = 25
height = 1.75
is_student = True
nothing = None

# 多变量同时赋值
x = y = z = 0

# 解包赋值（元组拆包）
a, b, c = 1, 2, 3
print(a, b, c)  # 1 2 3

# 解包交换
a, b = b, a
print(a, b)  # 2 1

# 扩展解包（星号表达式）
first, *middle, last = [1, 2, 3, 4, 5]
print(f"first={first}, middle={middle}, last={last}")
# first=1, middle=[2, 3, 4], last=5

# 下划线占位
a, _, c = (1, 2, 3)  # 忽略第二个值

# ==========================================
# 内置数据类型
# ==========================================

# 整数 int
num = 255
num_bin = 0b11111111  # 二进制
num_oct = 0o377       # 八进制
num_hex = 0xFF        # 十六进制
big_num = 1_000_000   # 下划线分隔（可读性）
print(f"十进制={num}, 二进制={bin(num)}, 十六进制={hex(num)}")
# 十进制=255, 二进制=0b11111111, 十六进制=0xff

# Python 整数无限精度
huge = 10 ** 100
print(f"超大整数位数: {len(str(huge))}")  # 101

# 浮点数 float
pi = 3.14159
sci = 1.5e10   # 科学计数法
neg_sci = 2.5e-3  # 负指数

# 浮点精度问题
print(0.1 + 0.2)          # 0.30000000000000004
print(round(0.1 + 0.2, 1))  # 0.3

# 精确计算用 decimal
from decimal import Decimal
result = Decimal('0.1') + Decimal('0.2')
print(f"精确计算: {result}")  # 0.3

# 布尔 bool
t, f = True, False
print(f"True -> int: {int(True)}, False -> int: {int(False)}")

# False 的值：0, 0.0, '', [], {}, None, set()
falsy_values = [False, 0, 0.0, '', [], {}, None]
for v in falsy_values:
    print(f"{str(v):15} -> {bool(v)}")

# 字符串 str
s1 = '单引号'
s2 = "双引号"
s3 = '''多行
字符串'''
raw = r"C:\Users\name"  # 原始字符串，不转义

# ==========================================
# 类型转换
# ==========================================
print(f"int('42')={int('42')}")
print(f"int(3.9)={int(3.9)}")       # 截断，不四舍五入
print(f"float('3.14')={float('3.14')}")
print(f"str(100)={str(100)}")
print(f"bool(1)={bool(1)}, bool(0)={bool(0)}")
print(f"list('abc')={list('abc')}")

# ==========================================
# 类型检查
# ==========================================
x = 42
print(f"type(x)={type(x)}")                          # <class 'int'>
print(f"isinstance(x, int)={isinstance(x, int)}")    # True
print(f"isinstance(x, (int, float))={isinstance(x, (int, float))}")  # True
```

---

## 4. 运算符

```python
# ==========================================
# 算术运算符
# ==========================================
a, b = 10, 3
print(f"{a}+{b}={a+b}")   # 13
print(f"{a}-{b}={a-b}")   # 7
print(f"{a}*{b}={a*b}")    # 30
print(f"{a}/{b}={a/b}")    # 3.333...（浮点除）
print(f"{a}//{b}={a//b}") # 3（整除，向下取整）
print(f"{a}%{b}={a%b}")    # 1（取余）
print(f"{a}**{b}={a**b}")  # 1000（幂）

# 整除特性
print(f"7//2={7//2}, -7//2={-7//2}")  # 3, -4（向下取整）

# ==========================================
# 比较运算符
# ==========================================
x, y = 5, 10
print(f"{x}=={y}={x==y}")   # False
print(f"{x}!={y}={x!=y}")   # True
print(f"{x}<{y}={x<y}")     # True
print(f"{x}>{y}={x>y}")     # False
print(f"{x}<={y}={x<=y}")   # True

# 链式比较（Python 独有）
age = 18
print(f"0 < age < 100 = {0 < age < 100}")  # True

# is vs ==
a = [1, 2, 3]
b = [1, 2, 3]
c = a
print(f"a==b={a==b}, a is b={a is b}")  # True, False
print(f"a is c={a is c}")              # True

# ==========================================
# 逻辑运算符
# ==========================================
print(f"True and False = {True and False}")  # False
print(f"True or False = {True or False}")    # True
print(f"not True = {not True}")             # False

# 短路求值
def check():
    print("check called")
    return True

result = False and check()  # check 不被调用
print(f"False and check() = {result}")

# and/or 返回实际值（非 bool）
print(f"1 and 2 = {1 and 2}")    # 2
print(f"0 and 2 = {0 and 2}")    # 0
print(f"1 or 2 = {1 or 2}")      # 1
print(f"0 or 2 = {0 or 2}")      # 2

# 常见用法：默认值
name = "" or "默认名称"
print(f"name = '{name}'")  # '默认名称'

# ==========================================
# 位运算符
# ==========================================
a, b = 0b1010, 0b1100  # 10, 12
print(f"a & b = {bin(a & b)}")  # 0b1000 = 8
print(f"a | b = {bin(a | b)}")  # 0b1110 = 14
print(f"a ^ b = {bin(a ^ b)}")  # 0b0110 = 6
print(f"~a = {bin(~a)}")         # -0b1011
print(f"a << 1 = {bin(a << 1)}") # 0b10100 = 20
print(f"a >> 1 = {bin(a >> 1)}") # 0b101 = 5

# ==========================================
# 海象运算符 := (Python 3.8+)
# ==========================================
numbers = [1, 2, 3, 4, 5]
if (n := len(numbers)) > 3:
    print(f"列表有 {n} 个元素")

# while 中使用
data = [1, 3, 5]
while (val := data.pop()) > 2:
    print(val, end=" ")  # 5 3
print()
```

---

## 5. 流程控制

```python
# ==========================================
# if / elif / else
# ==========================================
score = 85
if score >= 90:
    grade = "A"
elif score >= 80:
    grade = "B"
elif score >= 70:
    grade = "C"
elif score >= 60:
    grade = "D"
else:
    grade = "F"
print(f"成绩={score}, 等级={grade}")  # 成绩=85, 等级=B

# 三元表达式
age = 20
status = "成年" if age >= 18 else "未成年"
print(f"status = {status}")  # 成年

# ==========================================
# match-case (Python 3.10+)
# ==========================================
def http_status(code):
    match code:
        case 200: return "OK"
        case 404: return "Not Found"
        case 500: return "Server Error"
        case 400 | 401 | 403: return "Client Error"  # 多值匹配
        case _: return "Unknown"

print(f"200={http_status(200)}, 404={http_status(404)}")

# match 解构
def describe_point(p):
    match p:
        case (0, 0): return "原点"
        case (x, 0): return f"X轴, x={x}"
        case (0, y): return f"Y轴, y={y}"
        case (x, y): return f"({x}, {y})"

print(describe_point((0, 0)))   # 原点
print(describe_point((3, 0)))   # X轴, x=3
print(describe_point((2, 5)))   # (2, 5)

# ==========================================
# for 循环
# ==========================================
fruits = ["苹果", "香蕉", "橙子"]
for fruit in fruits:
    print(fruit, end=" ")  # 苹果 香蕉 橙子
print()

# range()
for i in range(5): print(i, end=" ")  # 0 1 2 3 4
print()
for i in range(1, 10, 2): print(i, end=" ")  # 1 3 5 7 9
print()

# enumerate
for i, fruit in enumerate(fruits, start=1):
    print(f"{i}. {fruit}")

# zip 遍历多个序列
names = ["Alice", "Bob", "Charlie"]
scores = [95, 87, 92]
for name, score in zip(names, scores):
    print(f"{name}: {score}")

# for-else
for i in range(3):
    if i == 5: break
else:
    print("循环正常结束")

# ==========================================
# while 循环
# ==========================================
count = 0
while count < 5:
    print(count, end=" ")
    count += 1
print()  # 0 1 2 3 4

# while-else
n = 10
while n > 0:
    n -= 3
else:
    print(f"循环结束，n={n}")

# ==========================================
# 循环控制
# ==========================================
for i in range(10):
    if i == 3: break     # 跳出循环
    if i % 2 == 0: continue  # 跳过偶数
    print(i, end=" ")  # 1 5 7 9
print()

# ==========================================
# 推导式
# ==========================================
# 列表推导式
squares = [x**2 for x in range(1, 11)]
print(f"平方: {squares}")

# 带条件
evens = [x for x in range(20) if x % 2 == 0]
print(f"偶数: {evens}")

# 嵌套
flat = [x for row in [[1,2],[3,4],[5,6]] for x in row]
print(f"扁平化: {flat}")

# 字典推导式
word_len = {w: len(w) for w in ["python", "java", "go"]}
print(f"词长: {word_len}")

# 集合推导式
unique_lens = {len(w) for w in ["python", "java", "go"]}
print(f"不同长度: {unique_lens}")

# 生成器表达式
gen = (x**2 for x in range(3))
print(f"生成器: {next(gen)}, {next(gen)}, {next(gen)}")
```

---

## 6. 字符串详解

```python
# ==========================================
# 字符串创建与基本操作
# ==========================================
s = "Hello, World!"
print(f"长度: {len(s)}")
print(f"索引 s[0]={s[0]}, s[-1]={s[-1]}")
print(f"切片 s[0:5]={s[0:5]}, s[::-1]={s[::-1]}")  # Hello, !dlroW ,olleH

# 字符串不可变
# s[0] = 'h'  # TypeError!

# ==========================================
# 字符串方法
# ==========================================
text = "  Hello, Python World!  "

# 大小写
print(f"upper={text.strip().upper()}")      # HELLO, PYTHON WORLD!
print(f"lower={text.strip().lower()}")      # hello, python world!
print(f"title={text.strip().title()}")      #  Hello, Python World!
print(f"swapcase={text.strip().swapcase()}")  #  hELLO, pYTHON wORLD!

# 去除空白
print(f"strip='{text.strip()}'")
print(f"lstrip='{text.lstrip()}'")
print(f"rstrip='{text.rstrip()}'")

# 查找
s = "Hello, World! Hello!"
print(f"find('Hello')={s.find('Hello')}")     # 0
print(f"rfind('Hello')={s.rfind('Hello')}")    # 14
print(f"count('Hello')={s.count('Hello')}")    # 2

# 判断
print(f"isdigit='123'.isdigit()={'123'.isdigit()}")       # True
print(f"isalpha='abc'.isalpha()={'abc'.isalpha()}")       # True
print(f"isalnum='abc123'.isalnum()={'abc123'.isalnum()}") # True
print(f"isspace='   '.isspace()={'   '.isspace()}")       # True
print(f"isupper='ABC'.isupper()={'ABC'.isupper()}")       # True
print(f"islower='abc'.islower()={'abc'.islower()}")       # True
print(f"startswith('He')={'Hello'.startswith('He')}")     # True
print(f"endswith('lo')={'Hello'.endswith('lo')}")         # True

# 替换
s = "Hello World"
print(f"replace: {s.replace('World', 'Python')}")  # Hello Python
print(f"replace(1次): {s.replace('l', 'L', 1)}")  # HeLlo World

# 分割
s = "a,b,c,d"
print(f"split: {s.split(',')}")              # ['a', 'b', 'c', 'd']
print(f"split(2次): {s.split(',', 2)}")     # ['a', 'b', 'c,d']
print(f"join: {'-'.join(['a','b','c'])}")   # a-b-c

# ==========================================
# 字符串格式化
# ==========================================
name, age, score = "Alice", 25, 98.567

# % 格式化（旧式）
print("方式1: 姓名=%s, 年龄=%d, 分数=%.2f" % (name, age, score))

# format() 方法
print("方式2: 姓名={}, 年龄={}, 分数={:.2f}".format(name, age, score))
print("方式2b: {0} + {1} = {2}".format(1, 2, 3))
print("方式2c: {name}年龄{age}".format(name=name, age=age))

# f-string（推荐，Python 3.6+）
print(f"方式3: 姓名={name}, 年龄={age}, 分数={score:.2f}")
print(f"计算: 2+3*4={2+3*4}")
print(f"方法: {name.upper()}")
print(f"居中: {'='.join(['居中']*3):*^20}")
print(f"千分位: {1000000:,}")
print(f"百分比: {0.25:.1%}")
print(f"16进制: {255:#04x}")
print(f"调试: {x:=5} and {y:=3}")  # Python 3.8+

# ==========================================
# 实用范例
# ==========================================

# 统计词频
sentence = "the quick brown fox jumps over the lazy dog the fox"
words = sentence.split()
freq = {}
for w in words:
    freq[w] = freq.get(w, 0) + 1
print(f"词频: {sorted(freq.items(), key=lambda x: -x[1])[:3]}")  # 前3

# 回文检测
def is_palindrome(s):
    s = s.lower().replace(" ", "")
    return s == s[::-1]

print(f"racecar是回文: {is_palindrome('racecar')}")  # True
print(f"hello是回文: {is_palindrome('hello')}")      # False

# 字符串压缩
def compress(s):
    if not s: return s
    result, count = [], 1
    for i in range(1, len(s)):
        if s[i] == s[i-1]:
            count += 1
        else:
            result.append(s[i-1] + (str(count) if count > 1 else ""))
            count = 1
    result.append(s[-1] + (str(count) if count > 1 else ""))
    return "".join(result)

print(f"压缩: aabcccddddee -> {compress('aabcccddddee')}")  # a2bc3d4e2
```

---

# 第二部分：数据结构

## 7. 列表 List

```python
# ==========================================
# 创建列表
# ==========================================
empty = []
nums = [1, 2, 3, 4, 5]
mixed = [1, "hello", 3.14, True, None]
nested = [[1, 2], [3, 4]]
from_range = list(range(1, 6))      # [1, 2, 3, 4, 5]
from_str = list("hello")             # ['h','e','l','l','o']

# ==========================================
# 索引与切片
# ==========================================
lst = [10, 20, 30, 40, 50]
print(f"索引: lst[0]={lst[0]}, lst[-1]={lst[-1]}")
print(f"切片: lst[1:3]={lst[1:3]}, lst[::2]={lst[::2]}")
print(f"反转: lst[::-1]={lst[::-1]}")

# ==========================================
# 增删改查
# ==========================================
lst = [3, 1, 4, 1, 5, 9]

# 增
lst.append(6)          # 末尾添加
lst.insert(0, 0)        # 索引0插入
lst.extend([7, 8])      # 扩展多个
print(f"增: {lst}")

# 删
lst.remove(1)            # 删除第一个1
popped = lst.pop()       # 删除并返回末尾
popped2 = lst.pop(0)     # 删除并返回索引0
print(f"删: popped={popped}, lst={lst}")

# 改
lst[0] = 100
print(f"改: {lst}")

# 查
print(f"index(4)={lst.index(4)}")
print(f"count(1)={lst.count(1)}")
print(f"1 in lst={1 in lst}")

# ==========================================
# 排序
# ==========================================
nums = [3, 1, 4, 1, 5, 9, 2, 6]
nums.sort()
print(f"原地排序: {nums}")

nums.sort(reverse=True)
print(f"降序: {nums}")

# 返回新列表
sorted_nums = sorted(nums)
print(f"新列表: {sorted_nums}")

# 自定义排序
words = ["banana", "apple", "cherry", "date"]
words.sort(key=len)
print(f"按长度: {words}")

students = [("Alice", 90), ("Bob", 85), ("Charlie", 92)]
students.sort(key=lambda x: x[1], reverse=True)
print(f"按成绩: {students}")

# ==========================================
# 复制
# ==========================================
a = [1, 2, [3, 4]]
b = a.copy()       # 浅拷贝
c = a[:]            # 切片拷贝
import copy
d = copy.deepcopy(a)  # 深拷贝

# ==========================================
# 常用操作
# ==========================================
nums = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3]
print(f"max={max(nums)}, min={min(nums)}, sum={sum(nums)}")

# 去重（保持顺序）
lst = [1, 2, 2, 3, 3, 3, 4]
unique = list(dict.fromkeys(lst))  # Python 3.7+ 保证顺序
print(f"去重: {unique}")

# 扁平化
nested = [[1, 2, 3], [4, 5], [6, 7, 8]]
flat = [x for sub in nested for x in sub]
print(f"扁平化: {flat}")

# 分组（每3个一组）
lst = list(range(10))
groups = [lst[i:i+3] for i in range(0, len(lst), 3)]
print(f"分组: {groups}")  # [[0,1,2],[3,4,5],[6,7,8],[9]]
```

---

## 8. 元组 Tuple

```python
# ==========================================
# 创建元组
# ==========================================
empty = ()
single = (1,)      # 单元素必须加逗号！
t = (1, 2, 3)
t2 = 1, 2, 3       # 括号可省略
mixed = (1, "hello", 3.14)

# ==========================================
# 基本操作
# ==========================================
t = (10, 20, 30, 40, 50)
print(f"t[0]={t[0]}, t[-1]={t[-1]}")
print(f"t[1:3]={t[1:3]}")

# 不可变（但内部可变对象除外）
# t[0] = 100  # TypeError!

t2 = ([1, 2], [3, 4])
t2[0].append(5)  # 可以修改列表
print(f"内部可变: {t2}")  # ([1, 2, 5], [3, 4])

# ==========================================
# 解包
# ==========================================
a, b, c, d, e = t
print(f"解包: a={a}, b={b}, c={c}")
first, *rest = t
print(f"星号解包: first={first}, rest={rest}")

# 交换变量
x, y = 1, 2
x, y = y, x  # 无需临时变量
print(f"交换: x={x}, y={y}")

# ==========================================
# namedtuple 命名元组
# ==========================================
from collections import namedtuple

Point = namedtuple("Point", ["x", "y"])
p = Point(3, 4)
print(f"命名元组: p.x={p.x}, p.y={p.y}")
print(f"支持索引: p[0]={p[0]}, p[1]={p[1]}")
print(f"转字典: {p._asdict()}")

# 带默认值
Person = namedtuple("Person", ["name", "age", "city"])
p1 = Person._make(["Alice", 25, "Beijing"])
print(f"_make: {p1}")

# ==========================================
# 用途
# ==========================================
# 1. 多返回值
def min_max(lst):
    return min(lst), max(lst)

lo, hi = min_max([3, 1, 4, 1, 5])
print(f"多返回: lo={lo}, hi={hi}")

# 2. 字典键（因为不可变）
coords = {(0, 0): "原点", (1, 1): "点A"}
print(f"元组作键: {coords[(0, 0)]}")
```

---

## 9. 字典 Dict

```python
# ==========================================
# 创建字典
# ==========================================
empty = {}
d = {"name": "Alice", "age": 25}
d2 = dict(name="Alice", age=25)
d3 = dict([("a", 1), ("b", 2)])
d4 = {x: x**2 for x in range(5)}  # {0:0, 1:1, 2:4, 3:9, 4:16}
d5 = dict.fromkeys(["a", "b", "c"], 0)  # 默认值都是0

# ==========================================
# 访问
# ==========================================
d = {"name": "Alice", "age": 25, "city": "Beijing"}
print(f"d['name']={d['name']}")
print(f"d.get('phone','N/A')={d.get('phone', 'N/A')}")  # 带默认值

# ==========================================
# 增删改查
# ==========================================
d["email"] = "a@b.com"   # 新增
d["age"] = 26            # 修改
del d["city"]            # 删除键
val = d.pop("email")    # 删除并返回值
print(f"pop={val}, d={d}")

# 判断键
print(f"'name' in d={'name' in d}")
print(f"'Alice' in d.values()={'Alice' in d.values()}")

# ==========================================
# 遍历
# ==========================================
d = {"a": 1, "b": 2, "c": 3}
for key in d:
    print(f"键={key}", end=" ")
print()
for val in d.values():
    print(f"值={val}", end=" ")
print()
for k, v in d.items():
    print(f"{k}={v}", end=" ")
print()

# ==========================================
# 合并（Python 3.9+）
# ==========================================
d1 = {"a": 1, "b": 2}
d2 = {"b": 3, "c": 4}
merged = d1 | d2
print(f"合并: {merged}")  # {'a':1, 'b':3, 'c':4}

# ==========================================
# defaultdict
# ==========================================
from collections import defaultdict

# 统计词频
text = "the quick brown fox the lazy dog the"
counter = defaultdict(int)
for word in text.split():
    counter[word] += 1
print(f"词频: {dict(counter)}")

# 分组
students = [("Alice", "A班"), ("Bob", "B班"), ("Charlie", "A班")]
groups = defaultdict(list)
for name, cls in students:
    groups[cls].append(name)
print(f"分组: {dict(groups)}")

# ==========================================
# Counter
# ==========================================
from collections import Counter
text = "hello world"
c = Counter(text)
print(f"字符计数: {c}")
print(f"最常见3个: {c.most_common(3)}")

nums = [1, 2, 3, 1, 2, 1]
print(f"数字计数: {Counter(nums)}")

# ==========================================
# 嵌套字典
# ==========================================
employees = {
    "E001": {"name": "Alice", "dept": "Engineering", "salary": 80000},
    "E002": {"name": "Bob", "dept": "Marketing", "salary": 75000},
}
# 按薪资排序
sorted_emp = dict(sorted(employees.items(),
                          key=lambda x: x[1]["salary"],
                          reverse=True))
for id, info in sorted_emp.items():
    print(f"{id}: {info['name']} - {info['salary']}")
```

---

## 10. 集合 Set

```python
# ==========================================
# 创建集合
# ==========================================
empty = set()  # 注意：{} 创建的是字典！
s = {1, 2, 3, 4, 5}
s2 = set([1, 2, 2, 3, 3])  # 自动去重
print(f"去重: {s2}")  # {1, 2, 3}

# 集合推导式
evens = {x for x in range(10) if x % 2 == 0}
print(f"偶数集合: {evens}")

# ==========================================
# 集合运算
# ==========================================
a, b = {1, 2, 3, 4, 5}, {3, 4, 5, 6, 7}
print(f"并集 a|b = {a | b}")      # {1,2,3,4,5,6,7}
print(f"交集 a&b = {a & b}")      # {3, 4, 5}
print(f"差集 a-b = {a - b}")      # {1, 2}
print(f"对称差集 a^b = {a ^ b}")  # {1, 2, 6, 7}

# 方法形式
print(f"union={a.union(b)}")
print(f"intersection={a.intersection(b)}")
print(f"difference={a.difference(b)}")

# ==========================================
# 子集/超集
# ==========================================
print(f"{{1,2}} <= {{1,2,3}} = {{1,2} <= {1,2,3}}")  # True
print(f"{{1,2}} < {{1,2,3}} = {1,2} < {1,2,3}")    # True（真子集）

# ==========================================
# 集合方法
# ==========================================
s = {1, 2, 3}
s.add(4)           # 添加
s.discard(2)       # 删除（不存在不报错）
s.remove(3)        # 删除（不存在抛 KeyError）
val = s.pop()      # 随机删除并返回
s.clear()          # 清空
print(f"操作后: {s}")

# ==========================================
# frozenset（不可变集合）
# ==========================================
fs = frozenset([1, 2, 3])
# fs.add(4)  # AttributeError!
d = {fs: "不可变集合作键"}  # 可以作为字典键
print(f"frozenset作键: {d}")

# ==========================================
# 应用场景
# ==========================================
# 1. 去重（顺序不定）
lst = [1, 2, 2, 3, 3, 3, 4]
print(f"去重: {list(set(lst))}")

# 2. 快速成员检测
valid_users = {"Alice", "Bob"}
print(f"Alice是用户: {'Alice' in valid_users}")  # True（O(1)）

# 3. 找共同好友
friends1 = {"Alice", "Bob", "Charlie"}
friends2 = {"Bob", "David", "Alice"}
common = friends1 & friends2
print(f"共同好友: {common}")  # {'Alice', 'Bob'}
```

---

# 第三部分：函数

## 11. 函数定义与参数

```python
# ==========================================
# 基本函数
# ==========================================
def greet(name):
    """问候函数（docstring）"""
    return f"Hello, {name}!"

print(greet("Alice"))
print(greet.__doc__)  # 问候函数（docstring）

# ==========================================
# 参数类型
# ==========================================

# 1. 位置参数
def add(a, b):
    return a + b
print(f"add(1,2)={add(1,2)}")
print(f"add(b=2,a=1)={add(b=2,a=1)}")  # 关键字参数

# 2. 默认参数
def power(base, exp=2):
    return base ** exp
print(f"power(3)={power(3)}")      # 9
print(f"power(3,3)={power(3,3)}")  # 27

# 注意：默认参数不要用可变对象！
def bad_append(item, lst=[]):  # 危险！
    lst.append(item)
    return lst
print(f"bad: {bad_append(1)}, {bad_append(2)}")  # [1], [1,2]!

def good_append(item, lst=None):  # 正确
    if lst is None:
        lst = []
    lst.append(item)
    return lst
print(f"good: {good_append(1)}, {good_append(2)}")  # [1], [2]

# 3. *args 可变位置参数
def sum_all(*args):
    return sum(args)
print(f"sum_all(1,2,3,4,5)={sum_all(1,2,3,4,5)}")

# 4. **kwargs 可变关键字参数
def print_info(**kwargs):
    for k, v in kwargs.items():
        print(f"{k}={v}")
print_info(name="Alice", age=25, city="Beijing")

# 5. 混合使用
def mixed(a, b, *args, keyword=None, **kwargs):
    print(f"a={a}, b={b}, args={args}, keyword={keyword}, kwargs={kwargs}")
mixed(1, 2, 3, 4, keyword="hello", x=10)

# 6. 仅关键字参数（* 之后必须用关键字）
def kw_only(a, b, *, c, d=10):
    return a + b + c + d
print(f"kw_only(1,2,c=3)={kw_only(1,2,c=3)}")

# 7. 仅位置参数（/ 之前只能按位置，Python 3.8+）
def pos_only(a, b, /, c):
    return a + b + c
print(f"pos_only(1,2,3)={pos_only(1,2,3)}")

# ==========================================
# 解包传参
# ==========================================
def add3(a, b, c):
    return a + b + c

args = [1, 2, 3]
print(f"解包列表: {add3(*args)}")

kwargs = {"a": 1, "b": 2, "c": 3}
print(f"解包字典: {add3(**kwargs)}")

# ==========================================
# 多返回值
# ==========================================
def min_max(lst):
    return min(lst), max(lst)

lo, hi = min_max([3, 1, 4, 1, 5, 9])
print(f"lo={lo}, hi={hi}")
```

---

## 12. 高级函数特性

```python
# ==========================================
# lambda 匿名函数
# ==========================================
square = lambda x: x ** 2
print(f"lambda平方: {square(5)}")  # 25

add = lambda x, y: x + y
print(f"lambda加法: {add(3, 4)}")   # 7

# 配合高阶函数
nums = [5, 2, 8, 1, 9, 3]
print(f"排序: {sorted(nums, key=lambda x: -x)}")  # 降序
students = [("Alice", 90), ("Bob", 85)]
print(f"按成绩: {sorted(students, key=lambda s: s[1])}")

# ==========================================
# 高阶函数
# ==========================================
nums = [1, 2, 3, 4, 5]

# map：对每个元素应用函数
squared = list(map(lambda x: x**2, nums))
print(f"平方: {squared}")  # [1, 4, 9, 16, 25]

# filter：过滤元素
evens = list(filter(lambda x: x % 2 == 0, nums))
print(f"偶数: {evens}")  # [2, 4]

# reduce：累积计算（需导入）
from functools import reduce
product = reduce(lambda x, y: x * y, nums)
print(f"连乘: {product}")  # 120

# ==========================================
# 闭包
# ==========================================
def make_counter(start=0):
    count = [start]  # 用列表包装可变对象
    def counter():
        count[0] += 1
        return count[0]
    return counter

c1 = make_counter()
c2 = make_counter(10)
print(f"c1: {c1()}, {c1()}, {c1()}")  # 1, 2, 3
print(f"c2: {c2()}, {c2()}")          # 11, 12

# nonlocal（Python 3）
def make_accumulator():
    total = 0
    def add(n):
        nonlocal total
        total += n
        return total
    return add

acc = make_accumulator()
print(f"累加: {acc(10)}, {acc(20)}, {acc(5)}")  # 10, 30, 35

# ==========================================
# 递归
# ==========================================
def factorial(n):
    if n <= 1: return 1
    return n * factorial(n - 1)
print(f"阶乘5! = {factorial(5)}")  # 120

# 斐波那契（带缓存）
from functools import lru_cache

@lru_cache(maxsize=None)
def fib(n):
    if n <= 1: return n
    return fib(n-1) + fib(n-2)
print(f"斐波那契50 = {fib(50)}")  # 12586269025

# ==========================================
# 类型注解
# ==========================================
from typing import List, Dict, Optional, Union

def process(
    items: List[int],
    config: Dict[str, str],
    callback: Optional[callable] = None
) -> tuple[int, int]:
    if callback:
        items = [callback(x) for x in items]
    return min(items), max(items)

# Python 3.10+ 简化
def new_style(x: int | str | None) -> list[int]:
    return []
```

---

# 第四部分：面向对象

## 13. 类与对象

```python
# ==========================================
# 基础类
# ==========================================
class Person:
    species = "Homo sapiens"  # 类变量

    def __init__(self, name: str, age: int):
        self.name = name      # 实例变量
        self.age = age

    def __str__(self):
        return f"Person({self.name}, {self.age})"

    def greet(self):
        return f"Hi, I'm {self.name}!"

    @classmethod
    def from_birth_year(cls, name: str, birth_year: int):
        """从出生年创建"""
        import datetime
        age = datetime.date.today().year - birth_year
        return cls(name, age)

    @staticmethod
    def is_adult(age: int) -> bool:
        return age >= 18

    @property
    def info(self):
        return f"{self.name}({self.age})"

# 使用
alice = Person("Alice", 25)
print(f"实例: {alice}")
print(f"问候: {alice.greet()}")
print(f"类方法: {Person.from_birth_year('Bob', 1995)}")
print(f"静态方法: {Person.is_adult(20)}")
print(f"属性: {alice.info}")

# ==========================================
# 继承
# ==========================================
class Animal:
    def __init__(self, name: str):
        self.name = name

    def speak(self):
        return f"{self.name} makes a sound"

class Dog(Animal):
    def __init__(self, name: str, breed: str):
        super().__init__(name)
        self.breed = breed

    def speak(self):
        return f"{self.name} says Woof! (breed: {self.breed})"

    def fetch(self, item):
        return f"{self.name} fetches {item}!"

dog = Dog("Rex", "German Shepherd")
print(dog.speak())   # Rex says Woof! (breed: German Shepherd)
print(dog.fetch("ball"))
```

---

## 14. 继承与多态

```python
# ==========================================
# 多态
# ==========================================
class Cat(Animal):
    def speak(self):
        return f"{self.name} says Meow~"

class Bird(Animal):
    def speak(self):
        return f"{self.name} says Tweet!"

animals = [Dog("Rex", "Shepherd"), Cat("Whiskers"), Bird("Tweety")]
for animal in animals:
    print(animal.speak())

# ==========================================
# 多继承
# ==========================================
class Flyable:
    def fly(self):
        return f"{self.__class__.__name__} is flying"

class Swimmable:
    def swim(self):
        return f"{self.__class__.__name__} is swimming"

class Duck(Animal, Flyable, Swimmable):
    def speak(self):
        return f"{self.name} says Quack!"

duck = Duck("Donald")
print(duck.speak())
print(duck.fly())
print(duck.swim())
print(f"MRO: {Duck.__mro__}")
```

---

## 15. 特殊方法与数据类

```python
# ==========================================
# 魔术方法
# ==========================================
class Vector:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __repr__(self):
        return f"Vector({self.x}, {self.y})"

    def __str__(self):
        return f"({self.x}, {self.y})"

    def __add__(self, other):
        return Vector(self.x + other.x, self.y + other.y)

    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

    def __len__(self):
        return 2  # 维度

    def __getitem__(self, idx):
        return [self.x, self.y][idx]

v1 = Vector(1, 2)
v2 = Vector(3, 4)
print(f"repr: {repr(v1)}")
print(f"str: {str(v1)}")
print(f"add: {v1 + v2}")
print(f"eq: {v1 == Vector(1, 2)}")
print(f"len: {len(v1)}")
print(f"index: v1[0]={v1[0]}")

# ==========================================
# dataclass（Python 3.7+）
# ==========================================
from dataclasses import dataclass, field
import math

@dataclass
class Product:
    name: str
    price: float
    quantity: int = 0
    tags: list = field(default_factory=list)

    def total_value(self) -> float:
        return self.price * self.quantity

p = Product("Phone", 4999, 10)
print(f"Product: {p}")
print(f"总价: {p.total_value()}")
```

---

# 第五部分：异常处理

## 16. 异常基础

```python
# ==========================================
# try-except
# ==========================================
try:
    result = 10 / 0
except ZeroDivisionError as e:
    print(f"捕获异常: {e}")

# 多个 except
try:
    data = [1, 2, 3]
    print(data[10])
except IndexError as e:
    print(f"索引越界: {e}")
except Exception as e:
    print(f"其他错误: {e}")
finally:
    print("finally 总是执行")

# try-except-else
try:
    result = 10 / 2
except ZeroDivisionError:
    print("除零")
else:
    print(f"成功: {result}")
```

---

## 17. 自定义异常

```python
# ==========================================
# 自定义异常
# ==========================================
class ValidationError(Exception):
    def __init__(self, field: str, message: str):
        self.field = field
        self.message = message
        super().__init__(f"验证失败 [{field}]: {message}")

def validate_age(age):
    if not isinstance(age, int):
        raise ValidationError("age", "必须是整数")
    if not 0 <= age <= 150:
        raise ValidationError("age", f"超出范围: {age}")
    return age

try:
    validate_age("abc")
except ValidationError as e:
    print(f"错误: {e.message}, 字段: {e.field}")

try:
    validate_age(200)
except ValidationError as e:
    print(f"错误: {e.message}")
```

---

# 第六部分：文件操作

## 18. 文件读写

```python
# ==========================================
# 基础读写
# ==========================================
# 写
with open("test.txt", "w", encoding="utf-8") as f:
    f.write("Hello, World!\n")
    f.writelines(["line2\n", "line3\n"])

# 读
with open("test.txt", "r", encoding="utf-8") as f:
    content = f.read()
    print(f"全部: {content}")

with open("test.txt", "r", encoding="utf-8") as f:
    lines = f.readlines()
    print(f"逐行: {lines}")

with open("test.txt", "r", encoding="utf-8") as f:
    for line in f:
        print(f"  {line}", end="")

# 追加
with open("test.txt", "a", encoding="utf-8") as f:
    f.write("append\n")

# seek/tell
with open("test.txt", "r") as f:
    print(f"位置: {f.tell()}")
    f.read(5)
    print(f"读5后位置: {f.tell()}")
    f.seek(0)
    print(f"seek(0)后: {f.tell()}")
```

---

## 19. JSON/CSV/路径操作

```python
# ==========================================
# JSON
# ==========================================
import json

data = {"name": "Alice", "age": 25, "skills": ["Python", "SQL"]}

# 写 JSON
with open("data.json", "w", encoding="utf-8") as f:
    json.dump(data, f, ensure_ascii=False, indent=2)

# 读 JSON
with open("data.json", "r", encoding="utf-8") as f:
    loaded = json.load(f)
    print(f"读取: {loaded}")

# 字符串转换
json_str = json.dumps(data, ensure_ascii=False, indent=2)
obj = json.loads(json_str)
print(f"解析: {obj}")

# ==========================================
# CSV
# ==========================================
import csv

# 写
students = [["姓名", "年龄", "成绩"], ["Alice", 20, 95], ["Bob", 21, 87]]
with open("students.csv", "w", newline="", encoding="utf-8-sig") as f:
    writer = csv.writer(f)
    writer.writerows(students)

# 读
with open("students.csv", "r", encoding="utf-8-sig") as f:
    reader = csv.reader(f)
    for row in reader:
        print(row)

# DictReader/DictWriter
with open("students.csv", "r", encoding="utf-8-sig") as f:
    reader = csv.DictReader(f)
    for row in reader:
        print(dict(row))

# ==========================================
# pathlib（推荐）
# ==========================================
from pathlib import Path

p = Path("test.txt")
p.write_text("Hello pathlib!", encoding="utf-8")
print(f"读取: {p.read_text(encoding='utf-8')}")
p.unlink()

# 目录操作
d = Path("test_dir")
d.mkdir(exist_ok=True)
(d / "file.txt").write_text("content")
print(f"遍历: {list(d.iterdir())}")
d.rmdir()
```

---

# 第七部分：进阶语法

## 20. 迭代器与生成器

```python
# ==========================================
# 迭代器协议
# ==========================================
class CountUp:
    def __init__(self, start, stop):
        self.current = start
        self.stop = stop

    def __iter__(self):
        return self

    def __next__(self):
        if self.current > self.stop:
            raise StopIteration
        val = self.current
        self.current += 1
        return val

for n in CountUp(1, 5):
    print(n, end=" ")  # 1 2 3 4 5
print()

# ==========================================
# 生成器函数
# ==========================================
def countdown(n):
    print("开始倒计时")
    while n > 0:
        yield n
        n -= 1
    print("结束")

for i in countdown(3):
    print(f"倒计时: {i}")

# 无限生成器
def fibonacci():
    a, b = 0, 1
    while True:
        yield a
        a, b = b, a + b

from itertools import islice
print(f"斐波那契前10: {list(islice(fibonacci(), 10))}")

# ==========================================
# 生成器表达式
# ==========================================
gen = (x**2 for x in range(5))
print(f"生成器: {next(gen)}, {next(gen)}, {list(gen)}")

# ==========================================
# itertools
# ==========================================
import itertools

print(f"count(1,2)前5: {list(itertools.islice(itertools.count(1, 2), 5))}")
print(f"cycle: {list(itertools.islice(itertools.cycle(['红','绿']), 5))}")
print(f"chain: {list(itertools.chain([1,2], [3,4]))}")
print(f"permutations([1,2,3],2): {list(itertools.permutations([1,2,3], 2))}")
print(f"combinations([1,2,3,4],2): {list(itertools.combinations([1,2,3,4], 2))}")
```

---

## 21. 装饰器

```python
import functools
import time

# ==========================================
# 基础装饰器
# ==========================================
def my_decorator(func):
    @functools.wraps(func)
    def wrapper(*args, **kwargs):
        print(f"调用 {func.__name__} 前")
        result = func(*args, **kwargs)
        print(f"调用 {func.__name__} 后")
        return result
    return wrapper

@my_decorator
def say_hello(name):
    print(f"Hello, {name}!")

say_hello("Alice")

# ==========================================
# 计时装饰器
# ==========================================
def timer(func):
    @functools.wraps(func)
    def wrapper(*args, **kwargs):
        start = time.perf_counter()
        result = func(*args, **kwargs)
        print(f"{func.__name__} 耗时: {time.perf_counter()-start:.4f}s")
        return result
    return wrapper

@timer
def slow():
    time.sleep(0.1)

slow()

# ==========================================
# 带参数装饰器
# ==========================================
def retry(max_attempts=3):
    def decorator(func):
        @functools.wraps(func)
        def wrapper(*args, **kwargs):
            for i in range(max_attempts):
                try:
                    return func(*args, **kwargs)
                except Exception as e:
                    if i == max_attempts - 1:
                        raise
                    print(f"第{i+1}次失败，重试...")
        return wrapper
    return decorator

@retry(max_attempts=2)
def may_fail():
    import random
    if random.random() < 0.5:
        raise ValueError("随机失败")
    return "成功"

try:
    print(may_fail())
except ValueError:
    print("最终失败")

# ==========================================
# lru_cache 缓存
# ==========================================
from functools import lru_cache

@lru_cache(maxsize=None)
def fib(n):
    if n <= 1: return n
    return fib(n-1) + fib(n-2)

print(f"fib(100) = {fib(100)}")  # 瞬间完成

# ==========================================
# 类装饰器 - 单例
# ==========================================
def singleton(cls):
    instance = None
    @functools.wraps(cls)
    def get_instance(*args, **kwargs):
        nonlocal instance
        if instance is None:
            instance = cls(*args, **kwargs)
        return instance
    return get_instance

@singleton
class Database:
    def __init__(self):
        print("创建数据库连接")

db1 = Database()
db2 = Database()
print(f"是同一实例: {db1 is db2}")  # True
```

---

## 22. 上下文管理器

```python
import contextlib
import time

# ==========================================
# 类方式
# ==========================================
class Timer:
    def __enter__(self):
        self.start = time.perf_counter()
        return self

    def __exit__(self, exc_type, exc_val, exc_tb):
        print(f"耗时: {time.perf_counter()-self.start:.4f}s")
        return False

with Timer() as t:
    time.sleep(0.1)
    print("任务完成")

# ==========================================
# @contextmanager 方式
# ==========================================
@contextlib.contextmanager
def temp_dir():
    import tempfile, shutil
    d = tempfile.mkdtemp()
    try:
        yield d
    finally:
        shutil.rmtree(d, ignore_errors=True)

with temp_dir() as td:
    print(f"临时目录: {td}")

# ==========================================
# suppress 忽略异常
# ==========================================
with contextlib.suppress(FileNotFoundError):
    open("nonexistent.txt")
print("忽略错误后继续执行")
```

---

## 23. 并发编程

```python
import threading
import multiprocessing
import asyncio
import time
from concurrent.futures import ThreadPoolExecutor, ProcessPoolExecutor

# ==========================================
# threading 多线程
# ==========================================
def download(url, delay):
    print(f"开始下载 {url}")
    time.sleep(delay)
    return f"{url} 完成"

# 顺序
start = time.time()
for url, delay in [("A", 1), ("B", 1), ("C", 1)]:
    download(url, delay)
print(f"顺序耗时: {time.time()-start:.1f}s")

# 并发
start = time.time()
threads = []
for url, delay in [("A", 1), ("B", 1), ("C", 1)]:
    t = threading.Thread(target=download, args=(url, delay))
    threads.append(t)
    t.start()
for t in threads:
    t.join()
print(f"并发耗时: {time.time()-start:.1f}s")

# Lock
counter = 0
lock = threading.Lock()
def safe_increment():
    global counter
    for _ in range(100000):
        with lock:
            counter += 1

threads = [threading.Thread(target=safe_increment) for _ in range(5)]
for t in threads: t.start()
for t in threads: t.join()
print(f"计数器: {counter}")

# ==========================================
# ThreadPoolExecutor
# ==========================================
def process(n):
    return n ** 2

with ThreadPoolExecutor(max_workers=4) as executor:
    results = list(executor.map(process, range(10)))
    print(f"并行结果: {results}")

# ==========================================
# asyncio 异步
# ==========================================
async def fetch(url, delay):
    print(f"请求 {url}")
    await asyncio.sleep(delay)
    return f"{url} 数据"

async def main():
    # 顺序
    r1 = await fetch("api1", 1)
    r2 = await fetch("api2", 1)

    # 并发
    results = await asyncio.gather(
        fetch("api1", 1),
        fetch("api2", 1),
        fetch("api3", 1),
    )
    print(f"并发结果: {len(results)}")

asyncio.run(main())

# ==========================================
# multiprocessing 多进程
# ==========================================
def cpu_task(n):
    return sum(i**2 for i in range(n))

with ProcessPoolExecutor(max_workers=4) as executor:
    results = list(executor.map(cpu_task, [100000]*4))
    print(f"进程结果: {results}")
```

---

## 24. 正则表达式

```python
import re

# ==========================================
# 基础
# ==========================================
text = "Python created in 1991 by Guido"

print(f"match: {re.match(r'Python', text).group()}")  # 从头匹配
print(f"search: {re.search(r'\d+', text).group()}")  # 第一个匹配
print(f"findall: {re.findall(r'\d+', text)}")         # 所有匹配

# ==========================================
# 模式语法
# ==========================================
# . 任意字符  ^ 开头  $ 结尾
# * 0+  + 1+  ? 0/1  {n} {n,m}
# \d 数字  \w 单词  \s 空白
# [] 字符集  () 分组

text = "电话: 138-1234-5678, 010-8888-9999"
print(f"手机号: {re.findall(r'\d{3}-\d{4}-\d{4}', text)}")

# 分组
date = "2024-01-15"
m = re.search(r'(\d{4})-(\d{2})-(\d{2})', date)
print(f"分组: {m.groups()}")
print(f"年={m.group(1)}, 月={m.group(2)}, 日={m.group(3)}")

# 命名分组
m = re.search(r'(?P<year>\d{4})-(?P<month>\d{2})-(?P<day>\d{2})', date)
print(f"命名: {m.groupdict()}")

# 替换
text = "Hello World"
print(f"替换: {re.sub(r'World', 'Python', text)}")

# 编译（性能优化）
phone_re = re.compile(r'1[3-9]\d{9}')
print(f"编译: {bool(phone_re.match('13812345678'))}")

# ==========================================
# 实用正则
# ==========================================
# 邮箱
email_re = re.compile(r'[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}')
print(f"邮箱: {bool(email_re.match('user@example.com'))}")

# IP地址
ip_re = re.compile(
    r'^(?:(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}'
    r'(?:25[0-5]|2[0-4]\d|[01]?\d\d?)$')
print(f"IP: {bool(ip_re.match('192.168.1.1'))}")

# URL提取
url_re = re.compile(r'https?://[^\s]+')
text = "访问 https://python.org 和 http://docs.python.org"
print(f"URLs: {url_re.findall(text)}")
```

---

# 第八部分：常用工具包

## 25. Requests

```python
# ==========================================
# Requests - HTTP 请求库
# ==========================================
import requests

# ==========================================
# GET 请求
# ==========================================
# 简单 GET
response = requests.get("https://httpbin.org/get")
print(f"状态码: {response.status_code}")
print(f"响应内容: {response.json()}")

# 带参数
params = {"key1": "value1", "key2": "value2"}
response = requests.get("https://httpbin.org/get", params=params)
print(f"URL: {response.url}")

# Headers
headers = {"User-Agent": "Python/3.x"}
response = requests.get("https://httpbin.org/headers", headers=headers)
print(f"Headers: {response.json()}")

# ==========================================
# POST 请求
# ==========================================
data = {"username": "alice", "password": "secret"}
response = requests.post("https://httpbin.org/post", data=data)
print(f"POST响应: {response.json()}")

# JSON 数据
json_data = {"name": "Alice", "age": 25}
response = requests.post("https://httpbin.org/post", json=json_data)
print(f"JSON: {response.json()['json']}")

# ==========================================
# 其他请求
# ==========================================
# PUT
requests.put("https://httpbin.org/put", data={"key": "value"})

# DELETE
requests.delete("https://httpbin.org/delete")

# ==========================================
# 高级用法
# ==========================================
# 超时设置
try:
    response = requests.get("https://httpbin.org/delay/1", timeout=2)
except requests.Timeout:
    print("请求超时")

# 认证
from requests.auth import HTTPBasicAuth
requests.get("https://httpbin.org/basic-auth/user/passwd",
             auth=HTTPBasicAuth("user", "passwd"))

# Session（保持 cookies）
session = requests.Session()
session.headers.update({"User-Agent": "MyApp/1.0"})
response = session.get("https://httpbin.org/headers")
print(f"Session Headers: {response.json()['headers']}")

# 文件上传
files = {"file": ("test.txt", "Hello World!", "text/plain")}
response = requests.post("https://httpbin.org/post", files=files)
print(f"上传: {response.json()['files']}")

# ==========================================
# 错误处理
# ==========================================
try:
    response = requests.get("https://httpbin.org/status/404")
    response.raise_for_status()  # 4xx/5xx 时抛异常
except requests.HTTPError as e:
    print(f"HTTP错误: {e}")

# 响应内容
print(f"文本: {response.text[:100]}")
print(f"JSON: {response.json()}")
```

---

## 26. Flask

```python
# ==========================================
# Flask - 轻量级 Web 框架
# ==========================================
# 安装: pip install flask

from flask import Flask, render_template, request, jsonify, redirect, url_for

app = Flask(__name__)

# ==========================================
# 基础路由
# ==========================================
@app.route("/")
def index():
    return "<h1>Hello Flask!</h1>"

@app.route("/user/<name>")
def user(name):
    return f"<h2>Welcome, {name}!</h2>"

@app.route("/post/<int:post_id>")
def show_post(post_id):
    return f"<h2>Post ID: {post_id}</h2>"

# ==========================================
# HTTP 方法
# ==========================================
@app.route("/login", methods=["GET", "POST"])
def login():
    if request.method == "POST":
        username = request.form.get("username")
        password = request.form.get("password")
        return f"登录: username={username}, password={password}"
    else:
        return '<form method="POST"><input name="username"><input name="password" type="password"><button>登录</button></form>'

# ==========================================
# JSON API
# ==========================================
@app.route("/api/users")
def get_users():
    users = [
        {"id": 1, "name": "Alice"},
        {"id": 2, "name": "Bob"},
        {"id": 3, "name": "Charlie"}
    ]
    return jsonify(users)

@app.route("/api/user/<int:user_id>")
def get_user(user_id):
    user = {"id": user_id, "name": f"User{user_id}"}
    return jsonify(user)

@app.route("/api/create", methods=["POST"])
def create_user():
    data = request.json
    return jsonify({"message": "创建成功", "data": data}), 201

# ==========================================
# 查询参数
# ==========================================
@app.route("/search")
def search():
    q = request.args.get("q", "")
    page = request.args.get("page", 1, type=int)
    return f"搜索: q={q}, page={page}"

# ==========================================
# 模板渲染（需要 templates/ 目录）
# ==========================================
# @app.route("/profile/<name>")
# def profile(name):
#     return render_template("profile.html", name=name)

# ==========================================
# 重定向
# ==========================================
@app.route("/old")
def old_url():
    return redirect(url_for("index"))

# ==========================================
# 错误处理
# ==========================================
@app.errorhandler(404)
def not_found(e):
    return jsonify({"error": "Not Found"}), 404

@app.errorhandler(500)
def server_error(e):
    return jsonify({"error": "Server Error"}), 500

# ==========================================
# 运行
# ==========================================
if __name__ == "__main__":
    # app.run(debug=True, port=5000)
    print("Flask 服务已定义（取消注释 app.run() 启动）")
```

---

## 27. ``SQLAlchemy``

```python
# ==========================================
# SQLAlchemy - ORM 框架
# ==========================================
# 安装: pip install sqlalchemy

from sqlalchemy import create_engine, Column, Integer, String, Float, ForeignKey, DateTime
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker, relationship
from datetime import datetime

# ==========================================
# 基础设置
# ==========================================
# SQLite 数据库（内存）
engine = create_engine("sqlite:///:memory:", echo=False)
Base = declarative_base()

# ==========================================
# 定义模型
# ==========================================
class Department(Base):
    __tablename__ = "departments"
    id = Column(Integer, primary_key=True)
    name = Column(String(50), nullable=False)

    employees = relationship("Employee", back_populates="department")

class Employee(Base):
    __tablename__ = "employees"
    id = Column(Integer, primary_key=True)
    name = Column(String(100), nullable=False)
    salary = Column(Float)
    department_id = Column(Integer, ForeignKey("departments.id"))
    created_at = Column(DateTime, default=datetime.now)

    department = relationship("Department", back_populates="employees")

# 创建表
Base.metadata.create_all(engine)

# ==========================================
# 操作数据
# ==========================================
Session = sessionmaker(bind=engine)
session = Session()

# 创建部门
dept1 = Department(name="技术部")
dept2 = Department(name="市场部")
session.add_all([dept1, dept2])
session.commit()

# 创建员工
emp1 = Employee(name="Alice", salary=15000, department=dept1)
emp2 = Employee(name="Bob", salary=12000, department=dept1)
emp3 = Employee(name="Charlie", salary=10000, department=dept2)
session.add_all([emp1, emp2, emp3])
session.commit()

# 查询
all_employees = session.query(Employee).all()
print("所有员工:")
for emp in all_employees:
    print(f"  {emp.name}: {emp.salary}")

# 条件查询
high_salary = session.query(Employee).filter(Employee.salary > 11000).all()
print(f"高薪员工: {[e.name for e in high_salary]}")

# 排序
sorted_emp = session.query(Employee).order_by(Employee.salary.desc()).all()
print(f"薪资排序: {[e.name for e in sorted_emp]}")

# 关联查询
tech_emps = session.query(Employee).join(Department).filter(Department.name == "技术部").all()
print(f"技术部员工: {[e.name for e in tech_emps]}")

# 更新
emp1.salary = 16000
session.commit()

# 删除
session.delete(emp3)
session.commit()

# ==========================================
# 聚合查询
# ==========================================
from sqlalchemy import func

# 各部门人数
dept_counts = session.query(
    Department.name,
    func.count(Employee.id)
).join(Employee).group_by(Department.name).all()
print(f"部门人数: {dept_counts}")

# 平均薪资
avg_salary = session.query(func.avg(Employee.salary)).scalar()
print(f"平均薪资: {avg_salary}")
```

---

## 28. ``Pydantic``

```python
# ==========================================
# Pydantic - 数据验证
# ==========================================
# 安装: pip install pydantic

from pydantic import BaseModel, Field, validator, EmailStr
from typing import Optional, List
from datetime import date, datetime

# ==========================================
# 基础模型
# ==========================================
class User(BaseModel):
    name: str
    age: int
    email: str

user = User(name="Alice", age=25, email="alice@example.com")
print(f"User: {user}")
print(f"name={user.name}, age={user.age}")

# 自动验证
try:
    bad_user = User(name="Bob", age="not_an_int", email="invalid")
except Exception as e:
    print(f"验证失败: {e}")

# ==========================================
# 字段约束
# ==========================================
class Product(BaseModel):
    name: str = Field(..., min_length=1, max_length=100)
    price: float = Field(..., gt=0)  # > 0
    quantity: int = Field(default=0, ge=0)  # >= 0
    description: Optional[str] = None
    tags: List[str] = Field(default_factory=list)

p = Product(name="Phone", price=4999, quantity=10, tags=["电子", "数码"])
print(f"Product: {p}")

# ==========================================
# 验证器
# ==========================================
class User2(BaseModel):
    username: str
    password: str
    confirm_password: str

    @validator("username")
    def username_alphanumeric(cls, v):
        if not v.isalnum():
            raise ValueError("用户名必须为字母或数字")
        return v.lower()

    @validator("password")
    def password_length(cls, v):
        if len(v) < 6:
            raise ValueError("密码至少6位")
        return v

    @validator("confirm_password")
    def passwords_match(cls, v, values):
        if v != values.get("password"):
            raise ValueError("两次密码不一致")
        return v

try:
    user = User2(username="Alice123", password="secret", confirm_password="secret")
    print(f"验证通过: {user}")
except Exception as e:
    print(f"验证失败: {e.errors()}")

# ==========================================
# 嵌套模型
# ==========================================
class Address(BaseModel):
    city: str
    street: str
    zip_code: str

class Person(BaseModel):
    name: str
    birthdate: date
    address: Address

person = Person(
    name="Alice",
    birthdate="1995-01-15",
    address={"city": "Beijing", "street": "Main St", "zip_code": "100000"}
)
print(f"Person: {person}")
print(f"城市: {person.address.city}")

# ==========================================
# 序列化
# ==========================================
user = User(name="Bob", age=30, email="bob@example.com")
print(f"dict: {user.dict()}")
print(f"json: {user.json()}")
print(f"copy: {user.copy(update={'age': 31})}")
```

---

## 29. ``Loguru``

```python
# ==========================================
# Loguru - 现代化日志
# ==========================================
# 安装: pip install loguru

from loguru import logger
import sys

# ==========================================
# 基础用法
# ==========================================
logger.trace("Trace 消息")
logger.debug("Debug 消息")
logger.info("Info 消息")
logger.success("Success 消息")
logger.warning("Warning 消息")
logger.error("Error 消息")
logger.critical("Critical 消息")

# ==========================================
# 输出到文件
# ==========================================
logger.add("app.log", rotation="10 MB", retention="7 days",
           format="{time:YYYY-MM-DD HH:mm:ss} | {level} | {message}",
           level="INFO")

logger.info("这条日志会写入文件")

# ==========================================
# 结构化日志
# ==========================================
logger.info("用户 {user} 执行了 {action}", user="Alice", action="登录")
logger.bind(request_id="12345").info("带请求ID的日志")

# ==========================================
# 异常日志
# ==========================================
try:
    1 / 0
except Exception:
    logger.exception("发生错误了")

# ==========================================
# 配置
# ==========================================
# 移除默认 handler
logger.remove()

# 添加自定义 handler（控制台）
logger.add(
    sys.stdout,
    format="<green>{time}</green> | <level>{level: <8}</level> | <level>{message}</level>",
    level="DEBUG"
)

# 添加文件 handler
logger.add(
    "app_{time}.log",
    format="{time} | {level} | {message}",
    level="INFO",
    rotation="00:00",  # 每天午夜轮转
    compression="zip"   # 压缩旧日志
)

logger.debug("调试信息")
logger.info("普通信息")
logger.warning("警告信息")
```

---

# 📎 附录

## A. Python 编码规范

```python
# PEP 8 核心要点

# 缩进：4 个空格
if True:
    pass  # 正确
    # pass  # 错误（3个空格）

# 行长度：不超过 79 字符
# 使用括号续行
result = (1 + 2 + 3 + 4 + 5 +
          6 + 7 + 8 + 9 + 10)

# 导入：每行一个，按标准库/第三方/本地排序
import os
import sys
import requests
from mypackage import MyClass

# 命名规范
# 变量/函数：snake_case
# 类名：CamelCase
# 常量：UPPER_SNAKE_CASE
# 私有：_leading_underscore

MY_CONSTANT = 100

def calculate_sum(numbers):
    return sum(numbers)

class DataProcessor:
    def __init__(self):
        self._private_cache = {}

# 注释：保持最新，与代码同步
# docstring：公共 API 使用
```

## B. 常见错误速查

```python
# 1. 可变默认参数
def bad(x, lst=[]):  # 危险！
    lst.append(x)
    return lst

def good(x, lst=None):
    if lst is None:
        lst = []
    lst.append(x)
    return lst

# 2. 循环变量泄漏
funcs = [lambda x: i*x for i in range(3)]  # 所有函数都用 i=2
funcs_correct = [lambda x, i=i: i*x for i in range(3)]  # 正确

# 3. 整数除法
print(10 / 3)   # 3.333...（浮点）
print(10 // 3)  # 3（整除）
print(10 % 3)   # 1（余数）

# 4. 深拷贝 vs 浅拷贝
import copy
a = [[1, 2], [3, 4]]
b = copy.copy(a)   # 浅拷贝，内部列表共享
c = copy.deepcopy(a)  # 深拷贝，完全独立

# 5. 字符串不可变
s = "hello"
# s[0] = 'H'  # TypeError!
s = "H" + s[1:]  # 正确做法
```

## C. 有用资源

```
官方文档: https://docs.python.org/3/
PEP 索引: https://www.python.org/dev/peps/
Python 包索引: https://pypi.org/
Real Python: https://realpython.com/
Python Weekly: https://pythonweekly.com/
```

---

