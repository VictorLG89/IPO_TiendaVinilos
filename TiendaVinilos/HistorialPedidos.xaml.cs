using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para HistorialPedidos.xaml
    /// </summary>
    public partial class HistorialPedidos : UserControl
    {
        private ViewModel viewModel;
        public static Frame MainContentFrame { get; set; }
        public static string culture2 { get; set; }
        public HistorialPedidos(string culture)
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.SelectCulture(culture));
            viewModel = new ViewModel();
            DataContext = viewModel;
            culture2 = culture;
            // Suscribirse al evento de cambio en la colección de deseos
            viewModel.HistorialPedidos.CollectionChanged += ListaDeseos_CollectionChanged;

            // Mostrar la etiqueta si la lista está vacía al inicio
            MostrarEtiquetaSiListaVacia();
        }
        private void MarkAsReceivedButton_Click(object sender, RoutedEventArgs e)
        {
            var pedido = (sender as FrameworkElement).DataContext as Pedido;
            if (pedido != null)
            {
                viewModel.CompletarPedido(pedido);
                RecargarHistorial();
                MostrarEtiquetaSiListaVacia();
            }
        }
        private void RecargarHistorial()
        {
            MainContentFrame.Navigate(new HistorialPedidos(culture2));
        }
        private void ListaDeseos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Mostrar la etiqueta si la lista está vacía
            MostrarEtiquetaSiListaVacia();
        }

        private void MostrarEtiquetaSiListaVacia()
        {
            // Verificar si la lista de deseos está vacía
            if (viewModel.HistorialPedidos.Count == 0)
            {
                // Mostrar la etiqueta y ocultar la lista
                txtMensajeVacio.Visibility = Visibility.Visible;
                lstPedidos.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Ocultar la etiqueta y mostrar la lista
                txtMensajeVacio.Visibility = Visibility.Collapsed;
                lstPedidos.Visibility = Visibility.Visible;
            }
        }
    }
}
