   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5          TiendaVinilos.Vinilos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:TiendaVinilos     5      $	��800��5      $	��800��6   .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �   5      �� 5      $��* �6     5      �� 5      $
��250* �6#   �� 5      $
��550* �6#   .+�5      �� -   5         ��Name$ lstListaPeliculas��5       �� SelectedIndex$ 0��61   $��0��6C   $	��Top=�6S    �� AlternationCount$ 2��6k   $	��700��6�   $	��250��6�   $
��Left=�6�   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   $	��250��6>   $
��Left=�6M   .+�5      �� $��50��6?   $��50��6J   $��5q�6V   $
��Left=�6a   ��6$   �� *	Portada+6a   �� 5      $
��Left=�6)   .+�5    "   �� $
��Bold"�6D   $��Center=�6V   ��6,   �� *Titulo+6V   �� 5!   "   ��6,   �� *Autor+5"      �� 5#      $	��100��6)   $��10,0,0,0q�65   $��Center=�6G   .+�5$   "   �� $��16(�6,   $
��Bold"�6:   �� 5%   &   �6*   �� *Precio+ �� StringFormat$ C��5&   #   5'      �� 5)      $��Right=�6)   .+�5*   "   �� -   5        $��Center=�5*   `   $��53��6}   $��24��6�   ��6(   �� *CorazonImage+ � DataContext 6H   �� 6�   5+      5,      5-      ��5/      �� 50       �� 
TargetType" ��6   .�51      �� 	 �� Property	 � ��
 �� Value$
 2q�63    �� Triggers 52      P� 53       P� Property �@��AlternationIndex P� Value$ 1��6O   . �54   "   �� 	 � ��

 �����6?   55      P� 56       �@��
IsSelected . . �57   "   �� 	 � ��

 ��  �6?   �� 58   "   	 � ��$

 Bold"�6?   �� 59   "   	 � ��

 ��  �6@   �� 5:   "   	 � ��$
 3q�6D   5;      5=      5?      �� 5@      -   5         ��Name$ spDetallesPelicula��5@      $��1��65   $ Vertical=�6E   $	��Top=�6\   $	��350��6t   $	��550��6�   $��30,30,30,30q�6�   .+�5A      �� -   5         ��Name$ 	lblTitulo��5A      $
��Bold"�6+   $��20(�6=   ��6K   ��  �� ElementName$ lstListaPeliculas�� �� Path$ SelectedItem.Titulo��� 5B      -   5         ��Name$ 
imgPortada��5B      $	��120��6,   $	��100��69   $
��Left=�6E   $��5q�6`   $
��Fill=�6k   ��6z   �� $ lstListaPeliculas��$ SelectedItem.Portada��� 5C      $
��Bold"�6      lblAutor#���   6*   �� 5D      -   5        $ lblAutor��5D      ��6*   �� $ lstListaPeliculas��$ SelectedItem.Autor��� 5E      $
��Bold"�6     lblAnio#���  6*   �� 5F      -   5        $ lblAnio��5F      ��6)   �� $ lstListaPeliculas��$ SelectedItem.Anio��� 5G      $
��Bold"�6     lblDuracion#���  6*   �� 5H      -   5        $ lblDuracion��5H      ��6-   �� $ lstListaPeliculas��$ SelectedItem.Duracion��� 5I      $
��Bold"�6     	lblPrecio#���  6*   �� 5J      -	   5         ��Name$ 	txtPrecio��5J      $��5q�6/   �� 5K      $��20(�6s   �6   �� $ lstListaPeliculas��$ SelectedItem.Precio�$ C��6s   5L      �� 5M      -
   5         ��Name$ btnCesta��5M        btnAnadirACesta#���  6+   $��5q�6u   $	��108��6�   $��40��6�   $
��Left=�6�   5N      5O      5P      5Q      