using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class RegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.ToTable("Registros");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FechaEntrada)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.FechaSalida)
                .IsRequired(false);

            builder.Property(e => e.TiempoEstadia)
                .IsRequired(false);

            builder.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10,2)")
                .IsRequired(false);

            builder.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo");

            // Relaciones
            builder.HasOne(e => e.Vehiculo)
                .WithMany(v => v.Registros)
                .HasForeignKey(e => e.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Espacio)
                .WithMany(d => d.Registros)
                .HasForeignKey(e => e.EspacioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}