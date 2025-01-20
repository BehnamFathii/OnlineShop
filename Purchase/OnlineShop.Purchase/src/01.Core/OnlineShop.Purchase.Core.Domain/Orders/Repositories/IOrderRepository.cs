using OnlineShop.Purchase.Core.Domain.Framework;
using OnlineShop.Purchase.Core.Domain.Orders.Entities;

namespace OnlineShop.Purchase.Core.Domain.Orders.Repositories;
public interface IOrderRepository : IBaseRepository
{
    Task<Order?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);
    Task Add(Order product, CancellationToken cancellationToken = default);
}
