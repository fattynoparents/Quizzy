   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   
 Quizzy   Quizzy.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5   	   Jcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Quizzy��5   	   $	��500��6   $	��700��6%      MainViewModel � DataContext# [  5   	     AccentColorBrush#���  5   	   $��1q�6:    � WindowStartupLocation$ CenterScreen=�6N    J� InputBindings 5      �� 5   
    �� Gesture$ Ctrl+N��6    �� Command 6&   �� *MakeNewQuizCommand+.��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   (� $��0��6   $��1��6"   .��5      � .+�5      �� $��NEW QUIZ��6   $	��160��6,   $	��160��68   $��18(�5      
�������   CustomMetroCircleButtonStyle#���  5      ��5       �� *MakeNewQuizCommand+5!      5"      5#      (� 5&   
   $��1��6   $��1��6"   .��5'      � .+�5(      �� $��OPEN FROM FILE��6   $	��160��62   $	��160��6>   $��18(�5)      
�������#���  5*      5+      5,      5-      (� 5/   
   $��2��6   $��1��6"   .��50      � .+�51      �� $
��HELP��6   $	��160��6(   $	��160��64   $��18(�52      
�������#���  53      54      55      56      58      59      