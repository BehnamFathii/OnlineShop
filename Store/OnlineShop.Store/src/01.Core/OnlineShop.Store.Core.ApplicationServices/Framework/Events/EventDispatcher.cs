using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OnlineShop.Store.Core.ApplicationServices.Framework.Events;
public class EventDispatcher : IEventDispatcher
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(ILogger logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
    {
        int counter = 0;
        try
        {
            _logger.LogDebug("Routing event of type {EventType} With value {Event}  Start at {StartDateTime}", @event.GetType(), @event, DateTime.Now);
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();
            List<Task> tasks = new List<Task>();
            foreach (var handler in handlers)
            {
                counter++;
                tasks.Add(handler.Handle(@event));
            }
            await Task.WhenAll(tasks);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "There is not suitable handler for {EventType} Routing failed at {StartDateTime}.", @event.GetType(), DateTime.Now);
            throw;
        }
    }
}
