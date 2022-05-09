using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors"); // TPT (Table Per Type)
        
        builder.HasKey(author => author.Id);

        builder
            .HasOne(author => author.User)
            .WithOne(user => user.Author)
            .HasForeignKey<Author>(author => author.UserId)
            .IsRequired();
    }
}