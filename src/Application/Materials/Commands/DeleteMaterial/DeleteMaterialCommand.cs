using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;

/// <summary>
/// Команда удаления материала
/// </summary>
public record DeleteMaterialCommand : IRequest<Boolean>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id;
}

public class DeleteMaterialCommandHandler : BaseHandler,
    IRequestHandler<DeleteMaterialCommand, Boolean>
{
    public DeleteMaterialCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<Boolean> Handle(
        DeleteMaterialCommand command, CancellationToken token)
    {
        var deleteMaterialRequestDto = _mapper.Map<DeleteMaterialRequestDto>(command);
        var material = await _context.Materials.FirstOrDefaultAsync(
            u => u.Id == deleteMaterialRequestDto.Id, token);

        if (material is null)
        {
            return false;
        }

        _context.Materials.Remove(material);
        await _context.SaveChangesAsync(token);

        return true;
    }
}
