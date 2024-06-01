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
        public int AutorId { set; get; }

        public Autor(string nombre, int anio, string nacionalidad, int autorId)
        {
            Nombre = nombre;
            Anio = anio;
            Nacionalidad = nacionalidad;
            AutorId = autorId;
        }
    }
}
