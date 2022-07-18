namespace FavoriteLiterature.Client.Models.Authors;

public class GetAuthorsListRequestModel : PaginationModel
{
    /// <summary>
    /// Фильтрация по названию
    /// </summary>
    public string? Query { get; init; }
}