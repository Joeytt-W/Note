   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions  5      clr-namespace:MyToDoMyToDo  5          MyToDo.Views.MainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /extclr-namespace:MyToDo.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5       localclr-namespace:MyToDo  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5        � Title$  
MainWindow��5      $
��1280��5      $	��768��5      ! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       � AllowsTransparency$
 True��5         MaterialDesignPaper#���   5      $��微软雅黑)�5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
DialogHost��5          DialogTheme$ Inherit=�6	   	   
Identifier$
	 Root��5   	   .��5   
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        
  Name$
 
drawerHost��5   $      IsLeftDrawerOpen 68   ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent 5      ]� 5       $	��220��6   .+�5!      �� $
��0,20q�6!   $	��Top=�6/   .+�5"      �� $��50��5#      $��50��5$      $��/Images/user.jpg��5%       J� Clip 5&      @� 5'   "    @� Center$ 25,25&�5(   %    @� RadiusX$ 25Q�5)   %    @� RadiusY$ 25Q�5*   %   5,      �� 5-      $
��0,10q�5.      $��Center=�5/      ��50      �� *
UserName+51      �� 53      -   5         ��Name$ menuBar��54        MyListBoxItemStyle#��[ 55      ��56      �� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 57      +  %Microsoft.Xaml.Behaviors.EventTrigger  58         	EventName$ SelectionChanged��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 59   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *NavigateCommand+   CommandParameter 5:   8   �� *SelectedItem+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ListBox5;      ��5=      �� 5>      .R�5?   "   �� 
������  �� Orientation$ 
Horizontal=�6F   .+�5@   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q�6>    	  Kind 6L   �� *Icon+�� 5A   &   $
��10,0q�60   ��6>   �� *Title+5B   #   5C      5E      5G      .��5I      �  � RowDefinitions 5J      �� 5K      $
��auto �6$   �� 5L      .+�5O      '
  !MaterialDesignThemes.Wpf.Snackbar
  -   5         
 Name$ Snackbar��5O   *     K� ZIndex$  1��6<   ! 
  MessageQueue! 6M   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  (  "MaterialDesignThemes.Wpf.ColorZone  5P      -   5        "  Name$" 	ColorZone��5Q      $��16q�5R      +  %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth2=�5S      $	��Top=�5T      $   Mode$$ 
PrimaryMid=�5U      .��5V      ]� $
��True��6    .+�5W      �� $��Right=�6%   $ 
Horizontal=�6<   .+�5X      �� -   5        % ��Name$% btnMin��5Y   !   $	��—��5Z   !    ! MaterialDesignFlatMidBgButton#��[ 5[   !   �� 5\      -   5        $% btnMax��5]   !   $	��☐��5^   !   #��[ 5_   !   �� 5`      -   5        $% btnClose��5a   !   $	��✕��5b   !   #��[ 5c   !   5d      '  !MaterialDesignThemes.Wpf.PopupBox  5f      $��Right=�62   &   ToggleContent& 5g      �� 5h   "   $��25��5i   !   $��25��5j   !   $��/Images/user.jpg��5k   !    5l   &   @� 5m   *   $ 	12.5,12.5&�5n   )   $
 12.5Q�5o   )   $
 12.5Q�5p   )   5r   #   '   PopupContent.' 5u      �� .+�5w   "   �� $��注销当前账户��6M   ��6)   �� *LoginOutCommand+6M   5x      5y      �� 5}      $ 
Horizontal=�6%   .+�5~      d� -	   5        ( d�Name$( MenuToggleButton��5   !   4  .System.Windows.Automation.AutomationProperties)   Name$) HamburgerToggleButton��5�   !   * d� 	IsChecked$* FalseY�5�   !    ' #MaterialDesignHamburgerToggleButton#��[ 5�   !   �� 5�      $��24,0,0,0q�5�   !     MaterialDesignToolButton#���  5�   !   + � ToolTip$+ Previous Item��5�   !   +  %MaterialDesignThemes.Wpf.RippleAssist,   Feedback, 5�   !   ��  �� *Self+$ 
Foreground�  BrushRoundConverter- �� 	Converter#- [ ��5�   !   �� *GoBackCommand+��5�   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  .   Kind$. 	ArrowLeft=�/   Size/ 24��5�   !   ��  �� " �$ (TextElement.Foreground)�5�   !   �� 5�      $��16,0,0,0q�5�   !   #���  5�   !   $+ 	Next Item��5�   !   , 5�   !   ��  �� *Self+$ 
Foreground�#- [ ��5�   !   �� *GoForwardCommand+��5�   !     $. 
ArrowRight=�/ 24��5�   !   ��  �� " �$ (TextElement.Foreground)�5�   !   �� 5�      $
��16,0q�5�   !   $��Center=�5�   !   $��Center=�5�   !   $%) Material Design In XAML Toolkit��5�   !   $��22(�5�   !   $��	笔记本��5�   !   5�      5�      5�      �� 5�      $��1��6!   $   MyToDo.Extensions.PrismManager0   MainViewRegionName! 	 Prism.Regions.RegionManager1   
RegionName#1 Z0 6.   5�      5�      5�      5�      