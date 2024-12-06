namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для связей между музыкальным жанром и артистом
/// </summary>
public class DtoParticipationDetails
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int GenreId { get; set; }
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    public int ArtistId { get; set; }
}