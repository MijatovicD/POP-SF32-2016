   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   2    ,POP_SF_32_2016_GUI.UI.ProdajaNamestajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  ProdajaNamestajaWindow��5   	   $	��570��6(   $	��770��65    � WindowStartupLocation$ CenterScreen=�6A   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��61* �6   �� 5      $
��350* �6   �� 5      $
��128* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgProdaja��5   .   $��1��6   $��20(�6       CanUserAddRows .   �� SelectedItem 6?   ��  �� Path$ IzabranaProdaja�6�   �� 5   
   -   5         ��Name$ 
tbPretraga��5      $
��Left=�6&   $��41��6A   $��
132,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��139��6�   6�   �� 5   
   -   5         ��Name$ 
cbSortiraj��5      $
��Left=�6'   $��40��6B   $��
596,10,0,0q�6N   $	��Top=�6b   $��98��6z   	 J� RenderTransformOrigin$	 -0.33,-8.425&�6�   �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��57��6d   $��39,32,666,39q�6p   $��57��6�   $��2��6�   $	 0.585,0.429&�6�   ��5      �� 5      .R�5      �� 
 �� Orientation$
 Vertical=�6!   .+�5      �� $��..\Images\dodaj.png��6    5      5      5      �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��57��6e   $��171,32,536,39q�6q   $��55��6�   $��2��6�   $	 0.566,0.302&�6�   ��5      �� 5      .R�5      �� $
 Vertical=�6!   .+�5      �� $��..\Images\izmena.png��6    5       5!      5#      �� 5$   
   -   5        $��Center=�5$      $��Center=�6.   $��57��6_   $��653,32,51,39q�6k   $��58��6�   $��2��6�   $	 2.971,-0.032&�6�   ��5%      �� 5&      .R�5'      �� $
 Vertical=�6!   .+�5(      �� $��..\Images\izadji.png��6    $	 	3.132,0.8&�6>   5)      5*      5,      �� 5-   
   $��Pretraga prodaje:��6   $
��Left=�6,   $��31��6G   $��	19,10,0,0q�6S   $	��Top=�6f   $	��108��6~   �� 5.   
   $��Sortiraj po:��6   $
��Left=�6'   $��41��6B   $��
492,10,0,0q�6N   $	��Top=�6b   $	��104��6z   �� 5/   
   -   5        $��Racun��5/      $
��Left=�6!   $��48��6<   $��
399,32,0,0q�6H   $��2��6\   $	��Top=�6i   $	��149��6�   6�   50      51      