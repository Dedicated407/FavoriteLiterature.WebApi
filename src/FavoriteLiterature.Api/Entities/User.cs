using FavoriteLiterature.Api.Entities.Enums;

namespace FavoriteLiterature.Api.Entities;

public class User : BaseEntity
{
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public int RoleId { get; set; } // внешний ключ
    public Role Role { get; set; } // навигационное свойство
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }

    public User(string userName, string email, string passwordHash, int roleId)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        RoleId = roleId;
    }

    public Critic? Critic { get; set; }
    public Author? Author { get; set; }
}