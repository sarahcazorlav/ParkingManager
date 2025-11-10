using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("Tarifa");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TipoVehiculo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.PrecioPorHora)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}
