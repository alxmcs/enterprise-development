using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Связь между артистом и исполняемым жанром
/// </summary>
[Table("ParticipationArtistGenre")]
public class ParticipationArtistGenre
{
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Идентификатор связанного жанра музыки
    /// </summary>
    [ForeignKey("Genre")]
    [Column("IdGenre")]
    public required int GenreId { get; set; }
    /// <summary>
    /// Идентификатор связанного музыкального исполнителя
    /// </summary>
    [Column("IdArtist")]
    public required int ArtistId { get; set; }
    /// <summary>
    /// Получение экземпляра жанра
    /// </summary>
    public required Genre Genre { get; set; } = null!;
    public required Artist Artist { get; set; } = null!;
}