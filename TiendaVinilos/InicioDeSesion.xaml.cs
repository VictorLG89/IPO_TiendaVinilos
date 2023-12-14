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
    /// <summary>
    /// Lógica de interacción para InicioDeSesion.xaml
    /// </summary>
    public partial class InicioDeSesion : Window
    {
        public InicioDeSesion()
        {
            InitializeComponent();
        }
       
        private void comprobarInformacion(object sender, RoutedEventArgs e)
        {
            string usuario = "ipo@PeliFlix.com";
             if (!String.IsNullOrEmpty(tbxEmail.Text) && tbxEmail.Text.Equals(usuario, StringComparison.InvariantCultureIgnoreCase))
            {
                // comprobación correcta
                pbxContraseña.IsEnabled = true;
                tbxEmail.BorderBrush = Brushes.Transparent;
            }
            else
            {
                // comprobación errónea
                tbxEmail.BorderBrush = Brushes.Red;
                tbxEmail.BorderThickness = new Thickness(2);
                if (pbxContraseña.IsEnabled)
                {
                    pbxContraseña.IsEnabled = false;
                }
            }
        }
        private void mostrarLetraPulsada(object sender, KeyEventArgs e)
        {
            lblEstado.Content = "Has pulsado la tecla <<" + e.Key.ToString() + ">>";
            lblEstado.Foreground = Brushes.Black;
        }
    }
}
