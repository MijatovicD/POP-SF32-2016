   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   C&clr-namespace:POP_SF_32_2016_GUI.UtilsPOP_SF_32_2016_GUI.Utils  5   	   4    .POP_SF_32_2016_GUI.UI.DodavanjeIzmenaNamestaja   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	   9local1&clr-namespace:POP_SF_32_2016_GUI.Utils     5   	     � Title$  DodavanjeIzmenaNamestaja��5	   	   $	��350��6*   $	��300��67    � WindowStartupLocation$ CenterScreen=�6C    � 	Resources 5
         TextBoxErrorTemplate1  +POP_SF_32_2016_GUI.Utils.ValidatorConverter  	converter��%�   &	        &	 �     �� 5   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
��� ���$
��12pt(�6H   !!!6^   �� 5      
��� � �$��1q�6-   ._�5      �� 5      5      5        5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��46* �6   �� 5      $	��46* �6   �� 5      $	��45* �6   �� 5      $	��46* �6   �� 5      $	��91* �6   �� 5      $	��45* �6    � ColumnDefinitions 5   
   �� 5       $
��106* �6   �� 5!      $
��187* �6   .+�5#   
   �� $��0��6   $��0��6   $��Naziv:��6-   $��15(�6>   �� 5$   
   -   5        $��tbNaziv��5$   <   $��0��6   $��1��6   $
��Auto��6/   ��6K   ��  �� Path$ Naziv� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5%      �� 5&      .R�5'      �� .+�5(      �� 	 ��Name$	 textBox��64   �� 5)      $��Polje ne sme biti prazno��6$   
���  ��6D   5*      5+      .��5,   (   5-      �� 5.   
   $��1��6   $��0��6   $��Cena:��6-   $��15(�6=   $��0,1,0,0q�6K   �� 5/   
   -   5        $��tbCena��5/   <   $��1��6   $��1��6   $
��Auto��6/   ��6J   �� $ JedinicnaCena� . $ PropertyChanged=�.��6�    50      �� 51      .R�52      �� .+�53      �� $	 textBox��64   �� 54      $��Greska��6$   
���  ��62   55      56      .��57   (   58      �� 59   
   $��2��6   $��0��6   $��	Kolicina:��6-   $��15(�6A   $��0,0,0,45q�6O   $��2��6a   �� 5:   
   -   5        $��
tbKolicina��5:   <   $��2��6   $��1��6   $
��Auto��6/   $��0,0,0,45q�6�   $��2��6�   ��6N   �� $ KolicinaUMagacinu� . $ PropertyChanged=�.��6�    5;      �� 5<      .R�5=      �� .+�5>      �� $	 textBox��64   �� 5?      $��Pogresan format��6$   
���  ��6;   5@      5A      .��5B   (   5C      �� 5D   
   $��3��6   $��0��6   $��Akcija:��6-   $��15(�6?   $��0,1,0,0q�6M   �� 5E   
   -   5        $��cbAkcija��5E   =   $��3��6   $��1��6    $
��Auto��60   
 �� SelectedItem
 6M   �� $ AkcijskaProdaja��� 5F   
   $��4��6   $��0��6   $
��Tip:��6-   $��15(�6<   $��0,0,0,45q�6J   �� 5G   
   -   5        $��cbTip��5G   =   $��4��6   $��1��6    $
��Auto��60   $��0,0,0,45q�6u   
 6J   �� $ TipNamestaja�6u   �� 5H   
   -   5        $��Sacuvaj��5H      $��0��6#   $
��Auto��63   $��5��6A   ��5I      �� 5J       �� 
TargetType" ��6   .�5K      ��  �� Property � {� �� Value .  62    �� Triggers 5L      ^� 5M       ^� 
Conditions 5N      �� 5O   "    �� Binding 6,   ��  �� ElementName$ tbNaziv��$ (Validation.HasError)� �� Value	 false5P   (   �� 5Q   "    6,   �� $ tbCena��$ (Validation.HasError)�	 false5R   (   �� 5S   "    6,   �� $ 
tbKolicina��$ (Validation.HasError)�	 false5T   (   .0�5V      ��  � {� . 5W      5X      5Z      5\      �� 5]   
   -   5        $��5��5]      $��Izadji��6   $��1��6/   $
��Auto��6?   6L   5^      5_      