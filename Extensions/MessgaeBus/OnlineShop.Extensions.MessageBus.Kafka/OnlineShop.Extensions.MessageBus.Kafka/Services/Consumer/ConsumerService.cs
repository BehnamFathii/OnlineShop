using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
public class ConsumerService<TDomainEvent>
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly ILogger<ConsumerService<TDomainEvent>> _logger;

    public ConsumerService(ILogger<ConsumerService<TDomainEvent>> logger, IConfiguration configuration)
    {
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = "OnlineShopGroup1",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        _logger = logger;
    }

    public void Subscribe()
        => _consumer.Subscribe("Test");


    public TDomainEvent? ProcessKafkaMessage(CancellationToken cancellationToken)
    {
        TDomainEvent? result = default;
        try
        {
            var consumeResult = _consumer.Consume(cancellationToken);

            var message = consumeResult.Message.Value;
            if (message != null)
            {
                result = JsonConvert.DeserializeObject<TDomainEvent>(message);
            }
            _logger.LogInformation($"Received inventory update: {message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing Kafka message: {ex.Message}");
        }
        return result;
    }
}