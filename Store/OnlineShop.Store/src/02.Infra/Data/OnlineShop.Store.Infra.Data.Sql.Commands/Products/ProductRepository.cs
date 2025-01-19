using OnlineShop.Store.Core.Domain.Products.Entitties;
using OnlineShop.Store.Core.Domain.Products.Repositories;
using OnlineShop.Store.Infra.Data.Sql.Commands.Common;

namespace OnlineShop.Store.Infra.Data.Sql.Commands.Products;
internal class ProductRepository : BaseCommandRepository<Product, long>, IProductRepository
{
    public ProductRepository(OnlineShopStoreCommandDbContext dbContext) : base(dbContext)
    {
    }
}
