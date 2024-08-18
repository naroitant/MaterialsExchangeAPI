using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Materials.Commands.UpdateMaterial;

public class UpdateMaterialCommandHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<UpdateMaterialCommand, UpdateMaterialResponseDto?>
{
    public async Task<UpdateMaterialResponseDto?> Handle(
        UpdateMaterialCommand command, CancellationToken token)
    {
        var updateMaterialRequestDto =
            Mapper.Map<UpdateMaterialRequestDto>(command);
        var material = await Context.Materials.FirstOrDefaultAsync(
            u => u.Id == command.Id, token);

        if (material is null)
        {
            return null;
        }

        material.Update(
            updateMaterialRequestDto.Name,
            updateMaterialRequestDto.Price
        );

        await Context.SaveChangesAsync(token);

        var updateMaterialResponseDto =
            Mapper.Map<UpdateMaterialResponseDto>(material);
        return updateMaterialResponseDto;
    }
}
