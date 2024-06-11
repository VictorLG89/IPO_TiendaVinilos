using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public partial class Artista
    {
        public string NombreArtistico { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EnlacesRedesSociales { get; set; }

        public Artista(string nombreArtistico, string nombre, string apellidos, string nacionalidad, DateTime fechaNacimiento, string enlacesRedesSociales)
        {
            NombreArtistico = nombreArtistico;
            Nombre = nombre;
            Apellidos = apellidos;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
            EnlacesRedesSociales = enlacesRedesSociales;
        }
    }
}

