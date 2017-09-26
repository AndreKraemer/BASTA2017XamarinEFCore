using System;
using System.IO;
using ElVegetarianoFurio.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElVegetarianoFurio.Models
{
    public class VegiContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "vegi.db");

            optionsBuilder.UseSqlite($"Filename={path}");

            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TraceLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}