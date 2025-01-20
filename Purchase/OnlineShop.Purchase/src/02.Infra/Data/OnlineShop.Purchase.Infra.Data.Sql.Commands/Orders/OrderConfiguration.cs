using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Purchase.Core.Domain.Orders.Entities;
using OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

namespace OnlineShop.Purchase.Infra.Data.Sql.Commands.Orders;
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(order => order.Id);

        builder.Property(order => order.TotalPrice)
            .HasConversion(name => name.Amount, value => new Money(value));

        builder.Property<uint>("Version").IsRowVersion();
    }
}
