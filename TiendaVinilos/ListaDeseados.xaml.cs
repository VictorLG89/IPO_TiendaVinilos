using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ListaDeseados : UserControl
    {
        private ViewModel viewModel;

        public ListaDeseados(string culture)
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.SelectCulture(culture));
            viewModel = new ViewModel();
            DataContext = viewModel;

            // Suscribirse al evento de cambio en la colección de deseos
            viewModel.ListaDeseos.CollectionChanged += ListaDeseos_CollectionChanged;

            // Mostrar la etiqueta si la lista está vacía al inicio
            MostrarEtiquetaSiListaVacia();
        }

        private void ListaDeseos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Mostrar la etiqueta si la lista está vacía
            MostrarEtiquetaSiListaVacia();
        }

        private void MostrarEtiquetaSiListaVacia()
        {
            // Verificar si la lista de deseos está vacía
            if (viewModel.ListaDeseos.Count == 0)
            {
                // Mostrar la etiqueta y ocultar la lista
                txtMensajeVacio.Visibility = Visibility.Visible;
                lstListaDeseados.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Ocultar la etiqueta y mostrar la lista
                txtMensajeVacio.Visibility = Visibility.Collapsed;
                lstListaDeseados.Visibility = Visibility.Visible;
            }
        }

        private void imgCorazon_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void imgCorazon_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void imgCorazon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image imgCorazon = (Image)sender;
            Vinilo viniloSeleccionado = (Vinilo)imgCorazon.DataContext;

            if (UsuarioActual.ListaDeseos.Contains(viniloSeleccionado))
            {
                viewModel.EliminarDeListaDeseos(viniloSeleccionado);
                imgCorazon.Source = new BitmapImage(new Uri("/Images/corazonVacio.png", UriKind.Relative));
            }
        }
    }
}