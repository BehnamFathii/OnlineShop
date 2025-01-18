using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.Domain.Orders.Events;

public record OrderClosed(long Id) : IDomainEvent;
