namespace FavoriteLiterature.Api.Entities;

public class CriticOpinion : BaseEntity
{
    public Guid Id { get; private set; }
    public Guid CriticId { get; private set; }
    public Critic Critic { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    public string Opinion { get; set; }
    public byte Estimation { get; set; }
    


    public CriticOpinion(Guid criticId, Guid bookId, string opinion, byte estimation) : this()
    {
        CriticId = criticId;
        BookId = bookId;
        Opinion = opinion;
        Estimation = estimation;
    }

    private CriticOpinion()
    {
        Id = Guid.Empty;
    }
}