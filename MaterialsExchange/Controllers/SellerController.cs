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
		public IEnumerable<Seller> getSellers()
		{
			return MaterialsExchangeRepository.Sellers;
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetSellerById")]
		public Seller GetSellerById(int id)
		{
			return MaterialsExchangeRepository.Sellers.Where(s => s.Id == id).FirstOrDefault();
		}

		[HttpPost]
		[Route("create")]
		public ActionResult CreateSeller(string name, decimal price, int sellerId)
		{
			int newId = MaterialsExchangeRepository.Sellers.LastOrDefault().Id + 1;
			Seller seller = new Seller
			{
				Id = newId,
				Name = name,
			};
			MaterialsExchangeRepository.Sellers.Add(seller);

			return Ok(seller);
		}

		[HttpPut]
		[Route("update")]
		public ActionResult UpdateSeller(int id, string name)
		{
			var existingMaterial = MaterialsExchangeRepository.Sellers.Where(m => m.Id == id).FirstOrDefault();

			if (existingMaterial == null)
			{
				return NotFound();
			}

			existingMaterial.Name = name;

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteSellerById")]
		public bool DeleteSeller(int id)
		{
			var seller = MaterialsExchangeRepository.Sellers.Where(s => s.Id == id).FirstOrDefault();
			MaterialsExchangeRepository.Sellers.Remove(seller);
			return true;
		}
	}
}
