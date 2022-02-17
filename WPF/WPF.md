# 项目结构

## 如何启动（App.xaml）

```xaml
<Application x:Class="WpfApp1.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:WpfApp1"
             StartupUri="MainWindow.xaml">  <!--用户设置启动页-->
    
    <!-- 资源字典(WPF资源以及WPF应用程序的其他元素) -->
    <Application.Resources>
         
    </Application.Resources>
</Application>
```

## xaml文件

```xaml
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"<!--WPF核心命名空间（控件，标签）-->
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        
    </Grid>
</Window><!--顶级元素-->
```

> 每个``xaml`` 文件只能有一个顶级元素
>
> ``xaml`` 区分大小写，但对于属性而言通常不区分

## 编译过程

xaml和cs文件编译成为baml文件

## 读取baml

```c#
var resourcesName = this.GetType().Assembly.GetName().Name + ".g";
var manager = new ResourceManager(resourcesName,this.GetType().Assembly);
var resourceSet = manager.GetResourceSet(CultureInfo.CurrentCulture,true,true);
var dictionaryEntries = resourceSet.OfType<DictionaryEntry>().ToList();
dictionaryEntries.ForEach(args =>
                          {
                              Baml2006Reader reader = new Baml2006Reader((Stream)args.Value);
                              //var win = XamlReader.Load(reader) as Window;
                              //MessageBox.Show(win.Name);
                          });
```

# 布局和控件

## 常用的布局属性

![](images/001.png)

## 常用的布局容器

1. Grid
2. StackPanel
3. WrapPanel
4. DockPanel
5. UniformGrid

### Grid

ShowGridLines属性(true/false)：行列分割线是否显示

```xaml
<Grid ShowGridLines="True">
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition/>
   </Grid.RowDefinitions>

   <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
   </Grid.ColumnDefinitions>

   <Border Background="#f26321" Margin="5"/>
   <Border Background="#8cc43d" Grid.Column="1" Margin="5"/>

   <Border Background="#00abed" Grid.Row="1" Margin="5"/>
   <Border Background="#efbe0b" Grid.Row="1" Grid.Column="1" Margin="5"/>
</Grid>
```

![](images/002.png)

### StackPanel

- Orientation属性：按行排或者按列排
- StackPanel主要用于垂直或水平排列元素、在容器的可用尺寸内放置有限个元素，元素的尺寸总和(长/高)不允许超过StackPanel的尺寸, 否则超出的部分不可见。

### WrapPanel

- WrapPanel默认排列方向与StackPanel相反、WrapPanel的Orientation默认为Horizontal。
- WrapPanel具备StackPanel的功能基础上具备在尺寸变更后自动适应容器的宽高进行换行换列处理。

### DockPanel

- 默认DockPanel中的元素具备DockPanel.Dock属性, 该属性为枚举具备: Top、Left、Right、Bottom。
- 默认情况下, DockPanel中的元素不添加DockPanel.Dock属性, 则系统则会默认添加 Left。
- DockPanel有一个LastChildFill属性, 该属性默认为true, 该属性作用为, 当容器中的最后一个元素时, 默认该元素填充DockPanel所有空间。

### UniformGrid

会按行列的个数均分窗体空间

```xa
<UniformGrid Columns="2" Rows="2">
            <Button Width="80" Height="40" Content="sdfsadf"/>
            <Button Width="80" Height="40" Content="sdfsadf"/>
            <Button Width="80" Height="40" Content="sdfsadf"/>
            <Button Width="80" Height="40" Content="sdfsadf"/>
</UniformGrid>
```

## 控件结构

![](images/003.png)

- 凡是继承于ContentControl的控件定义内容都用Content属性，除了TextBlock之外大部分都是用Content
- 继承Control的控件大部分都有Padding，Margin属性，TextBlock则是单独实现了这两个属性
- Content是object类型，所以对于Button，CheckBox等来说，不仅仅可以设置成字符串，也可以设置各种复杂的对象类型

```xa
<Button Width="80" Height="40">
            <Button.Content>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="❥(^_-)"/>
                    <TextBlock Text="哈哈"/>
                </StackPanel>
            </Button.Content>
</Button>
```

# 样式Style

## 声明样式

1.在Window里面声明

```xaml
<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Window.Resources>
        <Style x:Key="BaseStyle" TargetType="Button">
            <Setter Property="Width" Value="100"/>
            <Setter Property="Height" Value="40"/>
            <Setter Property="Foreground" Value="Red"/>
        </Style>
        <Style TargetType="Button" x:Key="StyleButton" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Content" Value="hello"/>
        </Style>
    </Window.Resources>
    <StackPanel>
        <Button Style="{StaticResource StyleButton}"></Button>
        <Button Content="button2"></Button>
        <Button Content="button3"></Button>
    </StackPanel>
</Window>
```

- 当样式没有设置`x:key` 属性时表示全局，如下面没有给声明的样式添加`x:key` 的时候全部的`button` 都使用这个样式
- `TargetType` 指定样式给什么控件使用
  * ` TargetType="Button"` 也可以写成 `TargetType="{x:Type Button}"` 
- `property` 指定要设置的样式
- `BasedOn` 指定继承的样式

```xaml
<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Window.Resources>
        <Style x:Key="BaseStyle" TargetType="Button">
            <Setter Property="Width" Value="100"/>
            <Setter Property="Height" Value="40"/>
            <Setter Property="Foreground" Value="Red"/>
        </Style>
        <Style TargetType="Button" x:Key="style1" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Content" Value="hello"/>
        </Style>
    </Window.Resources>
    <Grid>
        <StackPanel>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
        </StackPanel>
    </Grid>
</Window>
```

效果如下：

![](images/004.png)

## 触发器

### 定义

![](images/005.png)

### 声明触发器

```xaml
<Style x:Key="BaseStyle" TargetType="{x:Type Button}">
            <Setter Property="Width" Value="100"/>
            <Setter Property="Height" Value="40"/>
            <Setter Property="Foreground" Value="Red"/>
            <!--声明触发器-->
            <Style.Triggers>
                <!-- 触发器的条件,满足这个条件就会使用当前触发器里的样式
                   IsMouseOver:鼠标移入这个区域 value 为 True -->
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Foreground" Value="Blue"/>
                    <Setter Property="FontSize" Value="20"/>
                </Trigger>

                <Trigger Property="IsMouseOver" Value="False">
                    <Setter Property="Foreground" Value="red"/>
                    <Setter Property="FontSize" Value="25"/>
                </Trigger>
            </Style.Triggers>
</Style>
```

### 某个控件单独声明触发器

```xaml
<TextBox>
     <TextBox.Triggers>
                    
     </TextBox.Triggers>
</TextBox>
```

### 演示

```xaml
<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">

    <Window.Resources>
        <Style x:Key="BaseStyle" TargetType="{x:Type Button}">
            <Setter Property="Width" Value="100"/>
            <Setter Property="Height" Value="40"/>
            <Setter Property="Foreground" Value="Red"/>
            <!--声明触发器-->
            <Style.Triggers>
                <!-- 触发器的条件,满足这个条件就会使用当前触发器里的样式
                   IsMouseOver:鼠标移入这个区域 value 为 True -->
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Foreground" Value="Blue"/>
                    <Setter Property="FontSize" Value="20"/>
                </Trigger>

                <Trigger Property="IsMouseOver" Value="False">
                    <Setter Property="Foreground" Value="red"/>
                    <Setter Property="FontSize" Value="25"/>
                </Trigger>
            </Style.Triggers>
        </Style>
        
        <Style TargetType="Button" x:Key="style1" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Content" Value="hello"/>
        </Style>
    </Window.Resources>
    <Grid>
        <StackPanel>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
            <Button Style="{StaticResource style1}"/>
        </StackPanel>
    </Grid>
</Window>
```

![](images/006.png)

### MultiTrigger

```xaml
<MultiTrigger>
     <MultiTrigger.Conditions>
           <Condition Property="IsMouseOver" Value="True"/>
           <Condition Property="IsFocused" Value="True"/>
     </MultiTrigger.Conditions>

     <MultiTrigger.Setters>
          <Setter Property="Background" Value="Green"/>
          <Setter Property="Foreground" Value="Yellow"/>
     </MultiTrigger.Setters>
</MultiTrigger>
```

- `MultiTrigger.Conditions` 设置条件
- `MultiTrigger.Setters` 设置样式

![](images/007.png)

### DataTrigger

```xaml
<Style x:Key="style2" TargetType="{x:Type TextBox}">
            <Setter Property="Width" Value="100"/>
            <Setter Property="Height" Value="60"/>
            <Style.Triggers>
                <!--意思是绑定文本框的文本内容，当值为123时背景色为绿色-->
                <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=Self},Path=Text}" Value="123">
                    <Setter Property="Background" Value="Green"/>
                </DataTrigger>
            </Style.Triggers>
</Style>
```

- `DataTrigger` 监测数据达到条件使用特定样式

![](images/008.png)

### MultiDataTrigger

- 使用方式同`MultiTrigger`

### EventTrigger

- 某个事件发生时触发

# 控件模板

## ControlTemplate

```c#
 <ControlTemplate TargetType="{x:Type Button}">
                        <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="true">
                            <ContentPresenter x:Name="contentPresenter" Focusable="False" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="true">
                                <Setter Property="Background" TargetName="border" Value="{StaticResource Button.MouseOver.Background}"/>
                                <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource Button.MouseOver.Border}"/>
                            </Trigger>
                            <Trigger Property="IsPressed" Value="true">
                                <Setter Property="Background" TargetName="border" Value="{StaticResource Button.Pressed.Background}"/>
                                <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource Button.Pressed.Border}"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
</ControlTemplate>
```

## DataTemplate

```c#
 <ComboBox x:Name="Com" Width="200" Height="20" Margin="0 20 0 0">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Name}"></TextBlock>
                            <TextBlock Text="||"></TextBlock>
                            <TextBlock Text="{Binding Sex}"></TextBlock>
                        </StackPanel>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
```

# Bingding(绑定)

绑定的概念则侧重于: 两者的关联,协议与两者之间的影响

例子：创建一个滑块控件, 并且希望在滑动的过程中, 把值更新到另外一个静态文本上

```xaml
<Grid>
        <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
            <Slider Name="Slider" Width="200"/>
            <TextBlock Text="{Binding ElementName=Slider,Path=Value}" HorizontalAlignment="Center"/>
        </StackPanel>
    </Grid>
```

效果：

![009](images/009.png)



## 绑定的模式

- OneWay(单向绑定) : 当源属性发生变化更新目标属性
- TwoWay(双向绑定) : 当源属性发生变化更新目标属性, 目标属性发生变化也更新源属性
- OneTime(单次模式) : 根据第一次源属性设置目标属性, 在此之后所有改变都无效
- OneWayToSource : 和OneWay类型, 只不过整个过程倒置
- Default : 既可以是双向,也可以是单项, 除非明确表明某种模式, 否则采用该默认绑定

## **绑定到非元素上**

使用的绑定方式是根据元素的方式: ElementName=xxx, 如需绑定到一个非元素的对象, 则有一下几属性:

- Source : 指向一个数据源, 示例, TextBox使用绑定的方式用Source指向一个静态资源ABC

```xaml
	<Window.Resources>
        <TextBox x:Key="txt2"> ABC </TextBox>
    </Window.Resources>
    <Grid>
        <TextBox Text="{Binding Source={StaticResource txt2},Path=Text}"/>
    </Grid>
```

- RelativeSource : 使用一个名为RelativeSource的对象来根据不同的模式查找源对象

```xaml
	<!--使用RelativeSource的FindAncestor模式, 查找父元素为StackPanel的Width值-->
	<StackPanel Width="200">
        <StackPanel Width="300">
            <TextBlock Text="{Binding Path=Width,RelativeSource=
                {RelativeSource Mode=FindAncestor,AncestorType={x:Type StackPanel}}}"/>
        </StackPanel>
    </StackPanel>
```

- DataContext: 从当前的元素树向上查找到第一个非空的DataContext属性为源对象

```c#
	//后端代码
	public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Test() { Name = "小明" };
        }
    }

    public class Test
    {
        public string Name { get; set; }
    }
```

```xaml
	<!--xaml-->
	<Grid>
        <TextBlock Text="{Binding Name}"/>
    </Grid>
```

或者直接在页面申明强类型

```xaml
<Window.DataContext>
    <local:MainViewModel/>
</Window.DataContext>    
```

## DataGrid绑定

### MainViewModel

```c#
 	public class MainViewModel
    {
        public MainViewModel()
        {
            Students = new ObservableCollection<Student>();
            for (int i = 0; i < 10; i++)
            {
                Students.Add(new Student()
                {
                    Name = $"Student-{i}",
                    Sex = i % 2 == 0 ? "男" : "女"
                });
            }
        }

		//ObservableCollection  动态集合
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set => _students = value;
        }
    }
```

### MainWindow

```xaml
	<Window.DataContext>
        <local:MainViewModel></local:MainViewModel>
    </Window.DataContext>
    <Grid>
        <StackPanel>
            
            <!--AutoGenerateColumns:是否自动创建列-->
            <DataGrid ItemsSource="{Binding Students}"  AutoGenerateColumns="False" Margin="0 10 0 0 ">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="姓名" Binding="{Binding Name}"></DataGridTextColumn>
                    <DataGridTextColumn Header="性别" Binding="{Binding Sex}"></DataGridTextColumn>
</DataGrid.Columns>
            </DataGrid>


        </StackPanel>
    </Grid>
```

## 绑定命令

1. 定义方法实现Icommand

```c#
 	public class RelayCommand:ICommand
    {
        public Action Action;

        public RelayCommand(Action action)
        {
            Action = action;
        }

        /// <summary>
        /// 能不能执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 具体执行的什么
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (Action != null)
                Action();
        }

        public event EventHandler CanExecuteChanged;
    }
```

2. 在MainViewModel中定义命令GetDataCommand,并实现InotifyPropertyChanged

```c#
	public class MainViewModel:INotifyPropertyChanged
    {
        public MainViewModel()
        {
            GetDataCommand = new RelayCommand(GetData);
        }

        private void GetData()
        {
            Students = new ObservableCollection<Student>();
            for (int i = 0; i < 10; i++)
            {
                Students.Add(new Student()
                {
                    Name = $"Student-{i}",
                    Sex = i % 2 == 0 ? "男" : "女"
                });
            }
        }


        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set 
            { 	_students = value;
                OnPropertyChanged();
            }
        }


        #region 命令
        public RelayCommand GetDataCommand { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
```

3. 绑定命令

```xaml
<Button Margin="0 10 0 0" Command="{Binding GetDataCommand}" Width="40" Height="20" Content="显示"></Button>
<TextBlock Text="{Binding Name}"></TextBlock>
```

```c#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}    
```

## 对于没有Command属性的控件

1. 安装System.Windows.Interactivity.WPF包
2. 引用包`xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"`
3. 给控件绑定事件

```xaml
			<Border Width="60" Height="40" Background="Aqua" Margin="0 10 0 0">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseLeftButtonDown"><!--鼠标左击事件-->
                        <i:InvokeCommandAction Command="{Binding GetDataCommand}"></i:InvokeCommandAction>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </Border>
```

# MVVMLight

- 1.NuGet引用MVVM框架包

![](images/010.png)

引入该框架包之后, 默认会在目录下创建ViewModel层的示例代码

![](images/011.png)

- 第二步, 通过在MainViewModel中创建一些业务代码, 将其与MainWindow.xaml 通过上下文的方式关联起来, 而MainWindow则是通过Binding的写法 引用业务逻辑的部分
- 在MainViewModel中, 添加同一个班级名称, 与学生列表, 分别用于显示在文本 和列表上展示, Command则用于绑定DataGrid的双击命令上, 通过双击, 展示点击行的学生信息
- MainViewModel 继承了 ViewModelBase, 该继承的父类实在MVVM框架中, 实现双向通知的基类, 通过引用该类, 那么其之类的属性则可通过 添加 RaisePropertyChanged() 即可

```c#
	//Student类
	public class Student : ViewModelBase
    {
        private string name;
        private string age;
        private string sex;
        
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }
        public string Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged(); }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; RaisePropertyChanged(); }
        }
    }

	//MainViewModel.cs
	public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ClassName = "高二三班";
            Students = new ObservableCollection<Student>();
            Students.Add(new Student() { Name = "张三", Age = "18", Sex = "男" });
            Students.Add(new Student() { Name = "李四", Age = "19", Sex = "女" });
            Students.Add(new Student() { Name = "王二", Age = "20", Sex = "男" });
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; RaisePropertyChanged(); }
        }

        
        private RelayCommand<Student> command;
        public RelayCommand<Student> Command
        {
            get
            {
                if (command == null)
                    command = new RelayCommand<Student>((t) => Rcommand(t));
                return command;
            }
        }

        private void Rcommand(Student stu)
        {
            MessageBox.Show($"学生的姓名:{stu.Name}学生的年龄:{stu.Age}学生的性别:{stu.Sex}");
        }


        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(() => UpdateText());
                return updateCommand;
            }
        }

        private void UpdateText()
        {
            ClassName = "高三三班";
        }

    }

	//MainWindow.xaml.cs
	public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
```

- 设计UI层, 添加一个文本用于显示班级名称,  添加一个DataGrid 用于展示学生列表,  同时DataGrid中添加一个绑定的命令,MouseAction 以为触发的事件类型, CommandParameter 则是命令传递的参数, 也就是DataGrid选中的一行的类型 Student,Command 则是MainViewModel中定义的Command

```xaml
	<Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="20"/>
            <RowDefinition/>
        </Grid.RowDefinitions>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Command="{Binding UpdateCommand}" Content="刷新"/>
            <TextBlock Margin="5 0 0 0" Text="班级名称:" />
            <TextBlock Margin="5 0 0 0" Text="{Binding ClassName}"/>
        </StackPanel>

        <DataGrid Grid.Row="1" ItemsSource="{Binding Students}" AutoGenerateColumns="False">
            <DataGrid.InputBindings>
                <MouseBinding MouseAction="LeftDoubleClick"  
                                  CommandParameter="{Binding RelativeSource={RelativeSource Mode=FindAncestor, 
                        AncestorType=DataGrid}, Path=SelectedItem}"  
                                  Command="{Binding Command}"/>
            </DataGrid.InputBindings>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}"  Header="名称"/>
                <DataGridTextColumn Binding="{Binding Age}" Header="年龄"/>
                <DataGridTextColumn Binding="{Binding Sex}" Header="性别"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
```

## 注册和发送消息

```c#
		//在命令中发送消息
        Messenger.Default.Send("123","show");

		public MainWindow()
        {
            InitializeComponent();


            //在当前的页面注册一个消息
            Messenger.Default.Register<string>(this, "show", Show);
        }

        void Show(string str)
        {
            MessageBox.Show(str);
        }
```

## 如果需要发送信息且接收回调microsoft.toolkit.mvvm

将``MvvmLight`` 改为安装``microsoft.toolkit.mvvm``,``MainViewModel``继承``ObservableObject``

```c#
			//发送消息
			//回调会显示名字改成了李四
			var result = WeakReferenceMessenger.Default.Send(new Student()
            {
                Name = "张三",
                Sex = "男"
            },"show");


			//在当前的页面注册一个消息
            WeakReferenceMessenger.Default.Register<Student,string>(this, "show", (sender, arg) =>
            {
                arg.Name = "李四";
            });


			//用完要取消注册
			WeakReferenceMessenger.Default.UnregisterAll(this);

```

## 异步的Command

``IAsyncRelayCommand``

```c#
 public class MainViewModel:ObservableObject
    {
        public MainViewModel()
        {
            GetDataCommand = new AsyncRelayCommand(GetData);
        }

        private async Task GetData()
        {
            Students = new ObservableCollection<Student>();
            for (int i = 0; i < 10; i++)
            {
                Students.Add(new Student()
                {
                    Name = $"Student-{i}",
                    Sex = i % 2 == 0 ? "男" : "女"
                });
            }

            //发送消息
            var result = WeakReferenceMessenger.Default.Send(new Student()
            {
                Name = "张三",
                Sex = "男"
            },"show");


            await Task.Run(() =>
            {
                Console.WriteLine(result);
            });
        }


        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set 
            { _students = value;
                OnPropertyChanged();
            }
        }


        #region 命令
        public IAsyncRelayCommand GetDataCommand { get; set; }
        #endregion
    }
```

## DataGrid传递当前行参数

```c#
		public MainViewModel()
        {
            GetDataCommand = new AsyncRelayCommand(GetData);
            GetDataCommand2 = new RelayCommand<string>(GetData2);
        }

        private void GetData2(string m)
        {
            m = m + "s";
        }

		public RelayCommand<string> GetDataCommand2 { get; set; }
```

```xaml
DataGrid ItemsSource="{Binding Students}"  AutoGenerateColumns="False" Margin="0 10 0 0 ">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="姓名" Binding="{Binding Name}"></DataGridTextColumn>
                    <DataGridTextColumn Header="性别" Binding="{Binding Sex}"></DataGridTextColumn>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Button Content="编辑" Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type local:MainWindow}},Path=DataContext.GetDataCommand2}" CommandParameter="{Binding  Name}"></Button>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
```

# ToolKit

NuGet下载 Microsoft.Toolkit.Mvvm 

```c#
	internal class MainViewModel:ObservableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new RelayCommand(Show);
        }

        public RelayCommand ShowCommand { get; set; }


        public void Show()
        {
            Name = "点击";
            MessageBox.Show(Name);
        }
    }
```



# 调用api(可以用postman查看调用代码)

```c#
var client = new RestClient("https://localhost:44391/api/student/Login");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
request.AddParameter("UserName", "aaaaaa");
request.AddParameter("UserPwd", "12231");
IRestResponse response = client.Execute(request);




var client = new RestClient("https://localhost:44391/api/student/1");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJMb2dpbk5hbWUiOiJhYWFhYWEiLCJVc2VyUHdkIjoiMTIyMzEiLCJ0aW1lb3V0IjoiMjAyMS0wNC0yNVQwMDoyNzoyNC4zNDcyNTQ3KzA4OjAwIn0.baWyjzh52h12kdGbxaQ8ybJD2J0_Q5u1dCxw-M6Tp9E");
IRestResponse response = client.Execute(request);
```

# 装饰器

```c#
	public class TestAdorner:Adorner
    {
        public TestAdorner(UIElement adornedElement) : base(adornedElement)
        {

        }

        /// <summary>
        /// 该装饰器效果--给四个边角加圆圈
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;

            // Draw a circle at each corner.
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }
    }
```

```c#
 		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var layer = AdornerLayer.GetAdornerLayer(myBtn);//装饰层

            if (layer != null) layer.Add(new TestAdorner(myBtn)); //添加装饰器
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            var layer = AdornerLayer.GetAdornerLayer(myBtn);//装饰层

            if (layer != null)
            {
                var arr = layer.GetAdorners(myBtn); //装饰器数组
                if (arr != null)
                {
                    foreach (var item in arr)
                    {
                        layer.Remove(item);
                    }
                }
            }
        }
```

```xaml
	<Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition Height="100"></RowDefinition>
        </Grid.RowDefinitions>

        <Button Width="200" Height="40" x:Name="myBtn"></Button>
        

        <StackPanel Grid.Row="1">
            <Button Content="添加装饰效果" Width="200" Height="40" Click="ButtonBase_OnClick"></Button>
            <Button Content="移除装饰效果" Width="200" Height="40" Click="Button2_OnClick" Margin="0 10 0 0 "></Button>
        </StackPanel>

    </Grid>
```

- 效果

![](images/013.png)

![](images/012.png)

# 转换器

## 值转换器

```c#
	//实现IValueConverter
	public class IDisplayConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return  value.ToString().Equals("0")?"Yes":"No";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
```

```xaml
	<Window.Resources>
        <local:IDisplayConverter x:Key="Converter"></local:IDisplayConverter>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>

        <StackPanel>
            <TextBlock Text="0" Name="t1" FontSize="50"></TextBlock>
			<!--使用转换器-->
            <TextBlock Name="t2" FontSize="50" Text="{Binding ElementName=t1,Path=Text,Converter={StaticResource Converter}}">
            </TextBlock>
        </StackPanel>
    </Grid>
```

- 效果

![](images/014.png)

## 多值转换器

```c#
	//实现IMultiValueConverter
	public class IMultiValueDisplayConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length<3)
            {
                return null;
            }

            byte r = System.Convert.ToByte(values[0]);
            byte g = System.Convert.ToByte(values[1]);
            byte b = System.Convert.ToByte(values[2]);

            Color color = Color.FromRgb(r,g,b);

            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
```

```xaml
	<Window.Resources>
        <local:IMultiValueDisplayConverter x:Key="MultiValueDisplayConverter"></local:IMultiValueDisplayConverter>
    </Window.Resources>
    <Grid>
        <StackPanel>
            <Slider Name="Slider_R" Minimum="0" Maximum="255" Width="400" Margin="10"></Slider>
            <Slider Name="Slider_G" Minimum="0" Maximum="255" Width="400" Margin="10"></Slider>
            <Slider Name="Slider_B" Minimum="0" Maximum="255" Width="400" Margin="10"></Slider>

            <Path HorizontalAlignment="Center" Margin="321,0">
                <Path.Data>
                    <EllipseGeometry Center="80,80" RadiusX="50" RadiusY="50"></EllipseGeometry>
                </Path.Data>

                <Path.Fill>
                    <MultiBinding Converter="{StaticResource MultiValueDisplayConverter}">
                        <Binding ElementName="Slider_R" Path="Value"></Binding>
                        <Binding ElementName="Slider_G" Path="Value"></Binding>
                        <Binding ElementName="Slider_B" Path="Value"></Binding>
                    </MultiBinding>
                </Path.Fill>
            </Path>
        </StackPanel>
    </Grid>
```

- 效果

![](images/015.png)

# 行为(Behavior)

首先安装System.Windows.Interactivity.WPF

```c#
 	public class EffectBehavior:Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;

            AssociatedObject.MouseLeave += AssociatedObjectOnMouseLeave;
        }

        
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;

            AssociatedObject.MouseLeave -= AssociatedObjectOnMouseLeave;
        }
        
        private void AssociatedObjectOnMouseLeave(object sender, MouseEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element != null)
                element.Effect = (Effect)new DropShadowEffect() { Color = Colors.Transparent, ShadowDepth = 0 };
        }

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element != null)
                element.Effect = (Effect)new DropShadowEffect() { Color = Colors.Red, ShadowDepth = 0 };
        }

    }
```

```xaml
	<Window x:Class="WpfBehaviorDemo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"<!--引用命名空间-->
        xmlns:local="clr-namespace:WpfBehaviorDemo"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <StackPanel>
            
            <TextBox Width="100" Height="30" Margin="10">
                <i:Interaction.Behaviors>
                    <local:EffectBehavior></local:EffectBehavior>
                </i:Interaction.Behaviors>
            </TextBox>

            <Button Width="100" Height="30" Margin="10">
                <i:Interaction.Behaviors>
                    <local:EffectBehavior></local:EffectBehavior>
                </i:Interaction.Behaviors>
            </Button>
            
        </StackPanel>
    </Grid>
</Window>
```

# 动画

```c#
        private void BtnStart(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            //DoubleAnimation doubleAnimation = new DoubleAnimation();

            ////doubleAnimation.From = 0;//动画的起始值
            ////doubleAnimation.To = 100;//动画的结束值
            //doubleAnimation.By = 30;//代表在原有基础上增加的范围

            //doubleAnimation.Duration = TimeSpan.FromSeconds(2);//持续时间

            //doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;//一直重复

            //doubleAnimation.AutoReverse = true;//自动倒序播放

            //Storyboard.SetTarget(doubleAnimation,Btn1);
            //Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath("Width"));

            storyboard.Children.Add(CreateDoubleAnimation(Btn1,false, RepeatBehavior.Forever,"Width",30,2));
            storyboard.Children.Add(CreateDoubleAnimation(Btn2, false, new RepeatBehavior(5), "Width", 30, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn3, true, new RepeatBehavior(2), "Width", 30, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn4, true, RepeatBehavior.Forever, "Width", 30, 2));


            storyboard.Begin();

        }

        private void BtnStart1(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            ////Btn5.RenderTransform = new TranslateTransform(0, 0);//支持位移

            //Btn5.RenderTransform = new RotateTransform(0, 0, 0);//支持旋转

            //DoubleAnimation doubleAnimation = new DoubleAnimation();

            //doubleAnimation.By = 360;
            //doubleAnimation.Duration = TimeSpan.FromSeconds(2);
            //Storyboard.SetTarget(doubleAnimation, Btn5);

            //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));//(UIElement.RenderTransform).(TranslateTransform.X)
            //storyboard.Children.Add(doubleAnimation);

            //

            storyboard.Children.Add(CreateDoubleAnimation(Btn5,true,RepeatBehavior.Forever, "(UIElement.RenderTransform).(TranslateTransform.X)", 120,2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn6, false, new RepeatBehavior(2), "(UIElement.RenderTransform).(TranslateTransform.X)", 120, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn7, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 120, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn8, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 120, 2));

            storyboard.Begin();
        }

        /// <summary>
        /// 创建动画
        /// </summary>
        /// <param name="element">元素</param>
        /// <param name="autoReverse">是否自动倒序播放</param>
        /// <param name="repeatBehavior">运动类型</param>
        /// <param name="property">执行动画的属性</param>
        /// <param name="by">在原有基础上增加的范围</param>
        /// <param name="duration">持续时间</param>
        /// <returns></returns>
        private static Timeline CreateDoubleAnimation(UIElement element,bool autoReverse,RepeatBehavior repeatBehavior,string property,double by,double duration)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation doubleAnimation = new DoubleAnimation();

            doubleAnimation.From = 0;//动画的起始值
            //doubleAnimation.To = 100;//动画的结束值
            doubleAnimation.By = by;//代表在原有基础上增加的范围

            doubleAnimation.Duration = TimeSpan.FromSeconds(duration);//持续时间

            doubleAnimation.RepeatBehavior = repeatBehavior;//一直重复

            doubleAnimation.AutoReverse = autoReverse;//自动倒序播放

            Storyboard.SetTarget(doubleAnimation, element);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));

            return doubleAnimation;
        }


        private void BtnStart2(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            storyboard.Children.Add(CreateDoubleAnimation(Btn9, false, RepeatBehavior.Forever, "Opacity", 1, 2));
            storyboard.Children.Add(CreateDoubleAnimation(Btn10, false, new RepeatBehavior(5), "Opacity", 1, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn11, true, new RepeatBehavior(2), "Opacity", 1, 2));

            storyboard.Children.Add(CreateDoubleAnimation(Btn12, true, RepeatBehavior.Forever, "Opacity", 1, 2));


            storyboard.Begin();
        }
```

```xaml
    <Grid>
        <TabControl>
            <TabItem Header="大小变化">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="80"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>

                    <Button Width="120" Height="40" Content="启动" Click="BtnStart"></Button>


                    <UniformGrid Grid.Row="1" Columns="2" Rows="2">
                        <Button Width="80" Height="30" Name="Btn1"></Button>
                        <Button Width="80" Height="30" Name="Btn2"></Button>
                        <Button Width="80" Height="30" Name="Btn3"></Button>
                        <Button Width="80" Height="30" Name="Btn4"></Button>
                    </UniformGrid>

                </Grid>
            </TabItem>

            <TabItem Header="旋转移动">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="80"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>

                    <Button Width="120" Height="40" Content="启动" Click="BtnStart1"></Button>


                    <UniformGrid Grid.Row="1" Columns="2" Rows="2">
                        <Button Width="80" Height="30" Name="Btn5">
                            <Button.RenderTransform>
                                <TranslateTransform X="0" Y="0"></TranslateTransform>
                            </Button.RenderTransform>
                        </Button>
                        <Button Width="80" Height="30" Name="Btn6">
                            <Button.RenderTransform>
                                <TranslateTransform X="0" Y="0"></TranslateTransform>
                            </Button.RenderTransform>
                        </Button>
                        <Button Width="80" Height="30" Name="Btn7">
                            <Button.RenderTransform>
                                <RotateTransform Angle="0" CenterX="0" CenterY="0"></RotateTransform>
                            </Button.RenderTransform>
                        </Button>
                        <Button Width="80" Height="30" Name="Btn8">
                            <Button.RenderTransform>
                                <RotateTransform Angle="0" CenterX="0" CenterY="0"></RotateTransform>
                            </Button.RenderTransform>
                        </Button>
                    </UniformGrid>

                </Grid>
            </TabItem>

            <TabItem Header="渐变">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="80"></RowDefinition>
                        <RowDefinition></RowDefinition>
                    </Grid.RowDefinitions>

                    <Button Width="120" Height="40" Content="启动" Click="BtnStart2"></Button>


                    <UniformGrid Grid.Row="1" Columns="2" Rows="2">
                        <Button Width="80" Height="30" Name="Btn9"></Button>
                        <Button Width="80" Height="30" Name="Btn10"></Button>
                        <Button Width="80" Height="30" Name="Btn11"></Button>
                        <Button Width="80" Height="30" Name="Btn12"></Button>
                    </UniformGrid>

                </Grid>
            </TabItem>
        </TabControl>
    </Grid>
```







