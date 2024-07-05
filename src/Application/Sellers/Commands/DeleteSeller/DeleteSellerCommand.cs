using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
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

public class DeleteSellerCommandHandler : BaseHandler,
    IRequestHandler<DeleteSellerCommand, Boolean>
{
    public DeleteSellerCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<Boolean> Handle(
        DeleteSellerCommand command, CancellationToken token)
    {
        var deleteSellerRequestDto =
            _mapper.Map<DeleteSellerRequestDto>(command);
        var seller = await _context.Sellers.FirstOrDefaultAsync(
            u => u.Id == deleteSellerRequestDto.Id, token);

        if (seller is null)
        {
            return false;
        }

        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync(token);

        return true;
    }
}
