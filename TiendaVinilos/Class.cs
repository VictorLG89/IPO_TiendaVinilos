using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TiendaVinilos.Models
{
    public class Autor : INotifyPropertyChanged
    {
        private string _nombre;
        private string _tipo;

        [Key]
        public int Id { get; set; } // Clave primaria

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string Tipo
        {
            get { return _tipo; }
            set
            {
                if (_tipo != value)
                {
                    _tipo = value;
                    OnPropertyChanged(nameof(Tipo));
                }
            }
        }

        public ICollection<Vinilo> Vinilos { get; set; } // Relación uno a muchos

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Vinilo : INotifyPropertyChanged
    {
        private string _nombre;
        private Autor _autor;
        private string _portada;

        [Key]
        public int Id { get; set; } // Clave primaria

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public int AutorId { get; set; } // Clave externa

        [ForeignKey("AutorId")]
        public Autor Autor
        {
            get { return _autor; }
            set
            {
                if (_autor != value)
                {
                    _autor = value;
                    OnPropertyChanged(nameof(Autor));
                }
            }
        }

        public string Portada
        {
            get { return _portada; }
            set
            {
                if (_portada != value)
                {
                    _portada = value;
                    OnPropertyChanged(nameof(Portada));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
