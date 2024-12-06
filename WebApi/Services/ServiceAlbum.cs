using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceAlbum(IRepositoryAlbum repository, IMapper mapper, IServiceArtist serviceArtist) : IServiceAlbum
{
    /// <summary>
    /// Получение списка всех альбомов
    /// </summary>
    public IEnumerable<DtoAlbumDetails> GetEnum()
    {
        var albums = repository.GetEnum();
        return mapper.Map<IEnumerable<DtoAlbumDetails>>(albums);
    }

    /// <summary>
    /// Получение данных об альбоме по ID
    /// </summary>
    public DtoAlbumDetails? Get(int id)
    {
        var album = repository.Get(id);
        return album == null ? null : mapper.Map<DtoAlbumDetails>(album);
    }

    /// <summary>
    /// Добавление альбома в список
    /// </summary>
    public bool Post(DtoAlbumCreateUpdate dtoAlbum)
    {
        if (!serviceArtist.ArtistExists(dtoAlbum.ArtistId))
            return false;
        var album = mapper.Map<Album>(dtoAlbum);
        return repository.Post(album);
    }

    /// <summary>
    /// Изменение данных альбома
    /// </summary>
    public bool Put(int id, DtoAlbumCreateUpdate dtoAlbum)
    {
        var album = mapper.Map<Album>(dtoAlbum);
        album.Id = id;
        return repository.Put(id, album);
    }

    /// <summary>
    /// Удаление альбома по ID
    /// </summary>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Проверка существования альбома
    /// </summary>
    public bool AlbumExists(int id)
    {
        return repository.Get(id) != null;
    }
}