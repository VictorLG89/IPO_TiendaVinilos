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
        List<Usuario> listadoUsuarios;
        public PerfilUser()
        {
            InitializeComponent();
            // Crear el listado de películas
            listadoUsuarios = new List<Usuario>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstListaUsuarios.ItemsSource = listadoUsuarios;
        }

        private void CargarContenidoListaXML()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Usuarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoUsuario = new Usuario(0, "Nombre", null, null, null, false, null, null, null);

                nuevoUsuario.NombreUsuario = node.Attributes["NombreUsuario"]?.Value ?? "Desconocido";
                nuevoUsuario.Nombre = node.Attributes["Nombre"]?.Value ?? "Desconocido";
                nuevoUsuario.IdUsuario = Convert.ToInt32(node.Attributes["IdUsuario"].Value);
                nuevoUsuario.Apellido1 = node.Attributes["Apellido1"]?.Value ?? "Desconocido";
                nuevoUsuario.Apellido2 = node.Attributes["Apellido2"]?.Value ?? "Desconocido";
                nuevoUsuario.Admin = bool.TryParse(node.Attributes["Admin"]?.Value, out bool isAdmin) ? isAdmin : false;
                nuevoUsuario.correo = node.Attributes["correo"]?.Value ?? "Desconocido";
                nuevoUsuario.FotoPerfil = new Uri(node.Attributes["FotoPerfil"].Value, UriKind.Relative);
                nuevoUsuario.Contrasena = node.Attributes["Contrasena"]?.Value ?? "Desconocido";

                listadoUsuarios.Add(nuevoUsuario);
            }
        }
    }
}
