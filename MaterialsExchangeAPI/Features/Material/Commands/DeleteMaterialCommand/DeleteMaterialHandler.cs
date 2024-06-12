using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.DeleteMaterialCommand
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, MaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;

        public DeleteMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<MaterialDto?> Handle(DeleteMaterialCommand command, CancellationToken token)
        {
            int id = command.Id;
            var material = await _materialRepository.DeleteAsync(id);

            if (material == null)
            {
                return null;
            }

            MaterialDto materialDto = material.ToMaterialDto();
            return materialDto;
        }
    }
}
