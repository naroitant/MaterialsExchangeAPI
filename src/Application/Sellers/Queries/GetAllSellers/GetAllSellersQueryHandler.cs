using Application.Common;
using Application.Common.Interfaces;
using Application.Materials.Queries;
using AutoMapper;

namespace Application.Sellers.Queries.GetAllSellers;

public class GetAllSellersQueryHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<GetAllSellersQuery, GetSellersResponseDto>
{
    public async Task<GetSellersResponseDto> Handle(
        GetAllSellersQuery request, CancellationToken token)
    {
        var requestDto = request.Dto;

        var responseDtos = await Context.Sellers
            .AsNoTracking()
            .OrderBy(s => s.Id)
            .Select(s => new GetSellerResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Dtos = s.Materials
                    .Select(m => new GetMaterialResponseDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Price = m.Price,
                        SellerId = m.SellerId
                    })
                    .ToList(),
            })
            .Skip(requestDto.Skip)
            .Take(requestDto.Take)
            .ToListAsync(token);

        var responseDto = new GetSellersResponseDto
        {
            Dtos = responseDtos,
        };

        return responseDto;
    }
}
