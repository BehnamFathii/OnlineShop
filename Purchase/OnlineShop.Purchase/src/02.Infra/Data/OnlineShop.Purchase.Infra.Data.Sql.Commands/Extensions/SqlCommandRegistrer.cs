using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Purchase.Core.Domain.Orders.Repositories;
using OnlineShop.Purchase.Infra.Data.Sql.Commands.Common;
using OnlineShop.Purchase.Infra.Data.Sql.Commands.Orders;

namespace OnlineShop.Purchase.Infra.Data.Sql.Commands.Extensions;
public static class SqlCommandRegistrer
{
    public static IServiceCollection RegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
                    configuration.GetConnectionString("OnlineShopPurchaseCnn") ??
                    throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<OnlineShopPurchaseCommandDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
