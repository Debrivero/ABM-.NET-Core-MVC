using Microsoft.EntityFrameworkCore;
using Examen_tecnico_COA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_tecnico_COA
{
    public class ExamenTecnicoCOAContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public ExamenTecnicoCOAContext(DbContextOptions<ExamenTecnicoCOAContext> options) : base(options) { }
        public ExamenTecnicoCOAContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GEAR468\\SQLEXPRESS01; Initial Catalog=ExamenTecnicoDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { IdUsuario = 1, UserName = "debrivero", Name = "Debora", Email = "debora@gmail.com", Telefono = "1234556677" },
                new Usuario() { IdUsuario = 2, UserName = "coquito", Name = "Coqui", Email = "Coqui@gmail.com", Telefono = "1234556699" }
            );
        }

    }
}
