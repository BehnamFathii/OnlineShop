using OnlineShop.Purchase.Core.Domain.Orders.Entities;
using OnlineShop.Purchase.Core.Domain.Orders.Repositories;
using OnlineShop.Purchase.Infra.Data.Sql.Commands.Common;

namespace OnlineShop.Purchase.Infra.Data.Sql.Commands.Orders;
internal class OrderRepository : BaseCommandRepository<Order, long>, IOrderRepository
{
    public OrderRepository(OnlineShopPurchaseCommandDbContext dbContext) : base(dbContext)
    {
    }
}
