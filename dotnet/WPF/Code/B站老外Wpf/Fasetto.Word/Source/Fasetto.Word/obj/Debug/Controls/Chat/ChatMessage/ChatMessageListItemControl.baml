   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      L HFasetto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.CoreFasetto.Word.Core 5      -    'Fasetto.Word.ChatMessageListItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasetto.Word     5      Kcore:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.Core     5      .��5	      ��   �� Padding$  5q�6   ._�5   
   � .+�5      �� $	��Top=�6   $
��Left=�5      $��0 7.5 0 7.5q�5      $��35��5      
��� � �   ForegroundLightBrush#��[  5      $��1q�5      y�5      �� *
SentByMe+ �� 	Converter .   (Fasetto.Word.BooleanToVisiblityConverter   �� CornerRadius 5      �� *ActualWidth+ �� RelativeSource �� *Self+��5      �� *ActualWidth+ �� *Self+._�5      �� $��Center=�5      $��Center=�5      #��[  5        LatoRegular#��[ 5      ��5      �� *
Initials+5      5       � 5#      $��	25 0 25 0q�6   ��5$      �� *
SentByMe+ /   )Fasetto.Word.SentByMeToAlignmentConverter   � Triggers 5&      :� 5)       :� RoutedEvent$ 
MouseEnter��6#   .[�5*      �� .��5+      ��  �� 
TargetName$ ExtraDetails��6)    �� TargetProperty$ Opacity�6N   .��5,   "   W� 	 W� To$ 1X�62   	 g� Duration$	 
00:00:00.5D�69   5-      5.      5/      :� 52      $ 
MouseLeave��6#   .[�53      �� .��54      �� $ ExtraDetails��6)   $ Opacity�6N   .��55   "   W� $ 0X�62   $	 
00:00:00.5D�69   56      57      58      
 � RowDefinitions
 5<      �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   .+�5B      � 
 5D      �� 5E      $
��Auto �6(   �� 5F      $
��Auto �6(   .+�5J      �� $	��Top=�5K      ��5J      �� *
SentByMe+   ._�5M      ��   SpinningText#��[ 6$   #��[  5N        �� Padding$ 20q�5O        � DataContext 5P       �� *ImageAttachment+y�5Q       �� *ImageLoaded+ 2   ,Fasetto.Word.BooleanToVisiblityGoneConverter   �� ConverterParameter$
 True�� �� FallbackValue$ 	Collapsed��5T      �� 5W      $ 10��6   $��0 0 0 15q�5X      ._�5Z      �� �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.ClipFromBorderProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value . �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.FadeInImageOnLoadProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value . $	��600��5^        5Z       �� *ImageAttachment+��5]       �� *LocalFilePath+ �� NotifyOnTargetUpdated . 5^       5a      � 5d      $��1��6   ��5e      �� *
SentByMe+   y�5f      �� *
HasMessage+   
 5h      �� 5i      $
��Auto �6,   �� 5j      $
��Auto �6,   �� 5k      $
��Auto �6,   .+�5o      �� $ 10��6!   $  15q�5p   !   ��5q   !   �� *
SentByMe+ 0   *Fasetto.Word.SentByMeToBackgroundConverter  ._�5u      �� $��Center=�6(   $
��Wrap=�5v   (   #��[ 5w   (     WordDarkBlueBrush#��[ 5x   (   ��5y   (   �� *	Message+5|      F� 5      $��1��6   
���   � K� ZIndex$ 1��5�      $��
15 -1 15 0q�5�      +����        р�� ��� � -1    �        	$��0��5�      ��5�      �� *
SentByMe+   ��5�      �� *
SentByMe+   �� 5�      -   5        $��ExtraDetails��5�   %   $��2��5�       J� Opacity$ 0Q�5�       �� Orientation$ 
Horizontal=�5�      ��5�      �� *
SentByMe+   $
 True��.+�5�      �� #��[  5�         FontSizeSmall#��[ 5�       #��[ 5�       $��0 0 15 0q�5�       ��5�   (   �� *MessageSentTime+ -   'Fasetto.Word.TimeToDisplayTimeConverter  5�       �� 5�      #��[ 5�       #��[ 5�       #��[ 5�       ��5�   (   �� *MessageReadTime+ *   $Fasetto.Word.TimeToReadTimeConverter  5�       5�      5�      5�      5�      5�      5�      5�      