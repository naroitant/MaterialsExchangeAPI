using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;
using MaterialsExchangeAPI.Domain.Entities;
using System.Data;

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

        var seller = Seller.Create(createSellerRequestDto.Name);
        var latestSeller =
            await _context.Sellers.OrderBy(l => l.Id).LastOrDefaultAsync(token);

        if (latestSeller is null)
        {
            seller.SetId(1);
        }
        else
        {
            seller.SetId(latestSeller.Id + 1);
        }

        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync(token);

        var createSellerResponseDto = seller.ToCreateSellerResponseDto();

        return createSellerResponseDto;
    }
}
