using Domain.Common;

namespace Domain.Payments.ValueObjects;

public class PaymentMethod : ValueObject
{
    public string CardHolderName { get; private set; } = null!;
    public string Last4Digits { get; private set; } = null!;
    public string Expiry { get; private set; } = null!;

    private PaymentMethod() { }

    public PaymentMethod(string cardHolderName, string cardNumber, string expiry)
    {
        if (cardNumber.Length < 4)
            throw new ArgumentException("Kart numarası geçersiz.");

        CardHolderName = cardHolderName;
        Last4Digits = cardNumber[^4..]; // Son 4 rakam
        Expiry = expiry;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CardHolderName;
        yield return Last4Digits;
        yield return Expiry;
    }
}
