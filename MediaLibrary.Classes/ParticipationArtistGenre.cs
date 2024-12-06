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
    [Column("GenreId")]
    public required int GenreId { get; set; }
    /// <summary>
    /// Идентификатор связанного музыкального исполнителя
    /// </summary>
    [ForeignKey("Artist")]
    [Column("ArtistId")]
    public required int ArtistId { get; set; }
    /// <summary>
    /// Получение экземпляра жанра
    /// </summary>
    public Genre Genre { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}