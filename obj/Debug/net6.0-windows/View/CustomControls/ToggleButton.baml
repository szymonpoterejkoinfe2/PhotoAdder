   M S B A M L   `   `   `  ����E  APhotoAdder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PhotoAdder.View.CustomControlsPhotoAdder.View.CustomControls  5      1    +PhotoAdder.View.CustomControls.ToggleButton   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:PhotoAdder.View.CustomControls     5      -   5        $��ToggleButtonControl��5	        � 	Resources  5         BorderBrushColor �� Color  ToggleAreaBackgroundColor  ToggleButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius A�Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  &	        &	 !     &	 B     7  7   7   7   �� 5   
   $ #3b82f6��63   �� 5   
   $ #BDBDBD��6<   �� 5   
   " d�6*   .�5      ��  � ��8   6+   �� 5       � ��8  6,   �� 5       � ��$ 25��6'   �� 5       � ��$ 55��6&   �� 5       � ��$ 25��6*   �� 5       � ��$ 65��6)   �� 5       � �� 5      �� 5      " d�6&   .R�5      � .+�5      �� $ Border��6%   #��z��5      $ 15��5       #��z��5!      #��z��5"      $��Center=�5#      $��Center=�5$      5%      A� 5(      $ Ellipse��6&   
�������$��25��5*      $��25��5+      $��Center=�5,      $
��Left=�5-      #��z��5.      $��3��5/      51      	 54      P� 56      
 �@d�	IsChecked$
 TrueY�6;   . �58   "   �� $ Ellipse��6)   8   � ��6N   �� 59   "   $ Ellipse��6)    � ��
 �����6P   �� 5:   "   $ Ellipse��6)    � ��$ 30,0,0,0q�6Q   5;      P� 5>      
 �@d�	IsChecked$ FalseY�6;   . �5@   "   �� $ Ellipse��6)   8   � ��6P   �� 5A   "   $ Ellipse��6)    � ��
 �����6N   �� 5B   "   $ Ellipse��6)    � ��$ 0,0,0,0q�6Q   5C      5F      5H      5I      5L      .��5N      �  � ColumnDefinitions 5O   
   �� 5P      �� 5Q      �� 5R      .+�5V   
   �� -   5        $��Option_one_name��5V   V   $��0��6   $
��Left=�6    $��Center=�6;   ���#6b7280��6�   �� *	LeftLabel+ �� ElementName$ ToggleButtonControl���� 5W   
   $��1��6   $��Center=�6#   $��Center=�6>   #���  6[    d� 	IsChecked 6�   �� *IsOn+$ ToggleButtonControl���� 5X   
   -   5        $��Option_two_name��5X   W   $��2��6   $��Right=�6    $��Center=�6<   ���#6b7280��6�   �� *
RightLabel+$ ToggleButtonControl��5Z      5[      