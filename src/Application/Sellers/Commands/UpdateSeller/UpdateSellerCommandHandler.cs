using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Sellers.Commands.UpdateSeller;

public class UpdateSellerCommandHandler(IAppDbContext context, IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<UpdateSellerCommand, UpdateSellerResponseDto?>
{
    public async Task<UpdateSellerResponseDto?> Handle(
        UpdateSellerCommand command, CancellationToken token)
    {
        var requestDto = command.Dto;

        var seller = await Context.Sellers
            .FirstOrDefaultAsync(u => u.Id == command.Id, token);

        if (seller is null)
        {
            return null;
        }

        seller.Update(requestDto.Name);

        await Context.SaveChangesAsync(token);

        var responseDto = Mapper.Map<UpdateSellerResponseDto>(seller);
        return responseDto;
    }
}
