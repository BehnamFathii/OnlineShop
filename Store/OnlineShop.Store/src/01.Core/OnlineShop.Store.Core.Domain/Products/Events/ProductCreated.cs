using OnlineShop.Store.Core.Domain.Framework;

namespace OnlineShop.Store.Core.Domain.Products.Events;
public record ProductCreated(long id) : IDomainEvent;
