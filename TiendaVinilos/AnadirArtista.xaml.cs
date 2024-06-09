using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Microsoft.Win32;

namespace TiendaVinilos
{
    public partial class AnadirArtista : UserControl
    {
        // Ruta para el archivo XML en la carpeta AppData
        private string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "artistas.xml");

        public AnadirArtista()
        {
            InitializeComponent();
            CargarArtistas();
        }

        private void CargarArtistas()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    XDocument doc = XDocument.Load(rutaArchivo);

                    var artistas = doc.Descendants("Artista")
                                      .Select(a => new Artista
                                      {
                                          NombreArtistico = a.Element("NombreArtistico")?.Value,
                                          Nombre = a.Element("Nombre")?.Value,
                                          Apellidos = a.Element("Apellidos")?.Value,
                                          Nacionalidad = a.Element("Nacionalidad")?.Value,
                                          FechaNacimiento = DateTime.Parse(a.Element("FechaNacimiento")?.Value),
                                          EnlacesRedesSociales = a.Element("EnlacesRedesSociales")?.Value
                                      })
                                      .ToList();

                    ArtistaListBox.ItemsSource = artistas;
                    ArtistaListBox.DisplayMemberPath = "NombreArtistico";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los artistas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para seleccionar una imagen del artista
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaImagen = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                ImagenArtista.Source = bitmap; // Asignar la imagen seleccionada al control Image
            }
        }

        private void GuardarArtista_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del artista desde la interfaz de usuario
            string nombreArtistico = NombreArtisticoTextBox.Text;
            string nombre = NombreTextBox.Text;
            string apellidos = ApellidosTextBox.Text;
            string nacionalidad = NacionalidadComboBox.Text;
            DateTime fechaNacimiento = FechaNacimientoDatePicker.SelectedDate ?? DateTime.Now;
            string enlacesRedesSociales = RedesSocialesTextBox.Text;

            // Guardar los datos del artista en un archivo XML
            GuardarArtistaEnXML(nombreArtistico, nombre, apellidos, nacionalidad, fechaNacimiento, enlacesRedesSociales);

            // Mostrar mensaje de éxito
            MessageBox.Show("El artista ha sido guardado exitosamente.", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

            // Actualizar la lista de artistas en la interfaz
            CargarArtistas();
        }

        private void GuardarArtistaEnXML(string nombreArtistico, string nombre, string apellidos, string nacionalidad, DateTime fechaNacimiento, string enlacesRedesSociales)
        {
            try
            {
                // Crear un nuevo elemento XML para el artista
                XElement artista = new XElement("Artista",
                                        new XElement("NombreArtistico", nombreArtistico),
                                        new XElement("Nombre", nombre),
                                        new XElement("Apellidos", apellidos),
                                        new XElement("Nacionalidad", nacionalidad),
                                        new XElement("FechaNacimiento", fechaNacimiento.ToString("yyyy-MM-dd")),
                                        new XElement("EnlacesRedesSociales", enlacesRedesSociales));

                // Verificar si el archivo existe, si no existe, crearlo y agregar el elemento raíz
                if (!File.Exists(rutaArchivo))
                {
                    XDocument doc = new XDocument(new XElement("Artistas"));
                    doc.Save(rutaArchivo);
                }

                // Cargar el documento XML de artistas
                XDocument documentoArtistas = XDocument.Load(rutaArchivo);

                // Agregar el nuevo artista al documento
                documentoArtistas.Element("Artistas").Add(artista);

                // Guardar los cambios en el archivo XML
                documentoArtistas.Save(rutaArchivo);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el proceso de guardado
                MessageBox.Show($"Error al guardar el artista: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarArtista_Click(object sender, RoutedEventArgs e)
        {
            var artistaSeleccionado = ArtistaListBox.SelectedItem as Artista;

            if (artistaSeleccionado != null)
            {
                string nombreArtistico = artistaSeleccionado.NombreArtistico;

                if (MessageBox.Show($"¿Estás seguro de que deseas eliminar a {nombreArtistico}?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        XDocument documentoArtistas = XDocument.Load(rutaArchivo);

                        XElement artistaEliminar = documentoArtistas.Descendants("Artista")
                                                      .FirstOrDefault(a => a.Element("NombreArtistico")?.Value == nombreArtistico);

                        if (artistaEliminar != null)
                        {
                            artistaEliminar.Remove();
                            documentoArtistas.Save(rutaArchivo);
                            CargarArtistas();
                            MessageBox.Show("El artista ha sido eliminado exitosamente.", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el artista en el archivo XML.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el artista: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artista para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void AñadirFotoGaleria_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para seleccionar una imagen para la galería de fotos del artista
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaImagen = openFileDialog.FileName;

                // Aquí puedes manejar la lógica para añadir la imagen a la galería de fotos
                // Por ejemplo, puedes agregar la imagen a una ListBox o a una lista de imágenes para mostrar en la interfaz de usuario
            }
        }

        private string ConvertirImagenABase64(string rutaImagen)
        {
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            return Convert.ToBase64String(imagenBytes);
        }
        //private void Cancelar_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindowAdmin mainWindow = Application.Current.MainWindow as MainWindowAdmin;
        //    if (mainWindow != null)
        //    {
        //        mainWindow.VolverAlMenuPrincipal();
        //    }

        //}
    }
}
