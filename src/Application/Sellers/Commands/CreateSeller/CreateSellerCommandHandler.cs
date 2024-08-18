using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Sellers.Commands.CreateSeller;

public class CreateSellerCommandHandler(
    IAppDbContext context,
    IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<CreateSellerCommand, CreateSellerResponseDto?>
{
    public async Task<CreateSellerResponseDto?> Handle(
        CreateSellerCommand command, CancellationToken token)
    {
        var createSellerRequestDto =
            Mapper.Map<CreateSellerRequestDto>(command);
        var seller = Mapper.Map<Seller>(createSellerRequestDto);

        Context.Sellers.Add(seller);

        await Context.SaveChangesAsync(token);

        var createSellerResponseDto =
            Mapper.Map<CreateSellerResponseDto?>(seller);
        return createSellerResponseDto;
    }
}
