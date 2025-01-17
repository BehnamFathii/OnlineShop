namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Producer;

public interface ISendMessageBus
{
    Task Publish<TInput>(TInput input, CancellationToken cancellationToken);
}