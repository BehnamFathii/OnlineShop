namespace OnlineShop.Store.Core.Domain.Framework;
public class BaseEntity<TId>
{
    protected BaseEntity(TId id)
    {
        Id = id;
    }
    protected BaseEntity()
    {

    }

    public TId Id { get; set; }
}
