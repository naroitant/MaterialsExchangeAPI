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
        var requestDto = Mapper.Map<CreateSellerRequestDto>(command);

        var seller = Mapper.Map<Seller>(requestDto);

        Context.Sellers.Add(seller);

        await Context.SaveChangesAsync(token);

        var responseDto = Mapper.Map<CreateSellerResponseDto?>(seller);
        return responseDto;
    }
}
