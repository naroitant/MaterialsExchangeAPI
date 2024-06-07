using MaterialsExchange.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SellerController : ControllerBase
	{
		[HttpGet]
		[Route("all", Name = "GetAllSellers")]
		public ActionResult<IEnumerable<SellerDto>> GetSellers()
		{
			var sellers = MaterialsExchangeRepository.Sellers.Select(s => new SellerDto()
			{
				Id = s.Id,
				Name = s.Name,
			});

			if (sellers == null)
			{
				return NotFound();
			}

			return Ok(sellers);
		}		

		[HttpGet]
		[Route("{id:int}", Name = "GetSellerById")]
		public ActionResult<SellerDto> GetSellerById(int id)
		{
			var seller = MaterialsExchangeRepository.Sellers.Where(s => s.Id == id).FirstOrDefault();

			if (seller == null)
			{
				return NotFound($"The seller with id: {id} not found.");
			}

			var sellerDto = new SellerDto
			{
				Id = seller.Id,
				Name = seller.Name,
			};

			return Ok(sellerDto);
		}

		[HttpPost]
		[Route("create")]
		public ActionResult<SellerDto> CreateSeller([FromBody] SellerDto model)
		{
			int newId = MaterialsExchangeRepository.Sellers.LastOrDefault().Id + 1;

			Seller seller = new Seller
			{
				Id = newId,
				Name = model.Name,
			};
			MaterialsExchangeRepository.Sellers.Add(seller);

			model.Id = seller.Id;

			var validator = new SellerDtoValidator();
			var results = validator.Validate(model);

			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			return Ok(model);
		}

		[HttpPut]
		[Route("update")]
		public ActionResult UpdateSeller([FromBody] SellerDto model)
		{
			var seller = MaterialsExchangeRepository.Sellers.Where(m => m.Id == model.Id).FirstOrDefault();

			if (seller == null)
			{
				return NotFound();
			}

			seller.Name = model.Name;

			var validator = new SellerDtoValidator();
			var results = validator.Validate(model);

			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteSellerById")]
		public ActionResult<bool> DeleteSeller(int id)
		{
			var seller = MaterialsExchangeRepository.Sellers.Where(s => s.Id == id).FirstOrDefault();

			if (seller == null)
			{
				return NotFound($"The seller with id: {id} not found.");
			}

			MaterialsExchangeRepository.Sellers.Remove(seller);

			return NoContent();
		}
	}
}
