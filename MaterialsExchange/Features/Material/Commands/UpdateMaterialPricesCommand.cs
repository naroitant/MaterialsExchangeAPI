using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Commands
{
	public class UpdateMaterialPricesCommand : IRequest<List<MaterialDto>>
	{
		public class UpdateMaterialPricesCommandHandler : IRequestHandler<UpdateMaterialPricesCommand, List<MaterialDto>>
		{
			private readonly IMaterialRepository _materialRepository;

			public UpdateMaterialPricesCommandHandler(IMaterialRepository materialRepository)
			{
				_materialRepository = materialRepository;
			}

			public async Task<List<MaterialDto>> Handle(UpdateMaterialPricesCommand command, CancellationToken token)
			{
				var materials = await _materialRepository.GetAllAsync();
				List<MaterialDto> materialDtos = new List<MaterialDto>();

				if (materials.Any())
				{
					Random rnd = new Random();
					foreach (var material in materials)
					{
						material.Price = rnd.Next(1, 100);
						MaterialDto materialDto = material.ToMaterialDto();
						await _materialRepository.UpdateAsync(materialDto);
						materialDtos.Add(materialDto);
					}
				}
				
				return materialDtos;
			}
		}
	}
}
