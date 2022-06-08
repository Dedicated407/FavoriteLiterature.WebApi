namespace FavoriteLiterature.Api.Entities;

public class Author : BaseEntity
{
    public Guid UserId { get; private set; }
    public string? Description { get; set; }
    public DateTimeOffset? Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte Rating { get; set; }

    public Author(Guid userId, string? description, DateTimeOffset? birthday, string? phoneNumber, string? address, byte rating)
    {
        UserId = userId;
        Description = description;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        Address = address;
        Rating = rating;
    }

    public List<Book> Books { get; set; } = new();
    public User User { get; set; }
}