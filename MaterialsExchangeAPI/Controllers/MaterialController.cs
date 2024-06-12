using MaterialsExchange.Features.Material.Commands;
using MaterialsExchange.Features.Material.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MaterialController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MaterialController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("all", Name = "GetAllMaterials")]
		public async Task<IActionResult> GetAll([FromQuery] GetAllMaterialsQuery request, CancellationToken token)
		{
			var sellers = await _mediator.Send(request, token);

			if (sellers == null)
			{
				return NotFound("No seller found.");
			}

			return Ok(sellers);
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetMaterialById")]
		public async Task<IActionResult> GetById([FromQuery] GetMaterialByIdQuery request, CancellationToken token)
		{
			var seller = await _mediator.Send(request, token);

			if (seller == null)
			{
				return NotFound($"No seller found.");
			}

			return Ok(seller);
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> Create([FromBody] CreateMaterialCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);
			return Ok(seller);
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);

			if (seller == null)
			{
				return NotFound($"No seller found to update.");
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteMaterialById")]
		public async Task<IActionResult> DeleteSeller([FromBody] DeleteMaterialCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);

			if (seller == null)
			{
				return NotFound($"The seller was not found.");
			}

			return NoContent();
		}

		[HttpPost]
		[Route("update-prices")]
		public async Task<IActionResult> UpdatePrices([FromBody] UpdateMaterialPricesCommand command, CancellationToken token)
		{
			var materials = await _mediator.Send(command, token);

			if (materials == null)
			{
				return NotFound($"No materials found to be updated.");
			}

			return Ok($"Material prices successfully updated.");
		}
	}
}
