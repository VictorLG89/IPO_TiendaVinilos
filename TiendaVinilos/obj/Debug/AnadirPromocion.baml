   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5   	   #    TiendaVinilos.AnadirPromocion   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TiendaVinilos     5   	   $	��800��5   	   $	��800��6   .��5	      � 
�������$
��Left=�6   $��0,0,0,25q�69     � ColumnDefinitions  5
   
   �� 5      $��30 �6   �� 5      $	��120 �6   �� 5      $��10 �6   �� 5      $	��300 �6   �� 5      $��10 �6   �� 5      $	��300 �6   �� 5      $��30 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��120 �6   �� 5      $��27 �6   �� 5      $��* �6   �� 5      $��27 �6   �� 5      $��27 �6   .+�5   
   �� $��3��6   $	��NaN��6%   $��0,0,0,10q�62   $��3��6D   $��1��6U   $	��NaN��6b   .+�5      �� $��Nombre de la promoción��6   �� 5      -   5        $��NombrePromocionTextBox��5       �� TextWrapping$
 Wrap=�64   $	��120��6H   $
��Left=�6T   �� 5!      $��Artista��6   �� 5"      -   5        $��ArtistaComboBox��5"      $	��120��6.   $
��Left=�6:   �� 5$      $��Disco��6   �� 5%      -   5        $��DiscoComboBox��5%      $	��120��6,   $
��Left=�68   �� 5'      $��Fecha de inicio��6   (  "System.Windows.Controls.DatePicker  5(      -   5        $��FechaInicioDatePicker��5(      �� 5*      $��Fecha de finalización��6     5+      -   5        $��FechaFinDatePicker��5+      �� 5-      $!��Descuento en porcentaje (%)��6   �� 5.      -   5        $��DescuentoTextBox��5.      $
 Wrap=�6.   $	��120��6B   $
��Left=�6N   �� 50      $%��Enviar notificación a clientes��6   �� 51      $��Programar notificación��6     52      53      �� 56   
   $��3��6   $��Guardar promoción��6!   $��Right=�6=   $��3��6Y   $	��Top=�6f   $��28��6~   $	��116��6�    J� RenderTransformOrigin$ 0.499,0.675&�6�   $��	0,196,2,0q�6�   �� 57   
   -   5        $��3��57      $��Cancelar proceso��6!   $
��Left=�6<   $��	0,197,0,0q�6W   $��3��6j   $	��Top=�6w   $��27��6�   $	��117��6�   6�   58      59      