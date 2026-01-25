using Domain.Exceptions;

namespace Domain.ValueObjects;

public class OrderNumber : ValueObject
{
    public string Value { get; }

    private OrderNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Order number is required.");

        Value = value;
    }

    public static OrderNumber Create(string value)
        => new(value);

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
