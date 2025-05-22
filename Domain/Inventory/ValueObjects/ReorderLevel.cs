using Domain.Common;

namespace Domain.Inventory.ValueObjects;

public class ReorderLevel : ValueObject
{
    public int Value { get; private set; }

    private ReorderLevel() { }

    public ReorderLevel(int value)
    {
        if (value < 0)
            throw new ArgumentException("Reorder seviyesi negatif olamaz.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => $"Reorder Level: {Value}";
}