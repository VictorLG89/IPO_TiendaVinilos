using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public class ViewModel
    {
        public ObservableCollection<Vinilo> ListaDeseos => UsuarioActual.ListaDeseos;

        public void EliminarDeListaDeseos(Vinilo vinilo)
        {
            if (UsuarioActual.ListaDeseos.Contains(vinilo))
            {
                UsuarioActual.ListaDeseos.Remove(vinilo);
            }
        }
    }
}
