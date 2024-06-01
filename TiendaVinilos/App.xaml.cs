using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TiendaVinilos.Data;
using TiendaVinilos.Services;

namespace TiendaVinilos
{
    public partial class App : Application
    {
        public static AppDbContext AppDbContext { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configurar las opciones de DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=Dbase.db");

            // Crear una instancia de AppDbContext con las opciones
            AppDbContext = new AppDbContext(optionsBuilder.Options);
            AppDbContext.Database.EnsureCreated(); // Esto crea la base de datos si no existe
        }
    }
}
