   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   A =Quizzy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizzyQuizzy 5   	   C&clr-namespace:MahApps.Metro.ConvertersMahApps.Metro.Converters 5	   	      Quizzy.Constructor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	    localclr-namespace:Quizzy  5   	   7
Converters&clr-namespace:MahApps.Metro.Converters  5	   	     � Title$  Make a new quiz��5   	   $	��600��6!   $	��800��6.    � WindowStartupLocation$ CenterOwner=�6:      AccentColorBrush#���   5   	   $��1q�6:   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *CloseWindowCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5!   
   �� $��0��6   $��50��6!   $��5,5,5,0q�60   $��22(�6A   ��6O   ��  �� Path$ QuestionLabel�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5$   
     Quizzy.ConstValues!
   QuestionFieldDefaultString*   $MahApps.Metro.Controls.TextboxHelper   	Watermark# Z
 6   $��1��5&      $	��100��6   $��5,0,5,5q�6/   $��2��6@   $��16(�6T    �� TextWrapping$
 Wrap=�5'      ��5%      ��  �� Mode$ TwoWay=�$" CurrentQuestion.QuestionBody�$	 PropertyChanged=�.��5(      5)      �� 5+   
   $��3��6   $��50��6!   $��5,5,5,0q�60   $��22(�6A   
Choices:6Y   &   System.Windows.Controls.DataGrid  5-   
   $��4��6   $��2��6    $��5q�64   $��Stretch=�5.   P      CanUserAddRows .     AutoGenerateColumns .  $��1q�6�   ���	#FFCCCCCC��5-   ?   �� $! CurrentQuestion.AnswersList� �� SelectedItem 5.      �� $$ CurrentQuestion.SelectedAnswer�   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  52      ,	  &System.Windows.Controls.DataGridColumn 	  Header$	 No.��6%    	  
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 62   �� $ Number�6R   4  .System.Windows.Controls.DataGridTemplateColumn  55      $ Choice Text��6)      CellTemplate 56      �� 57      .R�58      ��    AnswerFieldDefaultString# Z 6&   $��40��5<   %   $��16(�64   $	��250��6B   $
 Wrap=�5=   %   $��Center=�5>   %   $��Center=�5?   %   ��59   %   �� $ TwoWay=�$ Value�$	 PropertyChanged=�.��5?   B   5@      5B      5D      4  .System.Windows.Controls.DataGridCheckBoxColumn  5F        MetroDataGridCheckBox 
  ElementStyle# �  6)    
  EditingElementStyle# �  5G   )   $ 	IsCorrect��5H   )    .   5J   )   �� $ 	IsCorrect�$ TwoWay=�$	 PropertyChanged=�  5L       	  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)    5M      �� 5N      .R�5P      ��  �� Orientation$ 
Horizontal=�6)   $��Right=�6B   .+�5Q   "   �� $��40��6)   $��40��5R   %      CustomMetroCircleButtonStyle#���  5S   %    � ToolTip 5T   %   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType"  $> 8DataContext.CurrentQuestion.AddChoiceCommand.Description���5U   %   ��  �� *FindAncestor+"  $2 ,DataContext.CurrentQuestion.AddChoiceCommand�.��5W   &   �� $��20��60   $��20��5X   -     IdealForegroundColorBrush#���  5Y   -    J� OpacityMask 5[   *   !� 5\   .    j� Stretch$
 Fill=�6:     
add_choice  !� Visual#  �  6I   5^   '   5_   #   �� 5a   "   $��40��6)   $��40��5b   %   #���  5c   %    5d   %   ��  �� *FindAncestor+"  $A ;DataContext.CurrentQuestion.RemoveChoiceCommand.Description���5e   %   ��  �� *FindAncestor+"  $5 /DataContext.CurrentQuestion.RemoveChoiceCommand�.��5f   &   �� $��20��60   $��20��5g   -   #���  5h   -    5i   *   !� 5j   .   $ Uniform=�6:     delete_choice#  �  6L   5l   '   5m   #   5n      ! �� Triggers! 5p      �� 5q   "   " �� Value$" False��6�   # �� Binding# 6.   ��  �� *FindAncestor+)  #System.Windows.Controls.DataGridRow"  $ 
IsSelected�.a�5r   &   �� $ �� Property$ � y�% �� Value$% 	Collapsed=�6C   5s   #   5v      5y      5~      �� 5�   
   $��5��6   $��2��6"   $ 
Horizontal=�66   $
��Left=�6O   $��5q�6j   .+�5�      �� $��70��6   $��35��6#   $��20(�6/   $��0,0,0,5q�6=     CustomSquareButtonStyle#���  6N   $ Go to first��6�   ��5�      �� $ GoToFirstQuestionCommand�.��5�      �� $��20��6   $��20��5�      #���  5�       5�      !� 5�      $
 Fill=�6&     go_to_first#  [ 5�   &   5�      5�      �� 5�      $��70��6   $��35��6#   $��20(�6/   $��5,0,0,5q�6=   #���  6N   $ Go to previous��6�   ��5�      �� $  RecoverPrevQuestionCommand�.��5�      �� $��20��6   $��20��5�      #���  5�       5�      !� 5�      $ Uniform=�6&     one_step_back#  [ 5�   &   5�      5�      �� 5�      $��70��6   $��35��6#   $��20(�6/   $��5,0,0,5q�6=   #���  6N   $ 
Go to next��6�   ��5�      �� $  RecoverNextQuestionCommand�.��5�      �� $��20��6   $��20��5�      #���  5�       5�      !� 5�      $ Uniform=�6&    	 one_step_forward#  [	 5�   &   5�      5�      �� 5�      $��70��6   $��35��6#   $��20(�6/   $��5,0,0,5q�6=   #���  6N   $ 
Go to last��6�   ��5�      �� $ GoToLastQuestionCommand�.��5�      �� $��20��6   $��20��5�      #���  5�       5�      !� 5�      $
 Fill=�6&    
 
go_to_last#  [
 5�   &   5�      5�      5�      �� 5�   
   $��5��6   $��2��6#   $ 
Horizontal=�67   $��Right=�6P   .+�5�      �� $��70��6   $��35��6#   $��20(�6/   $��5,0,0,5q�6=   $��Right=�5�      #���  61   $ Save as a template��6c   .��5�      �� $��20��6   $��20��5�       #���  5�        5�      !� 5�      $
 Fill=�6&     save_template#  [ 5�   *   5�      5�      �� 5�      $��70��6   $��35��6#   $��20(�6/   $��5,0,5,5q�6=   $��Right=�5�      #���  61   $
 Done��6c   ��5�      �� $ FinishQuizCommand�.��5�      �� $��20��6   $��20��5�       #���  5�        5�      !� 5�      $
 Fill=�6&     finish_quiz#  [ 5�   *   5�      5�      5�      5�      5�      