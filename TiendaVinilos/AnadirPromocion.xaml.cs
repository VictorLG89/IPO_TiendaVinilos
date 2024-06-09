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

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para AnadirPromocion.xaml
    /// </summary>
    public partial class AnadirPromocion : UserControl
    {
        public AnadirPromocion()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Cargar el archivo XML de los vinilos
                XDocument doc = XDocument.Load(rutaArchivoVinilos);

                // Obtener la lista de vinilos
                List<Vinilo> vinilos = doc.Descendants("Vinilo")
                    .Select(v => new Vinilo
                    {
                        Nombre = v.Element("Nombre")?.Value,
                        SelloDiscografico = v.Element("SelloDiscografico")?.Value,
                        Autor = v.Element("Autor")?.Value,
                        Pais = v.Element("Pais")?.Value,
                        FechaLanzamiento = DateTime.Parse(v.Element("FechaLanzamiento")?.Value),
                        EnlacesRedesSociales = v.Element("EnlacesRedesSociales")?.Value,
                        Foto = v.Element("Foto")?.Value,
                        Precio = double.Parse(v.Element("Precio")?.Value),
                        Promocion = v.Element("Promocion") != null ? new Promocion
                        {
                            // Aquí puedes agregar la lógica para obtener los datos de la promoción
                            // Puedes utilizar el mismo enfoque que se usó para cargar los datos de los vinilos
                        } : null
                    })
                    .ToList();

                // Aplicar las promociones (si es necesario)
                // Puedes implementar lógica para aplicar las promociones aquí

                // Guardar los cambios en el archivo XML (si es necesario)
                // Puedes implementar lógica para guardar los cambios aquí

                MessageBox.Show("Las promociones se han aplicado correctamente.", "Promociones aplicadas", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar las promociones: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
