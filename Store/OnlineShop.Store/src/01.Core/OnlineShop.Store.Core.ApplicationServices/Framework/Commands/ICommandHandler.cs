namespace OnlineShop.Store.Core.ApplicationServices.Framework.Commands;
public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}