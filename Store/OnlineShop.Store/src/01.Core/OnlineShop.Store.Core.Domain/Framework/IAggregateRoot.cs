namespace OnlineShop.Store.Core.Domain.Framework;
public interface IAggregateRoot
{
    void ClearDomainEvents();
    IReadOnlyList<IDomainEvent> Events();
}