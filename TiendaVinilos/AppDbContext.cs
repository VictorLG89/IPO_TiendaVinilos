using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TiendaVinilos.Models;


namespace TiendaVinilos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vinilo> Vinilos { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí puedes configurar más detalles si es necesario        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Dbase.db");
            }
        }
    }
}


