using FluentValidation;

namespace OnlineShop.Purchase.Core.ApplicationServices.Orders.Commands;
internal class PurchaseCommandValidator : AbstractValidator<PurchaseCommand>
{
    public PurchaseCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();

        RuleFor(c => c.Quantity).GreaterThan(0);
    }
}