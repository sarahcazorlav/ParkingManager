using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace Parking.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(150);

            builder.Property(u => u.Telefono)
                .HasMaxLength(20);

            builder.Property(u => u.Rol)
                .HasMaxLength(50);
        }
    }
}
