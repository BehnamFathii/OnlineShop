using OnlineShop.Store.Core.Domain.Framework;
using OnlineShop.Store.Core.Domain.Products.Entitties;

namespace OnlineShop.Store.Core.Domain.Products.Repositories;
public interface IProductRepository: IBaseRepository
{
    Task<Product?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);

    Task Add(Product product, CancellationToken cancellationToken = default);
}
