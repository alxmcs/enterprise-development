using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса музыкального трека
/// </summary>
public class RepositoryTrack : IRepositoryTrack
{
    /// <summary>
    /// Список музыкальных треков
    /// </summary>
    private readonly List<Track> tracks = [];
    /// <summary>
    /// Идентификатор трека
    /// </summary>
    private int trackId = 1;
    /// <summary>
    /// Реализация получения списка всех музыкальных треков
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Track> GetEnum() => tracks;

    /// <summary>
    /// Реализация получения данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Track? Get(int id) => tracks.Find(t => t.Id == id);

    /// <summary>
    /// Реализация удаления трека из списка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var track = Get(id);
        if (track != null)
        {
            tracks.Remove(track);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация добавления трека
    /// </summary>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Post(Track track)
    {
        track.Id = trackId++;
        if (Get(track.Id) == null)
        {
            tracks.Add(track);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация изменения данных трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Put(int id, Track track)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = track.Id;
        oldValue.TrackNum = track.TrackNum;
        oldValue.Title = track.Title;
        oldValue.Duration = track.Duration;
        oldValue.AlbumId = track.AlbumId;
        return true;
    }
}