using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Extensions.MessageBus.Kafka.Options;
using OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
using OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;

namespace OnlineShop.Extensions.MessageBus.Kafka.Extensions.DependencyInjection;
public static class KafkaMessageBusServiceCollectionExtensions
{
    public static IServiceCollection AddKafkaMessageBus(this IServiceCollection services, Action<KafkaOptions> configuration, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
    {
        services.Configure(configuration);
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<KafkaOptions>>();
            return options;
        });

        services.AddScoped<ISendMessageBus, KafkaSendMessageBus>();

        services.AddSingleton<IReceiveMessageBus, KafkaReceiveMessageBus>();

        return services;
    }

}
