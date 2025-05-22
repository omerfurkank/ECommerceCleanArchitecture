using Domain.Common;

namespace Domain.Promotions.ValueObjects;

public class Discount : ValueObject
{
    public decimal Amount { get; private set; }
    public bool IsPercentage { get; private set; }

    private Discount() { }

    public Discount(decimal amount, bool isPercentage)
    {
        if (amount <= 0)
            throw new ArgumentException("İndirim değeri sıfırdan büyük olmalıdır.");

        if (isPercentage && amount > 100)
            throw new ArgumentException("Yüzdelik indirim 100'ü geçemez.");

        Amount = amount;
        IsPercentage = isPercentage;
    }

    public override string ToString()
        => IsPercentage ? $"%{Amount}" : $"{Amount} ₺";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return IsPercentage;
    }
}
