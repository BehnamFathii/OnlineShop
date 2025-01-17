using OnlineShop.Store.Core.ApplicationServices.Framework.Events;
using OnlineShop.Store.Core.Domain.Products.Entitties;
using OnlineShop.Store.Core.Domain.Products.Events;
using OnlineShop.Store.Core.Domain.Products.Repositories;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Store.Core.ApplicationServices.Products.Events;
public class ProductPurchasedDomainEventHandler : IDomainEventHandler<ProductPurchased>
{
    private readonly IProductRepository _repository;

    public ProductPurchasedDomainEventHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ProductPurchased @event, CancellationToken cancellationToken)
    {
        Product product = await _repository.GetByIdAsync(@event.Id, cancellationToken);

        if (product is null)
        {
            return;
        }

        product.Decreased(new Quantity(@event.Number));

        await _repository.CommitAsync(cancellationToken);
    }
}
