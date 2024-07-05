using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

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

public class GetSellerByIdQueryHandler : BaseHandler,
    IRequestHandler<GetSellerByIdQuery, GetSellerResponseDto?>
{
    public GetSellerByIdQueryHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<GetSellerResponseDto?> Handle(GetSellerByIdQuery request,
        CancellationToken token)
    {
        var getSellerByIdRequestDto =
            _mapper.Map<GetSellerByIdRequestDto>(request);
        var seller = await _context.Sellers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => 
                u.Id == getSellerByIdRequestDto.Id, token);

        if (seller is null)
        {
            return null;
        }

        var getSellerResponseDto =
            _mapper.Map<GetSellerResponseDto>(seller);
        return getSellerResponseDto;
    }
}
