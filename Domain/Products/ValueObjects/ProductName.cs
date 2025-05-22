using Domain.Common;

namespace Domain.Products.ValueObjects;

public class ProductName : ValueObject
{
    public string Value { get; private set; } = null!;

    private ProductName() { } // EF için

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Ürün adı boş olamaz.");

        if (value.Length > 100)
            throw new ArgumentException("Ürün adı 100 karakterden uzun olamaz.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
