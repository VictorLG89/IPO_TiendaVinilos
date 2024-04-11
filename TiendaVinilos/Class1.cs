using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos
{
    using System.ComponentModel;

    public class Vinilo : INotifyPropertyChanged
    {
        private string _nombre;
        private string _autor;
        private string _portada;

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

        public string Autor
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
