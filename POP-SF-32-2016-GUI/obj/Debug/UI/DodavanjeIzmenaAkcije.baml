   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   1    +POP_SF_32_2016_GUI.UI.DodavanjeIzmenaAkcije   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  DodavanjeIzmenaAkcije��5   	   $��488.5��6'   $��671.5��66    � WindowStartupLocation$ CenterScreen=�6D   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $
��156* �6   �� 5      $	��52* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��0��6   $��0��6   $��Datum pocetka:��6-   $��15(�6F   $��	0,0,490,0q�6T   �� 5   
   $��1��6   $��0��6   $��Popust:��6-   $��15(�6?   $��	0,0,490,0q�6M   $��55��6`   $	��Top=�6l   �� 5   
   -   5        $��tbPopust��5   ,   $��1��6   $
��Auto��6   $��	174,0,0,0q�6<   ��6O   ��  �� Path$ Popust� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      ��  ��Name$ textBox��64   �� 5      $��Polje ne sme biti prazno��6$   
���  ��6D   5      5      .��5    (   5!      �� 5"   
   $��3��6   $��0��6   $��Datum 
zavrsetka:��6-   $��15(�6R   $��	0,0,490,0q�6`   �� 5#   
   $��4��6   $��0��6   $��Namestaj na 
popustu:��6-   $��15(�6V   $��0,0,490,108q�6d   �� 5$   
   -   5        $��Sacuvaj��5$      $
��Auto��6#   $��5��61   $��	428,0,0,0q�6T   ��5%      �� 5&      	 �� 
TargetType"	 ��6   .�5'      �� 
 �� Property
 � {� �� Value .  62    �� Triggers 5(      ^� 5)       ^� 
Conditions 5*      �� 5+   "    �� Binding 6,   ��  �� ElementName$ tbNaziv��$ (Validation.HasError)� �� Value	 false5,   (   �� 5-   "    6,   �� $ tbPopust��$ (Validation.HasError)�	 false5.   (   �� 5/   "    6,   �� $ dpDatumPocetka��$ (Validation.HasError)�	 false50   (   �� 51   "    6,   �� $ dpDatumZavrsetka��$ (Validation.HasError)�	 false52   (   .0�54      �� 
 � {� . 55      56      58      5:      �� 5;   
   -   5        $��5��5;      $��Izadji��6   $
��Auto��6/   $��	0,0,439,0q�6L   (  "System.Windows.Controls.DatePicker  5<   
   -   5          Name$ dpDatumPocetka��5<      $
��Left=�6-   $��56��6H   $	��Top=�6T   $	��490��6l   $��	174,0,0,0q�6x      Text 6�   �� $ DatumPocetka� . $ PropertyChanged=� 5=      �� 5>      .R�5?      �� .+�5@      �� $ 
dataPicker��64     5A      $ Polje ne sme biti prazno��6%   
���  ��6E   5B      5C      5E        5F   
   -   5        $ dpDatumZavrsetka��5F      $
��Left=�6/   $��55��6J   $��3��6V   $	��Top=�6c   $	��490��6{   $��	174,0,0,0q�6�    J� RenderTransformOrigin$ 0.515,0.837&�6    6�   �� $ DatumZavrsetka� . $ PropertyChanged=�6   &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$ dgNametajLista��5G      $
��Left=�6+   $	��176��6F   $��	174,0,0,0q�6S   $��4��6f   $	��Top=�6s   $	��490��6�      CanUserAddRows .   �� SelectedItem 6�   �� $ Namestaj�6�   �� 5H   
   $��Naziv:��6   $��Right=�6!   $��56��6=   $��2��6I   $	��Top=�6V   $	��174��6n   $��	0,0,490,0q�6z   $��15(�6�   �� 5I   
   -   5         ��Name$ tbNaziv��5I      $
��Left=�6#   $��56��6>   $��	174,0,0,0q�6J   $��2��6]    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��490��6�   ��6�   �� $ Naziv� . $ PropertyChanged=�.��6�    5J      �� 5K      .R�5L      �� .+�5M      �� $ textBox��64   �� 5N      $��Polje ne sme biti prazno��6$   
���  ��6D   5O      5P      .��5Q   (   5R      5S      5T      