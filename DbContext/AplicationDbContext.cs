using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Technical_Test_DHB.Models;

namespace Technical_Test_DHB.DbContext
{
    public class AplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> dbContext)
        : base(dbContext)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Seguros> Seguros { get; set; }
        public DbSet<Planes> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planes>().HasData(
                new Planes { Id = 1, CodigoPlan = "A05", NombrePlan = "Plan 1", Cuota = 675.00m, EdadMinima = 18, EdadMaxima = 59, TipoSeguro = "MRE" },
                new Planes { Id=2,  CodigoPlan = "A04", NombrePlan = "Plan 2", Cuota = 472.50m, EdadMinima = 18, EdadMaxima = 59, TipoSeguro = "MRE" },
                new Planes { Id =3, CodigoPlan = "A1B", NombrePlan = "Plan A1", Cuota = 141.00m, EdadMinima = 18, EdadMaxima = 65, TipoSeguro = "MAE" },
                new Planes { Id =4, CodigoPlan = "A1C", NombrePlan = "Plan A2", Cuota = 235.00m, EdadMinima = 18, EdadMaxima = 65, TipoSeguro = "MAE" },
                new Planes { Id =5, CodigoPlan = "M11", NombrePlan = "Plan BA1", Cuota = 47.00m, EdadMinima = 18, EdadMaxima = 30, TipoSeguro = "MNF" },
                new Planes { Id =6, CodigoPlan = "M10", NombrePlan = "Plan BA2", Cuota = 53.00m, EdadMinima = 18, EdadMaxima = 30, TipoSeguro = "MNF" }
            ); ;
        }
    }
}
