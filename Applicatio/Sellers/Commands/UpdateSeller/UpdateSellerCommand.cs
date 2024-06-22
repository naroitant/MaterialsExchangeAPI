using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

/// <summary>
/// Команда обновления продавца
/// </summary>
public class UpdateSellerCommand : IRequest<UpdateSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Имя продавца
    /// </summary>
    public required string Name { get; set; }
}

public class UpdateSellerCommandHandler 
    : IRequestHandler<UpdateSellerCommand, UpdateSellerResponseDto?>
{
    private readonly IAppDbContext _context;

    public UpdateSellerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateSellerResponseDto?> Handle(
        UpdateSellerCommand command, CancellationToken token)
    {
        var updateSellerRequestDto = new UpdateSellerRequestDto()
        {
            Id = command.Id,
            Name = command.Name,
        };

        var seller = 
            await _context.Sellers.FindAsync(updateSellerRequestDto.Id);

        if (seller == null)
        {
            return null;
        }

        seller.Name = updateSellerRequestDto.Name;

        await _context.SaveChangesAsync(token);

        var updateSellerResponseDto = seller.ToUpdateSellerResponseDto();

        return updateSellerResponseDto;
    }
}
