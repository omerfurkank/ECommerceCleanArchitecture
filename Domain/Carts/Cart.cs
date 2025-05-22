using Domain.Carts.Entities;
using Domain.Common;


namespace Domain.Carts;

public class Cart : Aggregate<Guid>
{
    public Guid CustomerId { get; private set; }

    private readonly List<CartItem> _items = new();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    private Cart() { }

    private Cart(Guid id, Guid customerId) : base(id)
    {
        CustomerId = customerId;
    }

    public static Cart Create(Guid customerId)
    {
        return new Cart(Guid.NewGuid(), customerId);
    }

    public void AddItem(Guid productId, int quantity)
    {
        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            var newItem = new CartItem(Guid.NewGuid(), productId, quantity);
            _items.Add(newItem);
        }
    }

    public void UpdateItemQuantity(Guid productId, int newQty)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item is not null)
        {
            item.UpdateQuantity(newQty);
        }
    }

    public void RemoveItem(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item is not null)
            _items.Remove(item);
    }

    public void ClearCart()
    {
        _items.Clear();
    }
}