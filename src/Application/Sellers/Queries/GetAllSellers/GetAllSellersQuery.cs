using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Sellers.Queries.GetAllSellers;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public record GetAllSellersQuery : IRequest<List<GetSellerResponseDto>>
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

public class GetAllSellersQueryHandler : BaseHandler,
    IRequestHandler<GetAllSellersQuery, List<GetSellerResponseDto>>
{
    public GetAllSellersQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<List<GetSellerResponseDto>> Handle(
        GetAllSellersQuery request, CancellationToken token)
    {
        var getSellerResponseDtos = await Context.Sellers
            .OrderBy(s => s.Id)
            .Select(s => Mapper.Map<GetSellerResponseDto>(s))
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: token);

        return getSellerResponseDtos;
    }
}
