using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineShop.Purchase.Core.ApplicationServices.Extensions.Behaviors.Logging;
using OnlineShop.Purchase.Core.ApplicationServices.Extensions.Behaviors.Validations;

namespace OnlineShop.Purchase.Core.ApplicationServices.Extensions.DependencyInjection;
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
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblyContaining(typeof(ApplicationRegistrer));
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrer).Assembly);

        return services;
    }
}
