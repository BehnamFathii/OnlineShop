using OnlineShop.Store.Core.Domain.Framework;
using System.Threading;

namespace OnlineShop.Store.Core.ApplicationServices.Framework.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event, CancellationToken cancellationToken) where TDomainEvent : class, IDomainEvent;
}
