namespace FavoriteLiterature.Api.Entities;

public class Critic : BaseEntity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public string? AboutMe { get; set; }
    public string? PhoneNumber { get; set; }
    public byte Rating { get; protected set; }

    public Critic(Guid userId, string? aboutMe, string? phoneNumber, byte rating)
    {
        UserId = userId;
        AboutMe = aboutMe;
        PhoneNumber = phoneNumber;
        Rating = rating;
    }

    public List<CriticOpinion> Opinions { get; set; } = new();
}