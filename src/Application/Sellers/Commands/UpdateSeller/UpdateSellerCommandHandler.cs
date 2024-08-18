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
        var updateSellerRequestDto =
            Mapper.Map<UpdateSellerRequestDto>(command);
        var seller = await Context.Sellers.FirstOrDefaultAsync(
            u => u.Id == updateSellerRequestDto.Id, token);

        if (seller is null)
        {
            return null;
        }

        seller.Update(updateSellerRequestDto.Name);

        await Context.SaveChangesAsync(token);

        var updateSellerResponseDto =
            Mapper.Map<UpdateSellerResponseDto>(seller);
        return updateSellerResponseDto;
    }
}
