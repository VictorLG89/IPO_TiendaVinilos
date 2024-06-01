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
using TiendaVinilos.Models;

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para Vinilos.xaml
    /// </summary>
    
    public partial class Vinilos : UserControl
    {
        List<Vinilo> listadoVinilos;
        public Vinilos()
        {
            InitializeComponent();
            // Crear el listado de películas
            listadoVinilos = new List<Vinilo>();
            // Se cargarán los datos de prueba de un fichero XML
            CargarContenidoListaXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstListaPeliculas.ItemsSource = listadoVinilos;
        }
    
        private void CargarContenidoListaXML()
        {
            XmlDocument doc = new XmlDocument();
                var fichero = Application.GetResourceStream(new Uri("Datos/Vinilos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVinilo = new Vinilo("",0,0,null,null);

                nuevoVinilo.Titulo = node.Attributes["Titulo"].Value;
                nuevoVinilo.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoVinilo.Duracion =Convert.ToInt32(node.Attributes["Duracion"].Value);
                ///nuevoVinilo.Argumento = node.Attributes["Argumento"].Value;
                nuevoVinilo.Portada = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative);
               /// nuevoVinilo.Director = node.Attributes["Director"].Value;
                ///nuevoVinilo.GeneroPelicula = node.Attributes["Genero"].Value;
                ///nuevoVinilo.AltaEnVideoteca = Convert.ToDateTime(node.Attributes["AltaEnVideoteca"].Value);
                ///nuevoVinilo.Visualizada = Convert.ToBoolean(node.Attributes["Visualizada"].Value);
                ///nuevoVinilo.URL_IMDB = new Uri(node.Attributes["URL_IMDB"].Value, UriKind.Absolute);
            
                listadoVinilos.Add(nuevoVinilo);
            }
        }
    }
}
