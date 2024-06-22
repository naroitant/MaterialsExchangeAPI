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
        var materials = 
            await _context.Materials.ToListAsync(cancellationToken: token);
        var updateMaterialPriceResponseDtos =
            new List<UpdateMaterialPriceResponseDto>();

        if (materials.Any())
        {
            Random rnd = new();
            int minValue = 1;
            int maxValue = 100;

            // Обходим материалы в БД.
            foreach (var material in materials)
            {
                material.Price = rnd.Next(minValue, maxValue);

                var updateMaterialPriceResponseDto = 
                    material.ToUpdateMaterialPriceResponseDto();

                updateMaterialPriceResponseDtos.Add(updateMaterialPriceResponseDto);

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
