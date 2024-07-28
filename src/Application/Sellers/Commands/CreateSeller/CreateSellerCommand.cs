using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Sellers.Commands.CreateSeller;

/// <summary>
/// Команда создания продавца
/// </summary>
public record CreateSellerCommand : IRequest<CreateSellerResponseDto?>
{
    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name { get; init; } = string.Empty;
}

public class CreateSellerCommandHandler : BaseHandler,
    IRequestHandler<CreateSellerCommand, CreateSellerResponseDto?>
{
    public CreateSellerCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

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
