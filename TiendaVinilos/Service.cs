using System.Collections.Generic;
using TiendaVinilos.Models;
using TiendaVinilos.Data;
using System.Linq;

namespace TiendaVinilos.Services
{
    public class ViniloService
    {
        private readonly AppDbContext _context;

        public ViniloService(AppDbContext context)
        {
            _context = context;
        }

        public List<Vinilo> GetAllVinilos()
        {
            return _context.Vinilos.ToList();
        }

        public void AddVinilo(Vinilo vinilo)
        {
            _context.Vinilos.Add(vinilo);
            _context.SaveChanges();
        }

        public List<Autor> GetAllAutores()
        {
            return _context.Autores.ToList();
        }

        public void AddAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }
        // Agrega más métodos según las operaciones que necesites realizar en tus vinilos
    }
}
