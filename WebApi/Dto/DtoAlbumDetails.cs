namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для альбома с его идентификатором 
/// </summary>
public class DtoAlbumDetails
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    public int Id { get; set; }
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