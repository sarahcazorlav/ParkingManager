using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class DisponibilidadConfiguration : IEntityTypeConfiguration<Disponibilidad>
    {
        public void Configure(EntityTypeBuilder<Disponibilidad> builder)
        {
            builder.ToTable("Disponibilidad");

            builder.HasKey(e => e.Id);

            builder.Property(d => d.TipoEspacio)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(d => d.NumeroEspacio)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Estado)
                   .HasMaxLength(20);

            builder.Property(d => d.Zona)
                   .HasMaxLength(50);

            builder.HasIndex(e => e.NumeroEspacio).IsUnique();

            builder.Property(e => e.Piso)
                .IsRequired();

            builder.Property(e => e.Ocupado)
                .HasDefaultValue(false);

            builder.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}