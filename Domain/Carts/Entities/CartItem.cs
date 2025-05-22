using Domain.Common;


namespace Domain.Carts.Entities;

public class CartItem : Entity<Guid>
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    private CartItem() { }

    public CartItem(Guid id, Guid productId, int quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }

    public void UpdateQuantity(int newQty)
    {
        Quantity = newQty;
    }
}
