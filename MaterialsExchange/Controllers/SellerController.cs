using MaterialsExchange.Features.Seller.Commands;
using MaterialsExchange.Features.Seller.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class SellerController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SellerController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("all", Name = "GetAllSellers")]
		public async Task<IActionResult> GetAll([FromQuery] GetAllSellersQuery request, CancellationToken token)
		{
			var sellers = await _mediator.Send(request, token);
			
			if (sellers == null)
			{
				return NotFound("No seller found.");
			}
			
			return Ok(sellers);
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetSellerById")]
		public async Task<IActionResult> GetById([FromQuery] GetSellerByIdQuery request, CancellationToken token)
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
		public async Task<IActionResult> Create([FromBody] CreateSellerCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);
			return Ok(seller);
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> Update([FromBody] UpdateSellerCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);
			
			if (seller == null)
			{
				return NotFound($"No seller found to update.");
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteSellerById")]
		public async Task<IActionResult> Delete([FromBody] DeleteSellerCommand command, CancellationToken token)
		{
			var seller = await _mediator.Send(command, token);

			if (seller == null)
			{
				return NotFound($"The seller was not found.");
			}

			return NoContent();
		}
	}
}
