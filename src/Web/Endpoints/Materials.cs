using MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;
using MaterialsExchangeAPI.Application.Materials.Queries.GetAllMaterials;
using MaterialsExchangeAPI.Application.Materials.Queries.GetMaterialById;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Web.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class Materials : BaseController
{
    public Materials(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Получение всех материалов
    /// </summary>
    /// <returns>Все материалы</returns>
    /// <response code="200">Возвращает все материалы</response>
    /// <response code="404">Материалов не найдено</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll()
    {
        var materials = await _mediator.Send(new GetAllMaterialsQuery());

        if (materials is null)
        {
            return NotFound("No material found.");
        }

        return Ok(materials);
    }

    /// <summary>
    /// Получение материала по id
    /// </summary>
    /// <param name="id">Уникальный идентификатор материала</param>
    /// <returns>Материал</returns>
    /// <response code="200">Возвращает материал</response>
    /// <response code="404">Материал не найден</response>
    [HttpGet("id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var material = await _mediator.Send(
            new GetMaterialByIdQuery() { Id = id });

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
    /// <param name="name">Название материала</param>
    /// <param name="price">Стоимость материала</param>
    /// <param name="sellerId">Уникальный идентификатор продавца</param>
    /// <returns>Новый материал</returns>
    /// <response code="201">Возвращает новый материал</response>
    /// <response code="400">Некорректно введены данные</response>
    /// <response code="500">Некорректно введены данные</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Create(string name, decimal price, 
        int sellerId)
    {
        var material = await _mediator.Send(new CreateMaterialCommand() { 
            Name = name, 
            Price = price, 
            SellerId = sellerId,
        });

        if (material is null)
        {
            return BadRequest(material);
        }

        return CreatedAtAction(nameof(Create), new { id = material.Id }, 
            material);
    }

    /// <summary>
    /// Обновление информации о материале
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name">Название материала</param>
    /// <param name="price">Стоимость материала</param>
    /// <param name="sellerId">Уникальный идентификатор продавца</param>
    /// <returns>Обновлённый материал</returns>
    /// <response code="200">Возвращает обновлённый материал</response>
    /// <response code="404">Материал не найден</response>
    /// <response code="500">Некорректно введены данные</response>
    [HttpPatch("id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Update(int id, string name, decimal price,
        int sellerId)
    {
        var material = await _mediator.Send(new UpdateMaterialCommand()
        {
            Id = id,
            Name = name,
            Price = price,
            SellerId = sellerId,
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
    /// <param name="id">Уникальный идентификатор материала</param>
    /// <response code="204">Материал успешно удалён</response>
    /// <response code="404">Материал не найден</response>
    [HttpDelete("id")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedMaterialIsFound = await _mediator.Send(
            new DeleteMaterialCommand() { Id = id });

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
    public async Task<IActionResult> UpdatePrices(
        UpdateMaterialPricesCommand command)
    {
        var updatedMaterialsAreFound = await _mediator.Send(command);

        if (updatedMaterialsAreFound is false)
        {
            return NotFound($"No material found.");
        }

        return Ok($"Material prices successfully updated.");
    }
}
