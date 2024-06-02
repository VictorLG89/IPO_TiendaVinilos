using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    internal class Autor
    {
        public string Nombre { set; get; }
        public int Anio { set; get; }
        public string Nacionalidad { set; get; }
        public int IdAutor { set; get; }
        public string Tipo { set; get; }

        public Uri Foto { set; get; }

        public Autor(string nombre, int anio, string nacionalidad, int autorId, string tipo, Uri foto)
        {
            Nombre = nombre;
            Anio = anio;
            Nacionalidad = nacionalidad;
            IdAutor = autorId;
            Tipo = tipo;
            Foto = foto;

        }
    }
}
