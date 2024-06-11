using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace TiendaVinilos
{
    public partial class AnadirDisco : UserControl
    {
        private string rutaImagen = string.Empty;
        private List<Vinilo> vinilos = new List<Vinilo>();
        private string rutaArchivo = @"C:\Users\lopez\Source\Repos\IPO_TiendaVinilos\TiendaVinilos\Vinilo.xml"; 

        public AnadirDisco()
        {
            InitializeComponent();
            CargarDiscos();
            PaisComboBox.ItemsSource = paises;
        }
        private void CargarDiscos()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    XDocument doc = XDocument.Load(rutaArchivo);
                    vinilos = doc.Descendants("Vinilo")
                        .Select(v => new Vinilo(
                            viniloId: int.Parse(v.Element("IdVinilo")?.Value), // Ajusta si el IdVinilo está como atributo en el XML
                            titulo: v.Element("Titulo")?.Value,
                            anio: DateTime.Parse(v.Element("FechaLanzamiento")?.Value).Year, // Obtener el año de la fecha de lanzamiento
                            duracion: double.Parse(v.Element("Duracion")?.Value), // Ajusta según el formato de tu XML
                            portada: null, // Ajusta si tienes la ruta de la imagen en el XML
                            autor: v.Element("Autor")?.Value,
                            precio: double.Parse(v.Element("Precio")?.Value)
                        ))
                        .ToList();

                    // Asignar los vinilos a la lista de ListBox
                    DiscosListBox.ItemsSource = vinilos;
                }
                else
                {
                    MessageBox.Show("El archivo XML no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los discos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                imgPortada.Source = bitmap; // Asignar la imagen seleccionada al control Image
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
            double precio= double.Parse(txtPrecio.Text);
            if (double.TryParse(txtPrecio.Text, out precio))
            {
                // El valor se pudo convertir correctamente a double
            }
            else
            {
                // Mostrar un mensaje de error al usuario o manejar la situación de otra manera
                MessageBox.Show("El precio ingresado no es válido. Por favor, ingrese un número decimal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            double duracion = double.Parse(DuracionTextBox.Text);
            if (double.TryParse(DuracionTextBox.Text, out duracion))
            {
                // La conversión fue exitosa, 'duracion' contiene el valor convertido
            }
            else
            {
                // La conversión falló, el texto no es un número entero válido
                MessageBox.Show("La duración ingresada no es válida. Por favor, ingrese un número entero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                        new XElement("Foto", base64Imagen),
                        new XElement("Precio", precio),
                        new XElement("Duracion", duracion)
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
        private void CargarVinilosDesdeXML()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    XDocument doc = XDocument.Load(rutaArchivo);
                    List<Vinilo> vinilos = new List<Vinilo>();

                    foreach (var element in doc.Root.Elements("Vinilo"))
                    {
                        int idVinilo = int.Parse(element.Element("IdVinilo").Value);
                        string titulo = element.Element("Titulo").Value;
                        int anio = int.Parse(element.Element("Anio").Value);
                        int duracion = int.Parse(element.Element("Duracion").Value);
                        Uri portada = new Uri(element.Element("Portada").Value);
                        string autor = element.Element("Autor").Value;
                        double precio = double.Parse(element.Element("Precio").Value);

                        vinilos.Add(new Vinilo(idVinilo, titulo, anio, duracion, portada, autor,precio));
                    }

                    // Mostrar los vinilos en la interfaz gráfica (por ejemplo, en un ListBox)
                    DiscosListBox.ItemsSource = vinilos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los vinilos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DiscosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Mostrar los detalles del vinilo seleccionado en la lista
            if (DiscosListBox.SelectedItem != null)
            {
                Vinilo viniloSeleccionado = (Vinilo)DiscosListBox.SelectedItem;
                lblTitulo.Content = viniloSeleccionado.Titulo;
                imgPortada.Source = new BitmapImage(viniloSeleccionado.Portada);
                lblAnio.Content = viniloSeleccionado.Anio;
                lblDuracion.Content = viniloSeleccionado.Duracion;
                txtPrecio.Text = $"{viniloSeleccionado.Precio} €";
            }
        }
        private List<string> paises = new List<string>
        {
            "España",
            "Estados Unidos",
            "Argentina",
            "México",
            
        };
        private void LimpiarCampos()
        {
            // Establecer todos los campos a su valor inicial
            NombreTextBox.Text = string.Empty;
            SelloDiscograficoTextBox.Text = string.Empty;
            AutorTextBox.Text = string.Empty;
            PaisComboBox.SelectedIndex = -1; // Desseleccionar cualquier país seleccionado
            FechaLanzamientoDatePicker.SelectedDate = DateTime.Now; // Establecer la fecha actual
            RedesSocialesTextBox.Text = string.Empty;
            DuracionTextBox.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            imgPortada.Source = null; // Limpiar la imagen
        }

        private void CancelarProceso_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }



    }
}
