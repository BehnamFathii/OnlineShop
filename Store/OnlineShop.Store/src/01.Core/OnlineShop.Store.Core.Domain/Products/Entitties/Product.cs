using OnlineShop.Store.Core.Domain.Framework;
using OnlineShop.Store.Core.Domain.Products.Enums;
using OnlineShop.Store.Core.Domain.Products.Parameters;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Store.Core.Domain.Products.Entitties;
public class Product :AggregateRoot<long>
{
    public Product(CreateProductParameter parameter)
    {
            
    }
    private Product()
    {
        
    }
    public Title Title { get; private set; }
    public int Amount { get; private set; }
    public ProductType Type { get; private set; }
    public IsActive IsActive { get; private set; }

    public static Product Create(CreateProductParameter parameter)
    {
        var product = new Product(parameter);
        product.AddDomainEvent(new HomeCreated(home.Id));
       // return home;
    }

}
