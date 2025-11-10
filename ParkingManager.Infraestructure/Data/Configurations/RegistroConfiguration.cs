using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class RegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.ToTable("Registro");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.VehiculoPlaca)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.FechaEntrada)
                .HasDefaultValueSql("CONVERT(date, SYSUTCDATETIME())");

            builder.Property(r => r.MontoTotal)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(r => r.Vehiculo)
                .WithMany()
                .HasForeignKey(r => r.VehiculoPlaca)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.Zona)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
