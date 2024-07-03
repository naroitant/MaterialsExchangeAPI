using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Queries.GetAllSellers;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public record GetAllSellersQuery : IRequest<List<GetSellerResponseDto>> { }

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
            .ToListAsync(cancellationToken: token);

        return getSellerResponseDtos;
    }
}
