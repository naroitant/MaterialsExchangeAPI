using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Sellers.Commands.DeleteSeller;

public class DeleteSellerCommandHandler(
    IAppDbContext context,
    IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<DeleteSellerCommand, bool>
{
    public async Task<bool> Handle(
        DeleteSellerCommand command, CancellationToken token)
    {
        var deleteSellerRequestDto =
            Mapper.Map<DeleteSellerRequestDto>(command);
        var seller = await Context.Sellers.FirstOrDefaultAsync(
            u => u.Id == deleteSellerRequestDto.Id, token);

        if (seller is null)
        {
            return false;
        }

        Context.Sellers.Remove(seller);
        await Context.SaveChangesAsync(token);

        return true;
    }
}
