   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   *    $POP_SF_32_2016_GUI.UI.KorisnikWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  KorisnikWindow��5   	   $	��439��6    $	��827��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��34* �6   �� 5      $
��133* �6   �� 5      $	��37* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgKorisnik��5   .   $��1��6   $��20(�6       CanUserAddRows .  $��	0,0,-10,0q�6�    �� SelectedItem 6@   ��  �� Path$ IzabraniKorisnik�6�   �� 5   
   -   5         ��Name$ 
tbPretraga��5      $
��Left=�6&   $��42��6A   $��
156,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��160��6�    J� RenderTransformOrigin$ -0.841,-3.095&�6�   �� 5   
   -   5        	 ��Name$	 
cbSortiraj��5      $
��Left=�6'   $��42��6B   $��
649,10,0,0q�6N   $	��Top=�6b   $	��146��6z   $ 	0.484,0.5&�6�   �� 5   
   $��Pretraga korisnika:��6   $
��Left=�6.   $��42��6I   $��	28,10,0,0q�6U   $	��Top=�6h   $	��114��6�   �� 5   
   $��Sortiraj po:��6   $
��Left=�6'   $��42��6B   $��
563,10,0,0q�6N   $	��Top=�6b   $��69��6z   �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��64��6`   $��
68,4,699,6q�6l   $��52��6�   $��2��6�   ��5      �� 5      .R�5      �� 
 �� Orientation$
 Vertical=�6!   .+�5      �� $��..\Images\dodaj.png��6    5      5      5      �� 5   
   -   5        $��Center=�5      $��Center=�6.   $��64��6a   $��200,4,565,6q�6m   $��54��6�   $��2��6�   ��5      �� 5      .R�5       �� $
 Vertical=�6!   .+�5!      �� $��..\Images\izmena.png��6    5"      5#      5%      �� 5&   
   -   5        $��Center=�5&      $��Center=�6.   $��64��6Y   $��332,4,419,6q�6e   $��68��6z   $��2��6�   ��5'      �� 5(      .R�5)      �� $
 Vertical=�6!   .+�5*      �� $��..\Images\obrisi.png��6    $ 	3.132,0.8&�6>   5+      5,      5.      �� 5/   
   -   5        $��Center=�5/      $��Center=�6.   $��60��6Y   $��700,4,60,10q�6e   $��59��6z   $��2��6�   $ 2.971,-0.032&�6�   ��50      �� 51      .R�52      �� $
 Vertical=�6!   .+�53      �� $��..\Images\izadji.png��6    $ 	3.132,0.8&�6>   54      55      57      �� 58   
   -   5        $��Center=�58      $��Center=�6.   $��42��6^   $��354,10,419,16q�6j   $��46��6�   ��59      �� 5:      .R�5;      �� $
 Vertical=�6!   .+�5<      �� $��..\Images\pretraga.png��6    5=      5>      5@      5A      5B      