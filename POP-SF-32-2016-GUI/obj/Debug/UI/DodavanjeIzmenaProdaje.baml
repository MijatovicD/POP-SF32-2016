   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   2    ,POP_SF_32_2016_GUI.UI.DodavanjeIzmenaProdaje   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  DodavanjeIzmenaProdaje��5   	   $��483.5��6(   $	��406��67    � WindowStartupLocation$ CenterScreen=�6C   .��5	      � .+�5
   
   (  "System.Windows.Controls.DatePicker  -   5        $��dDatumProdaje��5
      $
��Left=�6*   $��36��6E   $	��Top=�6Q   $	��282��6i   $��	122,0,0,0q�6u      SelectedDate 6�   ��  �� Path$ DatumProdaje��� 5   
   $��Datum prodaje:��6   $
��Left=�6)   $��36��6D   $	��Top=�6P   $	��122��6h   �� 5   
   $��	Namestaj:��6   $
��Left=�6$   $��36��6?   $	��Top=�6K   $	��122��6c   $��0,36,0,0q�6o   �� 5   
   $��Kupac:��6   $
��Left=�6!   $��36��6<   $	��Top=�6H   $	��122��6`   $��	0,173,0,0q�6l    J� RenderTransformOrigin$ 0.557,-0.472&�6   �� 5   
   $��Dodatna usluga:��6   $
��Left=�6*   $��36��6E   $	��Top=�6Q   $	��122��6i   $��	0,209,0,0q�6u   �� 5   
   $��Ukupan iznos:��6   $
��Left=�6(   $��36��6C   $	��Top=�6O   $	��122��6g   $��	0,362,0,0q�6s   �� 5   
   $��Izadji��6   $
��Left=�6"   $��43��6=   $��	0,398,0,0q�6I   $	��Top=�6\   $	��122��6t   $ 0.426,1.372&�6�   �� 5   
   -   5        $��Sacuvaj��5      $
��Left=�6#   $��43��6>   $��224,398,0,0q�6`   $	��Top=�6u   $	��170��6�   �� 5   
   -   5        $��tbKupac��5   f   $
��Left=�6   $��41��6-   $��122,173,0,0q�69   $	��Top=�6N   $	��282��6u   ��6�   �� $ Kupac��� 5   
   -   5        $��lbCena��5      $
��Left=�6   $��36��69   $��122,362,0,0q�6E   $	��Top=�6Z   $	��282��6r   $ 0.471,2.717&�6~   ��6�   �� $ UkupanIznos� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $��	Dodavanje��5      $
��Left=�6%   $��36��6@   $��0,72,0,0q�6L   $	��Top=�6^   $	��122��6v   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNamestajP��5      $
��Left=�6(   $	��137��6C   $��
122,36,0,0q�6P   $	��Top=�6d   $	��282��6|      CanUserAddRows .   �� SelectedItem 6�   �� $ StavkaNamestaja�6�     5   
   -   5        $ 	dgUslugaP��5      $
��Left=�6&   $	��148��6A   $��122,214,0,0q�6N   $	��Top=�6c   $	��282��6{   $ 0.5,0.5&�6�    .   6�   �� $ StavkeUslugeId�5      �� 5   
   -   5        $��	Dodavanje��5      $
��Left=�6%   $��36��6@   $��	0,245,0,0q�6L   $	��Top=�6_   $	��122��6w   6�   �� 5   
   -	   5        $��Izbrisi��5      $
��Left=�6#   $��36��6>   $��	0,113,0,0q�6J   $	��Top=�6]   $	��122��6u   6�   �� 5   
   -
   5        $��Izbrisi��5      $
��Left=�6#   $��36��6>   $��	0,286,0,0q�6J   $	��Top=�6]   $	��122��6u   6�   5      5      