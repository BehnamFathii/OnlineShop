using MediatR;
using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.ApplicationServices.Framework.Queries;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}