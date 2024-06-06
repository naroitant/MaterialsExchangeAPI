using MaterialsExchange.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MaterialController : ControllerBase
	{
		[HttpGet]
		[Route("all", Name = "GetAllMaterials")]
		public IEnumerable<Material> getMaterials()
		{
			return MaterialsExchangeRepository.Materials;
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetMaterialById")]
		public Material GetMaterialById(int id)
		{
			return MaterialsExchangeRepository.Materials.Where(m => m.Id == id).FirstOrDefault();
		}

		[HttpPost]
		[Route("create")]
		public ActionResult CreateMaterial(string name, decimal price, int sellerId)
		{
			int newId = MaterialsExchangeRepository.Materials.LastOrDefault().Id + 1;
			Material material = new Material
			{
				Id = newId,
				Name = name,
				SellerId = sellerId,
				Price = price,
			};
			MaterialsExchangeRepository.Materials.Add(material);

			return Ok(material);
		}

		[HttpPut]
		[Route("update")]
		public ActionResult UpdateMaterial(int id, string name, decimal price, int sellerId)
		{
			var existingMaterial = MaterialsExchangeRepository.Materials.Where(m => m.Id == id).FirstOrDefault();

			if (existingMaterial == null) {
				return NotFound();
			}
			
			existingMaterial.Name = name;
			existingMaterial.Price = price;
			existingMaterial.SellerId = sellerId;

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteMaterialById")]
		public bool DeleteMaterial(int id)
		{
			var material = MaterialsExchangeRepository.Materials.Where(n => n.Id == id).FirstOrDefault();
			MaterialsExchangeRepository.Materials.Remove(material);
			return true;
		}
	}
}
