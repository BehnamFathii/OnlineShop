namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;

public interface IProducerService
{
    Task ProduceAsync(string topic, string message);
}