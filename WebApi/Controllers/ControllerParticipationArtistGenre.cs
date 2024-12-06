using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы со связями артиста и музыкального жанра
/// </summary>
/// <param name="_participationService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerParticipationArtistGenre(IServiceParticipationArtistGenre _participationService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех связей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<DtoParticipationDetails>> Get()
    {
        var participations = _participationService.GetEnum();
        var participationsDtos = _mapper.Map<IEnumerable<DtoParticipationDetails>>(participations);
        return Ok(participationsDtos);
    }

    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DtoParticipationDetails> Get(int GenreId, int ArtistId)
    {
        var participation = _participationService.Get(GenreId, ArtistId);
        if (participation == null)
            return NotFound();
        var participationDto = _mapper.Map<DtoParticipationDetails>(participation);
        return Ok(participationDto);
    }

    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoParticipationDetails participation)
    {
        if (_participationService.Post(participation))
        {
            return CreatedAtAction(nameof(Get), participation);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int GenreId, int ArtistId, [FromBody] DtoParticipationDetails participation)
    {
        if (_participationService.Put(GenreId, ArtistId, participation))
        {
            participation.ArtistId = ArtistId;
            participation.GenreId = GenreId;
            return CreatedAtAction(nameof(Get), participation);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="GenreId"></param>
    /// <param name="ArtistId"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int GenreId, int ArtistId)
    {
        return _participationService.Delete(GenreId, ArtistId) ? Ok() : NoContent();
    }
}