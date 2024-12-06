namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для альбома
/// </summary>
public class DtoAlbumCreateUpdate
{
    /// <summary>
    /// Название альбома
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Дата релиза
    /// </summary>
    public required DateTime Release { get; set; }
    /// <summary>
    /// Идентификатор музыкального исполнителя,
    /// которому принадлежит этот альбом
    /// </summary>
    public required int ArtistId { get; set; }
}