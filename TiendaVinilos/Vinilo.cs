using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TiendaVinilos
{
    public class Vinilo
    {
        public int IdVinilo { set; get; }
        public string Titulo { set; get; }
        public int Anio { set; get; }
        public int Duracion { set; get; }
        public Uri Portada { set; get; }
        public string Autor {set; get; }
        public double Precio { set; get; }
        public string CorazonImage { get; set; }
        public string Promocion { get; set; }

        public Vinilo(int IdVinilo, string titulo, int anio, int duracion, Uri portada, string autor, double precio)
        {
            Titulo = titulo;
            Anio = anio;
            Duracion = duracion;
            Portada = portada;
            Autor = autor;
            Precio = precio;
            CorazonImage = "Images/corazonVacio.png";

        }

    }
}
