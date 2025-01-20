using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineShop.Extensions.MessageBus.Kafka.Options;
using static Confluent.Kafka.ConfigPropertyNames;

namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;
public class KafkaSendMessageBus : ISendMessageBus
{
    private readonly ILogger<KafkaSendMessageBus> _logger;
    private readonly string _topicName;
    private readonly IProducer<Null, string> _producer;

    public KafkaSendMessageBus(ILogger<KafkaSendMessageBus> logger, KafkaOptions kafkaOptions)
    {
        _logger = logger;
        _topicName = kafkaOptions.TopicName;
        var producerconfig = new ProducerConfig
        {
            BootstrapServers = kafkaOptions.Url,
        };
        _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
    }
    public async Task Publish<TInput>(TInput input, CancellationToken cancellationToken)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        string message = JsonConvert.SerializeObject(input);
        var kafkaMessage = new Message<Null, string> { Value = message, };
        
        await _producer.ProduceAsync(_topicName, kafkaMessage, cancellationToken);
    }
}
