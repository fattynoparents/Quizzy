   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   a ]GongSolutions.Wpf.DragDrop, Version=0.1.4.3, Culture=neutral, PublicKeyToken=d19974ea350ccea1kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop 5   	   A =Quizzy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizzyQuizzy 5	   	      Quizzy.PreviewQuiz   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   [ddLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	    localclr-namespace:Quizzy  5	   	     � Title$  Preview Quiz��5   	   $	��700��6   $	��800��6+      AccentColorBrush#���   5   	   $��1q�6:    � WindowStartupLocation$ CenterOwner=�5   V   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *CloseWindowCommand+5       � 	Resources 5        RadioBtnTemplate �� Orientation d� 	IsChecked	 �� Path  CheckboxTemplate
 �� 
TargetType  AnswersStyle �� Property �� Value �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value  QuestionsStyle��%=  &	       &	 �     &	 �    7  7  &	 y    �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      	� $��	20,0,10,5q�6   {�.   6C   �� *	IsCorrect+�� 5      $��0,0,0,5q�6   ��6-   �� $	 Value�5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��	20,0,10,5q�6   {�.   6@   �� *	IsCorrect+�� 5      $��0,0,0,5q�6   ��6-   �� $	 Value�5      5      �� 5"   
   "
 ��6   .�5#      ��  � ��8   60    5$      �� 5%       6   �� $	 DataContext.IsCheckBox� �� *FindAncestor+" �� true6�   .a�5&      ��  � ��8  68   5'      5)      �� 5+   
   "
 ��6   .�5,      ��  � ��$ 	0,10,0,10q�6'   �� 5-       � ��$ 1q�60   �� 5.       � ��# �   6,   5/      51      .��54      �  � RowDefinitions 55   
   �� 56      $
��Auto �6   �� 57      $
��Auto �6   �� 58      $
��Auto �6   �� 59      $
��Auto �6   �� 5:      �� 5;      $
��Auto �6    � ColumnDefinitions 5=   
   �� 5>      $
��Auto �6   �� 5?      .+�5C   
   �� $��0��6   $��5q�6!   $��16(�6,   $��WrapWithOverflow=�6:   $��2��6Z   $"Below is the preview of your quiz.5E      �� 5F   
   $��1��6   $��5,0,0,20q�6!   $��16(�63   $��WrapWithOverflow=�6A   $��2��6a   �You can change the title and description, and rearrange the sequence of the questions by drag-and-dropping them with the mouse.5H      �� 5L   
   $��5q�6   $��2��6   $��0��6,   $��16(�6<   $��Title: ��6J   6[   �� 5M   
   $��2��6   $��5,0,5,5q�5O      $��1��6#   $��16(�63    �� TextWrapping$
 Wrap=�5P      ��5N      ��  �� Mode$ TwoWay=�$	 Title� �� UpdateSourceTrigger$ PropertyChanged=�.��5P   &   5Q      �� 5S   
   $��5q�6   $��3��6   $��0��6,   $��16(�6<   $��Description: ��6J   6a   �� 5T   
   $��3��6   $��5,0,5,5q�5V      $��1��6#   $��16(�63   $
 Wrap=�5W      ��5U      �� $ TwoWay=�$	 Description�$ PropertyChanged=�.��5W   &   5X      �� 5Z   
   $��4��6   $��2��6    $��0q�5[   =   $��5q�6Q   $��Disabled=�5\      $��14(�6I   #��[ 5]      )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDragSource .    IsDropTarget . ��5[      �� $	 AllQuestions�   DropHandler 5`      ��  5a       �� Color��%  (��       5b   "   * SystemColors.HighlightBrushKey+)(�� %     5c   "   *SystemColors.ControlBrushKey+)(�� J     5d   "   *$"SystemColors.HighlightTextBrushKey+)�� 5b      $ Transparent��6T   �� 5c      $ Transparent��6R   �� 5d      $ Black��6X   5e      ��5g      �� 5h      .R�5i      �  5j      �� 5k      $
��Auto �6,   �� 5l       5n      �� 5o      $
��Auto �6/   �� 5p      $��5 �6/   �� 5q      $��* �6/   .+�5t      �� $ 
Horizontal=�6%   .+�5u      �� $��0��6(   $��0��65    �� Padding$ 3q�6j   $��0,0,10,5q�6v   ��6E   �� $	 QuestionNumber�6�   �� 5v      $��0��6(   $��2��65   $
��Wrap=�6h   $ 3q�6|   $��0,0,0,5q�6�   ��6E   �� $	 QuestionBody�6�   5w      �� 5y      $��1��6#   $��2��60   $��0q�6m   #��[ 5z   %   ��5y   D   �� $	 AnswersList� 5{      ��%  (��       5|   2   * SystemColors.HighlightBrushKey+)(�� %     5}   2   *SystemColors.ControlBrushKey+)(�� J     5~   2   *$"SystemColors.HighlightTextBrushKey+)�� 5|   "   $ Transparent��6d   �� 5}   "   $ Transparent��6b   �� 5~   "   $ Black��6h   5      5�      5�      5�      5�      �� 5�   
   $��5��6   $ 
Horizontal=�6"   $��Right=�6;   $��2��6W   .+�5�      �� $��70��6   $��35��6#   $��20(�6/   $��5,0,5,5q�6=   $��Right=�5�        CustomSquareButtonStyle#���  61    � ToolTip$$ Save the quiz as an executable��6c   ��5�      �� $	 CreateExeCommand�.��5�      �� $��20��6   $��20��5�         IdealForegroundColorBrush#���  5�        J� OpacityMask 5�      !� 5�       j� Stretch$
 Fill=�6&     save_exe !� Visual# [ 5�   *   5�      5�      �� 5�      -   5        $��70��5�      $��35��6#   $��20(�6/   $��5,0,5,5q�6=   $��Right=�5�      #���  61   $ Cancel��6c     �� IsCancel  . .��5�      �� $��20��6   $��20��5�       #���  5�        5�      !� 5�      $
 Fill=�6&    
 cancel# [ 5�   *   5�      5�      5�      5�      5�      