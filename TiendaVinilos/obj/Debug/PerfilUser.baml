   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5          TiendaVinilos.PerfilUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:TiendaVinilos     5      $	��800��5      $	��800��6   .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $��20 �6   �� 5      $	��120 �6   �� 5      $	��280 �6   �� 5      $	��120 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��280* �6   �� 5      $
��240* �6   �� 5      $
��280* �6   .+�5   
   �� $��2��6   $��1��6"   $��	10,0,10,0q�62   $��Center=�6E   .+�5      ��  �� Orientation$ Vertical=�6   $��0,0,0,20q�60   .+�5      ��    lblNombreUsuario#���   6   $��16(�6F   ���	#FF0000FF$��Center=�6k   �� 5      -   5         ��Name$ txtNombreUsuario��5      $��0,0,0,5q�66   $��18(�6G   !   TiendaVinilos.UsuarioActual   NombreUsuario#��Z 6U   $��Center=�6�   5      �� 5      $ Vertical=�6   $��0,0,0,20q�60   .+�5       ��   lblNombreApellidos#���  6   $��16(�6H   ���	#FF0000FF$��Center=�6m   �� 5!      -   5        $ 	txtNombre��5!      $��0,0,0,5q�6/   $��18(�6@   $��Center=�6N   �� 5"      $ 
Horizontal=�6!   .+�5#      �� -   5        $ txtNombreReal��5#   $   $��0,0,0,5q�6;   $��18(�6L      Nombre#��Z 6Z   $��Center=�6�   �� 5$      $��18(�6$   $�� ��62   �� 5%      -   5        $ txtApellidoUno��5%   $   $��0,0,0,5q�6<   $��18(�6M      	Apellido1#��Z 6[   $��Center=�6�   �� 5&      $��18(�6$   $�� ��62   �� 5'      -   5        $ txtApellidoDos��5'   $   $��0,0,0,5q�6<   $��18(�6M      	Apellido2#��Z 6[   $��Center=�6�   5(      5)      5*      �� 5,      $ Vertical=�6   $��0,0,0,20q�60   .+�5-      ��   	lblCorreo#���  6   $��16(�6?   ���	#FF0000FF$��Center=�6d   �� 5.      -   5        $ 	txtCorreo��5.      $��0,0,0,5q�6/   $��18(�6@      Correo#��Z 6N   $��Center=�6{   5/      �� 51      $ 
Horizontal=�6   $��0,0,0,20q�65   $��Center=�6G   .+�52      ��   lblUltimoAcceso#���  6   $
��Bold"�6E   $��16��6W   $��Center=�6c   $��40,0,0,0q�6�   �� 53      -   5        $ txtUltimoAcceso��53      	   UltimoAcceso#��Z	 65   $��Center=�54      $	��Top=�60   $��10q�6H   $	��100��6T   55      56      �� 59   
   -   5        
 ��Name$
 btnListaDeseos��59      $��1��6)     lblListaDeseos2#���  69   $��Center=�6e   $��0,5,0,5q�6�   $��3��6�   $	��Top=�6�   $��18(�6�   6�   �� 5:   
   -	   5        $
 btnHistorialPedidos��5:      $��1��6.     lblHistorial#���  6>   $��Center=�6g   $��0,40,0,0q�6�   $��3��6�   $	��Top=�6�   $��18(�6�   6�   �� 5;   
   -
   5        $
 btnEditarPerfil��5;      $��1��6*   $��Editar perfil��6:   $��Center=�6R   $��0,75,0,0q�6o   $��3��6�   $	��Top=�6�   $��18(�6�   6�   �� 5<   
   -   5         ��Name$ lblCerrarSesion��5<      $��1��5=        lblCerrarSesion#���  5>      $��Center=�5?      $��0,10,0,0q�5@      $��4��5A      $	��Top=�5B      {�. $��25��5D      5G      �� 5I   
   $��1��6   $��1��6    $	��100��6-   $	��100��69   $��50,10,50,10q�6F   ��6[   ��    
FotoPerfil �� Source# Z 5K      5L      