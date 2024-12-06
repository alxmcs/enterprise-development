using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса связи артиста и жанра музыки
/// </summary>
public class RepositoryParticipationArtistGenre : IRepositoryParticipationArtistGenre
{
    /// <summary>
    /// Список связей
    /// </summary>
    private readonly List<ParticipationArtistGenre> participations = [];
    /// <summary>
    /// Реализация получения списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum() => participations;

    /// <summary>
    /// Реализация получения данных связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int GenreId, int ArtistId) => participations.Find(t => t.GenreId == GenreId && t.ArtistId == ArtistId);

    /// <summary>
    /// Реализация удаления связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public bool Delete(int GenreId, int ArtistId)
    {
        var participation = Get(GenreId, ArtistId);
        if (participation != null)
        {
            participations.Remove(participation);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация добавления связи
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation)
    {
        if (Get(participation.GenreId, participation.ArtistId) == null)
        {
            participations.Add(participation);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация изменения связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Put(int GenreId, int ArtistId, ParticipationArtistGenre participation)
    {
        var oldValue = Get(GenreId, ArtistId);
        if (oldValue == null)
            return false;
        oldValue.GenreId = participation.GenreId;
        oldValue.ArtistId = participation.ArtistId;
        return true;
    }
}