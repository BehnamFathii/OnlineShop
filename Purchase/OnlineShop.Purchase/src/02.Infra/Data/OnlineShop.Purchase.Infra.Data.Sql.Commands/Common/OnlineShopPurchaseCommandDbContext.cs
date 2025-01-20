using Microsoft.EntityFrameworkCore;
using OnlineShop.Purchase.Core.Domain.Orders.Entities;

namespace OnlineShop.Purchase.Infra.Data.Sql.Commands.Common;
internal class OnlineShopPurchaseCommandDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public OnlineShopPurchaseCommandDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineShopPurchaseCommandDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
