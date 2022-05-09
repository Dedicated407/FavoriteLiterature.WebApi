namespace FavoriteLiterature.Api.Entities;

public class Author
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public string? Description { get; set; }
    public DateTime? Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte Rating { get; set; }

    public Author(Guid userId, string? description, DateTime? birthday, string? phoneNumber, string? address, byte rating) : this()
    {
        UserId = userId;
        Description = description;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        Address = address;
        Rating = rating;
    }

    private Author()
    {
        Id = Guid.Empty;
    }

    public List<Book> Books { get; set; } = new();
}