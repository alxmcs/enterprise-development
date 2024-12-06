using Microsoft.EntityFrameworkCore;
using MediaLibrary.Classes;

namespace WebApi;

/// <summary>
/// Контекст базы данных для работы с сущностями
/// </summary>
public class MediaLibraryDbContext : DbContext
{
    /// <summary>
    /// Коллекция альбомов в базе данных
    /// </summary>
    public DbSet<Album> Albums { get; set; } = null!;
    /// <summary>
    /// Коллекция жанров в базе данных 
    /// </summary>
    public DbSet<Genre> Genres { get; set; } = null!;
    /// <summary>
    /// Коллекция артистов в базе данных 
    /// </summary>
    public DbSet<Artist> Artists { get; set; } = null!;
    /// <summary>
    /// Коллекция связей в базе данных 
    /// </summary>
    public DbSet<ParticipationArtistGenre> ParticipationArtistGenres { get; set; } = null!;
    /// <summary>
    /// Коллекция треков в базе данных 
    /// </summary>
    public DbSet<Track> Tracks { get; set; } = null!;
    /// <summary>
    /// Инициализирует новый экземпляр контекста базы данных
    /// </summary>
    /// <param name="options"></param>
    public MediaLibraryDbContext(DbContextOptions<MediaLibraryDbContext> options) : base(options) { }
}