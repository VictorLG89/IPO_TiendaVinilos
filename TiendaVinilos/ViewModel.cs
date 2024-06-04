using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Producto> Cesta => UsuarioActual.Cesta;
        public ObservableCollection<Vinilo> ListaDeseos => UsuarioActual.ListaDeseos;


        public ViewModel()
        {
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
