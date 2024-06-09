using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MaterialsExchange.Mappers;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MaterialsExchange.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MaterialController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IMaterialRepository _materialRepository;
		public MaterialController(AppDbContext context, IMaterialRepository materialRepository)
		{
			_context = context;
			_materialRepository = materialRepository;
		}

		[HttpGet]
		[Route("all", Name = "GetAllMaterials")]
		public async Task<ActionResult> GetAll()
		{
			var materials = await _materialRepository.GetAllAsync();
			var materialDtos = materials.Select(m => m.ToMaterialDto()).ToList();

			return Ok(materialDtos);
		}

		[HttpGet]
		[Route("{id:int}", Name = "GetMaterialById")]
		public async Task<ActionResult> GetById(int id)
		{
			var material = await _materialRepository.GetByIdAsync(id);
			if (material == null)
			{
				return NotFound($"The material with id: {id} not found.");
			}

			var materialDto = material.ToMaterialDto();

			return Ok(materialDto);
		}

		[HttpPost]
		[Route("create")]
		public async Task<ActionResult> Create([FromBody] MaterialDto materialDto)
		{
			var validator = new MaterialDtoValidator();
			var results = validator.Validate(materialDto);
			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			var material = materialDto.ToMaterial();
			await _materialRepository.CreateAsync(material);

			return Ok(materialDto);
		}

		[HttpPut]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] MaterialDto materialDto)
		{
			var validator = new MaterialDtoValidator();
			var results = validator.Validate(materialDto);
			if (!results.IsValid)
			{
				return BadRequest(results.Errors);
			}

			var material = await _materialRepository.UpdateAsync(materialDto);
			if (material == null)
			{
				return NotFound($"No material found to update.");
			}

			return NoContent();
		}

		[HttpDelete]
		[Route("{id:int}", Name = "DeleteMaterialById")]
		public async Task<IActionResult> Delete(int id)
		{
			var material = await _materialRepository.DeleteAsync(id);

			if (material == null)
			{
				return NotFound($"The material with id: {id} not found.");
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateMaterialPrices()
		{
			var materials = await _materialRepository.GetAllAsync();

			if (materials.Any())
			{
				Random rnd = new Random();
				foreach (var material in materials)
				{
					material.Price = rnd.Next(1, 100);
					MaterialDto materialDto = material.ToMaterialDto();
					await _materialRepository.UpdateAsync(materialDto);
				}

				return Ok($"Material prices successfully updated.");
			}

			return NotFound($"No materials found to be updated.");
		}
	}
}
