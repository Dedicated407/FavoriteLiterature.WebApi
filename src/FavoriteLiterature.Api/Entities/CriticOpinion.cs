namespace FavoriteLiterature.Api.Entities;

public class CriticOpinion : BaseEntity
{
    public Guid CriticId { get; private set; }
    public Critic Critic { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    public string Opinion { get; set; }
    public byte Estimation { get; set; }

    public CriticOpinion(Guid criticId, Guid bookId, string opinion, byte estimation)
    {
        CriticId = criticId;
        BookId = bookId;
        Opinion = opinion;
        Estimation = estimation;
    }
}