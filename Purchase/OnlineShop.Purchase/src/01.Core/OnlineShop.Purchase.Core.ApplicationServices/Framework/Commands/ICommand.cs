using MediatR;
using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.ApplicationServices.Framework.Commands;
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}