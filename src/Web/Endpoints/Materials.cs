using Application.Materials.Commands.CreateMaterial;
using Application.Materials.Commands.DeleteMaterial;
using Application.Materials.Commands.UpdateMaterial;
using Application.Materials.Commands.UpdateMaterialPrices;
using Application.Materials.Queries.GetAllMaterials;
using Application.Materials.Queries.GetMaterialById;
using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class Materials : BaseController
{
    public Materials(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Получение всех материалов
    /// </summary>
    /// <param name="dto">Данные о паджинации</param>
    /// <returns>Все материалы</returns>
    /// <response code="200">Возвращает все материалы</response>
    /// <response code="404">Материалов не найдено</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllMaterials(
        [FromQuery] GetAllMaterialsRequestDto dto)
    {
        var materials = await Mediator.Send(new GetAllMaterialsQuery(dto)
        {
            Dto = dto,
        });

        if (materials.Dtos.Count == 0)
        {
            return NotFound("No material found.");
        }

        return Ok(materials);
    }

    /// <summary>
    /// Получение материала по id
    /// </summary>
    /// <param name="dto">Данные о материале</param>
    /// <returns>Материал</returns>
    /// <response code="200">Возвращает материал</response>
    /// <response code="404">Материал не найден</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetMaterialById(
        [FromRoute] GetMaterialByIdRequestDto dto)
    {
        var material = await Mediator.Send(new GetMaterialByIdQuery(dto)
        {
            Dto = dto,
        });

        if (material is null)
        {
            return NotFound($"No material found.");
        }

        return Ok(material);
    }

    /// <summary>
    /// Создание материала
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /Material
    ///     {
    ///        "name" : "Sand",
    ///        "price" : 1000,
    ///        "sellerId" : 1
    ///     }
    ///
    /// </remarks>
    /// <param name="dto">Данные о материале</param>
    /// <returns>Новый материал</returns>
    /// <response code="201">Возвращает новый материал</response>
    /// <response code="400">Некорректно введены данные</response>
    /// <response code="500">Некорректно введены данные</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateMaterial(
        CreateMaterialRequestDto dto)
    {
        var material = await Mediator.Send(new CreateMaterialCommand(dto)
        {
            Dto = dto,
        });

        if (material is null)
        {
            return BadRequest(material);
        }

        return CreatedAtAction(
            nameof(CreateMaterial), new
            {
                Id = material.Id,
            },
            material);
    }

    /// <summary>
    /// Обновление информации о материале
    /// </summary>
    /// <param name="id">Идентификатор материала</param>
    /// <param name="dto">Данные о материале</param>
    /// <returns>Обновлённый материал</returns>
    /// <response code="200">Возвращает обновлённый материал</response>
    /// <response code="404">Материал не найден</response>
    /// <response code="500">Некорректно введены данные</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UpdateMaterial(
        int id,
        UpdateMaterialRequestDto dto)
    {
        var material = await Mediator.Send(new UpdateMaterialCommand(
            id,
            dto)
        {
            Id = id,
            Dto = dto,
        });

        if (material is null)
        {
            return NotFound($"No material found.");
        }

        return Ok(material);
    }

    /// <summary>
    /// Удаление материала
    /// </summary>
    /// <param name="dto">Данные о материале</param>
    /// <response code="204">Материал успешно удалён</response>
    /// <response code="404">Материал не найден</response>
    [HttpDelete("id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteMaterial(
        DeleteMaterialRequestDto dto)
    {
        var deletedMaterialIsFound = await Mediator.Send(
            new DeleteMaterialCommand(dto)
            {
                Dto = dto,
            });

        if (deletedMaterialIsFound is false)
        {
            return NotFound($"No material found.");
        }

        return NoContent();
    }

    /// <summary>
    /// Обновление цен материалов
    /// </summary>
    /// <response code="200">Цены материалов успешно обновлены</response>
    /// <response code="404">Материалов не найдено</response>
    [HttpPatch]
    [Route("all-prices")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateMaterialPrices(
        UpdateMaterialPricesCommand command)
    {
        var updatedMaterialsAreFound = await Mediator.Send(command);

        if (updatedMaterialsAreFound is false)
        {
            return NotFound($"No material found.");
        }

        return Ok($"Material prices successfully updated.");
    }
}
