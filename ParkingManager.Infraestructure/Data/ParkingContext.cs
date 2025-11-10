using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ParkingManager.Infrastructure.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        // 👇 Agrega todos los DbSet que representen tus tablas
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public DbSet<Registro> Registros { get; set; } = null!;
        public DbSet<Tarifa> Tarifas { get; set; } = null!;
        public DbSet<Disponibilidad> Disponibilidades { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 👇 Configuraciones (si las tienes en carpetas separadas)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParkingContext).Assembly);
        }
    }
}

