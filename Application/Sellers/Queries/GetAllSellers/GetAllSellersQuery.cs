using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Queries.GetAllSellers;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public class GetAllSellersQuery : IRequest<List<GetSellerResponseDto>> { }

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
        var sellers =
            await _context.Sellers.ToListAsync(cancellationToken: token);
        var getSellerResponseDtos =
            sellers.Select(s => s.ToGetSellerResponseDto()).ToList();

        return getSellerResponseDtos;
    }
}
