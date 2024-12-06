using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса музыкального альбома
/// </summary>
public class RepositoryAlbum : IRepositoryAlbum
{
    /// <summary>
    /// Список музыкальных альбомов
    /// </summary>
    private readonly List<Album> albums = [];
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    private int albumId = 1;
    /// <summary>
    /// Реализация получения списка всех альбомов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Album> GetEnum() => albums;

    /// <summary>
    /// Реализация получения данных альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Album? Get(int id) => albums.Find(a => a.Id == id);

    /// <summary>
    /// Реализация удаления альбома 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var album = Get(id);
        if (album != null)
        {
            albums.Remove(album);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация добавления нового альбома
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    public bool Post(Album album)
    {
        album.Id = albumId++;
        if (Get(album.Id) == null)
        {
            albums.Add(album);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация изменения альбома
    /// </summary>
    /// <param name="id"></param>
    /// <param name="album"></param>
    /// <returns></returns>
    public bool Put(int id, Album album)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = album.Id;
        oldValue.Release = album.Release;
        oldValue.Title = album.Title;
        oldValue.ArtistId = album.ArtistId;
        return true;
    }
}