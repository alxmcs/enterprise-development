namespace MediaLibrary.Tests;

/// <summary>
/// Заполнение тестовых списков артистов, альбомов, треков, жанров и связей жанр-артист
/// </summary>
public class MediaFixture
{
    /// <summary>
    /// Объявление сущности с тестовыми списками артистов, альбомов, треков, жанров и связей жанр-артист 
    /// </summary>
    public TestData TestData { get; set; }

    /// <summary>
    /// Заполнение тестовых списков исходными данными
    /// </summary>
    public MediaFixture()
    {
        TestData = new TestData
        {
            Artists = new()
            {
                new () { Id = 1, Name = "Imagine Dragons", Description = "American pop-rock band formed in 2008 in Las Vegas, USA",Albums=[], ParticipationArtistGenres=[] },
                new () { Id = 2, Name = "Lana Del Rey", Description = "American poet, singer-songwriter",Albums=[], ParticipationArtistGenres=[] },
                new () { Id = 3, Name = "Bonapart", Description = "Kazakh musician, rapper and producer",Albums=[], ParticipationArtistGenres=[] },
                new () { Id = 4, Name = "Масло черного тмина", Description = "Kazakhstani underground hip-hop artist",Albums=[], ParticipationArtistGenres=[] },
                new () { Id = 5, Name = "The Weekend", Description = "Canadian singer, songwriter and actor",Albums=[], ParticipationArtistGenres=[] }
            },
            Albums = new()
            {
                new () { Id = 1, Title = "After Hours", Release = new DateTime(2020, 3, 20), ArtistId = 5,Tracks=[] },
                new () { Id = 2, Title = "Starboy", Release = new DateTime(2016, 11, 25), ArtistId = 5,Tracks=[] },
                new () { Id = 3, Title = "Born to die", Release = new DateTime(2012, 12, 27), ArtistId = 2,Tracks=[] },
                new () { Id = 4, Title = "Lie", Release = new DateTime(2020, 1, 12), ArtistId = 3,Tracks=[] },
                new () { Id = 5, Title = "Origins", Release = new DateTime(2018, 11, 9), ArtistId = 4,Tracks=[] },
                new () { Id = 6, Title = "Summer", Release = new DateTime(2018, 8, 23), ArtistId = 2,Tracks=[] },
                new () { Id = 7, Title = "Radioactive", Release = new DateTime(2014, 4, 1), ArtistId = 1,Tracks=[] }
            },
            Tracks = new()
            {
                new () { Id = 1, TrackNum = 3, Title = "Natural", AlbumId = 5, Duration = TimeSpan.FromSeconds(122) },
                new () { Id = 2, TrackNum = 1, Title = "LIII", AlbumId = 4, Duration = TimeSpan.FromSeconds(236) },
                new () { Id = 3, TrackNum = 5, Title = "Born", AlbumId = 4, Duration = TimeSpan.FromSeconds(651) },
                new () { Id = 4, TrackNum = 1, Title = "Party Monster", AlbumId = 2, Duration = TimeSpan.FromSeconds(111) },
                new () { Id = 5, TrackNum = 3, Title = "Alone Again", AlbumId = 6, Duration = TimeSpan.FromSeconds(541) },
                new () { Id = 6, TrackNum = 7, Title = "Feel like", AlbumId = 2, Duration = TimeSpan.FromSeconds(298) },
                new () { Id = 7, TrackNum = 2, Title = "Back please", AlbumId = 1, Duration = TimeSpan.FromSeconds(300) }
            },
            Genres = new()
            {
                new () { Id = 1, Name = "Rock", ParticipationArtistGenres=[] },
                new () { Id = 2, Name = "Pop", ParticipationArtistGenres=[] },
                new () { Id = 3, Name = "Hip-hop", ParticipationArtistGenres=[] }
            },
            ParticipationArtistGenre = new()
            {
                new () { Id = 1,GenreId = 1, ArtistId = 1 },
                new () { Id = 2,GenreId = 1, ArtistId = 2 },
                new () { Id = 3,GenreId = 2, ArtistId = 3 },
                new () { Id = 4,GenreId = 2, ArtistId = 4 },
                new () { Id = 5,GenreId = 3, ArtistId = 4 },
                new () { Id = 6,GenreId = 2, ArtistId = 5 },
                new () { Id = 7,GenreId = 3, ArtistId = 2 },
                new () { Id = 8,GenreId = 1, ArtistId = 3 },
                new () { Id = 9,GenreId = 3, ArtistId = 3 }

            }
        };
    }
}