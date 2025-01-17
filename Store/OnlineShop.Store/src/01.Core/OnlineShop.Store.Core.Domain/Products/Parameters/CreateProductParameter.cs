using OnlineShop.Store.Core.Domain.Products.Enums;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Store.Core.Domain.Products.Parameters;

public record CreateProductParameter(int id,
                                     Title title,
                                     int amount,
                                     ProductType type);
