using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("Tarifas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.TipoVehiculo)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.TarifaPorHora)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.TarifaPorDia)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200);

            builder.Property(e => e.Activo)
                .HasDefaultValue(true);

            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}