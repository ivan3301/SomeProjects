   M S B A M L   `   `   `  ����E  AKursovaya2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kursovaya2
Kursovaya2  5   	       Kursovaya2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Kursovaya2     5   	     � Title$  Главное меню��5   	   $	��415��6   $	��340��6+    � 
ResizeMode$ NoResize=�67    � 	Resources 5
       �� 
TargetType   AnimGradBTN �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth	   Opacity
 �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value :� RoutedEvent �� TargetProperty �� From	 �� To g� Duration g� AutoReverse g� RepeatBehavior g� 	BeginTime��%V  &	        �� 5   
   " ��6   .�5      ��  � ��$	 105��6&   �� 5       � ��$ 40��6'   �� 5       � ��
 �   �6+   �� 5       � ��$ Italic$�6*   �� 5       �@J�Effect 5        5      $ Black��6'   $	 310Q�65   $ 8Q�6E   $		 0.4Q�6U   5      �� 5       � �� 5      �� 5      "
 ��6&   .R�5      �� $ 20��6!   #��z��63   ._�5      �� #��z��6/   #��z��6r   5      5      5       5      P� 5!       �@J�IsMouseOver .  �5"      �� 5#       � ��$ 14(�66   5%      :� 5'      $ Button.Loaded��6   [�5(      �� 5)      .��5*      �� $ Background.Color�6)   .��5+   "   �� $ 	LimeGreenX�61   $ YellowX�6B   $ 0:0:3D�6N    . $ Forever��6r   $ 0X�6�   5,      5-      5/      51      52      .��54      � .+�55   
   �� .+�56      �� $��Italic$�6   $��20(�6'   
�������$,��&Пожалуйста, выберите��6H   $��
50,25,20,0q�6h   �� 57      -   5        #��[  57      $��Студенты��6F   $��107,40,106.4,0q�6q   �� 58      -   5        #��[  58      $ ��Преподаватели��6F   $��106.7, 25, 106.7, 0q�6^   6{   �� 59      -   5        #��[  59      $��Аспиранты��6F   $��106.7, 25, 106.7, 0q�6Z   6w   �� 5:      -   5        #��[  5:      $��
Выход��6F   $��25��6V   $��70��6b   $��124,40,124,0q�6�   5;      5<      ��5>      �� 5?   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 0,1&�6/   .��5@      �  � Color$ LightSteelBlue��6    � Offset$	 0.0Q�62   � 5A      $ 
DodgerBlue��6   $	 0.4Q�6.   � 5B      $ 
DodgerBlue��6   $	 0.6Q�6.   � 5C      $ LightSteelBlue��6   $	 1.0Q�62   5D      5F      