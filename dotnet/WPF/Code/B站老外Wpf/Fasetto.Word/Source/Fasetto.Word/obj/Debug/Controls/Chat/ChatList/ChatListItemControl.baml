   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      L HFasetto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.CoreFasetto.Word.Core 5      &     Fasetto.Word.ChatListItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasetto.Word     5      Kcore:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.Core     5        � 	Resources  5         ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name  ForegroundLightBrush J� InputBindings d� MouseAction �� Command	 �Name
 � ColumnDefinitions �� 	Converter.   (Fasetto.Word.BooleanToVisiblityConverter �� ConverterParameter �� Padding,   &Fasetto.Word.StringRGBToBrushConverter �� RelativeSource �� CornerRadius  FontSizeLarge  LatoRegular �� Padding  WordBlueBrush  ForegroundDarkBrush �� Triggers �� Value �� Binding �� 
TargetName  WordVeryVeryLightBlueBrush :� RoutedEvent  WordVeryVeryLightBlue	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value��%e  &	        7  7  7  7  7  7  7  7  7  7  7  �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
background��6!   8��   5      d� 5   "   $ 	LeftClicke�6/    6G   �� *OpenMessageCommand+._�5      � $	 	container��6#   
������ 
 5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63   .+�5#      �� 
���  ��$��4��5$   %   $
��Left=�5%   %   y�5&   %   �� *NewContentAvailable+   $
 True���� 5*      $��0��6%   $
 8 15q�5+   %   ._�5.   "   �� $��40��5/   )   ��5.   )   �� *ProfilePictureRGB+   ��50   )   �� *ActualHeight+ �� *Self+ 51   )   �� *ActualHeight+ �� *Self+._�53   &   �� $��Center=�54   0   $��Center=�55   0   8�� 8�� 8�� ��53   0   �� *
Initials+58   0   5:   #   5;      �� 5>      $��1��6%   $ 0 0 15 0q�65   ._�5?   "   �� $��Center=�6-   .+�5A   &   �� $ 0 0 0 2q�5B   1   8�� $��CharacterEllipsis=�5D   1   8�� ��5A   0   �� *Name+5E   1   �� 5H   &   $ 0 2 0 0q�5I   0   8�� $��CharacterEllipsis=�5K   0   8�� ��5H   0   �� *	Message+5L   0   5O   #   5P      5R      5S       5V      �� 5X      $
 True��6I    6*   �� *
IsSelected+.a�5Y   "   �� $ 
background��6?   8   � ��6W   5Z      :� 5\      $ 
MouseEnter��6+   .[�5]   "   �� .��5^   &   �� .��5_   *   �� 8 	 $ 0:0:0.3D�6e   $ 	container��6x   $ Background.Color�6�   5`   '   5a   #   5b      :� 5c      $ 
MouseLeave��6+   .[�5d   "   �� .��5e   &   �� .��5f   *   �� $ TransparentX�69   $ 0:0:0.3D�6J   $ 	container��6]   $ Background.Color�6   5g   '   5h   #   5i      P� 5j       � {� .  . �5k   "   �� $ 	container��6?   8 
  � ��6V   5l      5o      5q      5r      5s      .��5u      �� #��[  5v      5x      