   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   B >testApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:testApptestApp 5   	      testApp.OptionsView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:testApp     5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Y UXceed.Wpf.DataGrid, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5	   	     � Title$  Options��5   	    � SizeToContent$ WidthAndHeight=�6   $	��450��68   $	��400��6E    � 	Resources 5         datagridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value  transistionEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters	 M� TypeName��%A  &	        &	 �     �� 5   
   "  6&   .�5      ��  �@ AutoGenerateColumns .  64   �� 5       �@ 
IsReadOnly .  6+   �� 5       �@ CanUserAddRows . 6/   5      S� 5   
   $ 	GetValues��65   "  5       5      M� 5      $	 local:TransitionType��6   5      5      .��5      �� .@�5   
   �� $��General��6   .��5      � 
 � RowDefinitions
 5      �� 5      $��30 �6$   �� 5      $��30 �6$   �� 5      $��30 �6$   �� 5       $��30 �6$   �� 5!      $��30 �6$   �� 5"      $��30 �6$   �� 5#      $��30 �6$   �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   .+�5*      �� $��1��6   $��1q�6*    �� Orientation$ 
Horizontal=�65   .+�5+      �� -   5         ��Name$ lbl_openDefaultLocation��5+      $��Open Default Location:��6=   $��2,0,0,0q�6^   $
��Left=�6o   $	��Top=�6�   �� 5,      -   5         ��Name$ tb_openLocation��5,      $
��Auto��67   $
��Left=�6D   �� 5-      -   5         ��Name$ btn_openLocation��5-      $	��...��6k   $��30��6y   $��2q�6�   ��67   ��  �� Path$  OpenDefaultLocationCommand�6�   5.      �� 5/      $��2��6   $��1q�6*   $ 
Horizontal=�65   .+�50      �� -   5        $ lbl_saveDefaultLocation��50      $��Save Default Location:��6=   $��2,0,0,0q�6^   $
��Left=�6o   $	��Top=�6�   �� 51      -   5        $ tb_saveLocation��51      $
��Auto��67   $
��Left=�6D   �� 52      -   5        $ btn_saveLocation��52      $	��...��6k   $��30��6y   $��2q�6�   ��67   �� $  SaveDefaultLocationCommand�6�   53      �� 54      $��3��6   $��1q�6*   $ 
Horizontal=�65   .+�55      �� -   5        $ lbl_cnsweStartTime��55      $+��%CN SWE Starttime format: hh:mm:ss.ff:��68   $��2,0,0,0q�6h   $
��Left=�6y   $	��Top=�6�   �� 56      -   5        $ tb_cnsweStartTime��56      $
��Auto��69   $
��Left=�6F   57      �� 58      $��4��6   $ 
Horizontal=�6*   .+�59      �� -	   5        $ lbl_startRows��59      $��Start Rows:��63   $��2,0,0,0q�6I   $
��Left=�6Z   $	��Top=�6u   $
��Bold"�6�   5:      �� 5;      $��5��6   $��1q�6*   $ 
Horizontal=�65   .+�5<      �� -
   5        $ lbl_commercialRow��5<      $��Commercials:��67   �� 5=      -   5        $ lbl_cnsweComStartRow��5=      $��CNSWE:��6:   �� 5>      -   5        $ tb_cnsweComStartRow��5>      $
��Auto��6;   $
��Left=�6H   �� 5?      -   5        $ lbl_dcComStartRow��5?      $	��DC:��67   �� 5@      -   5        $ tb_dcComStartRow��5@      $
��Auto��68   $
��Left=�6E   �� 5A      -   5        $ lbl_tlcComStartRow��5A      $
��TLC:��68   �� 5B      -   5        $ tb_tlcComStartRow��5B      $
��Auto��69   $
��Left=�6F   �� 5C      -   5        $ lbl_tntComStartRow��5C      $
��TNT:��68   �� 5D      -   5        $ tb_tntComStartRow��5D      $
��Auto��69   $
��Left=�6F   5E      �� 5F      $��6��6   $��1q�6*   $ 
Horizontal=�65   .+�5G      �� -   5        $ lbl_scheduleRow��5G      $��	Schedule:��65   �� 5H      -   5        $ lbl_dcScheduleStartRow��5H      $	��DC:��6<   �� 5I      -   5        $ tb_dcScheduleStartRow��5I      $
��Auto��6=   $
��Left=�6J   �� 5J      -   5        $ lbl_tlcScheduleStartRow��5J      $
��TLC:��6=   �� 5K      -   5        $ tb_tlcScheduleStartRow��5K      $
��Auto��6>   $
��Left=�6K   5L      �� 5M      $��7��6   $ Vertical=�6*   .+�5N      �� -   5        $ lbl_tlcdcCondition��5N      $��TLCDC Conditions:��68   $
��Bold"�6T   �� 5O      -   5         ��Name$ tb_tlcdcCondition��5O   ;   $
��Left=�6    $��2q�6V   $	��400��6a   $����Hint! Necessary to compare Promotions. Must contain specific word. For Example: SURVIVAL. StartIdex marks the place where the special word starts and Length will mark the length of the word.��6m   $
��Wrap=�63  $��Arial)�6G  
�������
���   � J� Opacity$
 0.75Q�6�  5P      �� 5Q      $��8��6   $��1q�6*   $ 
Horizontal=�65   .+�5R      �� -   5        $ lbl_dcConditions��5R      $��DC Conditions: ��66   $
��Bold"�6P   �� 5S      -   5        $ lbl_dcConditionStartIndex��5S      $��Condition StartIndex:��6?   �� 5T      -   5        $ tb_dcConditionStartIndex��5T      $
��Auto��6�   $
��Left=�6�   ��6@   �� $ DCConditionStartIndex� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5U      -   5        $ lbl_dcConfitionLength��5U      $��Condition Length:��6;   �� 5V      -   5        $ tb_dcConfitionLength��5V      $
��Auto��6�   $
��Left=�6�   ��6<   �� $ DCConditionLength�$ PropertyChanged=�6�   �� 5W      -   5        $ lbl_dcSubStringTest��5W      $��Example Result:��69   �� 5X      -    5        $ tb_dcSubStringText��5X      $��1��6:   $��0��6G    �� TextWrapping$
 Wrap=�5Y      ��6&   �� $ DCSubStringText�$ PropertyChanged=�5Z      �� 5[      $��9��6   $��1q�6*   $ 
Horizontal=�65   .+�5\      �� -!   5        $ lbl_tlcConditions��5\      $��TLC Conditions: ��67   $
��Bold"�6R   �� 5]      -"   5        $  lbl_tlcConditionStartIndex��5]      $��Condition StartIndex:��6@   �� 5^      -#   5        $ tb_tlcConditionStartIndex��5^      $
��Auto��6�   $
��Left=�6�   ��6A   �� $ TLConditionStartIndex�$ PropertyChanged=�6�   �� 5_      -$   5        $ lbl_tlcConfitionLength��5_      $��Condition Length:��6<   �� 5`      -%   5        $ tb_tlcConfitionLength��5`      $
��Auto��6�   $
��Left=�6�   ��6=   �� $ TLCConditionLength�$ PropertyChanged=�6�   �� 5a      -&   5        $ lbl_tlcSubStringTest��5a      $��Example Result:��6:   �� 5b      -'   5        $ tb_tlcSubStringText��5b      $��1��6;   $��0��6H   $
 Wrap=�5c      ��6&   �� $ TLCSubStringText�$ PropertyChanged=�5d      �� 5e      $��10��6   $��1q�6+   $ Vertical=�66   $	��100��6M   $
��Left=�6Y   .+�5f      �� -(   5         ��Name$ cb_useTransistion��5f      $��Use Transistion��6:    d� 	IsChecked 6T   �� *UseTransistion+ �� Mode$ TwoWay=�$ PropertyChanged=��� 5g      -)   5        $" lbl_eventTransistionDuration��5g       $
��Wrap=�6F   $/��)Transistion Duration format: hh:mm:ss:ff:��6Z   �� 5h      -*   5        $! tb_eventTransistionDuration��5h   E   $	��100��6   $
��Left=�6*   {�6j   ��  �� ElementName$ cb_useTransistion��$ 	IsChecked��� 5i      -+   5        $ lbl_eventTransistion��5i      $��Transistion Type��6:   �� 5j      -,   5         ��Name$ cmb_eventTransistion��5j   F   $	��100��6   $
��Left=�6+   {�6d   �� $ cb_useTransistion��$ 	IsChecked���6�   ��  �� Source# [ 5k      �� 5l      $��11��6   $��1q�6+   $ 
Horizontal=�66   .+�5m      �� --   5        $ btn_applyOptions��5m      $��Apply Options��6e   ��68   �� $ ApplyOptionsCommand�6e   5n      5o      5p      �� 5q   
   -.   5         ��Name$ tab_tlcdcAudios��5q   )   $��TLC/DC Audios��6   .��5r      � $	��450��6   $	��400��6     � ColumnDefinitions 5s      �� 5t      $
��223* �6'   �� 5u      $
��177* �6'   
 5w      �� 5x      $
��Auto �6$   �� 5y      $
��Auto �6$   �� 5z      $	��160 �6$   �� 5{      $
��Auto �6$   .+�5}      �� $��1��6   $��1q�6*   $ 
Horizontal=�65   $��2��6N   .+�5~      �� -/   5        $ cb_useRussianAudios��5~      $��Use Russian Audios��6<    6Y   �� *UseRusAudios+$ TwoWay=�$ PropertyChanged=�5      �� 5�      $��0��6   $��1q�6*   $ 
Horizontal=�65   $��2��6N   .+�5�      �� -0   5        $ lbl_rusAudio��5�      $��Russian Audio Extension:��62   $��2,0,0,0q�6U   $
��Left=�6f   $	��Top=�6�   �� 5�      -1   5        $ tb_rusAudio��5�      $
��Auto��63   $
��Left=�6@   �� 5�      -2   5        $ lbl_estAudio��5�      $��Estonia Audio Extension:��62   $��2,0,0,0q�6U   $
��Left=�6f   $	��Top=�6�   �� 5�      -3   5        $ tb_estAudio��5�      $
��Auto��63   $
��Left=�6@   5�      �� 5�      -4   5        $��dgvStackPanel��5�      $��2��62   $��0q�6?   $��2��6J   .+�5�        -5   5          Name$ dgv_openAudios��5�      
�������#��[  6Q   $	��160��6x   
���   �   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Containing name��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *
FileName+5�      5�      �� 5�      $��3��6   $��2q�6*   $ 
Horizontal=�65   $��2��6N   .+�5�      �� -6   5        $ btn_applyAudios��5�      $��Apply Audios��6c   ��67   �� $ ApplyAudiosCommand�6c   5�      5�      5�      �� 5�   
   -7   5        $ tab_dcID��5�   !   $��DC ID��6   .��5�      � $	��450��6   $	��400��6    
 5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      �� $��0��6   $��1q�6*   $ Vertical=�65   .+�5�      �� -8   5        $ lbl_commercialReader��5�      $��For Commercial Reader:��6:   $��2,0,0,0q�6[   $
��Left=�6l   $	��Top=�6�   �� 5�      -9   5        $ cb_useFindReplace��5�      $��Use Find/Replace��6:    6U   �� *UseFindReplace+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��1��6   $��1q�6*   $ 
Horizontal=�65   .+�5�      �� -:   5        $ lbl_findWord��5�      $��
Find word:��62   $��2,0,0,0q�6G   $
��Left=�6X   $	��Top=�6s   �� 5�      -;   5        $ tb_findWord��5�      $
��Auto��63   $
��Left=�6@   �� 5�      -<   5        $ lbl_replaceWord��5�      $��Replace word:��65   $��2,0,0,0q�6M   $
��Left=�6^   $	��Top=�6y   �� 5�      -=   5        $ tb_replaceWord��5�      $
��Auto��66   $
��Left=�6C   5�      �� 5�      $��2��6   $��1q�6*   $ 
Horizontal=�65   .+�5�      �� ->   5        $ cb_useDCIDAudioExtension��5�      $��Use Audio Extension��6A    6_   �� *UseDCIDAudioExtension+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��3��6   $��1q�6*   $ 
Horizontal=�65   .+�5�      �� -?   5        $ lbl_dcIDAudioExtension��5�      $��Audio Extension:��6<   $��2,0,0,0q�6W   $
��Left=�6h   $	��Top=�6�   �� 5�      -@   5        $ tb_dcIDAudioExtension��5�      $
��Auto��6=   $
��Left=�6J   5�      �� 5�      $��4��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -A   5        $ btn_applyDCID��5�      $��Apply Changes��6_   ��65   �� $ ApplyDCIDCommand�6_   5�      5�      5�      �� 5�   
   -B   5        $ tab_sonyOptions��5�   (   $��Sony Options��6   .��5�      � $	��450��6   $	��400��6    
 5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $	��160 �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      �� $��1��6   $��1q�6*   $ 
Horizontal=�65   .+�5�      �� -C   5        $ cb_useSonyRusAudios��5�      $��Use Russian Audios��6<    6Y   �� *UseSonyRusAudios+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��0��6   $��1q�6*   $ 
Horizontal=�65   .+�5�      �� -D   5        $ lbl_SonyrusAudio��5�      $��Russian Audio Extension:��66   $��2,0,0,0q�6Y   $
��Left=�6j   $	��Top=�6�   �� 5�      -E   5        $ tb_SonyrusAudio��5�      $
��Auto��67   $
��Left=�6D   �� 5�      -F   5        $ lbl_SonyestAudio��5�      $��Estonia Audio Extension:��66   $��2,0,0,0q�6Y   $
��Left=�6j   $	��Top=�6�   �� 5�      -G   5        $ tb_SonyestAudio��5�      $
��Auto��67   $
��Left=�6D   5�      �� 5�      -H   5        $��dgvSonyStackPanel��5�      $��2��66   $��0q�6C   .+�5�        -I   5        $ dgv_openSonyAudios��5�      
�������#��[  6U   $	��160��6|   
���   � 5�        5�      $ Containing name��61    6J   �� *
FileName+5�      5�      �� 5�      $��3��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -J   5        $ btn_applySonyAudios��5�      $��Apply Audios��6k   ��6;   �� $ ApplySonyAudiosCommand�6k   5�      �� 5�      $��4��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -K   5        $��lbl_sonyComText��5�      $��Commercial Text:��63   #  Xceed.Wpf.Toolkit.ColorPicker  5�      -L   5        $��cp_sonyComText��5�   '       DisplayColorAndName  . !   ShowAdvancedButton! .  6X   5�      �� 5�      $��5��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -M   5        $��lbl_sonyComBg��5�      $��Commercial Background:��61     5�      -N   5        $��cp_sonyComBg��5�   '     . ! .  6V   5�      �� 5�      $��6��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -O   5        $��lbl_sonySponText��5�      $��Sponsor Text��64     5�      -P   5        $��cp_sonysponText��5�   '     . ! .  6Y   5�      �� 5�      $��7��6   $��2q�6*   $ 
Horizontal=�65   .+�5�      �� -Q   5        $��lbl_sonySponBg��5�      $��Sponsor Background��62     5�      -R   5        $��cp_sonysponBg��5�   '     . ! .  6W   5�      5�      5�      5�      5�      