namespace OnlineShop.Store.Core.Domain.Products.ValueObjects;
public class IsActive
{
    public bool Value { get; private set; }

    private IsActive()
    {
    }

    public IsActive(bool value)
    {
        Value = value;
    }

    public static IsActive True()
    {
        return new IsActive(value: true);
    }

    public static IsActive False()
    {
        return new IsActive(value: false);
    }

    public static IsActive FromBoolean(bool value)
    {
        return new IsActive(value);
    }
    public override string ToString()
    {
        return Value.ToString();
    }

    public static implicit operator IsActive(bool value)
    {
        return new IsActive(value);
    }

    public static explicit operator bool(IsActive isActive)
    {
        return isActive.Value;
    }
}