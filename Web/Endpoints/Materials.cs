using MaterialsExchangeAPI.Features.Material.Commands.CreateMaterialCommand;
using MaterialsExchangeAPI.Features.Material.Commands.DeleteMaterialCommand;
using MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialCommand;
using MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialPricesCommand;
using MaterialsExchangeAPI.Features.Material.Queries.GetAllMaterialsQuery;
using MaterialsExchangeAPI.Features.Material.Queries.GetMaterialByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Materials : ControllerBase
    {
        private readonly IMediator _mediator;

        public Materials(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получение всех материалов
        /// </summary>
        /// <returns>Все материалы</returns>
        /// <response code="200">Возвращает все материалы</response>
        /// <response code="404">Материалов не найдено</response>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var materials = await _mediator.Send(new GetAllMaterialsQuery());

            if (materials == null)
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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var material = await _mediator.Send(new GetMaterialByIdQuery() { Id = id });

            if (material == null)
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
        ///        "id" : 1,
        ///        "name" : "Sand",
        ///        "price" : 1000,
        ///        "sellerId" : 1,
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
        [Route("create")]
        public async Task<IActionResult> Create(string name, decimal price, int sellerId)
        {
            var material = await _mediator.Send(new CreateMaterialCommand() { 
                Name = name, Price = price, SellerId = sellerId
            });

            if (material == null)
            {
                return BadRequest(material);
            }

            return CreatedAtAction(nameof(Create), new { id = material.Id }, material);
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
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(int id, string name, decimal price, int sellerId)
        {
            var material = await _mediator.Send(new UpdateMaterialCommand() { 
                Id = id, Name = name, Price = price, SellerId = sellerId
            });

            if (material == null)
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
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _mediator.Send(new DeleteMaterialCommand() { Id = id });

            if (material == null)
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
        [HttpPut]
        [Route("update-prices")]
        public async Task<IActionResult> UpdatePrices()
        {
            var materials = await _mediator.Send(new UpdateMaterialPricesCommand());

            if (materials == null)
            {
                return NotFound($"No materials found.");
            }

            return Ok($"Material prices successfully updated.");
        }
    }
}
