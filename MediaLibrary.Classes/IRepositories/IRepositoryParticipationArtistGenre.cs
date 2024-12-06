namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория связи артиста и жанра музыки
/// </summary>
public interface IRepositoryParticipationArtistGenre
{
    /// <summary>
    /// Получение спика всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum();
    /// <summary>
    /// Получение данных связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int GenreId, int ArtistId);
    /// <summary>
    /// Добавление новой связи
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation);
    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public bool Delete(int GenreId, int ArtistId);
    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Put(int GenreId, int ArtistId, ParticipationArtistGenre track);
}