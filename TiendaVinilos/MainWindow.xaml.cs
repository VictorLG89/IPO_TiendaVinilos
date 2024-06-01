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
    using TiendaVinilos.Data;
    using TiendaVinilos.Services;
    using TiendaVinilos.Models;
    using TiendaVinilos.Properties;
    using Microsoft.EntityFrameworkCore;

    public partial class MainWindow : Window
    {
        private readonly ViniloService _vinylService;
        private readonly AppDbContext _context;

        
        public MainWindow()
        {
            InitializeComponent();
            var dbContext = new AppDbContext(new DbContextOptions<AppDbContext>()); // Crea una instancia de AppDbContext
            var _vinylService = new ViniloService(dbContext); // Crea una instancia de ViniloService pasando el contexto de la base de datos como argumento
            
        }
        private void OpenArtistas(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AnadirArtista());
        }
        private void OpenPromociones(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AnadirPromocion());
        }
        private void OpenProductos(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new Productos());
        }

        private void OpenQuienSomos(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new QuienSomos());
        }

        private void OpenListaDeseados(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new ListaDeseados());
        }

        private void OpenPerfilUser(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new PerfilUser());
        }

        private void OpenPreguntas(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new Preguntas());
        }

        private void OpenCesta(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new cesta());
        }

        private void OpenWindow(Window window)
        {
            window.Show();
        }

        private void AddVinilo(object sender, RoutedEventArgs e)
        {
            var newVinilo = new Vinilo
            {
                Nombre = "Nuevo Vinilo",
                Autor = _vinylService.GetAllAutores()[0], // Asigna un autor existente
                Portada = "Sin Portada"
            };
            _vinylService.AddVinilo(newVinilo);
        }


        private void AddAutor(object sender, RoutedEventArgs e)
        {
            var newAutor = new Autor
            {
                Nombre = "Nuevo Autor",
                Tipo = "Solista"
            };
            _vinylService.AddAutor(newAutor);
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
