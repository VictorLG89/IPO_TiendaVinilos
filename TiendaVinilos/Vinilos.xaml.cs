using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Linq;


namespace TiendaVinilos
{
    public partial class Vinilos : UserControl
    {
        List<Vinilo> listadoVinilos;
        private ViewModel viewModel;
        public Vinilos()
        {
            InitializeComponent();
            listadoVinilos = new List<Vinilo>();
            CargarContenidoListaXML();
            lstListaPeliculas.ItemsSource = listadoVinilos;
            viewModel = new ViewModel();
            DataContext = viewModel;

            // Comprobar si cada vinilo está en la lista de deseos del usuario
            foreach (Vinilo vinilo in listadoVinilos)
            {
                // Verificar si hay algún vinilo en la lista de deseos del usuario con el mismo IdVinilo
                if (UsuarioActual.ListaDeseos.Any(v => v.IdVinilo == vinilo.IdVinilo))
                {
                    vinilo.CorazonImage = "/Images/corazonLleno.png";
                }
                else
                {
                    vinilo.CorazonImage = "/Images/corazonVacio.png";
                }
            }
        }

        private void CargarContenidoListaXML()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Vinilos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVinilo = new Vinilo(0,"Titulo", 1, 2, null, null);

                nuevoVinilo.IdVinilo = Convert.ToInt32(node.Attributes["IdVinilo"].Value);
                nuevoVinilo.Titulo = node.Attributes["Titulo"]?.Value ?? "Desconocido";
                nuevoVinilo.Anio = Convert.ToInt32(node.Attributes["Anio"].Value);
                nuevoVinilo.Duracion = Convert.ToInt32(node.Attributes["Duracion"].Value);
                nuevoVinilo.Portada = new Uri(node.Attributes["Portada"].Value, UriKind.Relative);
                nuevoVinilo.Autor = node.Attributes["Autor"].Value;
                nuevoVinilo.Precio = Convert.ToDouble(node.Attributes["Precio"].Value);

                listadoVinilos.Add(nuevoVinilo);
            }
        }
        private void imgCorazon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image imgCorazon = (Image)sender;
            Vinilo viniloSeleccionado = (Vinilo)imgCorazon.DataContext;

            if (viniloSeleccionado != null)
            {
                // Verificar si el vinilo seleccionado ya está en la lista de deseos del usuario
                bool estaEnListaDeseos = UsuarioActual.ListaDeseos.Any(v => v.IdVinilo == viniloSeleccionado.IdVinilo);

                if (estaEnListaDeseos)
                { 
                    viewModel.EliminarDeListaDeseos(viniloSeleccionado);
                    imgCorazon.Source = new BitmapImage(new Uri("/Images/corazonVacio.png", UriKind.Relative));
                }
                else
                {
                    // Si el vinilo no está en la lista de deseos, lo agregamos y cambiamos la imagen del corazón a lleno
                    UsuarioActual.ListaDeseos.Add(viniloSeleccionado);
                    imgCorazon.Source = new BitmapImage(new Uri("/Images/corazonLleno.png", UriKind.Relative));
                }
            }
        }



        private void imgCorazon_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void imgCorazon_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

    }
}
