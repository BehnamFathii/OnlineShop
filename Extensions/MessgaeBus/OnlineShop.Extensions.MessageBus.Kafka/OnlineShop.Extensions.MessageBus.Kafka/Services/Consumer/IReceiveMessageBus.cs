namespace OnlineShop.Extensions.MessageBus.Kafka.Services.Consumer;

public interface IReceiveMessageBus
{
    TDomainEvent? ConsumeEvent<TDomainEvent>();
}