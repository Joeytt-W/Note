   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBarThumb  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels  WordDarkBlueBrush �� CornerRadius �� RelativeSource �Name	 �� Padding
 ]�Name J� IsMouseOver ]� DecreaseRepeatButton J� Opacity �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� Triggers P� Property P� Value �� PageLeftCommand �� PageRightCommand � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4   .System.Windows.Automation.AutomationProperties    AutomationId  � Cursor! �� ScrollableHeight" � Maximum# � Minimum*$ �� #ComputedVerticalScrollBarVisibility% �� ViewportHeight& �� ViewportSize' � Value( �� Mode) �� ScrollableWidth* �� Orientation,+ �� %ComputedHorizontalScrollBarVisibility, �� ViewportWidth- �� Triggers. :� RoutedEvent	/ W� To0 g� Duration1 �� 
TargetName2 �� TargetProperty�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:Fasetto.Word  5      %�  &	        7  '�� .    7   7   '�� z    �� 5      "  n�6#   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5	   
    � �� 5
      �� 5      " n�6"   .R�5      �� $ 	rectangle��6    . 8��  $ 3��5   !   #��z��5   !   #��z��5   !   5      5      5      �� 5      "  ��6   .�5   
   ��  �@��IsPressAndHoldEnabled .  69   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � ��$ 14��6"   �� 5   
    � ��$ 	-14 0 0 0q�6#   �� 5   
    � �� 6%   �� *Width+ �� *Self+�� 5   
    � �� 5      �� 5      " ��6"   .R�5       � $ Bg��6    . 
������ .+�5"      �� $		 0 4q�6!   ._�5#      ]� $
 
PART_Track��6$   ��. #{�z 5%       $��6��5&       $��Center=�5'        5(   "   �� 5)   &   $ 0Q�63   #��Z 6?    5+   "   �� 5,   &   $ 0Q�63   #��Z 6?    5.   "   n� 5/   &   8��  6,   51      52      53      54      56       57   
   P� 58       �@��Orientation$ 
Horizontal=�6-   . �59      ��  � ��$
 Auto��6*   �� 5:       � ��$ 0��6-   �� 5;       � ��$ 14��6+   �� 5<       � �� 6.   �� *Height+ �� *Self+�� 5=       � ��$ 	0 -14 0 0q�6+   �� 5?       � �� 5@      �� 5A      " ��6*   .R�5B      � $ Bg��6#    . .+�5C   "   ]� $
 
PART_Track��6(   #{�z 5D   %   $��6��5E   %    5G   &   �� 5H   *   $ 0Q�67   #��Z 6C    5J   &   �� 5K   *   $ 0Q�67   #��Z 6C    5M   &   n� 5N   *   8�� 60   5P   #   5Q      5R      5T      5U      5W      �� 5Y      "  ��6   .�5Z   
   ��  � �� 5[      �� 5\      " ��6"   .R�5]      � $
 Grid��6   #��z��6)    5^      �� 5_      $��* �6/   �� 5`      $
��Auto �6/    5b      �� 5c      $��* �6,   �� 5d      $
��Auto �6,   .+�5f      �� $ Corner��6$   $��1��64   #��� ��6D   $��1��6�   �� 5g      $! PART_ScrollContentPresenter��61   # z��6V    .   .  #��z��6�   #��z��6�   $��0��6  #��z��6.  $��0��6Q  �� 5i      $ PART_VerticalScrollBar��6$   $	 0.2Q�5j   $   $ VerticalScrollBar��5k   $   $  Arrow��5l   $   $��1��5m   $   #" z! 5n   $   $# 0Q�5o   $   $��0��5p   $   #y�z$ 5q   $   #& z% 5s   $   ' 5r   $   �� *VerticalOffset+$( OneWay=� �� *TemplatedParent+5s   $   �� 5u      $ PART_HorizontalScrollBar��6$   $	 0.2Q�5v   $   $ HorizontalScrollBar��5w   $   $  Arrow��5x   $   $��0��5y   $   #" z) 5z   $   $# 0Q�5{   $   $* 
Horizontal=�5|   $   $��1��5}   $   #y�z+ 5~   $   #& z, 5�   $   ' 5   $   �� *HorizontalOffset+$( OneWay=� �� *TemplatedParent+5�   $   5�      - 5�      :� 5�      $. 
MouseEnter��6'   .[�5�      �� .��5�   "   �� .��5�   &   W� $/ 1X�66   $0 0:0:0.3D�6=   $1 PART_VerticalScrollBar��6P   $2 Opacity�6   W� 5�   &   $/ 1X�66   $0 0:0:0.3D�6=   $1 PART_HorizontalScrollBar��6P   $2 Opacity�6�   5�   #   5�      5�      :� 5�      $. 
MouseLeave��6'   .[�5�      �� .��5�   "   �� .��5�   &   W� $	/ 0.2X�66   $0 0:0:0.3D�6?   $1 PART_VerticalScrollBar��6R   $2 Opacity�6�   W� 5�   &   $	/ 0.2X�66   $0 0:0:0.3D�6?   $1 PART_HorizontalScrollBar��6R   $2 Opacity�6�   5�   #   5�      5�      5�      5�      5�      5�      