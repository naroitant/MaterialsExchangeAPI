using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Materials.Commands.DeleteMaterial;

/// <summary>
/// Команда удаления материала
/// </summary>
public record DeleteMaterialCommand : IRequest<bool>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public Guid Id { get; init; }
}

public class DeleteMaterialCommandHandler : BaseHandler,
    IRequestHandler<DeleteMaterialCommand, bool>
{
    public DeleteMaterialCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<bool> Handle(
        DeleteMaterialCommand command, CancellationToken token)
    {
        var deleteMaterialRequestDto = Mapper.Map<DeleteMaterialRequestDto>(command);
        var material = await Context.Materials.FirstOrDefaultAsync(
            u => u.Id == deleteMaterialRequestDto.Id, token);

        if (material is null)
        {
            return false;
        }

        Context.Materials.Remove(material);
        await Context.SaveChangesAsync(token);
        
        return true;
    }
}
