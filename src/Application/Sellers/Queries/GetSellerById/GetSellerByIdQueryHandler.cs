using Application.Common;
using Application.Common.Interfaces;
using Application.Materials.Queries;
using AutoMapper;

namespace Application.Sellers.Queries.GetSellerById;

public class GetSellerByIdQueryHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<GetSellerByIdQuery, GetSellerResponseDto?>
{
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

        var getMaterialResponseDtos = await Context.Materials
            .Where(m => m.SellerId == seller.Id)
            .Select(m => new GetMaterialResponseDto
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                SellerId = m.SellerId,
            })
            .ToListAsync(token);

        var getSellerResponseDto = new GetSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
            Dtos = getMaterialResponseDtos,
        };

        return getSellerResponseDto;
    }
}
