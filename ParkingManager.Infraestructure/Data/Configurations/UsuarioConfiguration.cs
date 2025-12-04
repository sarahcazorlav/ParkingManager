using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.Username).IsUnique();

            builder.Property(e => e.Telefono)
                .HasMaxLength(15);

            builder.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValue("Usuario");

            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Activo)
                .HasDefaultValue(true);

            // Relación con Vehículos
            builder.HasMany(e => e.Vehiculos)
                .WithOne(v => v.Usuario)
                .HasForeignKey(v => v.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}