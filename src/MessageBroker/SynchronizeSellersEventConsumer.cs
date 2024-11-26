using Application.Sellers.Commands.SynchronizeSellers;
using EventLibrary;
using MassTransit;
using MediatR;

namespace MessageBroker;

public class SynchronizeSellersEventConsumer(IMediator mediator)
    : IConsumer<SynchronizeSellersEvent>
{
    public async Task Consume(ConsumeContext<SynchronizeSellersEvent> context)
    {
        await mediator.Send(
            new SynchronizeSellersCommand(
                new SynchronizeSellersRequestDto
                {
                    Sellers = context.Message.Sellers
                }),
            context.CancellationToken);
    }
}