using OnlineShop.Store.Core.Domain.Framework;
using OnlineShop.Store.Core.Domain.Products.Enums;

namespace OnlineShop.Store.Core.Domain.Products.Events;

public record HomeUpdated(long Id,string Title,double Price, ProductType Type) : IDomainEvent;