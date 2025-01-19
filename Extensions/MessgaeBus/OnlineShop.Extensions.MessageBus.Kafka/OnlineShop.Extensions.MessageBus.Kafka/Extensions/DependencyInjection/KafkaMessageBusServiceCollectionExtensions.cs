using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Extensions.MessageBus.Kafka.Options;
using OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
using OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;

namespace OnlineShop.Extensions.MessageBus.Kafka.Extensions.DependencyInjection;
public static class KafkaMessageBusServiceCollectionExtensions
{
    public static IServiceCollection AddKafkaMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        KafkaOptions kafkaOptions = new();
        configuration.Bind(nameof(KafkaOptions), kafkaOptions);
        services.AddSingleton(kafkaOptions);

        services.AddScoped<ISendMessageBus, KafkaSendMessageBus>();

        services.AddSingleton<IReceiveMessageBus, KafkaReceiveMessageBus>();

        return services;
    }

}
