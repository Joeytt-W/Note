   M S B A M L   `   `   `  ����G  CFasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasetto.WordFasetto.Word  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   	Hoverless �� Property �� Value �� 
TargetType �� Padding  SystemIconButton �� BasedOn'   !System.Windows.Shell.WindowChrome  WindowControlButton  	BaseStyle  ForegroundMainBrush �� ScaleX	 �� Triggers
 P� Property P� Value  BackgroundLightBrush  WindowCloseButton  ForegroundLightBrush  WordOrangeBrush 	 FontSizeXXLarge 
 LatoRegular�   �Fasetto.Word.BaseAttachedProperty`2[[Fasetto.Word.IsBusyProperty, Fasetto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] ��Name �� CornerRadius J� SnapsToDevicePixels �� 	Converter.   (Fasetto.Word.BooleanToVisiblityConverter  SpinningText �� ConverterParameter �� Triggers :� RoutedEvent  WordBlue	 �� To g� Duration �� 
TargetName �� TargetProperty �� From �� 
TargetName  ForegroundDarkBrush  
TextButton  FontSizeLarge  
IconButton  WordTransparentBlueBrush  FontAwesome �� RelativeSource  WordLightBlue  WordTransparentBlue  IconGrowButton J� RenderTransformOrigin 8� X 8� Y	 W� To�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:Fasetto.Word  5        5   
   �� 5      $ Colors.xaml?�6!   �� 5      $ 
Fonts.xaml?�6!   �� 5	      $ 
Texts.xaml?�6!   %�  &	        &	 !    7   &	 �    7  7  7  &	     7  7  '�� �    7  7  7  7 	 7 
 7  7  7  7  &	 
    7  7  7  7 
 7  7  &	     7  7  7  7 	 7  7  7  7  &	 �    7  7  7  7 	 7  7  �� 5      " ��6   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��$ 0q�6,   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� # z��6   #��z��6A   ._�5      �� $��Center=�6+   $��Center=�6F   5      5      5      5      �� 5      " ��6   8   .�5   
   ��   �@  IsHitTestVisibleInChrome . 6B   �� 5    
    � ��$ 10q�6#   5"      �� 5%      " ��6   8   .�5&   
   ��   �@  IsHitTestVisibleInChrome . 6B   �� 5'   
    � ��
 ���� 6'   �� 5(   
    � ��$ 8q�6$   �� 5)   
    � ��$ Stretch=�6.   �� 5*   
    � ��8  6'   �� 5,   
    �@�LayoutTransform 5-      �� 5.      $	 1.5Q�6!   50      �� 52   
    � �� 53      �� 54      " ��6"   .R�55      �� # z��6   #��z��6A   ._�56      �� $��Center=�6$   $��Center=�6?   #��z��6\   57      58      5:      	 5<   
   P� 5=      
 �@J�IsMouseOver . . �5>      ��  � ��8  6/   5?      5B      �� 5E      " ��6   8   	 5G   
   P� 5H      
 �@J�IsMouseOver . . �5I      ��  � ��
 �  ��6/   �� 5J       � ��8  6/   5K      5N      �� 5Q      " ��6   8   .�5S   
   ��  � ��8  6'   �� 5T   
    � ��8  6'   �� 5U   
    � ��$ 0q�6,   �� 5V   
    � ��8  6%   �� 5W   
    � ��8  6'   �� 5X   
    � ��$ 50 10q�6$   �� 5Y   
    � ��$
 0 10q�6#   �� 5[   
    �@ Value .  67   �� 5]   
    � �� 5^      �� 5_      " ��6"   .R�5`      �� $ border��6   $ 10��5a      #��z��5b      #��z��5c      #��z��5d       . ._�5f      � .+�5g      �� #��z��6(   |�.  #��z��5j   $   #��z��5k   $   #��z��5l   $   #��z��5m   $   # z 5n   $   #��z��5o   $   y�5h   $   �� *local:IsBusyProperty.Value+   5o   $   �� 5q      8�� #��z��5r   $   #��z��5s   $   #��z��5t   $   y�5u   $   �� *local:IsBusyProperty.Value+   $
 True��5x      5y       5z      :� 5{      $ 
MouseEnter��6'   .[�5|      �� .��5}   "   �� .��5~   &   �� 8  $ 0:0:0.3D�6T   $ border��6g   $ Background.Color�6�   5   #   5�      5�      :� 5�      $ 
MouseLeave��6'   .[�5�      �� .��5�   "   �� .��5�   &   �� 8  $ 0:0:0.3D�6V   $ border��6i   $ Background.Color�6�   5�   #   5�      5�      P� 5�      
 � {� .  . �5�      �� $ border��6;   8   � ��6O   5�      5�      5�      5�      �� 5�      " ��6   8   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��8  6%   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 50 10q�6$   �� 5�   
    � ��$
 0 10q�6#   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ border��6   $ 10��5�      #��z��5�      #��z��5�      #��z��5�       . ._�5�      �� #��z��6$   |�.  #��z��5�   $   #��z��5�   $   #��z��5�   $   #��z��5�   $   # z 5�   $   #��z��5�   $   5�       5�      P� 5�      
 �@J�IsMouseOver . . �5�      �� 8   � ��6;   5�      P� 5�      
 � {� .  . �5�      �� 8   � ��6;   5�      5�      5�      5�      �� 5�      " ��6   8   .�5�   
   ��  � ��8  6'   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��8  6%   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 30q�6$   �� 5�   
    � ��$ 0q�6#   �� 5�   
    � �� 6"   �� *ActualHeight+ �� *Self+�� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ border��6   #��z��5�      #��z��5�      #��z��5�       . ._�5�      � .+�5�      (� .��5�   "   �� #��z��6,   |�.  #��z��5�   (   #��z��5�   (   #��z��5�   (   #��z��5�   (   # z 5�   (   #��z��5�   (   5�      5�      5�       5�      :� 5�      $ 
MouseEnter��6'   .[�5�      �� .��5�   "   �� .��5�   &   �� 8  $ 0:0:0.3D�6Y   $ border��6l   $ Background.Color�6�   5�   #   5�      5�      :� 5�      $ 
MouseLeave��6'   .[�5�      �� .��5�   "   �� .��5�   &   �� 8  $ 0:0:0.3D�6_   $ border��6r   $ Background.Color�6�   5�   #   5�      5�      P� 5�      
 � {� .  . �5�      �� $ border��6;   8   � ��6O   5�      5�      5�      5�      �� 5�      " ��6#   8   .�5�   
   ��  � ��8  6'   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��8  6%   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ 30q�6$   �� 5�   
    � ��$ 0q�6#   �� 5  
    � �� 6"   �� *ActualHeight+ �� *Self+�� 5  
    � �� 5     �� 5     " ��6"   .R�5     �� $ border��6   #��z��5     #��z��5     #��z��5	      . z�5     �� 5      5     8� 5     $	 0.5Q�6$   $	 0.5Q�6,   ._�5     � .+�5     (� .��5  "   �� #��z��6,   |�.  #��z��5  (   #��z��5  (   #��z��5  (   #��z��5  (   # z 5  (   #��z��5  (   5     5     5       5!     :� 5"     $ 
MouseEnter��6'   .[�5#     �� .��5$  "   �� .��5%  &   W� $	 1.4X�66   $ 0:0:0.15D�6?   $ border��6S   $/ )(RenderTransform).(ScaleTransform.ScaleX)�6r   W� 5&  &   $	 1.4X�66   $ 0:0:0.15D�6?   $ border��6S   $/ )(RenderTransform).(ScaleTransform.ScaleY)�6r   5'  #   5(     5)     :� 5*     $ 
MouseLeave��6'   .[�5+     �� .��5,  "   �� .��5-  &   W� $ 1X�66   $ 0:0:0.15D�6=   $ border��6Q   $/ )(RenderTransform).(ScaleTransform.ScaleX)�6p   W� 5.  &   $ 1X�66   $ 0:0:0.15D�6=   $ border��6Q   $/ )(RenderTransform).(ScaleTransform.ScaleY)�6p   5/  #   50     51     P� 52     
 � {� .  . �53     �� $ border��6;   8   � ��6O   54     56     58     59     5;     