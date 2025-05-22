using Domain.Common;

namespace Domain.Customers.ValueObjects;

public class PaymentMethod : ValueObject
{
    public string CardHolderName { get; private set; } = null!;
    public string CardNumber { get; private set; } = null!;
    public string Expiry { get; private set; } = null!; // örn: 12/26

    private PaymentMethod() { }

    public PaymentMethod(string cardHolderName, string cardNumber, string expiry)
    {
        CardHolderName = string.IsNullOrWhiteSpace(cardHolderName)
            ? throw new ArgumentException("Kart sahibi adı boş olamaz")
            : cardHolderName;

        CardNumber = string.IsNullOrWhiteSpace(cardNumber)
            ? throw new ArgumentException("Kart numarası boş olamaz")
            : cardNumber;

        Expiry = string.IsNullOrWhiteSpace(expiry)
            ? throw new ArgumentException("Son kullanma tarihi boş olamaz")
            : expiry;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CardHolderName;
        yield return CardNumber;
        yield return Expiry;
    }
}