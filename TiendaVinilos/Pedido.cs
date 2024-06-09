﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    public class Pedido
    {
        public ObservableCollection<Producto> Productos { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Fecha { get; set; }
        public bool Completado { get; set; }
        public double PrecioTotal => Productos.Sum(p => p.PrecioTotal);

        public Pedido(string direccion, string ciudad, string codigopostal, string pais)
        {
            Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            Productos = new ObservableCollection<Producto>();
            Completado = false;
            Direccion = direccion;
            Ciudad = ciudad;
            CodigoPostal = codigopostal;
            Pais = pais;
        }
    }
}