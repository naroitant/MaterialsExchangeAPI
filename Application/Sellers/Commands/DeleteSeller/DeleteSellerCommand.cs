using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;

/// <summary>
/// Команда удаления продавца
/// </summary>
public record DeleteSellerCommand : IRequest<DeleteSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id;
}

public class DeleteSellerCommandHandler
    : IRequestHandler<DeleteSellerCommand, DeleteSellerResponseDto?>
{
    private readonly IAppDbContext _context;

    public DeleteSellerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<DeleteSellerResponseDto?> Handle(
        DeleteSellerCommand command, CancellationToken token)
    {
        var seller = await _context.Sellers.FindAsync(
            new object?[] { command.Id }, cancellationToken: token);

        if (seller is null)
        {
            return null;
        }

        var deleteSellerResponseDto = seller.ToDeleteSellerResponseDto();

        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync(token);

        return deleteSellerResponseDto;
    }
}
