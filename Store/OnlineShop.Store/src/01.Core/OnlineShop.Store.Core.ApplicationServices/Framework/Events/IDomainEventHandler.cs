using OnlineShop.Store.Core.Domain.Framework;

namespace OnlineShop.Store.Core.ApplicationServices.Framework.Events;
public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event, CancellationToken cancellationToken);
}
