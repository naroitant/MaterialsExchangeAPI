using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

/// <summary>
/// Команда обновления продавца
/// </summary>
public record UpdateSellerCommand : IRequest<UpdateSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id;

    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name = string.Empty;
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

        var seller = await _context.Sellers.FindAsync(
            new object?[] { updateSellerRequestDto.Id }, cancellationToken: token);

        if (seller is null)
        {
            return null;
        }

        seller.Update(updateSellerRequestDto.Name);
        await _context.SaveChangesAsync(token);

        var updateSellerResponseDto = seller.ToUpdateSellerResponseDto();

        return updateSellerResponseDto;
    }
}
