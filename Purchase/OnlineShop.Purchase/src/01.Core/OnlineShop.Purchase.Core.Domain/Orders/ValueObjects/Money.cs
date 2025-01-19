namespace OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

public record Money(double Amount)
{
    public static Money operator +(Money first, Money second)
    {
        return new Money(first.Amount + second.Amount);
    }
    public static Money FromDouble(double amount)=>new(amount);
    public static int Zero => 0;
    public bool IsZero() => Amount == Zero;
}
