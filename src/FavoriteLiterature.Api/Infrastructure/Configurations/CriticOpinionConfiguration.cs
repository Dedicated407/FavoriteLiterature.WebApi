using FavoriteLiterature.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Api.Infrastructure.Configurations;

public class CriticOpinionConfiguration : BaseEntityConfiguration<CriticOpinion>
{
    public override void Configure(EntityTypeBuilder<CriticOpinion> builder)
    {
        builder.ToTable("CriticOpinions"); // TPT (Table Per Type)

        builder
            .HasOne(opinion => opinion.Critic)
            .WithMany(critic => critic.Opinions)
            .HasForeignKey(opinion => opinion.CriticId)
            .IsRequired();

        builder
            .HasOne(opinion => opinion.Book)
            .WithMany(book => book.Opinions)
            .HasForeignKey(opinion => opinion.BookId)
            .IsRequired();
        
        builder
            .Property(opinion => opinion.Opinion)
            .IsRequired();
        
        builder
            .Property(opinion => opinion.Estimation)
            .IsRequired();
        
        
        base.Configure(builder);
    }
}