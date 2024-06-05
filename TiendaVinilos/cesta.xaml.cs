using System;
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
    public partial class cesta : UserControl
    {
        private ViewModel viewModel;
        public static Frame MainContentFrame { get; set; }

        public cesta()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
            viewModel.Cesta.CollectionChanged += Cesta_CollectionChanged;
            // Mostrar mensaje si la cesta está vacía
            ActualizarMensajeVacio();
        }
        private void Cesta_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Mostrar la etiqueta si la lista está vacía
            ActualizarMensajeVacio();
        }
        private void ActualizarMensajeVacio()
        {
            if (viewModel.Cesta.Count == 0)
            {
                // Mostrar la etiqueta y ocultar la lista
                txtMensajeVacio.Visibility = Visibility.Visible;
                lstCesta.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Ocultar la etiqueta y mostrar la lista
                txtMensajeVacio.Visibility = Visibility.Collapsed;
                lstCesta.Visibility = Visibility.Visible;
            }
        }
        private void RecargarCesta()
        {
            // Abrir la ventana de lista de deseos en el MainContentFrame

            MainContentFrame.Navigate(new cesta());
        }

        private void imgBasura_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var producto = (sender as FrameworkElement).DataContext as Producto;
            if (producto != null)
            {
                viewModel.EliminarDeCesta(producto);
                RecargarCesta();
                ActualizarMensajeVacio();
            }
        }

        private void imgBasura_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void imgBasura_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }
        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
