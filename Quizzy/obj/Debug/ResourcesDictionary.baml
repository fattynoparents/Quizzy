   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      A =Quizzy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizzyQuizzy 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Quizzy.ToLowerConverter   ToLowerConverter  EllipseForButtonTemplate  �� 
TargetType A�Name  IdealForegroundColorBrush J� Opacity  WindowTitleColorBrush �� TemplatedParent �� RelativeSource �� Path ��Name J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value N� EnterActions �� 
TargetName �� TargetProperty W� From	 W� To g� Duration N� ExitActions �� 
TargetName �� Property �� Value  
GrayBrush7   CustomMetroCircleButtonStyle �� 
TargetType  MetroCircleButtonStyle �� BasedOn  SquareForButtonTemplate'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value ��Name ��Name  ControlsDisabledBrush  J� IsHitTestVisible 	 AccentColorBrush3 
 AccentColorBrush! �� 	Converter" J� OpacityMask  CustomSquareButtonStyle  SquareButtonStyle  MetroDataGridCheckBox  MetroCheckBox# �� Triggers$ �� Binding% �� AncestorType& �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Hcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      localclr-namespace:Quizzy  5      %!  &	        &	      &	 �    7  7  &	 �    7   &	     7  7 
 7  &	 �    7     5      6   �� 5      "  ��67   .R�5   
   � .+�5      A� #��z��6   $��4q�5   "   $��0��5   "   A� 5      $ 	ellipsebg��6   #���  5   "   $ 0Q�5   "   $��4q�5   "   $��0��5   "   A� 5      $ ellipse��6   $��4q�5   "   #���  5   "   #���  5   �   ��6"   �� # Z $ BorderThickness.Left�6�   �� 5      $ content��6   #��z��5   +   #��z��5   +   ��. # z 5   +   #��z��5   +   5       5    
   P� 5!      	 � ��
 .  5#      �� 5$      .��5%      �� .��5&      W� $ 	ellipsebg��6.   $ Opacity�5'   :   $ 0X�5(   :   $	 0.3X�5)   :   $ 0:0:0D�5*   :   5+      5,       5/      �� 50      .��51      �� .��52      W� $ 	ellipsebg��6.   $ Opacity�53   :   $ 0X�54   :   $ 0:0:0.5D�55   :   56      57      59      P� 5:      	 �@J�IsMouseOver
 . . �5<      �� $ ellipse��6    �@J�Opacity$ 1Q�5>   %   5?      P� 5@      	 �@J�IsMouseOver
 .  . �5B      �� $ ellipse��6    �@J�Opacity$ .5Q�5D   %   5E      P� 5F      	 � {�
 .  . �5H      �� # �  5I   %    � ��5J      5L      �� 5P      " ��5Q   
   8   .�5S   
   ��  � ��8  6%   5T      �� 5Z      "  ��66   .R�5[   
   �  5\        5]      CommonStates��. 5^        
Normal��6"     5a      	MouseOver��. 5b      �� .��5c      U� $ (UIElement.Opacity)�6<   $ MouseOverBorder��5d   E   .\�5e   "     $ 0��67   $ 1Q�5f   A   5g      U� 5n      $ (UIElement.Opacity)�6<   $ 
Background��5o   E   .\�5p   "     $ 0��67   $ 0Q�5q   A   5r      5t      5u        5v      Pressed��. 5w      �� .��5x      U� $ (UIElement.Opacity)�6<   $ PressedBorder��5y   E   .\�5z   "     $ 0��67   $ 1Q�5{   A   5|      r� 5}      $ (Border.BorderThickness)�6?   $ MouseOverBorder��5~   I   .	�5   "     $ 0��6:   $ 0q�5�   E   5�      r� 5�      $ (Border.BorderThickness)�6?   $ PressedBorder��5�   I   .	�5�   "     $ 0��6:   $ 2q�5�   E   5�      5�      5�        5�      Disabled��. 5�      �� .��5�      U� $ Opacity�6<   $ DisabledVisualElement��5�   E   .\�5�   "   �� $ 0��67   $	 0.7Q�5�   A   5�      U� 5�      $ (UIElement.Opacity)�6<   $ contentPresenter��5�   E   .\�5�   "     $ 0��67   $	 0.3Q�5�   A   5�      5�      5�      5�        5�      FocusStates��. 5�        Focused��6"     5�      	Unfocused��6"   5�        5�      ValidationStates��. 5�        	Valid��6"     5�      InvalidFocused��6"     5�      InvalidUnfocused��6"   5�      .+�5�      �� $ 
Background��6   ���	#FFCCCCCC$��1q�5�      #��z��5�      $ 1Q�5�      �� 5�      $ DisabledVisualElement��6   #���  5�   !     .  $ 0Q�5�   !   �� 5�      $ MouseOverBorder��6   ���	#FFCCCCCC$��1q�5�      #��� 	 5�      $ 0Q�5�      �� 5�      $ PressedBorder��6   #��� 
 5�      $ 0Q�5�      #��� 
 5�      �� 5�      $ contentPresenter��6   #��z��5�   )   #��z��5�   )   #��z��5�   )   ��. #��z��5�   )   ��5�   )   �� *	Content+8!   " 5�   )   Z� 5�      5�      �� 5�      " ��5�   
   8   .�5�   
   ��  � ��8  6'   �� 5�   
    � ��8  6%   5�      �� 5�      " ��5�      8   .�5�   
   ��  � ��$ 0q�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � ��$ Center=�5�      # 5�   
   �� 5�      $ 6   �� $ 
IsReadOnly� �� $% DataGridCellL�& True5�      .a�5�      ��  � {� .  5�      5�      5�      5�      