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
using System.Xml;

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para PerfilUser.xaml
    /// </summary>
    public partial class PerfilUser : UserControl
    {
        public static Frame MainContentFrame { get; set; }
        public PerfilUser()
        {
            InitializeComponent();
            // Asignar eventos a los botones
            btnListaDeseos.Click += BtnListaDeseos_Click;
            btnHistorialPedidos.Click += BtnHistorialPedidos_Click;
            btnEditarPerfil.Click += BtnEditarPerfil_Click;
            lblCerrarSesion.MouseDown += lblCerrarSesion_MouseDown;

        }

        public void SetMainContentFrame(Frame mainContentFrame)
        {
            MainContentFrame = mainContentFrame;
        }

        private void BtnListaDeseos_Click(object sender, RoutedEventArgs e)
        {
            // Abrir la ventana de lista de deseos en el MainContentFrame
            MainContentFrame.Navigate(new ListaDeseados());
        }

        private void BtnHistorialPedidos_Click(object sender, RoutedEventArgs e)
        {
            // Abrir la ventana de historial de pedidos en el MainContentFrame
            MainContentFrame.Navigate(new HistorialPedidos());
        }

        private void BtnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            // Abrir la ventana de edición de perfil en el MainContentFrame
            MainContentFrame.Navigate(new EditarPerfil());
        }

        private void lblCerrarSesion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Lógica para cerrar la sesión aquí
        }
        private void lblCerrarSesion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Lógica para cerrar sesión aquí
        }

    }
}
