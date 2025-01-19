using Microsoft.EntityFrameworkCore;
using OnlineShop.Store.Core.Domain.Products.Entitties;

namespace OnlineShop.Store.Infra.Data.Sql.Commands.Common;
internal class OnlineShopStoreCommandDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public OnlineShopStoreCommandDbContext(DbContextOptions options) : base(options)
    {
    }
}
