namespace OnlineShop.Purchase.Core.Domain.Framework;
public interface IAggregateRoot
{
    void ClearDomainEvents();
    IReadOnlyList<IDomainEvent> Events();
}