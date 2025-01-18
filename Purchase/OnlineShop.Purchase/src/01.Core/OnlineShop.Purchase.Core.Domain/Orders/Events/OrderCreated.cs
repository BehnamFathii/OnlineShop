using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.Domain.Orders.Events;
public record OrderCreated(long Id) : IDomainEvent;
