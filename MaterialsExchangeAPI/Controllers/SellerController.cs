using MaterialsExchangeAPI.Features.Seller.Commands.CreateSellerCommand;
using MaterialsExchangeAPI.Features.Seller.Commands.DeleteSellerCommand;
using MaterialsExchangeAPI.Features.Seller.Commands.UpdateSellerCommand;
using MaterialsExchangeAPI.Features.Seller.Queries.GetAllSellersQuery;
using MaterialsExchangeAPI.Features.Seller.Queries.GetSellerByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SellerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получение всех продавцов
        /// </summary>
        /// <returns>Все продавцы</returns>
        /// <response code="200">Возвращает всех продавцов</response>
        /// <response code="404">Продавцов не найдено</response>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var sellers = await _mediator.Send(new GetAllSellersQuery());
            
            if (sellers == null)
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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seller = await _mediator.Send(new GetSellerByIdQuery() { Id = id });

            if (seller == null)
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
        ///        "id" : 1,
        ///        "name" : "Martin"
        ///     }
        ///
        /// </remarks>
        /// <param name="name">Имя продавца</param>
        /// <returns>Новый продавец</returns>
        /// <response code="201">Возвращает нового продавца</response>
        /// <response code="400">Некорректно введены данные</response>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(string name)
        {
            var seller = await _mediator.Send(new CreateSellerCommand() { Name = name });

            if (seller == null)
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
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var seller = await _mediator.Send(new UpdateSellerCommand() { Id = id, Name = name });
            
            if (seller == null)
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
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seller = await _mediator.Send(new DeleteSellerCommand() { Id = id });

            if (seller == null)
            {
                return NotFound($"No seller found.");
            }

            return NoContent();
        }
    }
}
