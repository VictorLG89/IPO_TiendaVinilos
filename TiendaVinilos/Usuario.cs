using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { set; get; }
        public string Nombre { set; get; }
        public string Apellido1 { set; get; }
        public string Apellido2 { set; get; }
        public bool Admin { set; get; }
        public string correo { set; get; }
        public Uri FotoPerfil { set; get; }
        public string Contrasena { set; get; }

        public Usuario(int id, string nombreUsuario, string nombre, string apellido1, string apellido2, bool admin, string Correo, Uri fotoPerfil, string contrasena)
        {
            IdUsuario = id;
            NombreUsuario = nombreUsuario;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Admin = admin;
            correo = Correo;
            FotoPerfil = fotoPerfil;
            Contrasena = contrasena;

        }
    }
}
