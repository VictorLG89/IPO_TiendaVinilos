   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5   	       TiendaVinilos.Artistas   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TiendaVinilos     5   	   $	��450��5   	   $	��800��6   .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �   5      �� 5      $��* �6     5      �� 5      $
��250* �6#   �� 5      $
��550* �6#   .+�5      �� -   5         ��Name$ lstListaArtistas��5       �� SelectedIndex$ 0��60   $��0��6B   $	��Top=�6R    �� AlternationCount$ 2��6j   $	��700��6   $	��250��6�   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��50��6<   $��50��6G   $��5q�6S   ��6$   �� *Foto+6S   �� 5      .+�5   "   �� $
��Bold"�6D   ��6,   �� *Nombre+6D   5       �� 5!      $	��100��6)   $��10,0,0,0q�65   .+�5"   "   �� $
��Wrap=�6D   ��6,   �� *Precio+6D   5#      5$      5%      ��5'      �� 5(       �� 
TargetType" ��6   .�5)      ��  �� Property � �� �� Value$ 2q�63   	 �� Triggers	 5*      P� 5+      
 P� Property
 �@��AlternationIndex P� Value$ 1��6O   . �5,   "   ��  � ��
 �����6?   5-      P� 5.      
 �@��
IsSelected . . �5/   "   ��  � ��
 ��  �6?   �� 50   "    � ��$
 Bold"�6?   �� 51   "    � ��
 ��  �6@   �� 52   "    � ��$ 3q�6D   53      55      57      �� 58      -   5         ��Name$ spDetallesPelicula��58      $��1��65   $ Vertical=�6E   $	��Top=�6\   $	��350��6t   $	��550��6�   $��30,30,30,30q�6�   .+�59      �� -   5         ��Name$ 	lblTitulo��59      $
��Bold"�6+   $��20(�6=   ��6K   ��  �� ElementName$ lstListaArtistas�� �� Path$ SelectedItem.Nombre��� 5:      -   5         ��Name$ 
imgPortada��5:      $	��120��6,   $	��140��69   $
��Left=�6E   $��5q�6`   ��6k   �� $ lstListaArtistas��$ SelectedItem.Foto��� 5;      $
��Bold"�6      lblAnio#���   6*   �� 5<      -   5        $ lblAnio��5<      ��6)   �� $ lstListaArtistas��$ SelectedItem.Anio��� 5=      $
��Bold"�6     lblNacionalidad#���  6*   �� 5>      -   5        $ lblNacionalidad��5>      ��61   �� $ lstListaArtistas��$ SelectedItem.Nacionalidad��� 5?      $
��Bold"�6     lblTipo#���  6*   �� 5@      -   5        $ lblTipo��5@      ��6)   �� $ lstListaArtistas��$ SelectedItem.Tipo�5A      5B      5C      5D      