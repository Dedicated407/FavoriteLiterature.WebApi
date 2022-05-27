using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class DocumentConfiguration : BaseEntityConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents"); // TPT (Table Per Type)

        builder
            .Property(doc => doc.Name)
            .IsRequired();

        builder
            .HasOne(doc => doc.Book)
            .WithMany(book => book.Documents)
            .HasForeignKey(doc => doc.BookId)
            .IsRequired();
        
        builder
            .Property(doc => doc.File)
            .IsRequired();
        
        base.Configure(builder);
    }
}