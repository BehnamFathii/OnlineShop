using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineShop.Extensions.MessageBus.Kafka.Options;

namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
public class KafkaReceiveMessageBus : IReceiveMessageBus
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly KafkaOptions _kafkaOptions;
    private readonly ILogger<KafkaReceiveMessageBus> _logger;

    public KafkaReceiveMessageBus(ILogger<KafkaReceiveMessageBus> logger, IOptions<KafkaOptions> kafkaOptions)
    {
        _logger = logger;
        _kafkaOptions = kafkaOptions.Value;
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = _kafkaOptions.Url,
            GroupId = _kafkaOptions.GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        _consumer.Subscribe(_kafkaOptions.TopicName);
    }

    public TDomainEvent? ConsumeEvent<TDomainEvent>()
    {
        TDomainEvent? result = default;
        try
        {
            var consumeResult = _consumer.Consume();

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