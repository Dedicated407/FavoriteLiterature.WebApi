using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class CriticConfiguration : BaseEntityConfiguration<Critic>
{
    public override void Configure(EntityTypeBuilder<Critic> builder)
    {
        builder.ToTable("Critics"); // TPT (Table Per Type)

        builder
            .HasOne(critic => critic.User)
            .WithOne(user => user.Critic)
            .HasForeignKey<Critic>(critic => critic.UserId)
            .IsRequired();
        
        base.Configure(builder);
    }
}