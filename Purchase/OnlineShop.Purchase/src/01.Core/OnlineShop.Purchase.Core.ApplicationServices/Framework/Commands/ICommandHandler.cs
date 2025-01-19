using MediatR;
using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.ApplicationServices.Framework.Commands;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}