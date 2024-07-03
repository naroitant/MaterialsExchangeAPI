using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

/// <summary>
/// Команда создания продавца
/// </summary>
public record CreateSellerCommand : IRequest<CreateSellerResponseDto>
{
    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name = string.Empty;
}

public class CreateSellerCommandHandler
    : IRequestHandler<CreateSellerCommand, CreateSellerResponseDto>
{
    private readonly IAppDbContext _context;

    public CreateSellerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<CreateSellerResponseDto> Handle(
        CreateSellerCommand command, CancellationToken token)
    {
        var createSellerRequestDto = new CreateSellerRequestDto()
        {
            Name = command.Name,
        };

        var seller = new Seller(createSellerRequestDto.Name);

        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync(token);

        var createSellerResponseDto = seller.ToCreateSellerResponseDto();
        return createSellerResponseDto;
    }
}
