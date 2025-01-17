namespace OnlineShop.Store.Core.Domain.Framework;
public interface IBaseRepository
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
