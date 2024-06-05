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
    /// Lógica de interacción para Checkout.xaml
    /// </summary>
    public partial class Checkout : UserControl
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void ResumenButton_Click(object sender, RoutedEventArgs e)
        {
            // Muestra un resumen del pedido
            if (DataContext is ViewModel viewModel)
            {
                string resumen = "Resumen del Pedido:\n\n";
                foreach (var producto in viewModel.PedidoActual.Productos)
                {
                    resumen += $"{producto.Vinilo.Titulo} x {producto.Cantidad} - {producto.PrecioTotal:C}\n";
                }
                resumen += $"\nTotal: {viewModel.PedidoActual.PrecioTotal:C}";
                MessageBox.Show(resumen, "Resumen del Pedido", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void PagarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel viewModel)
            {
                // Lógica de validación de los datos de la tarjeta y la dirección (simplificada)
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNumero.Text) ||
                    string.IsNullOrWhiteSpace(txtExpiracion.Text) || string.IsNullOrWhiteSpace(txtCVV.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoPostal.Text) || string.IsNullOrWhiteSpace(txtPais.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Finalizar el pedido
                viewModel.FinalizarPedido();

                // Cerrar la ventana de checkout
                
            }
        }
    }
}
