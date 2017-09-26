using System;
using System.IO;
using ElVegetarianoFurio.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElVegetarianoFurio.Models
{
    public class VegiContext : DbContext
    {

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library", "dishes.db");

            optionsBuilder.UseSqlite($"Filename={path}");

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TraceLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);

        }
    }
}