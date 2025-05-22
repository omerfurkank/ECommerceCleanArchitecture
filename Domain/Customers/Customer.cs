using Domain.Common;
using Domain.Customers.Entities;
using Domain.Customers.ValueObjects;

namespace Domain.Customers;

public class Customer : Aggregate<Guid>
{
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    public Guid? DefaultAddressId { get; private set; }

    public PaymentMethod? DefaultPaymentMethod { get; private set; }

    private Customer() { }

    private Customer(Guid id, string fullName, string email)
        : base(id)
    {
        FullName = fullName;
        Email = email;
    }

    public static Customer Create(string fullName, string email)
    {
        return new Customer(Guid.NewGuid(), fullName, email);
    }

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
        if (_addresses.Count == 1)
            DefaultAddressId = address.Id;
    }

    public void RemoveAddress(Guid addressId)
    {
        var address = _addresses.FirstOrDefault(a => a.Id == addressId);
        if (address is not null)
        {
            _addresses.Remove(address);
            if (DefaultAddressId == address.Id)
                DefaultAddressId = _addresses.FirstOrDefault()?.Id;
        }
    }

    public void SetDefaultAddress(Guid addressId)
    {
        if (_addresses.Any(a => a.Id == addressId))
            DefaultAddressId = addressId;
    }

    public void UpdatePaymentMethod(PaymentMethod newPayment)
    {
        DefaultPaymentMethod = newPayment;
    }
}
