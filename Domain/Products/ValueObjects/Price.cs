using Domain.Common;

namespace Domain.Products.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = "TRY"; // Varsayılan TL

    private Price() { } // EF için

    public Price(decimal amount, string currency = "TRY")
    {
        if (amount < 0)
            throw new ArgumentException("Fiyat negatif olamaz.");

        Amount = amount;
        Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    public override string ToString() => $"{Amount} {Currency}";
}
