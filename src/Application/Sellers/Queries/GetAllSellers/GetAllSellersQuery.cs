using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Queries.GetAllSellers;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public record GetAllSellersQuery : IRequest<List<GetSellerResponseDto>>
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

public class GetAllSellersQueryHandler
    : IRequestHandler<GetAllSellersQuery, List<GetSellerResponseDto>>
{
    private readonly IAppDbContext _context;

    public GetAllSellersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetSellerResponseDto>> Handle(
        GetAllSellersQuery request, CancellationToken token)
    {
        var getSellerResponseDtos = await _context.Sellers
            .Select(s => s.ToGetSellerResponseDto())
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getSellerResponseDtos;
    }
}
