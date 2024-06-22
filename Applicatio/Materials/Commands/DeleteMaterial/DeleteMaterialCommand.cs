using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;

/// <summary>
/// Команда удаления материала
/// </summary>
public class DeleteMaterialCommand : IRequest<DeleteMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public required int Id { get; set; }
}

public class DeleteMaterialCommandHandler 
    : IRequestHandler<DeleteMaterialCommand, DeleteMaterialResponseDto?>
{
    private readonly IAppDbContext _context;

    public DeleteMaterialCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<DeleteMaterialResponseDto?> Handle(
        DeleteMaterialCommand command, CancellationToken token)
    {
        var material = await _context.Materials.FindAsync(command.Id);

        if (material == null)
        {
            return null;
        }

        var deleteMaterialResponseDto = material.ToDeleteMaterialResponseDto();

        _context.Materials.Remove(material);
        await _context.SaveChangesAsync(token);

        return deleteMaterialResponseDto;
    }
}
