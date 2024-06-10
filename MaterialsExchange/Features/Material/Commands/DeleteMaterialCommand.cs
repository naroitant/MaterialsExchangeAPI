using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Commands
{
	public class DeleteMaterialCommand : IRequest<MaterialDto>
	{
		public int Id { get; set; }

		public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, MaterialDto>
		{
			private readonly IMaterialRepository _materialRepository;

			public DeleteMaterialCommandHandler(IMaterialRepository materialRepository)
			{
				_materialRepository = materialRepository;
			}

			public async Task<MaterialDto> Handle(DeleteMaterialCommand command, CancellationToken token)
			{
				int id = command.Id;
				var material = await _materialRepository.DeleteAsync(id);
				MaterialDto materialDto = material.ToMaterialDto();
				return materialDto;
			}
		}
	}
}
