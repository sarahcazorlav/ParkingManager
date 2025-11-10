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

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Estado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
