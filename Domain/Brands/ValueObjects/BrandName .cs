using Domain.Common;


namespace Domain.Brands.ValueObjects;

public class BrandName : ValueObject
{
    public string Value { get; private set; } = null!;

    private BrandName() { }

    public BrandName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Marka adı boş olamaz.");

        if (value.Length > 100)
            throw new ArgumentException("Marka adı 100 karakteri geçemez.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
