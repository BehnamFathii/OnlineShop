namespace OnlineShop.Store.Core.ApplicationServices.Framework;
public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}
