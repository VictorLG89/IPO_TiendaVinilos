using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public static class UsuarioActual
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido1 { get; set; }
        public static string Apellido2 { get; set; }
        public static bool Admin { get; set; }
        public static string Correo { get; set; }
        public static string FotoPerfil { get; set; }
        public static List<Vinilo> ListaDeseos { get; set; } = new List<Vinilo>();
    }
}
