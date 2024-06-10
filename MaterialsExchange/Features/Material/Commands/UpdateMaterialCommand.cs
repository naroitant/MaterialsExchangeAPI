using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Commands
{
	public class UpdateMaterialCommand : IRequest<MaterialDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int SellerId { get; set; }

		public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, MaterialDto>
		{
			private readonly IMaterialRepository _materialRepository;

			public UpdateMaterialCommandHandler(IMaterialRepository materialRepository)
			{
				_materialRepository = materialRepository;
			}

			public async Task<MaterialDto> Handle(UpdateMaterialCommand command, CancellationToken token)
			{
				MaterialDto materialDto = new MaterialDto();
				materialDto.Id = command.Id;
				materialDto.Name = command.Name;
				materialDto.Price = command.Price;
				materialDto.SellerId = command.SellerId;

				var validator = new MaterialDtoValidator();
				var results = validator.Validate(materialDto);
				await _materialRepository.UpdateAsync(materialDto);

				return materialDto;
			}
		}
	}
}
