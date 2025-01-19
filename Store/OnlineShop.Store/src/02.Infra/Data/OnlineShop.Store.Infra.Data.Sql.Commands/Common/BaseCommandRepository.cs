using OnlineShop.Store.Core.Domain.Framework;

namespace OnlineShop.Store.Infra.Data.Sql.Commands.Common;
internal abstract class BaseCommandRepository<TEntity, TId>(OnlineShopStoreCommandDbContext dbContext)
    where TEntity : AggregateRoot<TId>
{
    protected readonly OnlineShopStoreCommandDbContext DbContext = dbContext;


    public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity);
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => await DbContext.SaveChangesAsync(cancellationToken);

}