using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Sellers.Commands.SynchronizeSellers;

public class SynchronizeSellersCommandHandler(
    IAppDbContext context,
    IMapper mapper)
    : BaseHandler(context, mapper), 
        IRequestHandler<SynchronizeSellersCommand>
{
    public async Task Handle(
        SynchronizeSellersCommand command,
        CancellationToken token)
    {
        var sellers = command.Dto.Sellers
            .Select(s => new Seller(s.Name))
            .ToList();
        
        Context.Sellers.AddRange(sellers);
        
        await Context.SaveChangesAsync(token);
    }
}
