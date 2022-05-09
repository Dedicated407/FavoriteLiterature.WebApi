using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles"); // TPT (Table Per Type)

        builder.HasKey(role => role.Id);
        
        builder
            .Property(role => role.Name)
            .IsRequired();
        
        builder
            .HasIndex(role => role.Name)
            .IsUnique();
    }
}