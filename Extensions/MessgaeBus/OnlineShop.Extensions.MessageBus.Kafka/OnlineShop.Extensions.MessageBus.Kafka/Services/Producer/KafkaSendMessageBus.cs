using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineShop.Extensions.MessageBus.Kafka.Options;

namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;
public class KafkaSendMessageBus : ISendMessageBus
{
    private readonly ILogger<KafkaSendMessageBus> _logger;
    private readonly KafkaOptions _kafkaOptions;
    private readonly IProducer<Null, string> _producer;

    public KafkaSendMessageBus(ILogger<KafkaSendMessageBus> logger, IOptions<KafkaOptions> kafkaOptions)
    {
        _logger = logger;
        _kafkaOptions = kafkaOptions.Value;
        var producerconfig = new ProducerConfig
        {
            BootstrapServers = _kafkaOptions.Url
        };
        _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
    }
    public async Task Publish<TInput>(TInput input, CancellationToken cancellationToken)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        string message = JsonConvert.SerializeObject(input);
        var kafkaMessage = new Message<Null, string> { Value = message, };

        await _producer.ProduceAsync(_kafkaOptions.TopicName, kafkaMessage, cancellationToken);
    }
}
