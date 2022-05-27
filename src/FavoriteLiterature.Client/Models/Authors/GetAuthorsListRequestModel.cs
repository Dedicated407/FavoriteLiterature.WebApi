namespace FavoriteLiterature.Client.Models.Authors;

public class GetAuthorsListRequestModel
{
    /// <summary>
    /// Фильтрация по названию
    /// </summary>
    public string? Query { get; init; }
}