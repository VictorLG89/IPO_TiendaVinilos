using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public class Producto
    {
        public Vinilo Vinilo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal => Vinilo.Precio * Cantidad;
    }
}
