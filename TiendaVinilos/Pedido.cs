using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TiendaVinilos
{
    public class Pedido : INotifyPropertyChanged
    {
        private bool completado;

        public ObservableCollection<Producto> Productos { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Fecha { get; set; }
        public bool Completado
        {
            get => completado;
            set
            {
                if (completado != value)
                {
                    completado = value;
                    OnPropertyChanged();
                }
            }
        }
        public double PrecioTotal => Productos.Sum(p => p.PrecioTotal);

        public Pedido(string direccion, string ciudad, string codigopostal, string pais)
        {
            Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            Productos = new ObservableCollection<Producto>();
            Completado = false;
            Direccion = direccion;
            Ciudad = ciudad;
            CodigoPostal = codigopostal;
            Pais = pais;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
