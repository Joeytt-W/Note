   M S B A M L   `   `   `  ����F  BWpfTreeView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfTreeViewWpfTreeView  5   	       WpfTreeView.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfTreeView     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   R� -   5         R�Name$ 
FolderView��5
      ��6'   �� *Items+��5      �� 5       �� 
TargetType" Q�6   .�5      ��  �� Property �@Q�
IsExpanded �� Value 63   �� *
IsExpanded+ �� Mode$ TwoWay=�5      ��5!      �� 5"       �� ItemsSource 6+   �� *
Children+.R�5#      ��  �� Orientation$ 
Horizontal=�6!   .+�5$      �� $��20��6    $��3q�6   ��6+   �� *Type+(   "WpfTreeView.HeaderToImageConverter   	Instrance	 �� 	Converter#	 Z 6   �� 5%      $��Center=�6$   ��6?   �� *Name+5&      5'      5)      5*      5+      