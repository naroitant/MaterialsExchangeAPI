using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialPricesCommand
{
    public class UpdateMaterialPricesCommandHandler :
            IRequestHandler<UpdateMaterialPricesCommand, List<MaterialDto>>
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

                // Обходим материалы в БД.
                foreach (var material in materials)
                {
                    // Присваиваем текущему материалу случайную цену в диапазоне от 1 до 100.
                    material.Price = rnd.Next(1, 100);

                    MaterialDto materialDto = material.ToMaterialDto();
                    materialDtos.Add(materialDto);

                    await _materialRepository.UpdateAsync(materialDto);

                    // Останавливаем выполнение операции, если запрашивается отмена. 
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }

            return materialDtos;
        }
    }
}
