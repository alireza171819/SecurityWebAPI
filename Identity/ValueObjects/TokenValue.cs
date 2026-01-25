
namespace Identity.ValueObjects;

/// <summary>
/// Represents a token value in the domain.
/// Immutable and equality is based on value.
/// </summary>
public class TokenValue 
{
    public string Value { get; private set; }

    private TokenValue() { } // Required by EF Core

    public TokenValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Token value cannot be empty.");

        Value = value;
    }

    public override bool Equals(object? obj)
        => obj is TokenValue other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(TokenValue? a, TokenValue? b)
        => a?.Equals(b) ?? b is null;

    public static bool operator !=(TokenValue? a, TokenValue? b)
        => !(a == b);

    protected IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
