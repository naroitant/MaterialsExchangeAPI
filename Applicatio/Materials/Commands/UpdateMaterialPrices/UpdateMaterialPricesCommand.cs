using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;

/// <summary>
/// Команда обновления цен материалов
/// </summary>
public class UpdateMaterialPricesCommand
    : IRequest <List<UpdateMaterialPriceResponseDto>> { }

public class UpdateMaterialPricesCommandHandler 
    : IRequestHandler<UpdateMaterialPricesCommand, List<UpdateMaterialPriceResponseDto>>
{
    private readonly IAppDbContext _context;

    public UpdateMaterialPricesCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UpdateMaterialPriceResponseDto>> Handle(
        UpdateMaterialPricesCommand command, CancellationToken token)
    {
        var materials = await _context.Materials.ToListAsync();
        var updateMaterialPriceResponseDtos =
            new List<UpdateMaterialPriceResponseDto>();

        if (materials.Any())
        {
            Random rnd = new Random();

            // Обходим материалы в БД.
            foreach (var material in materials)
            {
                // Присваиваем текущему материалу случайную цену в диапазоне
                // от 1 до 100.
                material.Price = rnd.Next(1, 100);

                UpdateMaterialPriceResponseDto updateMaterialPriceResponseDto =
                    material.ToUpdateMaterialPriceResponseDto();

                updateMaterialPriceResponseDtos.Add(updateMaterialPriceResponseDto);

                // Останавливаем выполнение операции, если запрашивается отмена. 
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }
        await _context.SaveChangesAsync(token);

        return updateMaterialPriceResponseDtos;
    }
}
