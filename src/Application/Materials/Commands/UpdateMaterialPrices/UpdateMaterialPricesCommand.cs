using Application.Common.Interfaces;

namespace Application.Materials.Commands.UpdateMaterialPrices;

/// <summary>
/// Команда обновления цен материалов
/// </summary>
public record UpdateMaterialPricesCommand : IRequest <bool> { }

public class UpdateMaterialPricesCommandHandler 
    : IRequestHandler<UpdateMaterialPricesCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdateMaterialPricesCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        UpdateMaterialPricesCommand command, CancellationToken token)
    {
        var materials = await _context.Materials
            .ToListAsync(cancellationToken: token);

        if (!materials.Any()) return false;
        
        foreach (var material in materials)
        {
            material.UpdatePriceRandomly();
            token.ThrowIfCancellationRequested();
        }

        await _context.SaveChangesAsync(token);

        return true;

    }
}
