   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   .    (POP_SF_32_2016_GUI.UI.TipNamestajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  TipNamestajaWindow��5   	   $	��388��6$   $	��801��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��63* �6   �� 5      $
��171* �6   �� 5      $	��56* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgTipNamestaja��5   .   $��1��6   $��20(�6       CanUserAddRows .   �� SelectedItem 6D   ��  �� Path$ IzabraniTip�6�   �� 5   
   -   5         ��Name$ 
tbPretraga��5      $
��Left=�6&   $��42��6A   $��
158,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��141��6�   �� 5   
   -   5         ��Name$ 
cbSortiraj��5      $
��Left=�6'   $��31��6B   $��
617,22,0,0q�6N   $	��Top=�6b   $	��135��6z   6�   �� 5   
   $��Pretraga namestaja:��6   $
��Left=�6.   $��42��6I   $��	25,10,0,0q�6U   $	��Top=�6h   $	��128��6�   �� 5   
   $��Sortiraj po:��6   $
��Left=�6'   $��31��6B   $��
528,22,0,0q�6N   $	��Top=�6b   $��73��6z   	 J� RenderTransformOrigin$	 0.542,0.032&�6�   �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��56��6`   $��
31,5,714,8q�6l   $��48��6�   $��2��6�   ��5      �� 5      .R�5      �� 
 �� Orientation$
 Vertical=�6!   .+�5      �� $��..\Images\dodaj.png��6    5      5      5      �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��56��6a   $��178,5,563,8q�6m   $��52��6�   $��2��6�   ��5      �� 5      .R�5       �� $
 Vertical=�6!   .+�5!      �� $��..\Images\izmena.png��6    5"      5#      5%      �� 5&   
   -   5        $��Center=�5&      $��Center=�6.   $��54��6^   $��321,7,411,8q�6j   $��61��6   $��2��6�   ��5'      �� 5(      .R�5)      �� $
 Vertical=�6!   .+�5*      �� $��..\Images\obrisi.png��6    $	 	3.132,0.8&�6>   5+      5,      5.      �� 5/   
   -   5        $��Center=�5/      $��Center=�6.   $��51��6_   $��678,5,63,13q�6k   $��52��6�   $��2��6�   $	 2.971,-0.032&�6�   ��50      �� 51      .R�52      �� $
 Vertical=�6!   .+�53      �� $��..\Images\izadji.png��6    $	 	3.132,0.8&�6>   54      55      57      �� 58   
   -   5        $��Center=�58      $��Center=�6.   $��42��6`   $��336,10,411,25q�6l   $��46��6�   $	 0.957,0.571&�6�   ��59      �� 5:      .R�5;      �� $
 Vertical=�6!   .+�5<      �� $��..\Images\pretraga.png��6    5=      5>      5@      5A      5B      