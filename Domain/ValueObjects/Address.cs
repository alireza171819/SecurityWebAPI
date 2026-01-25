using Domain.Exceptions;

namespace Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public string City { get; }
    public string Street { get; }
    public string PostalCode { get; }

    private Address() { }

    public Address(string city, string street, string postalCode)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new DomainException("City is required.");

        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return PostalCode;
    }
}
