using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculo");

            builder.HasKey(v => v.Placa);

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(v => v.Tipo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Marca)
                .HasMaxLength(100);

            builder.Property(v => v.Descripcion)
                .HasMaxLength(250);

            builder.HasOne(v => v.Usuario)
                .WithMany(u => u.Vehiculos)
                .HasForeignKey(v => v.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
