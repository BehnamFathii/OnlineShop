using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Store.Core.Domain.Products.Repositories;
using OnlineShop.Store.Infra.Data.Sql.Commands.Common;
using OnlineShop.Store.Infra.Data.Sql.Commands.Products;

namespace OnlineShop.Store.Infra.Data.Sql.Commands.Extensions;
public static class SqlCommandRegistrer
{
    public static IServiceCollection RegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
                    configuration.GetConnectionString("OnlineShopStoreCnn") ??
                    throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<OnlineShopStoreCommandDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
