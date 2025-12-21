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

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Estado)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(e => e.Zona)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(e => e.Fecha)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.MontoTotal)
                   .HasColumnType("decimal(10,2)");

            // 🔹 Registro -> Vehiculo (N:1)
            builder.HasOne(r => r.Vehiculo)
                   .WithMany(v => v.Registros)
                   .HasForeignKey(r => r.VehiculoId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Registro -> Disponibilidad (N:1)
            builder.HasOne(r => r.Espacio)
                   .WithMany(d => d.Registros)
                   .HasForeignKey(r => r.EspacioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
