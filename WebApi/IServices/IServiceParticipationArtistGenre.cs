using WebApi.Dto;

/// <summary>
/// Интерфейс сервиса для управления связями между артистом и жанром музыки
/// </summary>
public interface IServiceParticipationArtistGenre
{
    /// <summary>
    /// Получение списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoParticipationDetails> GetEnum();
    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public DtoParticipationDetails? Get(int GenreId, int ArtistId);
    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="dtoPparticipation"></param>
    /// <returns></returns>
    public bool Post(DtoParticipationDetails dtoPparticipation);
    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <param name="dtoParticipation"></param>
    /// <returns></returns>
    public bool Put(int GenreId, int ArtistId, DtoParticipationDetails dtoParticipation);
    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    public bool Delete(int GenreId, int ArtistId);
}