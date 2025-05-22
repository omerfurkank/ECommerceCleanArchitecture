using Domain.Common;

namespace Domain.Orders.ValueObjects;

public class ShippingAddress : ValueObject
{
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;

    private ShippingAddress() { }

    public ShippingAddress(string country, string city, string street, string postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
        yield return PostalCode;
    }

    public override string ToString() => $"{Street}, {City}, {Country} ({PostalCode})";
}
