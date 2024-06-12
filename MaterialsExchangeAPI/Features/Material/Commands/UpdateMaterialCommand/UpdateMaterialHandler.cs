using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialCommand
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, MaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;

        public UpdateMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<MaterialDto?> Handle(UpdateMaterialCommand command, CancellationToken token)
        {
            MaterialDto materialDto = new MaterialDto();
            materialDto.Id = command.Id;
            materialDto.Name = command.Name;
            materialDto.Price = command.Price;
            materialDto.SellerId = command.SellerId;

            var updatedMaterial = await _materialRepository.UpdateAsync(materialDto);

            if (updatedMaterial == null)
            {
                return null;
            }

            return materialDto;
        }
    }
}
