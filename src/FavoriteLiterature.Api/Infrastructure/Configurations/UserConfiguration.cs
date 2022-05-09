using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users"); // TPT (Table Per Type)

        builder.HasKey(user => user.Id);
        
        builder
            .Property(user => user.Email)
            .IsRequired();

        builder
            .HasIndex(user => user.Email)
            .IsUnique();
        
        builder
            .Property(user => user.PasswordHash)
            .IsRequired();

        builder
            .Property(user => user.UserName)
            .IsRequired();

        builder
            .HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(user => user.RoleId)
            .IsRequired();
        
        base.Configure(builder);
    }
}