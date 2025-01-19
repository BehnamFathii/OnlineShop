using MediatR;
using OnlineShop.Purchase.Core.Domain.Framework;

namespace OnlineShop.Purchase.Core.ApplicationServices.Framework.Queries;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}