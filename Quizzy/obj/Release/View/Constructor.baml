   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  A =Quizzy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizzyQuizzy C&clr-namespace:MahApps.Metro.ConvertersMahApps.Metro.Converters    Quizzy.Constructor   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity   localclr-namespace:Quizzy  7
Converters&clr-namespace:MahApps.Metro.Converters  -     � Title$  Make a new quiz��$	��600��$	��800�� � WindowStartupLocation$ CenterOwner=�   AccentColorBrush#���   $��1q�.���  � ColumnDefinitions �� ��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� �� $
��Auto �.+��� $��0��$��50��$��5,5,5,0q�$��22(�����  �� Path$ QuestionLabel� �� UpdateSourceTrigger$ PropertyChanged=���   Quizzy.ConstValues!   QuestionFieldDefaultString*   $MahApps.Metro.Controls.TextboxHelper   	Watermark# Z $��1��$	��100��$��5,0,5,5q�$��2��$��16(� �� TextWrapping$
 Wrap=����� 	 �� Mode$	 TwoWay=�$" CurrentQuestion.QuestionBody�$ PropertyChanged=�.���� $��3��$��50��$��5,5,5,0q�$��22(�
Choices:&   System.Windows.Controls.DataGrid  $��4��$��2��$��5q�$��Stretch=�
   CanUserAddRows
 .     AutoGenerateColumns .  $��1q����	#FFCCCCCC���� $! CurrentQuestion.AnswersList� �� SelectedItem �� $$ CurrentQuestion.SelectedAnswer�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ Number�4  .System.Windows.Controls.DataGridTemplateColumn  $ Choice Text��   CellTemplate �� .R���    AnswerFieldDefaultString# Z $��40��$��16(�$	��250��$
 Wrap=�$��Center=�$��Center=����� $	 TwoWay=�$ Value�$ PropertyChanged=�.��4  .System.Windows.Controls.DataGridCheckBoxColumn    MetroDataGridCheckBox   ElementStyle# �     EditingElementStyle# �  $ 	IsCorrect�� .   �� $ 	IsCorrect�$	 TwoWay=�$ PropertyChanged=�     Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	  �� .R���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $��40��$��40��   CustomMetroCircleButtonStyle#���   � ToolTip ��  �� RelativeSource �� *FindAncestor+ �� AncestorType"  $> 8DataContext.CurrentQuestion.AddChoiceCommand.Description�����  �� *FindAncestor+"  $2 ,DataContext.CurrentQuestion.AddChoiceCommand�.���� $��20��$��20��  IdealForegroundColorBrush#���   J� OpacityMask !�  j� Stretch$
 Fill=�  
add_choice !� Visual# �  �� $��40��$��40��#���   ��  �� *FindAncestor+"  $A ;DataContext.CurrentQuestion.RemoveChoiceCommand.Description�����  �� *FindAncestor+"  $5 /DataContext.CurrentQuestion.RemoveChoiceCommand�.���� $��20��$��20��#���   !� $ Uniform=�  delete_choice# �   �� Triggers ��  �� Value$ False�� �� Binding ��  �� *FindAncestor+)
  #System.Windows.Controls.DataGridRow" 
 $ 
IsSelected�.a���   �� Property  � y�! �� Value$! 	Collapsed=��� $��5��$��2��$ 
Horizontal=�$
��Left=�$��5q�.+��� $��70��$��35��$��20(�$��0,0,0,5q�  CustomSquareButtonStyle#���  $ Go to first������ $ GoToFirstQuestionCommand�.���� $��20��$��20��#���   !� $
 Fill=�  go_to_first# [ �� $��70��$��35��$��20(�$��5,0,0,5q�#���  $ Go to previous������ $  RecoverPrevQuestionCommand�.���� $��20��$��20��#���   !� $ Uniform=�  one_step_back# [ �� $��70��$��35��$��20(�$��5,0,0,5q�#���  $ 
Go to next������ $  RecoverNextQuestionCommand�.���� $��20��$��20��#���   !� $ Uniform=� 	 one_step_forward# [	 �� $��70��$��35��$��20(�$��5,0,0,5q�#���  $ 
Go to last������ $ GoToLastQuestionCommand�.���� $��20��$��20��#���   !� $
 Fill=� 
 
go_to_last# [
 �� $��5��$��2��$ 
Horizontal=�$��Right=�.+��� $��70��$��35��$��20(�$��5,0,0,5q�$��Right=�#���  $ Save as a template������ $ SaveTemplateCommand�.���� $��20��$��20��#���   !� $
 Fill=�  save_template# [ �� $��70��$��35��$��20(�$��5,0,5,5q�$��Right=�#���  $
 Done������ $ FinishQuizCommand�.���� $��20��$��20��#���   !� $
 Fill=�  finish_quiz# [ 