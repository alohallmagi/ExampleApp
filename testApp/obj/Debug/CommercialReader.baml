   M S B A M L   `   `   `  ����B  >testApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:testApptestApp  5   	       testApp.CommercialReader   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:testApp     5   	     � Title$  CommercialReader��5   	    � SizeToContent$ WidthAndHeight=�6"   $	��300��6A   $	��300��6N    � 	Resources 5	         datagridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value��%�   &	        �� 5
   
   "  6&   .�5      ��  �@ AutoGenerateColumns .  64   �� 5       �@ 
IsReadOnly .  6+   �� 5       �@ CanUserAddRows . 6/   5      5      .��5      � .+�5   
   �� .@�5      �� -   5         ��Name$ tab_dcIDCommercialReader��5   7   $��DC ID Commercial Reader��6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� $��0��6!   $��1q�6.    �� Orientation$ 
Horizontal=�69   .+�5      �� -   5        	 ��Name$	 btn_openCommercials��5   !   $��Open Commercials��6m   ��6?   �� 
 �� Path$
 DCIDCommercialReader�6m   5      �� 5      -   5        $��lbStackPanel��5   !   $��1��65   $��0q�6B   .+�5      �� -   5         ��Name$ lbCommercialReader��5   "   5      5      5       5!      5"      5#      