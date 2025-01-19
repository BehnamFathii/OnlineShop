using OnlineShop.Purchase.Core.Domain.Framework;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Core.Domain.Orders.Entities;
public class OrderLine : BaseEntity<long>
{
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public Quantity Number { get; private set; }
    public Money Price { get; private set; }



    private OrderLine()
    {

    }

    public OrderLine(long productId)
    {
        ProductId = productId;
    }
}
