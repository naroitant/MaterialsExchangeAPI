using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Queries.GetAllMaterials;

/// <summary>
/// Запрос на получение всех материалов
/// </summary>
public record GetAllMaterialsQuery : IRequest<List<GetMaterialResponseDto>> { }

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
        var materials = await _context.Materials.ToListAsync(
                cancellationToken: token);
        var getMaterialResponseDtos =
            materials.Select(m => m.ToGetMaterialResponseDto()).ToList();

        return getMaterialResponseDtos;
    }
}
