﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public static string culture2 { get; set; }
        public MainWindowAdmin()
        {
            InitializeComponent();
            
            DataContext = new ViewModel();
            culture2 = "es-ES";
        }

       

        private void AddVinilos(object sender, MouseButtonEventArgs e)
        {
            
            MainContentFrame.Navigate(new AnadirDisco());
           
        }

        private void AddArtistas(object sender, MouseButtonEventArgs e)
        {
           
             MainContentFrame.Navigate(new AnadirArtista());
            
        }

        private void OnOfertasClicked(object sender, MouseButtonEventArgs e)
        {
            MainContentFrame.Navigate(new AnadirPromocion());
        }

       
        private void OpenPerfilUser(object sender, MouseButtonEventArgs e)
        {
            PerfilUser.MainContentFrame = MainContentFrame;
            MainContentFrame.Navigate(new PerfilUser(culture2));
        }

        private void OpenWindow(Window window)
        {
            window.Show();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Aquí colocas la lógica que deseas ejecutar cuando cambia la selección en el ComboBox
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Manejo del evento TextBox
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Manejo del evento Label
        }
        
    }
}
