using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.Domain.Orders.Entities;
public class OrderLine : BaseEntity<long>
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }


    private OrderLine()
    {

    }

    public OrderLine(long productId)
    {
        ProductId = productId;
    }
}
