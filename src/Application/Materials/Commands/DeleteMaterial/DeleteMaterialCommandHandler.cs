using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommandHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<DeleteMaterialCommand, bool>
{
    public async Task<bool> Handle(
        DeleteMaterialCommand command, CancellationToken token)
    {
        var requestDto = Mapper.Map<DeleteMaterialRequestDto>(command);

        var material = await Context.Materials
            .FirstOrDefaultAsync(u => u.Id == requestDto.Id, token);

        if (material is null)
        {
            return false;
        }

        Context.Materials.Remove(material);

        await Context.SaveChangesAsync(token);

        return true;
    }
}
