using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Materials.Queries.GetAllMaterials;

/// <summary>
/// Запрос на получение всех материалов
/// </summary>
public record GetAllMaterialsQuery : IRequest<List<GetMaterialResponseDto>>
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы
    /// </summary>
    public int PageSize { get; set; }
}

public class GetAllMaterialsQueryHandler : BaseHandler,
    IRequestHandler<GetAllMaterialsQuery, List<GetMaterialResponseDto>>
{
    public GetAllMaterialsQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<List<GetMaterialResponseDto>> Handle(
        GetAllMaterialsQuery request, CancellationToken token)
    {
        var getMaterialResponseDtos = await _context.Materials
            .OrderBy(m => m.Id)
            .Select(m => _mapper.Map<GetMaterialResponseDto>(m))
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getMaterialResponseDtos;
    }
}
