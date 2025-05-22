using Domain.Common;

namespace Domain.Products.ValueObjects;

public class SKU : ValueObject
{
    public string Value { get; private set; } = null!;

    private SKU() { } // EF için

    public SKU(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SKU boş olamaz.");

        if (value.Length is < 4 or > 20)
            throw new ArgumentException("SKU 4 ile 20 karakter arasında olmalıdır.");

        Value = value.ToUpperInvariant(); // SKU genellikle büyük harfle tutulur
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}