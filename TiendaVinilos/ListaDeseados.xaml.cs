﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para ListaDeseados.xaml
    /// </summary>
    public partial class ListaDeseados : UserControl
    {
        public ListaDeseados()
        {
            InitializeComponent();
        }
        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Aquí colocas la lógica que deseas ejecutar cuando se cambia la selección en el ListBox
        }
    }
}
