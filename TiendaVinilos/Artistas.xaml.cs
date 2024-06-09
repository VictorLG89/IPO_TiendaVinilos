using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.Threading;

namespace TiendaVinilos
{
    public partial class Artistas : UserControl
    {
        List<Autor> listadoAutores;

        public Artistas(string culture)
        {
            InitializeComponent();
            // Cambiar el diccionario de recursos según el idioma seleccionado
            Resources.MergedDictionaries.Add(App.SelectCulture(culture));
            // Crear el listado de autores
            listadoAutores = new List<Autor>();
            // Cargar los datos de prueba de un fichero XML
            CargarContenidoListaXML();
            // Indicar que el origen de datos del ListBox es listadoAutores
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
                nuevoAutor.IdAutor = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoAutor.Tipo = node.Attributes["Tipo"]?.Value ?? "Desconocido";
                nuevoAutor.Foto = new Uri(node.Attributes["Foto"].Value, UriKind.Relative);
                listadoAutores.Add(nuevoAutor);
            }
        }

        
    }
}
