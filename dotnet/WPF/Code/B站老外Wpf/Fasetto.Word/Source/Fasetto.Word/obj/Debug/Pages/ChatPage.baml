   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      L HFasetto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.CoreFasetto.Word.Core 5          Fasetto.Word.ChatPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasetto.Word     5      Kcore:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.Core     5      -   5           Fasetto.Word.BasePage`1   Name$
  Page��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� 
������ $��2��5       K� ZIndex$ 1��5       y�5!      �� *AnyPopupVisible+ �� 	Converter .   (Fasetto.Word.BooleanToVisiblityConverter   �� ConverterParameter$
 True�� J� InputBindings 5#      d� 5$       d� MouseAction$ 	LeftClicke�6    �� Command 67   �� *PopupClickawayCommand+5&      � 5)   
   $��50��6    � ColumnDefinitions 5+      �� 5,      $��* �6#   �� 5-      $
��Auto �6#   .+�5@      �� $��2��5A         ForegroundLightBrush#��[  5B        FontSizeXLarge#��[ 5C        LatoRegular#��[ 5D      $��Center=�5E      $��Center=�5F      ��5@      �� *DisplayTitle+5F      �� 5J      	 �� Orientation$	 
Horizontal=�6   $��1��62   .+�5M      ��   IconGrowButton#��[ 6     FontAwesomeSearchIcon#��[ 5N      ��5O      �� *OpenSearchCommand+�� 5R      #��[ 6    # FontAwesomeEllipsisVerticalIcon#��[ 6A   5S      � 5V      $��2��6   �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.AnimateSlideInFromRightMarginProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
   Value
 5W      �� *SearchIsOpen+ 5Z      �� 5[      $
��Auto �6'   �� 5\      $��* �6'   .+�5`      �� #��[ 6     FontAwesomeCloseIcon#��[ 5a        WordOrangeBrush#��[ 5c      ��5b      �� *CloseSearchCommand+5c      �� 5g      $��1��5h      
 � Tag$ Search text...��5i      $��0 5 5 5q�5l        FontSizeRegular#��[ 5m      �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.FocusProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5j      �� *SearchIsOpen+��5k      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��5n       5o      �� 5q      
 �� Key$	 Esc��6L    6%   �� *ClearSearchCommand+6L   �� 5s      $ Return��6G    6%   �� *SearchCommand+6G   .��5t   -   5u      5x      5z      )   #Fasetto.Word.ChatMessageListControl  5}   
   -   5          Name$ ChatMessageList��5~      $��1��5       � DataContext 5�      �� �� 5�   
   $��1��6   $ 2��5�      $��Bottom=�5�      $
��Left=�5�      �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.AnimateSlideInFromBottomProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5�      �� *AttachmentMenuVisible+._�5�          Fasetto.Word.BubbleContent   6"   �� *AttachmentMenu+5�      � 5�   
   $��2��6   $ 3��5�      $��50��5�      $	��114��5�      #��[  5�       5�      �� 5�      $
��Auto �6#   �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�      �� #��[ 6    	 FontAwesomePaperclipIcon#��[	 5�      $	��Top=�5�       
 ForegroundDarkBrush#��[
 5�      ��5�      �� *	MinHeight+ �� RelativeSource ��  �� AncestorType$
 GridL���5�      �� *AttachmentButtonCommand+5�      �� 5�      -   5         ��Name$ MessageText��5�      $��1��5�      $ Write a message...��5�      �   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.IsFocusedProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value . #��[ 5�      $��Center=�5�      $��0q�5�      $��
0 10 10 10q�5�       �� AcceptsReturn .  �� 
AcceptsTab . " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5�      �� *PendingMessageText+$ PropertyChanged=�5�      �� 5�      $��2��6   $	 
Horizontal=�5�      $	��Top=�5�      $��0 0 8 0q�5�      .+�5�      �� #��[ 6     FontAwesomeEmojiIcon#��[ 5�      #��[ 5�      ��5�      �� *	MinHeight+ �� $
 GridL�5�      �� 5�      $
��Send��6   $��8q�5�       �� 	IsDefault . |�.    WordGreenBrush#��[ 5�      #��[ 5�      ��5�      �� *SendCommand+5�      5�      5�      5�      5�      