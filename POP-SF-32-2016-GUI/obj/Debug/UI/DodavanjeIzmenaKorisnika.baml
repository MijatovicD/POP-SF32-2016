   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   4    .POP_SF_32_2016_GUI.UI.DodavanjeIzmenaKorisnika   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  DodavanjeIzmenaKorisnika��5   	   $	��300��6*   $	��300��67    � WindowStartupLocation$ CenterScreen=�6C   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6    � ColumnDefinitions 5   
   �� 5      $
��106* �6   �� 5      $
��187* �6   .+�5   
   �� $��0��6   $��0��6   $
��Ime:��6-   $��15(�6<   �� 5   
   -   5        $��tbIme��5   <   $��0��6   $��1��6   $
��Auto��6/   ��6I   ��  �� Path$	 Ime� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      ��  ��Name$ textBox��64   �� 5      $��Polje ne sme biti prazno��6$   
���  ��6D   5      5      .��5   (   5       �� 5!   
   $��1��6   $��0��6   $��Prezime:��6-   $��15(�6@   �� 5"   
   -   5        $��	tbPrezime��5"   <   $��1��6   $��1��6   $
��Auto��6/   ��6M   �� $ Prezime� . $ PropertyChanged=�.��6�    5#      �� 5$      .R�5%      �� .+�5&      �� $ textBox��64   �� 5'      $��Polje ne sme biti prazno��6$   
���  ��6D   5(      5)      .��5*   (   5+      �� 5,   
   $��2��6   $��0��6   $��Korisnicko ime:��6-   $��15(�6G   �� 5-   
   -   5        $��	tbKoriIme��5-   <   $��2��6   $��1��6   $
��Auto��6/   ��6M   �� $ KorisnickoIme� . $ PropertyChanged=�.��6�    5.      �� 5/      .R�50      �� .+�51      �� $ textBox��64   �� 52      $��Polje ne sme biti prazno��6$   
���  ��6D   53      54      .��55   (   56      �� 57   
   -   5        	 ��Name$	 	tbLozinka��57      $��1��6%   $
��Left=�65   $��45��6�   $��3��6�   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $	��186��6�   ��6P   �� $ Lozinka� . $ PropertyChanged=�.��6   58      �� 59      .R�5:      �� .+�5;      �� $ textBox��64   �� 5<      $��Polje ne sme biti prazno��6$   
���  ��6D   5=      5>      .��5?   (   5@      �� 5A   
   $��3��6   $��0��6   $��Lozinka:��6-   $��15(�6@   �� 5B   
   $��4��6   $��0��6   $��Tip korisnika:��6-   $��15(�6F   �� 5C   
   -   5        $��cbTipKorisnika��5C   =   $��4��6   $��1��6    $
��Auto��60    �� SelectedItem 6S   �� $ TipKorisnika��� 5D   
   -   5        $��Sacuvaj��5D      $��0��6#   $
��Auto��63   $��5��6A   ��5E      �� 5F       �� 
TargetType" ��6   .�5G      ��  �� Property � {� �� Value .  62    �� Triggers 5H      ^� 5I       ^� 
Conditions 5J      �� 5K   "    �� Binding 6,   ��  �� ElementName$ tbIme��$ (Validation.HasError)� �� Value	 false5L   (   �� 5M   "    6,   �� $ 	tbPrezime��$ (Validation.HasError)�	 false5N   (   �� 5O   "    6,   �� $ 	tbKoriIme��$ (Validation.HasError)�	 false5P   (   �� 5Q   "    6,   �� $ 	tbLozinka��$ (Validation.HasError)�	 false5R   (   .0�5T      ��  � {� . 5U      5V      5X      5Z      �� 5[   
   -   5        $��5��5[      $��Izadji��6   $��1��6/   $
��Auto��6?   6L   5\      5]      