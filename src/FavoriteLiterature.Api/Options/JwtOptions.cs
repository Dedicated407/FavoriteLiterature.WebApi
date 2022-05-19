namespace FavoriteLiterature.Api.Options;

/// <summary>
/// Класс, описывающий ряд свойств, используемый для генерации токена
/// <param name="ISSUER">Издатель токена</param>
/// <param name="KEY">Ключ для шифрации</param>
/// <param name="LIFETIME">Время жизни токена (в минутах)</param>
/// </summary>
public class JwtOptions
{
    public string Issuer { get; set; }
    public string SecretKey { get; set; }
    public int Lifetime { get; set; }
}