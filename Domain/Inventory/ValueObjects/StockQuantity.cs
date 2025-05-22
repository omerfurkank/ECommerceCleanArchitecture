using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inventory.ValueObjects;

public class StockQuantity : ValueObject
{
    public int Value { get; private set; }

    private StockQuantity() { }

    public StockQuantity(int value)
    {
        if (value < 0)
            throw new ArgumentException("Stok miktarı negatif olamaz.");

        Value = value;
    }

    public static StockQuantity operator +(StockQuantity current, int amount) => new(current.Value + amount);
    public static StockQuantity operator -(StockQuantity current, int amount)
    {
        if (amount > current.Value)
            throw new InvalidOperationException("Stok miktarı yetersiz.");
        return new StockQuantity(current.Value - amount);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
