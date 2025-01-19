using OnlineShop.Extensions.MessageBus.Kafka.Extensions.DependencyInjection;
using OnlineShop.Store.Core.ApplicationServices.Extensions.DependencyInjection;
using OnlineShop.Store.Endpoints.HostedService.Products;
using OnlineShop.Store.Infra.Data.Sql.Commands.Extensions;

namespace OnlineShop.Store.Endpoints.HostedService.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.RegisterApplicaitonService();
        builder.Services.RegisterDataAccessService(builder.Configuration);
        builder.Services.AddKafkaMessageBus(builder.Configuration);
        builder.Services.AddHostedService<ProductPurchaseJob>();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        return app;
    }
}
