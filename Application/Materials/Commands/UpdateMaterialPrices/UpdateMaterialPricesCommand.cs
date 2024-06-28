using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;

/// <summary>
/// Команда обновления цен материалов
/// </summary>
public record UpdateMaterialPricesCommand : IRequest <Boolean> { }

public class UpdateMaterialPricesCommandHandler 
    : IRequestHandler<UpdateMaterialPricesCommand, Boolean>
{
    private readonly IAppDbContext _context;

    public UpdateMaterialPricesCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Boolean> Handle(
        UpdateMaterialPricesCommand command, CancellationToken token)
    {
        var materials =
            await _context.Materials.ToListAsync(cancellationToken: token);

        if (materials.Any())
        {
            // Обходим материалы в БД.
            foreach (var material in materials)
            {
                material.UpdatePriceRandomly();

                if (token.IsCancellationRequested)
                {
                    break;
                }
            }

            await _context.SaveChangesAsync(token);

            return true;
        }

        return false;
    }
}
