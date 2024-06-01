using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class InicioDeSesion : Window
    {

        public InicioDeSesion()
        {
            InitializeComponent();
        }
        private void mostrarLetraPulsada(object sender, KeyEventArgs e)
        {
            // Lógica para manejar la tecla pulsada
            MessageBox.Show("Letra pulsada: " + e.Key.ToString());
        }

        // Método para comprobar la información cuando se haga clic en el botón de inicio de sesión
        private void comprobarInformacion(object sender, RoutedEventArgs e)
        {
            // Lógica para verificar la información de inicio de sesión
            string usuario = tbxEmail.Text;
            string contraseña = pbxContraseña.Password;

            // Aquí puedes añadir la lógica de validación
            if (usuario == "Usuario" && contraseña == "Contraseña")
            {
                MessageBox.Show("Inicio de sesión exitoso.");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}