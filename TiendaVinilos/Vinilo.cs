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
        public double Duracion { set; get; }
        public Uri Portada { set; get; }
        public string Autor {set; get; }
        public double Precio { set; get; }
        public string CorazonImage { get; set; }
        public Promocion Promocion { get; set; }

        public Vinilo(int viniloId, string titulo, int anio, double duracion, Uri portada, string autor, double precio)
        {
            IdVinilo = viniloId;
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
