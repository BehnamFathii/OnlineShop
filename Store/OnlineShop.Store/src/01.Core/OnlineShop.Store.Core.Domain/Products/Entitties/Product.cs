using OnlineShop.Store.Core.Domain.Framework;
using OnlineShop.Store.Core.Domain.Products.Enums;
using OnlineShop.Store.Core.Domain.Products.Events;
using OnlineShop.Store.Core.Domain.Products.Parameters;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Store.Core.Domain.Products.Entitties;
public class Product : AggregateRoot<long>
{
    public Product(CreateProductParameter parameter)
    {
        Title = parameter.Title;
        Number = parameter.Number;
        Price = parameter.Price;
        Type = parameter.Type;
        IsActive = true;
    }
    private Product()
    {

    }

    public Title Title { get; private set; }
    public Money Price { get; private set; }
    public Quantity Number { get; private set; }
    public ProductType Type { get; private set; }
    public IsActive IsActive { get; private set; }

    public static Product Create(CreateProductParameter parameter)
    {
        var product = new Product(parameter);
        product.AddDomainEvent(new ProductCreated(product.Id));
        return product;
    }

    public void Update(UpdateProductParameter parameter)
    {
        Title = parameter.Title;
        Number = parameter.Number;
        Type = parameter.Type;
        Price = parameter.Price;
        AddDomainEvent(new HomeUpdated(Id, Title.Value, Price.Amount, Type));
    }


    public void Active()
    {
        if (!IsActive.Value)
        {
            IsActive = IsActive.True();

            AddDomainEvent(new ProductActived(Id));
        }
    }


    public void Deactive()
    {
        if (IsActive.Value)
        {
            IsActive = IsActive.False();

            AddDomainEvent(new ProductDeactived(Id));
        }
    }

    public void Decreased(Quantity numberOfDecrease)
    {
        if (!Number.IsZero())
        {

            Number = Number - numberOfDecrease;

            AddDomainEvent(new ProductDecreased(Id, numberOfDecrease.Number));
        }
    }


}
