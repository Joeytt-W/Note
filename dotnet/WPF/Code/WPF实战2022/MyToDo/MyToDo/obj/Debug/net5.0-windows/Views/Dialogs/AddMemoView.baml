   M S B A M L   `   `   `  ����
  MyToDo&     MyToDo.Views.Dialogs.AddMemoView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��450��5      $	��280��6   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   ��  �� Padding$ 20,10q�5      $��添加备忘录��5      $
��Bold"�6   $��20(�6,   ]� 5   
   $��1��6   $��False��6!   .+�5      �� $
��20,0q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入备忘录概要��5      $	��Top=�64   ��5      �� *Model.Title+5   4   �� 5      $��20,10q�6   $	��100��5       �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5      $ 请输入备忘录内容��5      $	��Top=�64   ��5   &   �� *Model.Content+5   4   5      �� 5!   
   $��10q�6    �� Orientation$ 
Horizontal=�6!   $��2��6:   $��Right=�6G   .+�5"      �� $��取消��6   $��0,0,10,0q�6"       MaterialDesignOutlinedButton#��[  5$      ��5#      �� *CancelCommand+5$      �� 5%      $��确定��6   ��6'   �� *SaveCommand+5&      5'      5(      