   M S B A M L   `   `   `  ����E  AKursovaya2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kursovaya2
Kursovaya2  5   	   !    Kursovaya2.GraduateStudents   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Kursovaya2     5   	     � Title$  Аспиранты��5   
   $	��415��6   $	��554��6)    � 
ResizeMode$ NoResize=�65    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value&   System.Windows.Controls.DataGrid :� RoutedEvent �� TargetProperty	 W� To��%-  '��       '  �    �� 5
   
   " ��6   .�5      ��  � ��$ 70��6&   �� 5       � ��$ 20��6'   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 7��6!   #��z��62   $��2q�6\   
����=H�._�5      �� #��z��6/   #��z��6r   5      5      5       5      P� 5      	 �@J�IsMouseOver
 .  �5      �� 5       � ��$ 75��62   �� 5       � ��$ 25��63   �� 5       � ��
 ��İ�67   5!      P� 5$      	 � ��
 .  �5%      �� 5&       � ��$ 68��62   �� 5'       � ��$ 18��63   �� 5(       � ��
 �����67   5*      5-      �� 5/   
   "  6    51      :� 52      $ 
MouseEnter��6   .[�53      �� .��54      �� .��55      W� $  Effect.(BlurEffect.Radius)�6.   $ 0X�6e   56      57      58      :� 59      $ 
MouseLeave��6   .[�5:      �� .��5;      �� .��5<      W� $  Effect.(BlurEffect.Radius)�6.   5=      5>      5?      5A      5B      .��5D      � .+�5E   
     -   5          Name$
 grid��5E      $
��Left=�6!   $	��220��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��519��6t      AutoGenerateColumns .     Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Статус��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 95 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ status�6U     5H      $ ФИО��6%   $	 100 6O    62   �� $	 fio�6O     5I      $4 .Дата рождения (мм/дд/гггг)��6%   $	 100 6|    6I   �� $	 DOB� �� StringFormat$ {0:d}��6|     5J      $! Время обучения��6%   $	 105 6_    6=   �� $ StudTime�6_     5K      $# Тема дисертации��6%   $	 110 6]    6>   �� $ Topic�6]    J� Effect 5M      -  'System.Windows.Media.Effects.BlurEffect  5N         Radius$ 6Q�6   5P      �� 5R   
   -   5        $��Добавить��5R      $��149,254,256,87q�6$   6q   �� 5S   
   -   5        $��Обновить��5S      $��240,254,166,87q�6$   6m   �� 5T   
   -   5        $��Сохранить��5T      $��149,302,256,40q�6%   6q   �� 5U   
   -   5        $��Закрыть��5U      $��240,302,166,40q�6#   6q   �� 5W   
   -   5        $��SBarStud��5W   =   $��	0,350,0,0q�6   
�������.@�5X      �� $�� ��6   �� 5Y      .��5Z      �� -   5        $��	CursorPos��5Z      5[      5\      5^      ��5`      �� 5a   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 0,1&�6/   .��5b      �  � Color$ LightSteelBlue��6    � Offset$
 0.57Q�62   � 5c      $ Cornsilk��6   $	 1.0Q�6,   5d      5f      