using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Statuses"); // TPT (Table Per Type)
        
        builder.HasKey(status => status.Id);
        
        builder
            .Property(status => status.Name)
            .IsRequired();

        builder
            .HasIndex(status => status.Name)
            .IsUnique();
    }
}