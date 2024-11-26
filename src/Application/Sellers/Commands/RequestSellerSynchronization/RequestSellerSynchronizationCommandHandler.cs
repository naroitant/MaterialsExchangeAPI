using Application.Common;
using Application.Common.Interfaces;
using Application.Sellers.Commands.SynchronizeSellers;
using AutoMapper;
using EventLibrary;
using MassTransit;

namespace Application.Sellers.Commands.RequestSellerSynchronization;

public class RequestSellerSynchronizationCommandHandler(
    IAppDbContext context,
    IMapper mapper,
    IPublishEndpoint publishEndpoint)
    : BaseHandler(context, mapper), 
        IRequestHandler<RequestSellerSynchronizationCommand>
{
    public async Task Handle(
        RequestSellerSynchronizationCommand command,
        CancellationToken token)
    {
        await publishEndpoint.Publish(new NeedSynchronizationEvent(), token);
        
        await Context.SaveChangesAsync(token);
    }
}
