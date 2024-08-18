using Application.Sellers.Commands.CreateSeller;
using Application.Sellers.Commands.DeleteSeller;
using Application.Sellers.Commands.UpdateMaterialsForSeller;
using Application.Sellers.Commands.UpdateSeller;
using Application.Sellers.Queries.GetAllSellers;
using Application.Sellers.Queries.GetSellerById;
using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class Sellers : BaseController
{
    public Sellers(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Получение всех продавцов
    /// </summary>
    /// <param name="dto">Данные о паджинации</param>
    /// <returns>Все продавцы</returns>
    /// <response code="200">Возвращает всех продавцов</response>
    /// <response code="404">Продавцов не найдено</response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllSellers(
        [FromQuery] GetAllSellersRequestDto dto)
    {
        var sellers = await Mediator.Send(new GetAllSellersQuery(dto)
        {
            Dto = dto,
        });
        
        if (sellers.Dtos.Count == 0)
        {
            return NotFound("No seller found.");
        }
        
        return Ok(sellers);
    }

    /// <summary>
    /// Получение продавца по id
    /// </summary>
    /// <param name="id">Идентификатор продавца</param>
    /// <returns>Продавец</returns>
    /// <response code="200">Возвращает продавца</response>
    /// <response code="404">Продавец не найден</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetSellerById(
        [FromRoute] int id)
    {
        var seller = await Mediator.Send(new GetSellerByIdQuery(id)
        {
            Id = id,
        });

        if (seller is null)
        {
            return NotFound($"No seller found.");
        }

        return Ok(seller);
    }

    /// <summary>
    /// Создание продавца
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Seller
    ///     {
    ///        "name" : "Martin"
    ///     }
    ///
    /// </remarks>
    /// <param name="dto">Имя продавца</param>
    /// <returns>Новый продавец</returns>
    /// <response code="201">Возвращает нового продавца</response>
    /// <response code="400">Некорректно введены данные</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateSeller(CreateSellerRequestDto dto)
    {
        var seller = await Mediator.Send(new CreateSellerCommand(dto)
        {
            Dto = dto,
        });

        if (seller is null)
        {
            return BadRequest(seller);
        }

        return CreatedAtAction(
            nameof(CreateSeller),
            new
            {
                id = seller.Id,
            },
            seller);
    }

    /// <summary>
    /// Обновление информации о продавце
    /// </summary>
    /// <param name="id">Идентификатор продавца</param>
    /// <param name="dto">Данные о продавце</param>
    /// <returns>Обновлённый продавец</returns>
    /// <response code="200">Возвращает обновлённого продавца</response>
    /// <response code="400">Некорректно введены данные</response>
    /// <response code="404">Продавец не найден</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateSeller(
        [FromRoute] int id,
        [FromQuery] UpdateSellerRequestDto dto)
    {
        var seller = await Mediator.Send(new UpdateSellerCommand(
            id,
            dto)
        {
            Id = id,
            Dto = dto,
        });
        
        if (seller is null)
        {
            return NotFound($"No seller found.");
        }

        return Ok(seller);
    }

    /// <summary>
    /// Обновление списка материалов продавца
    /// </summary>
    /// <param name="id">Идентификатор продавца</param>
    /// <param name="dto">Данные о материалах</param>
    /// <returns>Обновлённый продавец</returns>
    /// <response code="200">Возвращает обновлённого продавца</response>
    /// <response code="400">Некорректно введены данные</response>
    /// <response code="404">Продавец не найден</response>
    [HttpPatch("{id:int}/materials")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateMaterials(
        [FromRoute] int id,
        [FromBody] UpdateMaterialsForSellerRequestDto dto)
    {
        var seller = await Mediator.Send(new UpdateMaterialsForSellerCommand(
            id,
            dto));

        if (seller is null)
        {
            return NotFound($"No seller found.");
        }

        return Ok(seller);
    }

    /// <summary>
    /// Удаление продавца
    /// </summary>
    /// <param name="id">Идентификатор продавца</param>
    /// <response code="204">Продавец успешно удалён</response>
    /// <response code="404">Продавец не найден</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSeller(
        [FromRoute] int id)
    {
        var deletedSellerIsFound = await Mediator.Send(
            new DeleteSellerCommand(id));

        if (deletedSellerIsFound is false)
        {
            return NotFound($"No seller found.");
        }

        return NoContent();
    }
}
