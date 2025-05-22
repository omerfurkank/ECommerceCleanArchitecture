using Domain.Common;

namespace Domain.Categories.ValueObjects;

public class CategoryName : ValueObject
{
    public string Value { get; private set; } = null!;

    private CategoryName() { } // EF için

    public CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Kategori adı boş olamaz.");

        if (value.Length > 100)
            throw new ArgumentException("Kategori adı 100 karakteri geçemez.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
