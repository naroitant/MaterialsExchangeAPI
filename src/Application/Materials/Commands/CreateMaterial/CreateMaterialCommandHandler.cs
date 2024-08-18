using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Materials.Commands.CreateMaterial;

public class CreateMaterialCommandHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<CreateMaterialCommand, CreateMaterialResponseDto?>
{
    public async Task<CreateMaterialResponseDto?> Handle(
        CreateMaterialCommand command, CancellationToken token)
    {
        var requestDto = command.Dto;

        var material = Mapper.Map<Material>(requestDto);

        Context.Materials.Add(material);

        await Context.SaveChangesAsync(token);

        var createMaterialResponseDto =
            Mapper.Map<CreateMaterialResponseDto?>(material);
        return createMaterialResponseDto;
    }
}
