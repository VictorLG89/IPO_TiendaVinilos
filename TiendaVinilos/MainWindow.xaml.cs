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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    using System.Windows;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenProductos(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Productos Productos = new Productos();

            Productos.Show();
        }

        private void OpenQuienSomos(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            QuienSomos QuienSomos = new QuienSomos();

            QuienSomos.Show();
        }

        private void OpenListaDeseados(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListaDeseados ListaDeseados = new ListaDeseados();

            ListaDeseados.Show();
        }

        private void OpenPerfilUser(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PerfilUser PerfilUser = new PerfilUser();

            PerfilUser.Show();
        }

        private void OpenPreguntas(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Preguntas Preguntas = new Preguntas();

            Preguntas.Show();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextAlignment center = TextAlignment.Center;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
