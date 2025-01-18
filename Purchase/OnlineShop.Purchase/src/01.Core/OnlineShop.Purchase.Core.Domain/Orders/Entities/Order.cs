using OnlineShop.Purchase.Core.Domain.Framework;
using OnlineShop.Purchase.Core.Domain.Framework.Exceptions;
using OnlineShop.Purchase.Core.Domain.Orders.Enums;
using OnlineShop.Purchase.Core.Domain.Orders.Events;
using OnlineShop.Purchase.Core.Domain.Orders.Parameters;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Core.Domain.Orders.Entities;
public class Order : AggregateRoot<long>
{
    public Order(CreateOrderParameter parameter)
    {
        OrderDate = parameter.OrderDate;
        Status = parameter.Status;
        TotalPrice = parameter.TotalPrice;
    }
    private Order()
    {

    }
    private List<OrderLine> _orderLines = new();

    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public Money TotalPrice { get; private set; }

    public IReadOnlyList<OrderLine> OrderLines => _orderLines;


    public static Order Create(CreateOrderParameter parameter)
    {
        var order = new Order(parameter);
        order.AddDomainEvent(new OrderCreated(order.Id));
        return order;
    }

    public void AddItem(long productId)
    {
        if (_orderLines.Any(c => c.ProductId == productId))
        {
            throw new InvalidEntityStateException("سفارش تکراری");
        }

        var orderLine = new OrderLine(productId);
        _orderLines.Add(orderLine);

        AddDomainEvent(new OrderLineAdded(Id, orderLine.Id));
    }


    public void DeleteItem(long productId)
    {
        var orderLine = _orderLines.FirstOrDefault(c => c.ProductId == productId);
        if (orderLine is null)
        {
            throw new InvalidEntityStateException("سفارش وجود ندارد");
        }

        _orderLines.Remove(orderLine);

        if (!_orderLines.Any())
        {
            Status = OrderStatus.New;
            TotalPrice = Money.FromInt(0);
            AddDomainEvent(new OrderWasEmpty(Id));
        }

        AddDomainEvent(new OrderLineDeleted(Id, orderLine.Id));
    }


    public void FinalizeOrder()
    {
        if (Status == OrderStatus.Closed)
        {
            throw new InvalidEntityStateException("سفارش قبلا نهایی شده است");
        }
        Status = OrderStatus.Closed;

        AddDomainEvent(new OrderClosed(Id));
    }
}