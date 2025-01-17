using OnlineShop.Store.Core.Domain.Products.Enums;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Store.Core.Domain.Products.Parameters;

public record UpdateProductParameter(int Id,
                                     Title Title,
                                     Quantity Number,
                                      Money Price,
                                      ProductType Type);
