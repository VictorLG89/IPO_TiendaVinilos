using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TiendaVinilos
{
    internal class Vinilo
    {
        public string Titulo { set; get; }
        public int Anio { set; get; }
        public int Duracion { set; get; }
        public Uri Portada { set; get; }
        public string Autor {set; get; }
        
        public Vinilo(string titulo, int anio, int duracion, Uri portada, string autor)
        {
            Titulo = titulo;
            Anio = anio;
            Duracion = duracion;
            Portada = portada;
            Autor = autor;
        }

    }
}
