namespace FavoriteLiterature.Api.Options;

/// <summary>
/// Класс <see cref="JwtOptions"/>, описывающий ряд свойств,
/// используемый для генерации токена
/// </summary>
public class JwtOptions
{
    /// <value>
    /// Свойство: <see cref="Issuer"/>. Тип: <see langword="string"/>.
    /// Издатель токена.
    /// </value>
    public string Issuer { get; set; }
    
    /// <value>
    /// Свойство: <see cref="SecretKey"/>. Тип: <see langword="string"/>.
    /// Ключ безопасности.
    /// </value>
    public string SecretKey { get; set; }
    
    /// <value>
    /// Свойство: <see cref="Lifetime"/>. Тип: <see langword="int"/>.
    /// Время жизни токена (в минутах).
    /// </value>
    public int Lifetime { get; set; }
}