using System;
using System.Collections.Generic;
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
        private string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "artistas.xml");

        public AnadirArtista()
        {
            InitializeComponent();
            CargarArtistas();
            NacionalidadComboBox.ItemsSource = nacionalidad;
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
                                          FechaNacimiento = DateTime.Parse(a.Element("FechaNacimiento")?.Value ?? DateTime.MinValue.ToString()),
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaImagen = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                ImagenArtista.Source = bitmap;
            }
        }

        private void GuardarArtista_Click(object sender, RoutedEventArgs e)
        {
            string nombreArtistico = NombreArtisticoTextBox.Text;
            string nombre = NombreTextBox.Text;
            string apellidos = ApellidosTextBox.Text;
            string nacionalidad = NacionalidadComboBox.Text;
            DateTime fechaNacimiento = FechaNacimientoDatePicker.SelectedDate ?? DateTime.Now;
            string enlacesRedesSociales = RedesSocialesTextBox.Text;

            GuardarArtistaEnXML(nombreArtistico, nombre, apellidos, nacionalidad, fechaNacimiento, enlacesRedesSociales);

            MessageBox.Show("El artista ha sido guardado exitosamente.", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

            CargarArtistas();
        }

        private void GuardarArtistaEnXML(string nombreArtistico, string nombre, string apellidos, string nacionalidad, DateTime fechaNacimiento, string enlacesRedesSociales)
        {
            try
            {
                XElement artista = new XElement("Artista",
                                        new XElement("NombreArtistico", nombreArtistico),
                                        new XElement("Nombre", nombre),
                                        new XElement("Apellidos", apellidos),
                                        new XElement("Nacionalidad", nacionalidad),
                                        new XElement("FechaNacimiento", fechaNacimiento.ToString("yyyy-MM-dd")),
                                        new XElement("EnlacesRedesSociales", enlacesRedesSociales));

                if (!File.Exists(rutaArchivo))
                {
                    XDocument doc = new XDocument(new XElement("Artistas"));
                    doc.Save(rutaArchivo);
                }

                XDocument documentoArtistas = XDocument.Load(rutaArchivo);

                documentoArtistas.Element("Artistas").Add(artista);

                documentoArtistas.Save(rutaArchivo);
            }
            catch (Exception ex)
            {
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string rutaImagen = openFileDialog.FileName;

                // Añadir la imagen a la galería de fotos
            }
        }

        private string ConvertirImagenABase64(string rutaImagen)
        {
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            return Convert.ToBase64String(imagenBytes);
        }
        private List<string> nacionalidad = new List<string>
        {
            "España",
            "Estados Unidos",
            "Argentina",
            "México",

        };
        private void CancelarProceso_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            NombreArtisticoTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            NacionalidadComboBox.SelectedIndex = -1;
            FechaNacimientoDatePicker.SelectedDate = null;
            RedesSocialesTextBox.Text = string.Empty;
            ImagenArtista.Source = null;
            // Limpiar otros campos que necesites
        }

    }
}
