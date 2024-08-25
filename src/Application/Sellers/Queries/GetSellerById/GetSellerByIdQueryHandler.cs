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
        var requestDto = Mapper.Map<GetSellerByIdRequestDto>(request);

        var responseDto = await Context.Sellers
            .AsNoTracking()
            .Select(s => new GetSellerResponseDto
            {
                Id = s.Id,
                Name = s.Name,
            })
            .FirstOrDefaultAsync(s =>
                s.Id == requestDto.Id, token);

        return responseDto ?? null;
    }
}
