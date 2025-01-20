using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Store.Core.Domain.Products.Entitties;
using OnlineShop.Store.Core.Domain.Products.ValueObjects;

namespace OnlineShop.Purchase.Infra.Data.Sql.Commands.Orders;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Price)
            .HasConversion(name => name.Amount, value => new Money(value));

        builder.Property<uint>("Version").IsRowVersion();
    }
}
