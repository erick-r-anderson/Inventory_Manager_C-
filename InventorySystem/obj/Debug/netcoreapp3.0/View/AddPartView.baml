   M S B A M L   `   `   `  ����J  FInventorySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:InventorySystemInventorySystem  5      &     InventorySystem.View.AddPartView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      0local1clr-namespace:InventorySystem     5      -   5        .��5
   
   � $��0,0,3.4,12.4q�6     � RowDefinitions  5      �� 5      $	��.5* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      $	��.5* �6#   �� 5      $	��.5* �6#   �� 5      $��1* �6#   �� 5      $	��.5* �6#   �� 5      $��1* �6#   �� 5      $	��.5* �6#   .+�5      �� $��Add Part��6   $��0��6'   $��6��67   $��Center=�6K   $��0��6i   $��Center=�6v   	� 5    
   -   5         	�Name$ 	rdInHouse��5       $��In House��6*   $��1��6=   $��Center=�6M   $��1��6j   $��Center=�6w   $��2��6�    d� 	IsChecked$
 TrueY�6�    	� 	GroupName$ 
PartSource��6�   	� 5!   
   -   5        $ rdOutsourced��5!      $��
Outsourced��6-   $��3��6B   $��Center=�6R   $��1��6o   $��Center=�6|   $��2��6�   $ 
PartSource��6�   �� 5"      $��ID��6   $��1��6!   $��Right=�61   $��2��6M   $��Center=�6Z   �� 5#      -   5         ��Name$ txtId��5#      $��3��6%   $��2��69   $��2��6I    �� TextWrapping$
 Wrap=�6V   ${�False��6j   $��10.2,9.8,10.4,10.6q�6|   ��6�   �� *	NewPartId+ �� Mode$ TwoWay=��� 5$      $
��Name��6   $��1��6#   $��Right=�63   $��3��6O   $��Center=�6\   �� 5%      -   5        $ txtName��5%      $��3��6'   $��2��6;   $��3��6K   $
 Wrap=�6X   $��10.2,9.8,10.4,10.6q�6m    �� AcceptsReturn$
 True��6�   .��6�   	 =� ErrorTemplate	 5&      �� 5'      .R�5(      �� .+�5*      �� 
 ��Name$
 textBox��68   �� 5+      
���  ����6(   �� *[0].ErrorContent+6J   5,      5-      .��5.   ,   ��5/      �� 50       �� Path$ NewPartName�6   $ TwoWay=�61    �� UpdateSourceTrigger$ PropertyChanged=�6?    �� ValidationRules 51      )   #InventorySystem.TextValidationRules  52      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��69   54      .��55   !   56      �� 57      $��	Inventory��6   $��1��6(   $��Right=�68   $��4��6T   $��Center=�6a   �� 58      -   5        $ txtInv��58      $��3��6&   $��2��6:   $��4��6J   $
 Wrap=�6W   $��10.2,9.8,10.4,10.6q�6k   .��6�   	 59      �� 5:      .R�5;      �� .+�5=      �� $
 textBox��68   �� 5>      
���  ����6(   �� *[0].ErrorContent+6J   5?      5@      .��5A   ,   ��5B      �� 5C      $ NewPartStock�6   $ TwoWay=�62   $ PropertyChanged=�6@    5D      (  "InventorySystem.IntValidationRules  5E      $
 True��68   5G      .��5H       5I      �� 5J      $��Price��6   $��1��6$   $��Right=�64   $��5��6P   $��Center=�6]   �� 5K      -   5        $ txtPrice��5K      $��3��6(   $��2��6<   $��5��6L   $
 Wrap=�6Y   $��10.2,9.8,10.4,10.6q�6m   .��6�   	 5L      �� 5M      .R�5N      �� .+�5P      �� $
 textBox��68   �� 5Q      
���  ����6(   �� *[0].ErrorContent+6J   5R      5S      .��5T   ,   ��5U      �� 5V      $ NewPartPrice�6   $ TwoWay=�62   $ PropertyChanged=�6@    5W      +   %InventorySystem.DoubleValidationRules  5X      $
 True��6;   5Z      .��5[       5\      �� 5]      $	��Max��6   $��1��6"   $��Right=�62   $��6��6N   $��Center=�6[   �� 5^      -   5        $ txtMax��5^      $��2��6&   $��6��66   $
 Wrap=�6C   $��10.2,9.8,10.4,10.6q�6X   .��6u   	 5_      �� 5`      .R�5a      �� .+�5c      �� $
 textBox��68   �� 5d      
���  ����6(   �� *[0].ErrorContent+6J   5e      5f      .��5g   ,   ��5h      �� 5i      $ 
NewPartMax�6   $ TwoWay=�60   $ PropertyChanged=�6>    5j        5k      $
 True��68   5m      .��5n       5o      �� 5p      $	��Min��6   $��3��6"   $��Right=�62   $��6��6N   $��Center=�6[   �� 5q      -	   5        $ txtMin��5q      $��4��6&   $��6��66   $
 Wrap=�6C   $��10.2,9.8,10.4,10.6q�6W   .��6t   	 5r      �� 5s      .R�5t      �� .+�5v      �� $
 textBox��68   �� 5w      
���  ����6(   �� *[0].ErrorContent+6J   5x      5y      .��5z   ,   ��5{      �� 5|      $ 
NewPartMin�6   $ TwoWay=�60   $ PropertyChanged=�6>    5}        5~      $
 True��68   5�      .��5�       5�      �� 5�   
   -
   5         ��Name$ lblMachineId��5�      $��1��6&   $��Right=�66   $��7��6R   $��Center=�6_    � 	Resources 5�       �� 
TargetType �� Triggers �� Binding �� ElementName �� Value �� Property �� Value��%;  '��       �� 5�      " ��6    5�      �� 5�       6&   �� $ 	rdInHouse��$ 	IsChecked� True6`   .a�5�      ��  � ��$ 
Machine ID��68   5�      �� 5�       6&   �� $ rdOutsourced��$ 	IsChecked� True6c   .a�5�      ��  � ��$ Vendor��68   5�      5�      5�      5�      �� 5�   
   -   5        $ txtMachineID��5�      $��2��6(   $��7��68   $ WrapWithOverflow=�6E   $��10.2,9.8,9.8,10.4q�6f   .��6�   	 5�      �� 5�      .R�5�      �� .+�5�      �� $
 textBox��64   �� 5�      
���  ����6$   �� *[0].ErrorContent+6F   5�      5�      .��5�   (   ��5�      �� 5�      $ NewPartMachineId�6   $ OneWayToSource=�62   $ PropertyChanged=�6H    5�        5�      $
 True��64   5�      .��5�      ��5�      �� 5�      " ��6    5�      �� 5�       6&   �� $ rdOutsourced��$ 	IsChecked� True6c   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�       6&   �� $ 	rdInHouse��$ 	IsChecked� True6`   .a�5�      ��  � y�$ Visible=�6;   5�      5�      .��5�      5�      �� 5�   
   -   5        $ 	txtVendor��5�      $��2��6%   $��7��65   $ WrapWithOverflow=�6B   $��10.2,9.8,9.8,10.4q�6c   .��6   	 5�      �� 5�      .R�5�      �� .+�5�      �� $
 textBox��64   �� 5�      
���  ����6$   �� *[0].ErrorContent+6F   5�      5�      .��5�   (   ��5�      �� 5�      $ NewPartVendor�6   $ OneWayToSource=�6/   $ PropertyChanged=�6E    5�        5�      $
 True��65   5�      .��5�      ��5�      �� 5�      " ��6    5�      �� 5�       6&   �� $ 	rdInHouse��$ 	IsChecked� True6`   .a�5�      ��  � y�$ Hidden=�6;   5�      5�      .��5�      5�      �� 5�   
   -   5         ��Name$ btnSave��5�      $
��Save��6"   $��2��61   $
��Left=�6A   $��0.2,9.6,0,0q�6\   $��8��6q   $	��Top=�6~   $	��114��6�   $��32��6�   ��6�   �� *HandleNewPartSave+��5�      �� 5�      " ��6    5�      �� 5�       6&   �� *Text.Length+$ txtName��$ PropertyChanged=� 06�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� $ (Validation.HasError)�$ txtName��$ PropertyChanged=� True6�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� *Text.Length+$ txtInv��$ PropertyChanged=� 06   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� $ (Validation.HasError)�$ txtInv��$ PropertyChanged=� True6�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� *Text.Length+$ txtPrice��$ PropertyChanged=� 06�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� $ (Validation.HasError)�$ txtPrice��$ PropertyChanged=� True6�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� *Text.Length+$ txtMin��$ PropertyChanged=� 06   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� $ (Validation.HasError)�$ txtMin��$ PropertyChanged=� True6�   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� *Text.Length+$ txtMax��$ PropertyChanged=� 06   .a�5�      ��  � {�$ False��6:   5�      �� 5�       6&   �� $ (Validation.HasError)�$ txtMax��$ PropertyChanged=� True6�   .a�5�      ��  � {�$ False��6:   5�      5�      5�      �� 5�   
   -   5        $ 	btnCancel��5�      $��Cancel��6$   $��4��65   $
��Left=�6E   $��0.2,9.6,0,0q�6`   $��8��6u   $	��Top=�6�   $	��114��6�   $��32��6�   ��6�   �� *HandleCancel+5�      5�      