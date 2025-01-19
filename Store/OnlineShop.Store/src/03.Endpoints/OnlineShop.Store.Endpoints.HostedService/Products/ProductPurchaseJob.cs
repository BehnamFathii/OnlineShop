using OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
using OnlineShop.Store.Core.ApplicationServices.Framework.Events;
using OnlineShop.Store.Core.Domain.Products.Events;

namespace OnlineShop.Store.Endpoints.HostedService.Products;

public class ProductPurchaseJob : BackgroundService
{
    private readonly IReceiveMessageBus _receive;
    private readonly IEventDispatcher _dispatcher;

    public ProductPurchaseJob(IReceiveMessageBus receive, IEventDispatcher dispatcher)
    {
        _receive = receive;
        _dispatcher = dispatcher;
    }
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var @event = _receive.ConsumeEvent<ProductPurchased>();

            if (@event != null)
            {
                await _dispatcher.PublishDomainEventAsync(@event, cancellationToken);
            }

            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
        }

    }
}
