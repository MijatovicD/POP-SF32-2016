   M S B A M L   `   `   `  ����M  IPOP-SF-32-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_32_2016_GUI.UIPOP_SF_32_2016_GUI.UI  5   	   1    +POP_SF_32_2016_GUI.UI.DodavanjeIzmenaUsluge   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_32_2016_GUI.UI     5   	     � Title$  DodavanjeIzmenaUsluge��5   	   $	��200��6'   $	��300��64    � WindowStartupLocation$ CenterScreen=�6@   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��50* �6   �� 5      $	��50* �6   �� 5      $	��30* �6    � ColumnDefinitions 5   
   �� 5      $
��106* �6   �� 5      $
��187* �6   .+�5   
   �� $��0��6   $��0��6   $��Naziv:��6-   $��15(�6>   �� 5   
   -   5        $��tbNaziv��5   <   $��0��6   $��1��6   $
��Auto��6/   ��6K   ��  �� Path$ Naziv� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      ��  ��Name$ textBox��64   �� 5      $��Polje ne sme biti prazno��6$   
���  ��6D   5      5      .��5   (   5      �� 5   
   $��1��6   $��0��6   $��Cena:��6-   $��15(�6=   �� 5    
   -   5        $��tbCena��5    <   $��1��6   $��1��6   $
��Auto��6/   ��6J   �� $
 Cena� . $ PropertyChanged=�.��6�    5!      �� 5"      .R�5#      �� .+�5$      �� $ textBox��64   �� 5%      $��Greska��6$   
���  ��62   5&      5'      .��5(   (   5)      �� 5*   
   -   5        $��Sacuvaj��5*      $��0��6#   $
��Auto��63   $��2��6A   ��5+      �� 5,      	 �� 
TargetType"	 ��6   .�5-      �� 
 �� Property
 � {� �� Value .  62    �� Triggers 5.      ^� 5/       ^� 
Conditions 50      �� 51   "    �� Binding 6,   ��  �� ElementName$ tbNaziv��$ (Validation.HasError)� �� Value	 false52   (   �� 53   "    6,   �� $ tbCena��$ (Validation.HasError)�	 false54   (   .0�56      �� 
 � {� . 57      58      5:      5<      �� 5=   
   -   5        $��2��5=      $��Izadji��6   $��1��6/   $
��Auto��6?   6L   5>      5?      