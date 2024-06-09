using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public static class UsuarioActual
    {
        public static string IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido1 { get; set; }
        public static string Apellido2 { get; set; }
        public static bool Admin { get; set; }
        public static string Correo { get; set; }
        public static Uri FotoPerfil { get; set; }
        public static string UltimoAcceso { set; get; }
        public static ObservableCollection<Vinilo> ListaDeseos { get; set; } = new ObservableCollection<Vinilo>();
        public static ObservableCollection<Producto> Cesta { get; set; } = new ObservableCollection<Producto>();
        public static ObservableCollection<Pedido> HistorialPedidos { get; set; } = new ObservableCollection<Pedido>();
        
    }

}
