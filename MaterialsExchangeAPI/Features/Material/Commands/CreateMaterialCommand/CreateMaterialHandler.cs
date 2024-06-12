using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.CreateMaterialCommand
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, MaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;

        public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<MaterialDto> Handle(CreateMaterialCommand command, CancellationToken token)
        {
            MaterialDto materialDto = new MaterialDto();
            materialDto.Name = command.Name;
            materialDto.Price = command.Price;
            materialDto.SellerId = command.SellerId;

            var material = await _materialRepository.CreateAsync(materialDto);
            materialDto.Id = material.Id;

            return materialDto;
        }
    }
}
