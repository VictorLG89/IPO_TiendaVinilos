   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5   	   "    TiendaVinilos.InicioDeSesion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TiendaVinilos     5   	     � Title$  Iniciar Sesión��5   	   $	��450��6    $	��800��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��218* �6   �� 5      $	��82* �6   �� 5      $
��200* �6   �� 5      $	��82* �6   �� 5      $
��218* �6    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��115 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��70 �6   �� 5      $
��200* �6   .+�5   
   �� -   5         ��Name$ tbxEmail��5      $��2��6$   $��	0,28,0,22q�64   $��2��6G    �� TextWrapping$
 Wrap=�6T   $��Usuario��6h   $��Center=�6w   ���	#FF605B5B$	��1,2q�6�   $��1��6�   6�   G� 5   
   -   5         G�Name$ pbxContraseña��5      $��2��6-   $��0,26,0,1q�6=   $��3��6O   $��2q�6\    G� Password$ Contraseña��6p   $��2��6�   $��Stretch=�6�   $��Stretch=�6�   �� 5   
   -   5         ��Name$ btnLogin��5      $��Iniciar Sesión��6#   $��2��6<   $��37,28.8,37,0q�6L   $��4��6b   $��2q�6o   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ 
lblUsuario��5      
���   �	 J� RenderTransformOrigin$	 0.902,-0.345&�67   $��Nombre de Usuario��6\   $��2��6x   $��2��6�   $��Center=�6�   $��	0,2,70,49q�6�   �� 5   
   -   5        $ lblContraseña��5      
���   �$��Contraseña��6:   $��2��6O   $��3��6_   $��Center=�6l   $��1.2,0.2,68.8,26.2q�6�   $
��Left=�6�   �� 5    
   -   5        $ 	lblEstado��5       $��Italic$�6#   ��. $��Center=�6G   $��Center=�6k   $ ��Bienvenido a TiendaVinilos��6�   $��	49,3,49,3q�6�   $��7��6�   $��10,10,10,10q�6�   $��9(�6�   
�������$��2��6  ��5!      �� 5"      
 �� Color$
 Black��6"    �� Opacity$	 0.7Q�60   5$      �� 5%   
   -   5         ��Name$ FotoLogoTienda��5%      $��2��6(   $��	44,6,42,6q�68   $��1��6K   $!��/Images/disco-de-vinilo.png��6X    J� OpacityMask 5&      �� 5'       �� ImageSource$! /Images/disco-de-vinilo.png��6   5)      5+      5,      