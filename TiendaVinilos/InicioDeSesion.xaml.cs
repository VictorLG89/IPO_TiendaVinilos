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
using System.Xml;
using System.Xml.Linq;

namespace TiendaVinilos
{
    public partial class InicioDeSesion : Window
    {
        private string rutaXml = "Usuarios.xml";

        public InicioDeSesion()
        {
            InitializeComponent();
            tbxEmail.Text = "Usuario";
            pbxContraseña.Password = "Contrasena";
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Usuario")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Cambia el color del texto a negro
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Usuario";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Cambia el color del texto a gris
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null && passwordBox.Password == "Contrasena")
            {
                passwordBox.Password = "";
                passwordBox.Foreground = new SolidColorBrush(Colors.Black); // Cambia el color del texto a negro
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null && string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordBox.Password = "Contrasena";
                passwordBox.Foreground = new SolidColorBrush(Colors.Gray); // Cambia el color del texto a gris
            }
        }

        private void comprobarInformacion(object sender, RoutedEventArgs e)
        {
            string nombreUsuario = tbxEmail.Text;
            string contraseña = pbxContraseña.Password;

            if (ValidarCredenciales(nombreUsuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                lblEstado.Content = "Usuario o contraseña incorrectos";
                lblEstado.Foreground = new SolidColorBrush(Colors.Red);

                // Limpiar las cajas de texto y password
                tbxEmail.Clear();
                pbxContraseña.Clear();
            }
        }

        private bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                var fichero = Application.GetResourceStream(new Uri("Usuarios.xml", UriKind.Relative));
                doc.Load(fichero.Stream);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    string nombreUsuarioXml = node.Attributes["NombreUsuario"]?.Value;
                    string contraseñaXml = node.Attributes["Contrasena"]?.Value;

                    if (nombreUsuario == nombreUsuarioXml && contraseña == contraseñaXml)
                    {
                        UsuarioActual.IdUsuario = int.Parse(node.Attributes["IdUsuario"].Value);
                        UsuarioActual.NombreUsuario = nombreUsuarioXml;
                        UsuarioActual.Nombre = node.Attributes["Nombre"].Value;
                        UsuarioActual.Apellido1 = node.Attributes["Apellido1"].Value;
                        UsuarioActual.Apellido2 = node.Attributes["Apellido2"].Value;
                        UsuarioActual.Admin = bool.Parse(node.Attributes["Admin"].Value);
                        UsuarioActual.Correo = node.Attributes["correo"].Value;
                        UsuarioActual.FotoPerfil = node.Attributes["FotoPerfil"].Value;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo XML: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void mostrarLetraPulsada(object sender, KeyEventArgs e)
        {
        }
    }
}