namespace FavoriteLiterature.Client.Models.Users.JwtToken;

public class JwtTokenResponseModel
{
    public string TypeToken { get; set; }
    public string AccessToken { get; set; }
    public int Lifetime { get; set; }
    public string Email { get; set; }
}