   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5          TiendaVinilos.Preguntas   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:TiendaVinilos     5      $	��800��5      $	��800��6   .��5	      � 
�������  � ColumnDefinitions  5      �� 5   
   $	��90* �6   �� 5   
   $
��620* �6   �� 5   
   $	��90* �6    � RowDefinitions 5      �� 5   
   $��50 �6   �� 5   
   $��50 �6   �� 5   
   $	��250 �6   �� 5   
   $��30 �6   �� 5   
   $��* �6   .+�5      �� $��1��6   $��1��6       lblPregunta#���   6-   $��Center=�6R   $��Center=�6o   $��24(�6�   $
��Bold"�6�   $
��0,10q�6�   �� 5      $��1��6   $��2��6!   $��Center=�6.   .+�5   
   �� -   5        $��PreguntaTextBox��5      $��Center=�6)    �� TextWrapping$
 Wrap=�6F   $	��Top=�6Z   $��18(�6r   $	��618��6�   $	��204��6�   $	��Top=�6�   .��6�   ��5      �� 5        �� 
TargetType" ��6   .�5!      ��  �� Property � �� �� Value
 �����63   �� 5"       � ��  lblEscribeAqui# �  6-    �� Triggers 5#      P� 5$       P� Property �@J�IsKeyboardFocused P� Value . . �5%      ��  � ��
 �   �6;   �� 5&       � ��$  ��65   5'      P� 5(       �@J�IsKeyboardFocused .  . �5)      ��  � ��$ Escribe aquí...��65   5*      5,      .��5-      5.      �� 50   
   $��1��6     	lblEnviar#���  6!   $��3��6G   	 J� RenderTransformOrigin$	 0.545,0.079&�6T   $��0,10,0,0q�6x   $	��100��6�   $��Center=�6�   51      52      53      