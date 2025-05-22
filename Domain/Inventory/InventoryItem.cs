using Domain.Common;
using Domain.Inventory.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inventory;

public class InventoryItem : Aggregate<Guid>
{
    public Guid ProductId { get; private set; }
    public StockQuantity Quantity { get; private set; } = null!;
    public ReorderLevel ReorderLevel { get; private set; } = null!;

    private InventoryItem() { }

    private InventoryItem(Guid id, Guid productId, StockQuantity quantity, ReorderLevel reorderLevel)
        : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        ReorderLevel = reorderLevel;
    }

    public static InventoryItem Create(Guid productId, int initialStock, int reorderLevel)
    {
        return new InventoryItem(
            Guid.NewGuid(),
            productId,
            new StockQuantity(initialStock),
            new ReorderLevel(reorderLevel));
    }

    public void IncreaseStock(int amount)
    {
        Quantity = Quantity + amount;
    }

    public void DecreaseStock(int amount)
    {
        Quantity = Quantity - amount;
    }

    public bool IsBelowReorderLevel() => Quantity.Value < ReorderLevel.Value;
}
