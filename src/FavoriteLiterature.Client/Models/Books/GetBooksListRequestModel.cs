namespace FavoriteLiterature.Client.Models.Books;

public class GetBooksListRequestModel
{
    /// <summary>
    /// Фильтрация по названию
    /// </summary>
    public string? Query { get; init; }
}