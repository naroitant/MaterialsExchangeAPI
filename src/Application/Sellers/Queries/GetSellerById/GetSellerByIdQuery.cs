using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Sellers.Queries.GetSellerById;

/// <summary>
/// Запрос на получение продавца по id
/// </summary>
public record GetSellerByIdQuery : IRequest<GetSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public Guid Id { get; init; }
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
            Mapper.Map<GetSellerByIdRequestDto>(request);
        var seller = await Context.Sellers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => 
                u.Id == getSellerByIdRequestDto.Id, token);

        if (seller is null)
        {
            return null;
        }

        var getSellerResponseDto =
            Mapper.Map<GetSellerResponseDto>(seller);
        return getSellerResponseDto;
    }
}
