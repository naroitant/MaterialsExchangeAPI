using Application.Common.Interfaces;

namespace Application.Materials.Commands.UpdateMaterialPrices;

public class UpdateMaterialPricesCommandHandler(IAppDbContext context)
    : IRequestHandler<UpdateMaterialPricesCommand, bool>
{
    public async Task<bool> Handle(
        UpdateMaterialPricesCommand command, CancellationToken token)
    {
        var materials = await context.Materials
            .ToListAsync(token);

        if (materials.Count == 0)
        {
            return false;
        }
        
        foreach (var material in materials)
        {
            material.UpdatePriceRandomly();
            token.ThrowIfCancellationRequested();
        }

        await context.SaveChangesAsync(token);
        
        return true;
    }
}