   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   8    2POP_SF_32_2016_GUI.UI.DodavanjeIzmenaTipaNamestaja   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$"  DodavanjeIzmenaTipaNamestaja��5   	   $��92��6.   $	��274��6:    � WindowStartupLocation$ CenterScreen=�6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��35* �6   �� 5      $	��61* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6   $��Naziv:��6-   $��15(�6>   �� 5   
   -   5        $��tbNaziv��5   <   $��0��6   $��1��6   $
��Auto��6/   ��6K   ��  �� Path$ Naziv� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      ��  ��Name$ textBox��64   �� 5      $��Polje ne sme biti prazno��6$   
���  ��6D   5      5      .��5   (   5      �� 5   
   -   5        $��Sacuvaj��5      $��0��6#   $
��Auto��63   $��1��6A   ��5      �� 5      	 �� 
TargetType"	 ��6   .�5       �� 
 �� Property
 � {� �� Value .  62    �� Triggers 5!      ^� 5"       ^� 
Conditions 5#      �� 5$   "    �� Binding 6,   ��  �� ElementName$ tbNaziv��$ (Validation.HasError)� �� Value	 false5%   (   .0�5'      �� 
 � {� . 5(      5)      5+      5-      �� 5.   
   -   5        $��1��5.      $��Izadji��6   $��1��6/   $
��Auto��6?   6L   5/      50      