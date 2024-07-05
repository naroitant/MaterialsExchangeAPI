using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

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

public class GetAllMaterialsQueryHandler
    : IRequestHandler<GetAllMaterialsQuery, List<GetMaterialResponseDto>>
{
    private readonly IAppDbContext _context;

    public GetAllMaterialsQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetMaterialResponseDto>> Handle(
        GetAllMaterialsQuery request, CancellationToken token)
    {
        var getMaterialResponseDtos = await _context.Materials
            .Select(m => m.ToGetMaterialResponseDto())
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getMaterialResponseDtos;
    }
}
