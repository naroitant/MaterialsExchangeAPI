using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Materials.Queries.GetAllMaterials;

public class GetAllMaterialsQueryHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<GetAllMaterialsQuery, GetAllMaterialsResponseDto>
{
    public async Task<GetAllMaterialsResponseDto> Handle(
        GetAllMaterialsQuery request, CancellationToken token)
    {
        var requestDto = request.Dto;

        var responseDtos = await Context.Materials
            .AsNoTracking()
            .OrderBy(m => m.Id)
            .Select(m => Mapper.Map<GetMaterialResponseDto>(m))
            .Skip(requestDto.Skip)
            .Take(requestDto.Take)
            .ToListAsync(cancellationToken: token);

        var responseDto = new GetAllMaterialsResponseDto
        {
            Dtos = responseDtos,
        };

        return responseDto;
    }
}
