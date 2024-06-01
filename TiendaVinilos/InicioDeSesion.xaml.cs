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
        private const string CadenaConexion = "Data Source=Data/Dbase.db";

        public InicioDeSesion()
        {
            InitializeComponent();
        }

        private void comprobarInformacion(object sender, RoutedEventArgs e)
        {
            string nombreUsuario = tbxEmail.Text;
            string contrasena = pbxContraseña.Password;

            if (ValidarCredenciales(nombreUsuario, contrasena))
            {
                MessageBox.Show("Inicio de sesión exitoso!", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                // Aquí puedes abrir la ventana principal de tu aplicación
                // Por ejemplo:
                MainWindow ventanaPrincipal = new MainWindow();
                ventanaPrincipal.Show();
                this.Close(); // Cierra la ventana de inicio de sesión
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Por favor, inténtalo de nuevo.", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCredenciales(string nombreUsuario, string contrasena)
        {
            // Aquí realizas la conexión a la base de datos y ejecutas la consulta SQL para validar las credenciales
            // Reemplaza "cadena_de_conexion_a_tu_base_de_datos" con tu cadena de conexión real
            string cadenaConexion = "Data Source=Data/Dbase.db";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Define tu consulta SQL para verificar las credenciales
                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena";

                // Crea y configura el comando SQL
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);

                try
                {
                    // Abre la conexión a la base de datos
                    conexion.Open();
                    // Ejecuta el comando y obtén el resultado
                    int resultado = (int)comando.ExecuteScalar();
                    // Si el resultado es mayor que cero, las credenciales son válidas
                    return resultado > 0;
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir durante la conexión o la ejecución de la consulta
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
    }
}