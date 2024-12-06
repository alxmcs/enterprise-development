using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Жанр музыки
/// </summary>
[Table("Genre")]
public class Genre
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Название жанра
    /// </summary>
    [Column("Name")]
    public required string Name { get; set; }
    public required ICollection<ParticipationArtistGenre> ParticipationArtistGenres { get; set; } = [];
}