   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  5      5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions  5
          MyToDo.Views.LoginView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      &localclr-namespace:MyToDo.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	      *passclr-namespace:MyToDo.Extensions  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      $	��600��5      $	��350��5      # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$	 600��6&   �� 5       � ��$	 350��6'   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@ WindowStartupLocation$ CenterScreen=�6C   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      .+�5   
   '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnakeBar��5      $��2��5        K� ZIndex$ 1��5!         MessageQueue 5"      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� 5$   
   $��50q�6   $��/Images/login.png��6   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5&   
   $��1��6    �� SelectedIndex 6*   �� *SelectIndex+	 �� FallbackValue$	 0��.@�5'      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��5(      ]� $��15q�6   $��Center=�6(   .+�5)      �� $
��0,10q�5*      $	��Top=�5+      $��22(�5,      $
��Bold"�5-      $��欢迎使用��5.      �� 50      $
��0,10q�51      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 请输入账号��52      $	��Top=�53      ��54      �� *
UserName+G� 55      $
��0,10q�56      $
 请输入密码��57      $	��Top=�59      *   $MyToDo.Extensions.PassWordExtensions   PassWord 58      �� *
PassWord+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5:      (	   "MyToDo.Extensions.PasswordBehavior	  5;      5=      �� 5?      $��Login��5A      $��登录系统��5B      $	��Top=�5C      ��5@      �� *ExecuteCommand+5C      ]� 5E      $	��0,5q�6    $��False��6-   .+�5F      �� $��注册账号��6$      Triggers 5G      +
  %Microsoft.Xaml.Behaviors.EventTrigger
  5H   "    
  	EventName$ MouseLeftButtonDown��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5I   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ ResgiterPage��6_      Command 6<   �� *ExecuteCommand+6_   5J   #   5L      �� 5M      $��Right=�6$   $��忘记密码?��6;   5N      5O      5P        5R      .��5S      ]� $��15q�6   $��Center=�6(   .+�5T      �� $
��0,10q�5U      $	��Top=�5V      $��22(�5W      $
��Bold"�5X      $��注册账号��5Y      �� 5[      $	��0,5q�5\      $
 请输入用户名��5]      $	��Top=�5^      ��5_      �� *UserDto.Account+�� 5`      $	��0,5q�5a      $
 请输入账号��5b      $	��Top=�5c      ��5d      �� *UserDto.UserName+G� 5f      $	��0,5q�5g      $
 请输入密码��5h      $	��Top=�5j       5i      �� *UserDto.PassWord+$ TwoWay=�$ PropertyChanged=� 5k      	  5l      5n      G� 5p      $	��0,5q�5q      $
 请再次输入密码��5r      $	��Top=�5t       5s      �� *UserDto.NewPassWord+$ TwoWay=�$ PropertyChanged=� 5u      	  5v      5x      �� 5z      $��Resgiter��5|      $��注册账号��5}      $	��Top=�5~      ��5{      �� *ExecuteCommand+5~      �� 5�      $
��0,10q�5�      $��Return��5�      $��返回登录��5�      $	��Top=�5�          MaterialDesignOutlinedButton#��[  5�      ��5�      �� *ExecuteCommand+5�      5�      5�      5�      5�      5�      