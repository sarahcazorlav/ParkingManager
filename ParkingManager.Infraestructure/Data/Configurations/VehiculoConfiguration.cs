using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Placa)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(e => e.Placa).IsUnique();

            builder.Property(e => e.Marca)
                .HasMaxLength(50);

            builder.Property(e => e.Modelo)
                .HasMaxLength(50);

            builder.Property(e => e.Color)
                .HasMaxLength(30);

            builder.Property(e => e.TipoVehiculo)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Activo)
                .HasDefaultValue(true);
        }
    }
}
