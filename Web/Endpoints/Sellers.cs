using MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;
using MaterialsExchangeAPI.Application.Sellers.Queries.GetAllSellers;
using MaterialsExchangeAPI.Application.Sellers.Queries.GetSellerById;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Web.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class Sellers : BaseController
{
    public Sellers(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Получение всех продавцов
    /// </summary>
    /// <returns>Все продавцы</returns>
    /// <response code="200">Возвращает всех продавцов</response>
    /// <response code="404">Продавцов не найдено</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sellers = await _mediator.Send(new GetAllSellersQuery());
        
        if (sellers is null)
        {
            return NotFound("No seller found.");
        }
        
        return Ok(sellers);
    }

    /// <summary>
    /// Получение продавца по id
    /// </summary>
    /// <param name="id">Уникальный идентификатор продавца</param>
    /// <returns>Продавец</returns>
    /// <response code="200">Возвращает продавца</response>
    /// <response code="404">Продавец не найден</response>
    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var seller = await _mediator.Send(
            new GetSellerByIdQuery() { Id = id });

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
    /// <param name="name">Имя продавца</param>
    /// <returns>Новый продавец</returns>
    /// <response code="201">Возвращает нового продавца</response>
    /// <response code="400">Некорректно введены данные</response>
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        var seller = await _mediator.Send(
            new CreateSellerCommand() { Name = name });

        if (seller is null)
        {
            return BadRequest(seller);
        }

        return CreatedAtAction(nameof(Create), new { id = seller.Id }, seller);
    }

    /// <summary>
    /// Обновление информации о продавце
    /// </summary>
    /// <param name="id">Уникальный идентификатор продавца</param>
    /// <param name="name">Имя продавца</param>
    /// <returns>Обновлённый продавец</returns>
    /// <response code="200">Возвращает обновлённого продавца</response>
    /// <response code="400">Некорректно введены данные</response>
    /// <response code="404">Продавец не найден</response>
    [HttpPatch("id")]
    public async Task<IActionResult> Update(int id, string name)
    {
        var seller = await _mediator.Send(new UpdateSellerCommand() { 
            Id = id,
            Name = name,
        });
        
        if (seller is null)
        {
            return NotFound($"No seller found.");
        }

        return Ok(seller);
    }

    /// <summary>
    /// Удаление продавца
    /// </summary>
    /// <param name="id">Уникальный идентификатор продавца</param>
    /// <response code="204">Продавец успешно удалён</response>
    /// <response code="404">Продавец не найден</response>
    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedSellerIsFound = await _mediator.Send(
            new DeleteSellerCommand() { Id = id });

        if (deletedSellerIsFound is false)
        {
            return NotFound($"No seller found.");
        }

        return NoContent();
    }
}
