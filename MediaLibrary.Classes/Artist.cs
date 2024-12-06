using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Музыкальный исполнитель
/// </summary>
[Table("Artist")]
public class Artist
{
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Никнейм артиста
    /// </summary>
    [Column("Name")]
    public required string Name { get; set; }
    /// <summary>
    /// Краткое описание артиста
    /// </summary>
    [Column("Description")]
    public required string Description { get; set; }
    public required ICollection<ParticipationArtistGenre> ParticipationArtistGenres { get; set; } = [];
    public required ICollection<Album> Albums { get; set; } = [];
}