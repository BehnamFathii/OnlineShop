using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineShop.Store.Core.ApplicationServices.Framework.Commands;
using OnlineShop.Store.Core.ApplicationServices.Framework.Events;
using OnlineShop.Store.Core.ApplicationServices.Products.Commands;
using OnlineShop.Store.Core.ApplicationServices.Products.Events;
using OnlineShop.Store.Core.Domain.Products.Events;

namespace OnlineShop.Store.Core.ApplicationServices.Extensions.DependencyInjection;
public static class ApplicationRegistrer
{
    public static IServiceCollection RegisterApplicaitonService(this IServiceCollection services)
    {
        services.AddTransient(provider =>
        {
            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            const string categoryName = "Log";
            return loggerFactory.CreateLogger(categoryName);
        });
        services.AddSingleton(typeof(ICommandHandler<CreateProductCommand, long>) ,new  CreateProductCommandHandler());
        services.AddSingleton<IEventDispatcher, EventDispatcher>();
        services.AddScoped< IDomainEventHandler<ProductPurchased>,ProductPurchasedDomainEventHandler>();

        return services;
    }
}
