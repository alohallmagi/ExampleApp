   M S B A M L   `   `   `  ����@  <CNSWE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CNSWECNSWE  5   	       CNSWE.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:CNSWE     5   	     � Title$  CN SWE��5   	    � SizeToContent$ WidthAndHeight=�6   $	��200��67   $	��315��6G   $	��500��6T    J� 	AllowDrop . ��.  � 
ResizeMode$ NoResize=�6�    � 	Resources 5	         buttonStyle �� 
TargetType �� Property �� Value  datagridStyle&   System.Windows.Controls.DataGrid��%8  &	        &	 l     �� 5
   
   " ��6$   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 1q�6'   5      �� 5   
   "  6&   .�5      ��  �@ AutoGenerateColumns .  64   �� 5       �@ 
IsReadOnly .  6+   �� 5       �@ CanUserAddRows . 6/   5      5      .��5      � $��5,0,0,0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��30 �6   �� 5      $��5 �6   �� 5      $��27 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   	 � ColumnDefinitions	 5"   
   �� 5#      $	��225 �6   �� 5$      $	��125 �6   �� 5%      $	��130 �6   �� 5&      $
��Auto �6   .+�5(   
   o� -   5        $��TopMenu��5(      
 o� 
IsMainMenu
 . $
��Left=�61   $��70��6L   $��2q�6Z   .@�5)      m� $��_File��6   .@�5*      m� $��_New...��6   .@�5+      m� -   5        $��CnSwe��5+   Y   $��_CNSWE��6    m� Command 6/   ��  �� Path$ OpenCNSWECommand�6Y   m� 5,      -   5        $	��TLC��5,   U   $
��_TLC��6    6-   �� $ OpenTLCCommand�6U   m� 5-      -   5        $��DC��5-   S   $	��_DC��6    6,   �� $ OpenDCCommand�6S   5.      �� 5/      m� 50      $��_Options��6    6-   �� $ OpenOptionsCommand�m� 51      -   5        $��exitProgram��51   *   $��_Exit��6   6*   52      m� 53      $��_About��6   .@�54      m� -   5        $��VersionInfo��54   V   $��_Info��6    6*   �� $ VersionInfoCommand�6V   55      56      �� 57   
   $��1��6   $��3��6"   $��1q�66    �� Orientation$ 
Horizontal=�6A   .+�58      �� -   5         ��Name$ lbl_commercialFile��58      $��Open Commercials��60   $��2,0,0,0q�6K   $
��Left=�6\   $	��Top=�6w   �� 59      -   5        $ lbl_scheduleFile��59      $��Open Dayschedule��6.   $��1,0,0,0q�6I   $
��Left=�6Z   $	��Top=�6u   �� 5:      -	   5        $ lbl_addLogo��5:      $��Interstitals��6)   $��Center=�6@   $	��Top=�6]   $��7,0,0,0q�6u   �� 5;      -
   5        $ lbl_generate��5;      $��Generate List��6*   $��Center=�6B   $	��Top=�6_   $��10,0,0,0q�6w   5<      �� 5=   
   $��3��6   $��3��6"   $��1q�66   $ 
Horizontal=�6A   .+�5>      �� -   5         ��Name$ btn_commercialFile��5>      $
��Open��6a   $	��110��6p   #��[  6|   ��61   �� $ OpenCommercialsCommand�5?      �� 5@      -   5        $ btn_scheduleFile��5@      $
��Open��6\   $	��110��6k   #��[  6w   ��6/   �� $ OpenScheduleCommand�6w   �� 5A      -   5        $ btn_Interstitals��5A      $��Interstitals��6/   $��10,0,0,0q�6w   ��6F   �� $ OpenInterstitalsCommand�6w   �� 5B      -   5        $ btn_generate��5B      $��10,0,0,0q�6T   $��Generate��6f   $��85��6y   #��[  6�   ��6+   �� $ GenerateCommand�6�   �� 5C      -   5        $ btn_date��5C      $��10,0,0,0q�6L   $
��Date��6^   $��70��6m   #��[  6x   $y�	Collapsed=�6�   ��6'   �� $ DateCommand�6�   � 5D      -   5        $��CalendarPopup��5D      ��.  .��5E      �� 
�������.+�5F      �� .��6   
Pick date:6*   (  "System.Windows.Controls.DatePicker  5G      -   5        $��listDate��5G   !      SelectedDate 61   �� $ ListDate��� 5H      $��15��6   $��8(�6U   $��0,1,0,0q�6b   ��6*   �� $ DatePickerCommand�.��6s   	Save date6~   5I      5J      5K      �� 5L   
   -   5        $��lbStackPanel��5L      $��5��6)   $��1��66   $��3��6G   $��1q�6[   $
��Auto��6f   $
��Auto��6t   $	��315��6�   $
��Auto=�6�   .+�5M      �� -   5         ��Name$ lb_openedFiles��5M      
�������$	��160��6H   
���   �6U   5N      �� 5O   
   -   5        $��cbInterstitals��5O      $��4��6+   $��3��68   $��1q�6L   $ 
Horizontal=�6W   $y�	Collapsed=�6p   .+�5P      �� -   5        $ lbl_cnSweCB��5P      $��CN SWE:��6)   $��10(�6;   �� 5Q      -   5         ��Name$ cb_cnSwe��5Q      $��0,5,0,0q�6Z   ��6)   �� $ CnSWEInterstitalCommand�6Z   �� 5R      -   5        $ 	lbl_tlcCB��5R      $
��TLC:��6(   $��10(�68   �� 5S      -   5        $ cb_tlc��5S      $��0,5,0,0q�6V   ��6'   �� $ TLCInterstitalCommand�6V   �� 5T      -   5        $ lbl_dcCB��5T      $	��DC:��6&   $��10(�65   �� 5U      -   5        $ cb_dc��5U      $��0,5,0,0q�6T   ��6&   �� $ DCInterstitalCommand�6T   5V      �� 5W   
   -   5        $��dgvStackPanel��5W      $��6��6*   $��1��67   $��3��6H   $��1q�6\   $y�	Collapsed=�6g   .+�5X        -   5          Name$ dgv_openedFiles��5X      
�������#��[ 6J   $	��160��6q   
���   �$��0,10,0,0q�6�      Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ FileName��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 350 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
FileName+  5[      $ Duration��6)   $	 130 6;    6G   �� *
Duration+5]      5^      �� 5_   
   -   5        $��
dgvButtons��5_      $��7��6'   $��3��64   $��1q�6H   $y�	Collapsed=�6S   .+�5`      �� -   5        $ 	btn_Logos��5`      $��Logos��6(   $	��210��6b   $��	0,0,264,0q�6n   ��68   �� $ OpenLogosCommand�6n   �� 5a      -   5        $ btn_Fillers��5a      $��Fillers��6*   $	��210��6h   $��264,-22,0,0q�6t   ��6<   �� $ OpenFillersCommand�6t   �� 5b      -    5        $ btn_Save��5b      $
��Save��6'   $��2q�6g   ��66   �� $ SaveInterstitalsCommand�6g   5c      5d      5e      