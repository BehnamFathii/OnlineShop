namespace OnlineShop.Purchase.Core.Domain.Framework;
public interface IBaseRepository
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
