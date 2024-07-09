using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Materials.Queries.GetAllMaterials;

/// <summary>
/// Запрос на получение всех материалов
/// </summary>
public record GetAllMaterialsQuery : IRequest<List<GetMaterialResponseDto>>
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber { get; init; }

    /// <summary>
    /// Размер страницы
    /// </summary>
    public int PageSize { get; init; }
}

public class GetAllMaterialsQueryHandler : BaseHandler,
    IRequestHandler<GetAllMaterialsQuery, List<GetMaterialResponseDto>>
{
    public GetAllMaterialsQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<List<GetMaterialResponseDto>> Handle(
        GetAllMaterialsQuery request, CancellationToken token)
    {
        var getMaterialResponseDtos = await Context.Materials
            .OrderBy(m => m.Id)
            .Select(m => Mapper.Map<GetMaterialResponseDto>(m))
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getMaterialResponseDtos;
    }
}
