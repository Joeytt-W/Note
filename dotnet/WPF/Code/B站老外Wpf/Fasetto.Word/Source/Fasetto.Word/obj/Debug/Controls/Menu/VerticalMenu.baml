   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      L HFasetto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.CoreFasetto.Word.Core 5          Fasetto.Word.VerticalMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasetto.Word     5      Kcore:clr-namespace:Fasetto.Word.Core;assembly=Fasetto.Word.Core     5      .��5	      �� 
���������5
      �� *Items+��5   
   �� 5      .R�5      � .+�5      � y�6   �� *Type+  �� 	Converter  1   +Fasetto.Word.MenuItemTypeVisiblityConverter   �� ConverterParameter$ Header��.+�5      �� $	��0.5��6!      ForegroundDarkBrush#��[  6.   �� 5        LatoRegular#��[ 5   $     FontSizeSmall#��[ 5   $    �� Padding$ 0 5 10 5q�5   $     ForegroundLightBrush#��[ 5   $   $
��Left=�5   $   #��[  5    $   ��5   $   �� *Text+5    $   5#      �� 5&      #��[ 6    �� CornerRadius$ 8��5'       �� Padding$ 5q�5(      y�5)      �� *Type+    $ TextAndIcon�� � Triggers 5,      :� 5.       :� RoutedEvent$ 
MouseEnter��6+   .[�5/   "   �� .��50   &   �� .��51   *   ��   WordBlue	 �� To# [ 69    g� Duration$ 0:0:0D�52   9   	 �� TargetProperty$	 Background.Color�53   9   �� 54   *     ForegroundLight# [ 69   $ 0:0:0D�55   9   $	 Foreground.Color�56   9   
 �� 
TargetName$

 icon��57   9   �� 59   *   # [ 69   $ 0:0:0D�5:   9   $	 Foreground.Color�5;   9   $

 text��5<   9   5>   '   5?   #   5@      :� 5B      $ 
MouseLeave��6+   .[�5C   "   �� .��5D   &   �� .��5E   *   �� # [ 69   $ 0:0:0D�5F   9   $	 Background.Color�5G   9   �� 5H   *     ForegroundDark# [ 69   $ 0:0:0D�5I   9   $	 Foreground.Color�5J   9   $

 icon��5K   9   �� 5M   *     ForegroundVeryDark# [ 69   $ 0:0:0D�5N   9   $	 Foreground.Color�5O   9   $

 text��5P   9   5R   '   5S   #   5T      ._�5X      �  � ColumnDefinitions 5Y      �� 5[   "   $
��Auto �63   �� 5]   "   $��* �63   .+�5a      �� $
��icon��6(   $ 5q�5b   (   $��Center=�5c   (     FontAwesome#��[ 5d   (   #��[  5f   (   ��5e   (   �� *Icon+  1   +Fasetto.Word.IconTypeToFontAwesomeConverter  5f   (   �� 5j      $
��text��6(   $��1��5k   (   $��5 0 5 0q�5l   (    	 ForegroundVeryDarkBrush#��[	 5m   (   #��[ 5n   (   $��Center=�5o   (   ��5p   (   �� *Text+5r      5t      5v      5x      5{      5|      