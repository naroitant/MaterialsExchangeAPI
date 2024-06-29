using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Queries.GetSellerById;

/// <summary>
/// Запрос на получение продавца по id
/// </summary>
public record GetSellerByIdQuery : IRequest<GetSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id;
}

public class GetSellerByIdQueryHandler
    : IRequestHandler<GetSellerByIdQuery, GetSellerResponseDto?>
{
    private readonly IAppDbContext _context;

    public GetSellerByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<GetSellerResponseDto?> Handle(GetSellerByIdQuery request,
        CancellationToken token)
    {
        var seller = await _context.Sellers.FindAsync(
            new object?[] { request.Id }, cancellationToken: token);

        if (seller is null)
        {
            return null;
        }

        var getSellerResponseDto = seller.ToGetSellerResponseDto();

        return getSellerResponseDto;
    }
}
