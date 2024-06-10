using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace TiendaVinilos
{
    public partial class AnadirPromocion : UserControl
    {
        private string rutaArchivo = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vinilos.xml");

        public AnadirPromocion()
        {
            InitializeComponent();
            CargarVinilos();
        }

        // Cargar los vinilos en los ComboBox (Artista y Disco) desde el archivo XML
        private void CargarVinilos()
        {
            try
            {
                if (System.IO.File.Exists(rutaArchivo))
                {
                    XDocument doc = XDocument.Load(rutaArchivo);

                    var vinilos = doc.Descendants("Vinilo")
                                     .Select(v => new Vinilo(
                                         int.Parse(v.Element("IdVinilo")?.Value ?? "0"),
                                         v.Element("Titulo")?.Value ?? "Desconocido",
                                         int.Parse(v.Element("Anio")?.Value ?? "0"),
                                         int.Parse(v.Element("Duracion")?.Value ?? "0"),
                                         new Uri(v.Element("Portada")?.Value ?? "http://defaulturi.com/portada.jpg"),
                                         v.Element("Autor")?.Value ?? "Desconocido",
                                         double.Parse(v.Element("Precio")?.Value ?? "0.0")
                                     ))
                                     .ToList();

                    // Poblamos el ComboBox de artistas y discos (asumiendo que cada artista tiene al menos un disco)
                    var artistas = vinilos.Select(v => v.Autor).Distinct().ToList();
                    ArtistaComboBox.ItemsSource = artistas;

                    // Poblamos el ComboBox de discos (asociado al artista seleccionado)
                    // Suponemos que tenemos algún evento que actualice los discos cuando se selecciona un artista
                    ArtistaComboBox.SelectionChanged += ArtistaComboBox_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los vinilos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Evento que se dispara cuando se selecciona un artista
        private void ArtistaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var artistaSeleccionado = ArtistaComboBox.SelectedItem as string;

            if (artistaSeleccionado != null)
            {
                try
                {
                    XDocument doc = XDocument.Load(rutaArchivo);
                    var vinilos = doc.Descendants("Vinilo")
                                     .Where(v => v.Element("Autor")?.Value == artistaSeleccionado)
                                     .Select(v => v.Element("Titulo")?.Value)
                                     .ToList();

                    DiscoComboBox.ItemsSource = vinilos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los discos para el artista seleccionado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Evento que se dispara cuando se hace clic en el botón "Guardar promoción"
        private void GuardarPromocion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombrePromocion = NombrePromocionTextBox.Text;
                string artistaSeleccionado = ArtistaComboBox.SelectedItem as string;
                string discoSeleccionado = DiscoComboBox.SelectedItem as string;
                DateTime fechaInicio = FechaInicioDatePicker.SelectedDate ?? DateTime.Now;
                DateTime fechaFin = FechaFinDatePicker.SelectedDate ?? DateTime.Now;
                double descuento;

                if (double.TryParse(DescuentoTextBox.Text, out descuento))
                {
                    if (!string.IsNullOrEmpty(nombrePromocion) && !string.IsNullOrEmpty(artistaSeleccionado) && !string.IsNullOrEmpty(discoSeleccionado))
                    {
                        // Crear y asignar la promoción
                        Promocion promocion = new Promocion
                        {
                            Nombre = nombrePromocion,
                            DescuentoPorcentaje = descuento,
                            FechaInicio = fechaInicio,
                            FechaFin = fechaFin
                        };

                        // Agregar la promoción al vinilo correspondiente en el XML
                        XDocument doc = XDocument.Load(rutaArchivo);
                        var viniloNode = doc.Descendants("Vinilo")
                                            .FirstOrDefault(v => v.Element("Titulo")?.Value == discoSeleccionado && v.Element("Autor")?.Value == artistaSeleccionado);

                        if (viniloNode != null)
                        {
                            viniloNode.Element("Promocion")?.Remove();
                            viniloNode.Add(new XElement("Promocion",
                                                new XElement("Nombre", promocion.Nombre),
                                                new XElement("Descuento", promocion.DescuentoPorcentaje),
                                                new XElement("FechaInicio", promocion.FechaInicio.ToString("yyyy-MM-dd")),
                                                new XElement("FechaFin", promocion.FechaFin.ToString("yyyy-MM-dd"))));

                            doc.Save(rutaArchivo);
                            MessageBox.Show("La promoción ha sido guardada exitosamente.", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El descuento debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la promoción: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Manejar el evento de clic en el botón Cancelar (simplemente limpia los campos o cierra el formulario)
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            NombrePromocionTextBox.Text = string.Empty;
            ArtistaComboBox.SelectedItem = null;
            DiscoComboBox.ItemsSource = null;
            FechaInicioDatePicker.SelectedDate = null;
            FechaFinDatePicker.SelectedDate = null;
            DescuentoTextBox.Text = string.Empty;
        }

        // Métodos para vincular los controles XAML con el código C#
        private TextBox NombrePromocionTextBoxControl => this.FindName("NombrePromocionTextBox") as TextBox;
        private ComboBox ArtistaComboBoxControl => this.FindName("ArtistaComboBox") as ComboBox;
        private ComboBox DiscoComboBoxControl => this.FindName("DiscoComboBox") as ComboBox;
        private DatePicker FechaInicioDatePickerControl => this.FindName("FechaInicioDatePicker") as DatePicker;
        private DatePicker FechaFinDatePickerControl => this.FindName("FechaFinDatePicker") as DatePicker;
        private TextBox DescuentoTextBoxControl => this.FindName("DescuentoTextBox") as TextBox;

        // Métodos de evento adicionales necesarios
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuardarPromocion_Click(sender, e);
          //  Cancelar_Click(sender, e);
        }
    }
}

