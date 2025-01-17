namespace OnlineShop.Extensions.MessageBus.Kafka.Options;
public class KafkaOptions
{
    public string Url { get; set; }
    public string GroupId { get; set; }
    public string TopicName { get; set; }
}
