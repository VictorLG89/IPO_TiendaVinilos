   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5          TiendaVinilos.cesta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:TiendaVinilos     5      -   5          >�Name$  cesta1��5      $	��750��5      $	��800��6    � DataContext 5	         TiendaVinilos.ViewModel  5
   
   .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��436 �6   �� 5      $��90 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txtMensajeVacio��5         lblViniloCesta#���   5      $��Center=�5      $	��Top=�5      $y�	Collapsed=�5      $��Italic$�5      ���	#FF6D6D6D$��26(�5       $��51��6"   $	��600��6.   $��0,29,0,0q�6:   �� 5#   
   -   5         ��Name$ lstCesta��5#      $	��400��6B   $	��Top=�6R   $	��400��6j   $��
30,30,30,0q�6w   ��6$   �� *Cesta+��5$      �� 5%      .R�5&      ��  �� Orientation$ 
Horizontal=�6!   $	��785��6:   .+�5'      �� $��50��6B   $��50��6M   $��5q�6Y   ��6    �� *Vinilo.Portada+6Y   �� 5(      .+�5)      �� $
��Bold"�6G   ��6(   �� *Vinilo.Titulo+6G   �� 5*      ��6(   �� *Vinilo.Autor+5+      �� 5,      $��Center=�6%   .+�5-      ��   lblCantidad#���  6(   $
��Bold"�6M   $��Center=�6_   �� 5.      ��6(   �� *
Cantidad+5/      �� 50      $	��100��6%   $��10,0,0,0q�61   .+�51      ��   lblPrecioUnitario#���  6(   $
��Bold"�6S   �� 52      $
��Wrap=�6W   ��6(   �� *Vinilo.Precio+ �� StringFormat$ C��6W   53      �� 54      $	��100��6%   $��10,0,0,0q�61   .+�55      ��   lblPrecioTotal#���  6(   $
��Bold"�6P   �� 56      $
��Wrap=�6U   ��6(   �� *PrecioTotal+$ C��6U   57      �� 58      $��70��6%   $��10,0,0,0q�60   .+�59      ��  ��Name$ 	imgBasura��6$   -   5        $��/Images/eliminar.png��59   7   $��Center=�6U   $��24��6r   $��24��6~   6�   5:      5;      5<      5>      �� 5A   
   $ 
Horizontal=�6   $��1��6.   .+�5B      �� #���  6   $
��Bold"�6@   $��16��6R   $��
1200,0,0,0q�6^   �� 5C      $��16��6J   $��86��6V   $��5,0,0,0q�6a   ��6   �� *PrecioTotalCesta+$ C��6a   �� 5D      -   5          lblCheckout#���  5D      $��20,0,0,0q�6=   $��Center=�6O   $��Right=�6j   $��30��6�   $��60��6�   5E      5H      5I      