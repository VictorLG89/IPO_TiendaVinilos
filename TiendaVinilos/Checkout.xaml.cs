using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ViewModel viewModel;
        public static Frame MainContentFrame { get; set; }
        public Checkout()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Cambia el color del texto a negro
            }
        }
        public void SetMainContentFrame(Frame mainContentFrame)
        {
            MainContentFrame = mainContentFrame;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Cambia el color del texto a gris
            }
        }

        private void ResumenButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el ViewModel del DataContext del UserControl actual
            ViewModel viewModel = this.DataContext as ViewModel;

            // Verificar si el ViewModel es válido
            if (viewModel != null)
            {
                // Crear una instancia de la ventana Resumen y pasar el ViewModel como argumento
                Resumen resumenWindow = new Resumen(viewModel);

                // Mostrar la ventana Resumen
                resumenWindow.ShowDialog();
            }
            else
            {
                // Manejar el caso en el que el ViewModel no sea válido
                MessageBox.Show("Error: No se pudo obtener el ViewModel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PagarButton_Click(object sender, RoutedEventArgs e)
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
            //viewModel.FinalizarPedido();
            Pedido PedidoActual = new Pedido(txtCiudad.Text, txtCodigoPostal.Text, txtPais.Text, txtDireccion.Text);

            // Crear una nueva lista de productos para evitar la referencia de la misma lista
            PedidoActual.Productos = new ObservableCollection<Producto>(UsuarioActual.Cesta.Select(p => new Producto
            {
                Vinilo = p.Vinilo,
                Cantidad = p.Cantidad,
                //PrecioTotal = p.PrecioTotal
            }));

            

            UsuarioActual.HistorialPedidos.Add(PedidoActual);

            UsuarioActual.Cesta.Clear();
            PedidoActual = new Pedido(null, null, null, null); // Crear un nuevo pedido para la siguiente compra

            MessageBox.Show("Pedido realizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            // Cerrar la ventana de checkout
            MainContentFrame.Navigate(new Vinilos());

        }
    }
}
