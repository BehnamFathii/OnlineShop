using OnlineShop.Purchase.Core.Domain.Orders.Enums;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Core.Domain.Orders.Parameters;
public record CreateOrderParameter(int Id,
                                   DateTime OrderDate,
                                   OrderStatus Status,
                                   Money TotalPrice);
