   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   (    "POP_SF_32_2016_GUI.UI.AkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  AkcijaWindow��5   	   $��418.5��6   $��814.5��6-    � WindowStartupLocation$ CenterScreen=�6;   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��56* �6   �� 5      $
��255* �6   �� 5      $	��76* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgAkcija��5   .   $��1��6   $��20(�6       CanUserAddRows .   �� SelectedItem 6>   ��  �� Path$ IzabranaAkcija�6�   �� 5   
   -   5         ��Name$ 
tbPretraga��5      $
��Left=�6&   $��36��6A   $��
158,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��166��6�   �� 5   
   -   5         ��Name$ 
cbSortiraj��5      $
��Left=�6'   $��37��6B   $��
610,10,0,0q�6N   $	��Top=�6b   $	��152��6z   6�   �� 5   
   $��Sortiraj po:��6   $
��Left=�6'   $��37��6B   $��
488,10,0,0q�6N   $	��Top=�6b   $��76��6z   �� 5   
   $��Pretraga akcija:��6   $
��Left=�6+   $��42��6F   $��	25,10,0,0q�6R   $	��Top=�6e   $	��128��6}   �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��64��6c   $��
61,6,692,6q�6o   $��53��6�   $��2��6�   ��5      �� 5      .R�5      �� 	 �� Orientation$	 Vertical=�6!   .+�5      �� $��..\Images\dodaj.png��6    5      5      5      �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��64��6d   $��194,6,559,6q�6p   $��53��6�   $��2��6�   ��5      �� 5      .R�5       �� $	 Vertical=�6!   .+�5!      �� $��..\Images\izmena.png��6    5"      5#      5%      �� 5&   
   -   5        $��Center=�5&      $��Center=�6.   $��64��6c   $��325,6,413,6q�6o   $��68��6�   $��2��6�   ��5'      �� 5(      .R�5)      �� $	 Vertical=�6!   .+�5*      �� $��..\Images\obrisi.png��6    
 J� RenderTransformOrigin$
 	3.132,0.8&�6>   5+      5,      5.      �� 5/   
   -   5        $��Center=�5/      $��Center=�6.   $��60��6_   $��670,6,80,10q�6k   $��56��6�   $��2��6�   $
 2.971,-0.032&�6�   ��50      �� 51      .R�52      �� $	 Vertical=�6!   .+�53      �� $��..\Images\izadji.png��6    $
 	3.132,0.8&�6>   54      55      57      �� 58   
   -   5        $��Center=�58      $��Center=�6.   $��36��6^   $��355,10,413,10q�6j   $��38��6�   $
 -0.382,0.431&�6�   ��59      �� 5:      .R�5;      �� $	 Vertical=�6!   .+�5<      �� $��..\Images\pretraga.png��6    5=      5>      5@      5A      5B      