   M S B A M L   `   `   `  ����B  >testApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:testApptestApp  5   	       testApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:testApp     5   	     � Title$  AutomatedLists��5   	    � SizeToContent$ WidthAndHeight=�6    $	��200��6?   $	��315��6O   $	��500��6\    J� 	AllowDrop . ��.  � 
ResizeMode$ NoResize=�6�    � 	Resources 5	         buttonStyle �� 
TargetType �� Property �� Value  datagridStyle&   System.Windows.Controls.DataGrid��%8  &	        &	 l     �� 5
   
   " ��6$   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 1q�6'   5      �� 5   
   "  6&   .�5      ��  �@ AutoGenerateColumns .  64   �� 5       �@ 
IsReadOnly .  6+   �� 5       �@ CanUserAddRows . 6/   5      5      .��5      � $��5,0,0,0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   	 � ColumnDefinitions	 5   
   �� 5       $	��225 �6   �� 5!      $	��125 �6   �� 5"      $	��130 �6   �� 5#      $
��Auto �6   .+�5%   
   o� -   5        $��TopMenu��5%      
 o� 
IsMainMenu
 . $
��Left=�61   $��70��6L   $��2q�6Z   .@�5&      m� $��_File��6   .@�5'      m� $��_New...��6   .@�5(      m� -   5        $��CnSwe��5(   Y   $��_CNSWE��6    m� Command 6/   ��  �� Path$ OpenCNSWECommand�6Y   m� 5)      -   5        $	��TLC��5)   U   $
��_TLC��6    6-   �� $ OpenTLCCommand�6U   m� 5*      -   5        $��DC��5*   S   $	��_DC��6    6,   �� $ OpenDCCommand�6S   m� 5+      -   5        $
��DCID��5+   X   $��_DC ID��6    6/   �� $ OpenDCIDCommand�6X   m� 5,      -   5        $	��TNT��5,   U   $
��_TNT��6    6-   �� $ OpenTNTCommand�6U   m� 5-      -   5        $
��SONY��5-   W   $��_SONY��6    6.   �� $ OpenSONYCommand�.@�5.      m� -   5        $��SONYLVA��5.   ]   $
��_LVA��6#    61   �� $ OpenSONYLVACommand�6]   m� 5/      -	   5        $��SONYEST��5/   ]   $
��_EST��6#    61   �� $ OpenSONYESTCommand�6]   50      51      �� 52      m� 53      $��_Options��6    6-   �� $ OpenOptionsCommand�54      m� 55      $��_About��6   .@�56      m� -
   5        $��VersionInfo��56   V   $��_Info��6    6*   �� $ VersionInfoCommand�6V   57      m� 58      $��_Tools��6   .@�59      m� -   5        $��CommercialReader��59   g   $��_CommercialReader��6    66   �� $ CommercialReaderCommand�6g   5:      5;      �� 5<   
   $��1��6   $��3��6"   $��1q�66    �� Orientation$ 
Horizontal=�6A   .+�5=      �� -   5         ��Name$ lbl_formTitle��5=      $
��Left=�6+   5>      �� 5?   
   $��2��6   $��3��6"   $��1q�66   $ 
Horizontal=�6A   .+�5@      �� -   5        $ lbl_commercialFile��5@      $��Open Commercials��60   $��2,0,0,0q�6K   $
��Left=�6\   $	��Top=�6w   �� 5A      -   5        $ lbl_scheduleFile��5A      $��Open Dayschedule��6.   $��1,0,0,0q�6I   $
��Left=�6Z   $	��Top=�6u   �� 5B      -   5        $ lbl_addLogo��5B      $��Interstitals��6)   $��Center=�6@   $	��Top=�6]   $��7,0,0,0q�6u   �� 5C      -   5        $ lbl_generate��5C      $��Generate List��6*   $��Center=�6B   $	��Top=�6_   $��10,0,0,0q�6w   5D      �� 5E   
   $��3��6   $��3��6"   $��1q�66   $ 
Horizontal=�6A   .+�5F      �� -   5         ��Name$ btn_commercialFile��5F      $
��Open��6a   $	��110��6p   #��[  6|   ��61   �� $ OpenCommercialsCommand�5G      �� 5H      -   5        $ btn_scheduleFile��5H      $
��Open��6\   $	��110��6k   #��[  6w   ��6/   �� $ OpenScheduleCommand�6w   �� 5I      -   5        $ btn_Interstitals��5I      $��Interstitals��6/   $��10,0,0,0q�6w   ��6F   �� $ OpenInterstitalsCommand�6w   �� 5J      -   5        $ btn_generate��5J      $��10,0,0,0q�6T   $��Generate��6f   $��85��6y   #��[  6�   ��6+   �� $ GenerateCommand�6�   �� 5K      -   5        $ btn_date��5K      $��10,0,0,0q�6L   $
��Date��6^   $��70��6m   #��[  6x   $y�	Collapsed=�6�   ��6'   �� $ DateCommand�6�   � 5L      -   5        $��CalendarPopup��5L      ��.  .��5M      �� 
�������.+�5N      �� .��6   
Pick date:6*   (  "System.Windows.Controls.DatePicker  5O      -   5        $��listDate��5O   !      SelectedDate 61   �� $ ListDate��� 5P      $��15��6   $��8(�6U   $��0,1,0,0q�6b   ��6*   �� $ DatePickerCommand�.��6s   	Save date6~   5Q      5R      5S      �� 5T   
   -   5        $��lbStackPanel��5T      $��5��6)   $��1��66   $��3��6G   $��1q�6[   $
��Auto��6f   $
��Auto��6t   $	��315��6�   $
��Auto=�6�   .+�5U      �� -   5         ��Name$ lb_openedFiles��5U      
�������$	��160��6H   
���   �6U   5V      �� 5W   
   -   5        $��cbInterstitals��5W      $��4��6+   $��3��68   $��1q�6L   $ 
Horizontal=�6W   $y�	Collapsed=�6p   .+�5X      �� -   5        $ lbl_cnSweCB��5X      $��CN SWE:��6)   $��10(�6;   �� 5Y      -   5         ��Name$ cb_cnSwe��5Y      $��0,5,0,0q�6Z   ��6)   �� $ CnSWEInterstitalCommand�6Z   �� 5Z      -   5        $ 	lbl_tlcCB��5Z      $
��TLC:��6(   $��10(�68   �� 5[      -   5        $ cb_tlc��5[      $��0,5,0,0q�6V   ��6'   �� $ TLCInterstitalCommand�6V   �� 5\      -   5        $ lbl_dcCB��5\      $	��DC:��6&   $��10(�65   �� 5]      -    5        $ cb_dc��5]      $��0,5,0,0q�6T   ��6&   �� $ DCInterstitalCommand�6T   �� 5^      -!   5        $ 
lbl_dcIdCB��5^      $��DC IDx:��6(   $��10(�6:   �� 5_      -"   5        $ cb_dcID��5_      $��0,5,0,0q�6Y   ��6)   �� $ DCIDInterstitalCommand�6Y   5`      �� 5a   
   -#   5        $��dgvStackPanel��5a      $��6��6*   $��1��67   $��3��6H   $��1q�6\   $y�	Collapsed=�6g   .+�5b        -$   5          Name$ dgv_openedFiles��5b      
�������#��[ 6J   $	��160��6q   
���   �$��0,10,0,0q�6�      Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Header$ FileName��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 350 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
FileName+  5e      $ Duration��6)   $	 130 6;    6G   �� *
Duration+5g      5h      �� 5i   
   -%   5        $��
dgvButtons��5i      $��7��6'   $��3��64   $��1q�6H   $y�	Collapsed=�6S   .+�5j      �� -&   5        $ 	btn_Logos��5j      $��Logos��6(   $	��210��6b   $��	0,0,264,0q�6n   ��68   �� $ OpenLogosCommand�6n   �� 5k      -'   5        $ btn_Fillers��5k      $��Fillers��6*   $	��210��6h   $��264,-22,0,0q�6t   ��6<   �� $ OpenFillersCommand�6t   �� 5l      -(   5        $ btn_Save��5l      $
��Save��6'   $��2q�6g   ��66   �� $ SaveInterstitalsCommand�6g   5m      5n      5o      