   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   C&clr-namespace:POP_SF_32_2016_GUI.UtilsPOP_SF_32_2016_GUI.Utils  5   	   *    $POP_SF_32_2016_GUI.UI.NamestajWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	   9local1&clr-namespace:POP_SF_32_2016_GUI.Utils     5   	     � Title$  NamestajWindow��5	   	   $	��570��6    $	��770��6-    � WindowStartupLocation$ CenterScreen=�69   .��5
      �� 
�������._�5   
   �  � RowDefinitions 5      �� 5      $	��68* �6    �� 5      $
��365* �6    �� 5      $
��106* �6    .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
dgNamestaj��5   2   $��1��6   $��20(�6$      CanUserAddRows .   �� SelectedIndex$ 0��6�    �� SelectedItem 6D   ��  �� Path$ IzabraniNamestaj�6�   �� 5      -   5         ��Name$ 
tbPretraga��5      $
��Left=�6*   $��42��6E   $��
158,10,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��141��6�   �� 5      -   5        	 ��Name$	 
cbSortiraj��5      $
��Left=�6+   $��42��6F   $��
587,10,0,0q�6R   $	��Top=�6f   $	��126��6~   
 J� RenderTransformOrigin$
 0.333,0.548&�6�   �� 5      $��Pretraga namestaja:��6   $
��Left=�62   $��42��6M   $��	25,10,0,0q�6Y   $	��Top=�6l   $	��128��6�   �� 5      $��Sortiraj po:��6   $
��Left=�6+   $��42��6F   $��
496,10,0,0q�6R   $	��Top=�6f   $��86��6~   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��381,0q�6O   $��0��6^   �� 5      -   5        $��Center=�5      $��Center=�62   $��63��6i   $��46,21,659,22q�6u   $��57��6�   $��2��6�   ��5      �� 5      .R�5      �� $ Vertical=�6%   .+�5      �� $��..\Images\dodaj.png��6$   5      5      5      �� 5       -   5        $��Center=�5       $��Center=�62   $��63��6j   $��185,21,515,22q�6v   $��62��6�   $��2��6�   ��5!      �� 5"      .R�5#      �� $ Vertical=�6%   .+�5$      �� $��..\Images\izmena.png��6$   5%      5&      5(      �� 5)      -   5        $��Center=�5)      $��Center=�62   $��63��6i   $��313,21,381,22q�6u   $��68��6�   $��2��6�   ��5*      �� 5+      .R�5,      �� $ Vertical=�6%   .+�5-      �� $��..\Images\obrisi.png��6$   $
 	3.132,0.8&�6B   5.      5/      51      �� 52      -   5        $��Center=�52      $��Center=�62   $��63��6c   $��652,21,49,22q�6o   $��61��6�   $��2��6�   $
 2.971,-0.032&�6�   ��53      �� 54      .R�55      �� $ Vertical=�6%   .+�56      �� $��..\Images\izadji.png��6$   $
 	3.132,0.8&�6B   57      58      5:      �� 5;      -   5        $��Center=�5;      $��Center=�62   $��42��6b   $��325,10,391,16q�6n   $��46��6�   ��5<      �� 5=      .R�5>      �� $ Vertical=�6%   .+�5?      �� $��..\Images\pretraga.png��6$   5@      5A      5C      5D      5E      5F      