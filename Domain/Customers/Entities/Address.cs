using Domain.Common;

namespace Domain.Customers.Entities;

public class Address : Entity<Guid>
{
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;

    private Address() { }

    public Address(Guid id, string country, string city, string street, string postalCode)
    {
        Id = id;
        Country = country;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public override string ToString() => $"{Street}, {City}, {Country} ({PostalCode})";
}