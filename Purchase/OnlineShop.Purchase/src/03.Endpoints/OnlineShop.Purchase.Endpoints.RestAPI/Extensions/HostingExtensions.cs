using OnlineShop.Extensions.MessageBus.Kafka.Extensions.DependencyInjection;
using OnlineShop.Purchase.Core.ApplicationServices.Extensions.DependencyInjection;
using OnlineShop.Purchase.Infra.Data.Sql.Commands.Extensions;
using Scalar.AspNetCore;

namespace OnlineShop.Purchase.Endpoints.RestAPI.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.RegisterApplicaitonService();
        builder.Services.RegisterDataAccessService(builder.Configuration);
        builder.Services.AddKafkaMessageBus(builder.Configuration);
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }
}
