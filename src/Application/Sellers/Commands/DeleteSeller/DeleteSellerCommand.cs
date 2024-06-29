using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;

/// <summary>
/// Команда удаления продавца
/// </summary>
public record DeleteSellerCommand : IRequest<Boolean>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id;
}

public class DeleteSellerCommandHandler
    : IRequestHandler<DeleteSellerCommand, Boolean>
{
    private readonly IAppDbContext _context;

    public DeleteSellerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Boolean> Handle(
        DeleteSellerCommand command, CancellationToken token)
    {
        var seller = await _context.Sellers.FindAsync(
            new object?[] { command.Id }, cancellationToken: token);

        if (seller is null)
        {
            return false;
        }

        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync(token);

        return true;
    }
}
