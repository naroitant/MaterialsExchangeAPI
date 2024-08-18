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
        var requestDto = request.Dto;

        var material = await Context.Materials
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Id == requestDto.Id, token);

        if (material is null)
        {
            return null;
        }

        var responseDto = Mapper.Map<GetMaterialResponseDto>(material);
        return responseDto;
    }
}
