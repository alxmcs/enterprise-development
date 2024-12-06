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

    /// <summary>
    /// Конфигурация модели данных, включая настройку композитных ключей
    /// и других свойств
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Связь альбома и артиста
        modelBuilder.Entity<Album>()
            .HasOne(ar => ar.Artist)
            .WithMany()
            .HasForeignKey(al => al.ArtistId);
        //Связь трека и альбома
        modelBuilder.Entity<Track>()
            .HasOne(al => al.Album)
            .WithMany()
            .HasForeignKey(al => al.AlbumId);
        //Связь артиста и жанра
        modelBuilder.Entity<ParticipationArtistGenre>()
            .HasOne(a => a.Artist)
            .WithMany()
            .HasForeignKey(ar => ar.ArtistId);
        modelBuilder.Entity<ParticipationArtistGenre>()
            .HasOne(g => g.Genre)
            .WithMany()
            .HasForeignKey(g => g.GenreId);
    }   
}