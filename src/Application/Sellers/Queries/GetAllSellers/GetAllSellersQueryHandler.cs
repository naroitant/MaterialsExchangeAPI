using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Sellers.Queries.GetAllSellers;

public class GetAllSellersQueryHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<GetAllSellersQuery, GetAllSellersResponseDto>
{
    public async Task<GetAllSellersResponseDto> Handle(
        GetAllSellersQuery request, CancellationToken token)
    {
        var requestDto = request.Dto;

        var responseDtos = await Context.Sellers
            .AsNoTracking()
            .OrderBy(s => s.Id)
            .Select(s => Mapper.Map<GetSellerResponseDto>(s))
            .Skip(requestDto.Skip)
            .Take(requestDto.Take)
            .ToListAsync(cancellationToken: token);

        var responseDto = new GetAllSellersResponseDto
        {
            Dtos = responseDtos,
        };

        return responseDto;
    }
}
