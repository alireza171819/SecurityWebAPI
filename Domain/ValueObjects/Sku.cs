
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Sku : ValueObject
{
    public string Value { get; }

    private Sku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Sku is required.");

        Value = value;
    }

    public static Sku Create(string value)
        => new(value);

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
