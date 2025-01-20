using Microsoft.Extensions.Logging;
using OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;
using OnlineShop.Purchase.Core.ApplicationServices.Framework.Commands;
using OnlineShop.Purchase.Core.Domain.Framework;
using OnlineShop.Purchase.Core.Domain.Orders.Entities;
using OnlineShop.Purchase.Core.Domain.Orders.Events;
using OnlineShop.Purchase.Core.Domain.Orders.Repositories;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Core.ApplicationServices.Orders.Commands;
public sealed class PurchaseCommandHandler : ICommandHandler<PurchaseCommand, long>
{
    private readonly ILogger _logger;
    private readonly IOrderRepository _repository;
    private readonly ISendMessageBus _messageBus;

    public PurchaseCommandHandler(ILogger logger, IOrderRepository repository, ISendMessageBus messageBus)
    {
        _logger = logger;
        _repository = repository;
        _messageBus = messageBus;
    }

    public async Task<Result<long>> Handle(PurchaseCommand request, CancellationToken cancellationToken)
    {
        Order order = Order.Create(DateTime.Now);
        order.AddItem(request.ProductId, Money.FromDouble(request.price), Quantity.FromInt(request.Quantity));
        order.FinalizeOrder();
        await _repository.CommitAsync();
        await _messageBus.Publish(order.Events().FirstOrDefault(c=>c.GetType().Name.Equals("ProductPurchased")), cancellationToken); //.ها در آن قسمت مدیریت خواهد شد و نباید در این قسمت انجام شود ولی با توجه به کمبود زمان و فقط پیاده سازی اولیه پروژه موقتا در این قسمت انجام شد Event ارسال OutBox در صورت پیاده سازی الگو 
        return order.Id;
    }
}
