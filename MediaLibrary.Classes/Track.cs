using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Музыкальный трек
/// </summary>
[Table("Track")]
public class Track
{
    /// <summary>
    /// Идентификатор трека
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Номер трека в альбоме
    /// </summary>
    [Column("TrackNum")]
    public required int TrackNum { get; set; }
    /// <summary>
    /// Название трека
    /// </summary>
    [Column("Title")]
    public required string Title { get; set; }
    /// <summary>
    /// Длительность трека 
    /// </summary>
    [Column("Duration")]
    public required TimeSpan Duration { get; set; }
    /// <summary>
    /// Идентификатор альбома, в котором находится трек
    /// </summary>
    [ForeignKey("Album")]
    [Column("AlbumId")]
    public required int AlbumId { get; set; }
    /// <summary>
    /// Получение экземпляра альбома
    /// </summary>
    public required Album Album { get; set; } = null!;
}