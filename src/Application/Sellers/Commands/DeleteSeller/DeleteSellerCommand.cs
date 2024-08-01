using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Sellers.Commands.DeleteSeller;

/// <summary>
/// Команда удаления продавца
/// </summary>
public record DeleteSellerCommand : IRequest<bool>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public Guid Id { get; init; }
}

public class DeleteSellerCommandHandler : BaseHandler,
    IRequestHandler<DeleteSellerCommand, bool>
{
    public DeleteSellerCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<bool> Handle(
        DeleteSellerCommand command, CancellationToken token)
    {
        var deleteSellerRequestDto =
            Mapper.Map<DeleteSellerRequestDto>(command);
        var seller = await Context.Sellers.FirstOrDefaultAsync(
            u => u.Id == deleteSellerRequestDto.Id, token);

        if (seller is null)
        {
            return false;
        }

        Context.Sellers.Remove(seller);
        await Context.SaveChangesAsync(token);

        return true;
    }
}
