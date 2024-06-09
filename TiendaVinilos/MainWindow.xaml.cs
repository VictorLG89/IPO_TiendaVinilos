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
    using System.Windows;
    using System.Windows.Input;
    using TiendaVinilos.Properties;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public partial class MainWindow : Window
    {
        private string currentCulture = "es-ES";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
        }
        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbIdiomas.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP")) && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                ChangeCulture("es-ES");
            }
            else if (selectedText.Equals("EN") && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                ChangeCulture("en-US");
            }
        }

        private void ChangeCulture(string culture)
        {
            currentCulture = culture;
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(App.SelectCulture(culture));
            
        }
        private void OpenArtistas(object sender, RoutedEventArgs e)
        {

            MainContentFrame.Navigate(new Artistas(currentCulture));
        }
        private void OpenPromociones(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ProductosAdmin());
        }
        private void OpenProductos(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new Vinilos(currentCulture));
        }

        private void OpenQuienSomos(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new QuienSomos(currentCulture));
        }

        private void OpenListaDeseados(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new ListaDeseados(currentCulture));
        }

        private void OpenPerfilUser(object sender, MouseButtonEventArgs e)
        {
            PerfilUser.MainContentFrame = MainContentFrame;
            MainContentFrame.Navigate(new PerfilUser(currentCulture));
        }

        private void OpenPreguntas(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new Preguntas(currentCulture));
        }

        private void OpenCesta(object sender, MouseButtonEventArgs e)
        {
            cesta.MainContentFrame = MainContentFrame;
            MainContentFrame.Navigate(new cesta(currentCulture));
        }

        private void OpenWindow(Window window)
        {
            window.Show();
        }

        private void AddVinilo(object sender, RoutedEventArgs e)
        {
            
        }


        private void AddAutor(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Manejo del evento ComboBox
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Manejo del evento TextBox
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Manejo del evento Label
        }

        private void lstListaPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
