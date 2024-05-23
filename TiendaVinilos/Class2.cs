using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos.Service
{
    public class VinylService
    {
        private ObservableCollection<Vinilo> _vinilos;
        private ObservableCollection<Autor> _autores;

        public VinylService()
        {
            var autor1 = new Autor { Nombre = "Autor 1", Tipo = "Solista" };
            var autor2 = new Autor { Nombre = "Autor 2", Tipo = "Grupo" };

            _autores = new ObservableCollection<Autor> { autor1, autor2 };

            _vinilos = new ObservableCollection<Vinilo>
            {
                new Vinilo { Nombre = "Vinilo 1", Autor = autor1, Portada = "Portada1.jpg" },
                new Vinilo { Nombre = "Vinilo 2", Autor = autor2, Portada = "Portada2.jpg" }
            };
        }

        public ObservableCollection<Vinilo> GetAllVinilos()
        {
            return _vinilos;
        }

        public ObservableCollection<Autor> GetAllAutores()
        {
            return _autores;
        }

        public void AddVinilo(Vinilo vinilo)
        {
            _vinilos.Add(vinilo);
        }

        public void DeleteVinilo(Vinilo vinilo)
        {
            _vinilos.Remove(vinilo);
        }

        public void AddAutor(Autor autor)
        {
            _autores.Add(autor);
        }

        public void DeleteAutor(Autor autor)
        {
            _autores.Remove(autor);
        }
    }
}
