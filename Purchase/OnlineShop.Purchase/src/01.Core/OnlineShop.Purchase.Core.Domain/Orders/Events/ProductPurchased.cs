using OnlineShop.Purchase.Core.Domain.Framework;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Core.Domain.Orders.Events;

public record ProductPurchased(long Id, double price, int Number) : IDomainEvent;
