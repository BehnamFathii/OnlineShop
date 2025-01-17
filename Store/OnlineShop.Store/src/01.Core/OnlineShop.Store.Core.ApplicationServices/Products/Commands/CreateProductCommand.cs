using OnlineShop.Store.Core.ApplicationServices.Framework.Commands;
using OnlineShop.Store.Core.Domain.Products.Enums;

namespace OnlineShop.Store.Core.ApplicationServices.Products.Commands;
public record CreateProductCommand(
    string Title,
    int Quantity,
    ProductType Type) : ICommand<long>;