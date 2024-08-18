using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Materials.Queries.GetMaterialById;

public class GetMaterialByIdQueryHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<GetMaterialByIdQuery, GetMaterialResponseDto?>
{
    public async Task<GetMaterialResponseDto?> Handle(
        GetMaterialByIdQuery request, CancellationToken token)
    {
        var getMaterialByIdRequestDto =
            Mapper.Map<GetMaterialByIdRequestDto>(request);
        var material = await Context.Materials
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Id == getMaterialByIdRequestDto.Id, token);

        if (material is null)
        {
            return null;
        }

        var getMaterialResponseDto =
            Mapper.Map<GetMaterialResponseDto>(material);
        return getMaterialResponseDto;
    }
}
