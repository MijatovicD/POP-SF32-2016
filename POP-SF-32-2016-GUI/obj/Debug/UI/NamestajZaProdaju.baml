   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   -    'POP_SF_32_2016_GUI.UI.NamestajZaProdaju   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  NamestajZaProdaju��5   	   $	��431��6#   $	��730��60    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgNamestajProdaja��5
      $
��Left=�6.   $	��318��6I   $	��Top=�6V   $	��495��6n   $��	227,0,0,0q�6�    �� SelectedIndex$ 0��6�      CanUserAddRows .   �� SelectedItem 6�   ��  �� Path$ Namestaj�6  �� 5   
   -   5        $��Dodaj��5      $
��Left=�6!   $��42��6<   $��	0,348,0,0q�6H   $	��Top=�6[   $	��116��6s   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � {�	 �� Value	 .  62   
 �� Triggers
 5      ^� 5       ^� 
Conditions 5      �� 5   "    �� Binding 6,   ��  �� ElementName$ 
tbKolicina��$ (Validation.HasError)� �� Value	 false5   (   .0�5      ��  � {�	 . 5      5      5      5      �� 5   
   $��Izadji��6   $
��Left=�6"   $��42��6=   $��596,348,0,0q�6I   $	��Top=�6^   $	��116��6v    J� RenderTransformOrigin$ 2.534,2.667&�6�   �� 5   
   -   5         ��Name$ 
tbKolicina��5   �   $
��Left=�6   $��39��6-   $��	94,62,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��117��6x   ��6�   �� $ KolicinaNamestaja� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6   =� ErrorTemplate 5      �� 5      .R�5       �� .+�5!      ��  ��Name$ textBox��64   �� 5"      $��Pogresan format��6$   
���  ��6;   5#      5$      .��5%   (   5&      �� 5'   
   $��Unesite
kolicinu:��6   $
��Left=�65   $��	10,62,0,0q�6P   $	��Top=�6c   $��39��6{   $��79��6�   5(      5)      