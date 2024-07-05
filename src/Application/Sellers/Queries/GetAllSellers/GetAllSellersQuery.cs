using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

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

public class GetAllSellersQueryHandler : BaseHandler,
    IRequestHandler<GetAllSellersQuery, List<GetSellerResponseDto>>
{
    public GetAllSellersQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<List<GetSellerResponseDto>> Handle(
        GetAllSellersQuery request, CancellationToken token)
    {
        var getSellerResponseDtos = await _context.Sellers
            .OrderBy(s => s.Id)
            .Select(s => _mapper.Map<GetSellerResponseDto>(s))
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getSellerResponseDtos;
    }
}
