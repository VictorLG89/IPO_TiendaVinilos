using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace TiendaVinilos
{
    public partial class AnadirDisco : UserControl
    {
        private string rutaImagen = string.Empty;
        private string rutaArchivo = @"C:\Users\lopez\Source\Repos\IPO_TiendaVinilos\TiendaVinilos\Vinilo.xml";

        public AnadirDisco()
        {
            InitializeComponent();
            CargarDiscos();
        }
        private void CargarDiscos()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    XDocument doc = XDocument.Load(rutaArchivo);
                    var discos = doc.Descendants("Vinilo")
                                    .Select(v => new
                                    {
                                        Nombre = v.Element("Nombre")?.Value,
                                        SelloDiscografico = v.Element("SelloDiscografico")?.Value
                                    })
                                    .ToList();

                    DiscosListBox.ItemsSource = discos;
                    DiscosListBox.DisplayMemberPath = "Nombre";
                }
            }
            catch (Exception)
            {
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para seleccionar una imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                rutaImagen = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                ImagenVinilo.Source = bitmap; // Asignar la imagen seleccionada al control Image
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos de la interfaz de usuario
            string nombre = NombreTextBox.Text;
            string selloDiscografico = SelloDiscograficoTextBox.Text;
            string autor = AutorTextBox.Text; // Ajuste si el autor es un TextBox en lugar de un ComboBox
            string pais = PaisComboBox.Text;
            DateTime fechaLanzamiento = FechaLanzamientoDatePicker.SelectedDate ?? DateTime.Now;
            string enlacesRedesSociales = RedesSocialesTextBox.Text;

            // Convertir la imagen a base64 si se ha seleccionado una
            string base64Imagen = string.Empty;
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                base64Imagen = ConvertirImagenABase64(rutaImagen);
            }

            try
            {
                // Crear el XML
                XDocument doc;
                if (File.Exists(rutaArchivo))
                {
                    doc = XDocument.Load(rutaArchivo);
                }
                else
                {
                    doc = new XDocument(new XElement("Vinilo"));
                }

                doc.Root.Add(
                    new XElement("Vinilo",
                        new XElement("Nombre", nombre),
                        new XElement("SelloDiscografico", selloDiscografico),
                        new XElement("Autor", autor),
                        new XElement("Pais", pais),
                        new XElement("FechaLanzamiento", fechaLanzamiento.ToString("yyyy-MM-dd")),
                        new XElement("EnlacesRedesSociales", enlacesRedesSociales),
                        new XElement("Foto", base64Imagen)
                    )
                );

                // Guardar el XML en un archivo
                doc.Save(rutaArchivo);

                MessageBox.Show("El disco ha sido guardado exitosamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refrescar la lista de discos
                CargarDiscos();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar guardar el disco. Inténtalo de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = DiscosListBox.SelectedItem;
            if (seleccionado != null)
            {
                string nombreDisco = ((dynamic)seleccionado).Nombre;

                // Cargar el documento XML y encontrar el disco a eliminar
                XDocument doc = XDocument.Load(rutaArchivo);
                var discoAEliminar = doc.Descendants("Vinilo")
                        .FirstOrDefault(v => v.Element("Nombre")?.Value == nombreDisco);


                if (discoAEliminar != null)
                {
                    discoAEliminar.Remove();
                    doc.Save(rutaArchivo);
                    MessageBox.Show($"El disco '{nombreDisco}' ha sido eliminado.", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Refrescar la lista de discos
                    CargarDiscos();
                }
                else
                {
                    MessageBox.Show("No se encontró el disco a eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un disco para eliminar.", "Selección requerida", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private string ConvertirImagenABase64(string rutaImagen)
        {
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            return Convert.ToBase64String(imagenBytes);
        }

    }
}