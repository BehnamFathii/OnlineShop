﻿namespace OnlineShop.Purchase.Core.Domain.Orders.ValueObjects;

public record Quantity(int Number)
{
    public static Quantity operator +(Quantity first, Quantity second)
    {
        return new Quantity(first.Number + second.Number);
    }

    public static Quantity operator -(Quantity first, Quantity second)
    {
        return new Quantity(first.Number - second.Number);
    }

    public static int Zero => 0;
    public bool IsZero() => Number == Zero;
    public static Quantity FromInt(int number) => new(number);

}
