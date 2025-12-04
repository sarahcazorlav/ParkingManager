using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Enum;

namespace ParkingManager.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.Login).IsUnique();

            builder.Property(e => e.Password)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Role)
                .HasMaxLength(15)
                .HasConversion(
                    v => v.ToString(),
                    v => (RoleType)System.Enum.Parse(typeof(RoleType), v)
                )
                .HasDefaultValue(RoleType.User);
        }
    }
}