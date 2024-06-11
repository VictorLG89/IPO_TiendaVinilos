using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public class Promocion
    {
        // Atributos de la promoción
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double DescuentoPorcentaje { get; set; }
        public bool EnviarNotificacion { get; set; }
        public bool ProgramarNotificacion { get; set; }

        // Constructor de la clase Promocion
        public Promocion(string nombre, DateTime fechaInicio, DateTime fechaFin, double descuentoPorcentaje, bool enviarNotificacion, bool programarNotificacion)
        {
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            DescuentoPorcentaje = descuentoPorcentaje;
            EnviarNotificacion = enviarNotificacion;
            ProgramarNotificacion = programarNotificacion;
        }

        // Constructor vacío para permitir la creación de la promoción sin parámetros
        public Promocion() { }

        // Método para aplicar el descuento a un precio específico
        public double AplicarDescuento(double precioOriginal)
        {
            return precioOriginal - (precioOriginal * (DescuentoPorcentaje / 100));
        }

        // Método para verificar si la promoción está activa en una fecha específica
        public bool EstaActiva(DateTime fecha)
        {
            return fecha >= FechaInicio && fecha <= FechaFin;
        }
    }
}
