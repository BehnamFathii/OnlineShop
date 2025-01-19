using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineShop.Extensions.MessageBus.Kafka.Options;

namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;
public class KafkaReceiveMessageBus : IReceiveMessageBus
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly ILogger<KafkaReceiveMessageBus> _logger;

    public KafkaReceiveMessageBus(ILogger<KafkaReceiveMessageBus> logger, KafkaOptions kafkaOptions)
    {
        _logger = logger;
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = kafkaOptions.Url,
            GroupId = kafkaOptions.GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        _consumer.Subscribe(kafkaOptions.TopicName);
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
                _logger.LogInformation($"Message of type {typeof(TDomainEvent).Name} Received : {message}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing Kafka message: {ex.Message}");
        }
        return result;
    }
}