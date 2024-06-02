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
    /// Lógica de interacción para Artistas.xaml
    /// </summary>
    public partial class Artistas : UserControl
    {
        List<Autor> listadoAutores;
        public Artistas()
        {
            InitializeComponent();
            // Crear el listado de películas
            listadoAutores = new List<Autor>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstListaArtistas.ItemsSource = listadoAutores;
        }

        private void CargarContenidoListaXML()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Autores.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoAutor = new Autor("Nombre", 1, null, 0, null, null);

                nuevoAutor.Nombre = node.Attributes["Nombre"]?.Value ?? "Desconocido";
                nuevoAutor.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoAutor.Nacionalidad = node.Attributes["Nacionalidad"]?.Value ?? "Desconocido";
                ///nuevoVinilo.Argumento = node.Attributes["Argumento"].Value;
                nuevoAutor.IdAutor = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoAutor.Tipo = node.Attributes["Tipo"]?.Value ?? "Desconocido";
                nuevoAutor.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                ///nuevoVinilo.GeneroPelicula = node.Attributes["Genero"].Value;
                ///nuevoVinilo.AltaEnVideoteca = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value);
                ///nuevoVinilo.Visualizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value);
                ///nuevoVinilo.URL_IMDB = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute);


                listadoAutores.Add(nuevoAutor);
            }
        }
    }
}
