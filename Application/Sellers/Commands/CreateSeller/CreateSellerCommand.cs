using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

/// <summary>
/// Команда создания продавца
/// </summary>
public class CreateSellerCommand : IRequest<CreateSellerResponseDto>
{
    /// <summary>
    /// Имя продавца
    /// </summary>
    public required string Name { get; set; }
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

        var seller = createSellerRequestDto.ToSeller();
        var latestSeller = 
            await _context.Sellers.OrderBy(l => l.Id).LastOrDefaultAsync(token);

        if (latestSeller is null)
        {
            seller.Id = 1;
        }
        else
        {
            seller.Id = latestSeller.Id + 1;
        }

        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync(token);

        var createSellerResponseDto = seller.ToCreateSellerResponseDto();

        return createSellerResponseDto;
    }
}
