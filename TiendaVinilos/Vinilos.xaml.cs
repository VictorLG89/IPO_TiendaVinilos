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
                var fichero = Application.GetResourceStream(new Uri("Vinilos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVinilo = new Vinilo("Titulo",1,2,null,null);

                nuevoVinilo.Titulo = node.Attributes["Titulo"]?.Value ?? "Desconocido";
                nuevoVinilo.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoVinilo.Duracion =Convert.ToInt32(node.Attributes["Duracion"].Value);
                nuevoVinilo.Portada = new Uri(node.Attributes["Portada"].Value, UriKind.Relative);
                nuevoVinilo.Autor = node.Attributes["Autor"].Value;
                nuevoVinilo.Precio = Convert.ToDouble(node.Attributes["Precio"].Value);

                

                listadoVinilos.Add(nuevoVinilo);
            }
        }
        private void Corazon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Obtener el vinilo seleccionado
            Vinilo viniloSeleccionado = (Vinilo)lstListaPeliculas.SelectedItem;

            // Verificar si el vinilo ya está en la lista de deseos del usuario actual
            if (UsuarioActual.ListaDeseos.Contains(viniloSeleccionado))
            {
                // Quitar el vinilo de la lista de deseos del usuario actual
                UsuarioActual.ListaDeseos.Remove(viniloSeleccionado);

                // Cambiar la imagen del corazón lleno por una imagen de corazón vacío
                Image corazon = (Image)sender;
                corazon.Source = new BitmapImage(new Uri("/Images/corazonVacio.png", UriKind.Relative));
            }
            else
            {
                // Agregar el vinilo a la lista de deseos del usuario actual
                UsuarioActual.ListaDeseos.Add(viniloSeleccionado);

                // Cambiar la imagen del corazón vacío por una imagen de corazón lleno
                Image corazon = (Image)sender;
                corazon.Source = new BitmapImage(new Uri("/Images/corazonLleno.png", UriKind.Relative));
            }
        }
        private void Corazon_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void Corazon_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
