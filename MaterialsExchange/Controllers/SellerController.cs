using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class SellerController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly ISellerRepository _sellerRepository;
		public SellerController(AppDbContext context, ISellerRepository sellerRepository)
		{
			_context = context;
			_sellerRepository = sellerRepository;
		}

		[HttpGet]
		[Route("all", Name = "GetAllSellers")]
		public async Task<ActionResult> GetAll()
		{
			var sellers = await _sellerRepository.GetAllAsync();
			var sellerDtos = sellers.Select(s => s.ToSellerDto()).ToList();
			return Ok(sellerDtos);
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetSellerById")]
		public async Task<ActionResult> GetById(int id)
		{
			var seller = await _sellerRepository.GetByIdAsync(id);

			if (seller == null)
			{
				return NotFound($"The seller with id: {id} not found.");
			}

			var sellerDto = seller.ToSellerDto();

			return Ok(sellerDto);
		}

		[HttpPost]
		[Route("create")]
		public async Task<ActionResult> Create([FromBody] SellerDto sellerDto)
		{
			var validator = new SellerDtoValidator();
			var results = validator.Validate(sellerDto);
			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			var seller = sellerDto.ToSeller();
			await _sellerRepository.CreateAsync(seller);

			return Ok(sellerDto);
		}

		[HttpPut]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] SellerDto sellerDto)
		{
			var validator = new SellerDtoValidator();
			var results = validator.Validate(sellerDto);
			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			var seller = await _sellerRepository.UpdateAsync(sellerDto);
			if (seller == null)
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteSellerById")]
		public async Task<IActionResult> DeleteSeller(int id)
		{
			var seller = await _sellerRepository.DeleteAsync(id);

			if (seller == null)
			{
				return NotFound($"The seller with id: {id} not found.");
			}

			return NoContent();
		}
	}
}
