using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaVinilos
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Producto> Cesta => UsuarioActual.Cesta;
        public ObservableCollection<Vinilo> ListaDeseos => UsuarioActual.ListaDeseos;
        public ObservableCollection<Pedido> HistorialPedidos => UsuarioActual.HistorialPedidos;
        // public ObservableCollection<Producto> Pedido;
        public Pedido PedidoActual = new Pedido(null,null,null,null);

        public ViewModel()
        {
        }
        //private void OpenCheckoutWindow(object parameter)
        //{
          //  Checkout checkoutWindow = new Checkout();
            //checkoutWindow.DataContext = this; // Pasar el ViewModel a la ventana de checkout
            //checkoutWindow.ShowDialog();
        //}

        public void FinalizarPedido()
        {
            PedidoActual.Productos = Cesta;
            UsuarioActual.HistorialPedidos.Add(PedidoActual);
            UsuarioActual.Cesta.Clear();
            PedidoActual = new Pedido(null,null,null,null); // Crear un nuevo pedido para la siguiente compra
            OnPropertyChanged(nameof(Pedido));
            OnPropertyChanged(nameof(Cesta));                  
        }
        public void EliminarDeListaDeseos(Vinilo vinilo)
        {
            if (ListaDeseos.Contains(vinilo))
            {
                ListaDeseos.Remove(vinilo);
            }
        }

        public void EliminarDeCesta(Producto producto)
        {
            if (Cesta.Contains(producto))
            {
                if (producto.Cantidad > 1)
                {
                    producto.Cantidad--; // Restar 1 a la cantidad si es mayor que 1

                }
                else
                {
                    Cesta.Remove(producto); // Eliminar el producto si la cantidad es 1 o menos
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
