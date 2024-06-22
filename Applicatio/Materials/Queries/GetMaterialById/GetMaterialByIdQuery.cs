using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Queries.GetMaterialById;

/// <summary>
/// Запрос на получение материала по id
/// </summary>
public class GetMaterialByIdQuery : IRequest<GetMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id { get; set; }
}

public class GetMaterialByIdQueryHandler
    : IRequestHandler<GetMaterialByIdQuery, GetMaterialResponseDto?>
{
    private readonly IAppDbContext _context;

    public GetMaterialByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<GetMaterialResponseDto?> Handle(
        GetMaterialByIdQuery request, CancellationToken token)
    {
        var material = await _context.Materials.FindAsync(request.Id);

        if (material == null)
        {
            return null;
        }

        var getMaterialResponseDto = material.ToGetMaterialResponseDto();

        return getMaterialResponseDto;
    }
}
