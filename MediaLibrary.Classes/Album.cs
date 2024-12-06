using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Музыкальный альбом
/// </summary>
[Table("Album")]
public class Album
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Название альбома
    /// </summary>
    [Column("Title")]
    public required string Title { get; set; }
    /// <summary>
    /// Дата релиза
    /// </summary>
    [Column("Release")]
    public required DateTime Release { get; set; }
    /// <summary>
    /// Идентификатор музыкального исполнителя,
    /// которому принадлежит этот альбом
    /// </summary>
    [Column("IdArtist")]
    public required int ArtistId { get; set; }

    public required Artist Artist { get; set; } = null!;
    /// <summary>
    /// Коллекция артистов
    /// </summary>
    public required ICollection<Track> Tracks { get; set; } = [];
}