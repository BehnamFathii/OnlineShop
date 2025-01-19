using OnlineShop.Purchase.Core.ApplicationServices.Framework.Commands;

namespace OnlineShop.Purchase.Core.ApplicationServices.Orders.Commands;
public record PurchaseCommand(
    long ProductId,
    int Quantity) : ICommand<long>;