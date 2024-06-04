using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ViewModel viewModel;

        public ListaDeseados()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
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

