namespace FavoriteLiterature.Api.Entities;

public class User : BaseEntity
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public int RoleId { get; private set; } // внешний ключ
    public Role Role { get; private set; } // навигационное свойство
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public User(string userName, string email, string passwordHash, Role role, 
        string? firstName = null, string? lastName = null, string? patronymic = null) : this()
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    private User()
    {
        Id = Guid.Empty;
    }

    public Critic? Critic { get; set; }
    public Author? Author { get; set; }
}