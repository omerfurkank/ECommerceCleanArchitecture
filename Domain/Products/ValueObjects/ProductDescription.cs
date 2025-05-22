using Domain.Common;

namespace Domain.Products.ValueObjects;

public class ProductDescription : ValueObject
{
    public string Value { get; private set; } = null!;
    private ProductDescription() { } // EF için

    public ProductDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Açıklama boş olamaz.");
        if (value.Length > 1000)
            throw new ArgumentException("Açıklama 1000 karakteri geçemez.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}