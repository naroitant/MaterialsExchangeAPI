using FluentValidation;
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
		public ActionResult<IEnumerable<MaterialDto>> GetMaterials()
		{
			var materials = MaterialsExchangeRepository.Materials.Select(m => new MaterialDto()
			{
				Id = m.Id,
				Name = m.Name,
				Price = m.Price,
				SellerId = m.SellerId,
			});

			if (materials == null)
			{
				return NotFound();
			}

			return Ok(materials);
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetMaterialById")]
		public ActionResult<MaterialDto> GetMaterialById(int id)
		{
			var material = MaterialsExchangeRepository.Materials.Where(m => m.Id == id).FirstOrDefault();
			
			if (material == null)
			{
				return NotFound($"The material with id: {id} not found.");
			}

			var materialDto = new MaterialDto
			{
				Id = material.Id,
				Name = material.Name,
				Price = material.Price,
				SellerId = material.SellerId,
			};

			return Ok(materialDto);
		}

		[HttpPost]
		[Route("create")]
		public ActionResult<MaterialDto> CreateMaterial([FromBody] MaterialDto model)
		{
			int newId = MaterialsExchangeRepository.Materials.LastOrDefault().Id + 1;
			
			Material material = new Material
			{
				Id = newId,
				Name = model.Name,
				SellerId = model.SellerId,
				Price = model.Price,
			};
			MaterialsExchangeRepository.Materials.Add(material);

			model.Id = material.Id;

			var validator = new MaterialDtoValidator();
			var results = validator.Validate(model);

			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			return Ok(model);
		}

		[HttpPut]
		[Route("update")]
		public ActionResult UpdateMaterial([FromBody] MaterialDto model)
		{
			var material = MaterialsExchangeRepository.Materials.Where(m => m.Id == model.Id).FirstOrDefault();

			if (material == null) {
				return NotFound();
			}
			
			material.Name = model.Name;
			material.Price = model.Price;
			material.SellerId = model.SellerId;

			var validator = new MaterialDtoValidator();
			var results = validator.Validate(model);

			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteMaterialById")]
		public ActionResult<bool> DeleteMaterial(int id)
		{
			var material = MaterialsExchangeRepository.Materials.Where(n => n.Id == id).FirstOrDefault();

			if (material == null)
			{
				return NotFound($"The material with id: {id} not found.");
			}

			MaterialsExchangeRepository.Materials.Remove(material);

			return NoContent();
		}
	}
}
