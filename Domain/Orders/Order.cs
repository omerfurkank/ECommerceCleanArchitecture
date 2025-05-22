using Domain.Common;
using Domain.Orders.Entities;
using Domain.Orders.Enums;
using Domain.Orders.ValueObjects;

namespace Domain.Orders;

public class Order : Aggregate<Guid>
{
    public Guid CustomerId { get; private set; }
    public OrderNumber OrderNumber { get; private set; } = null!;
    public OrderStatus Status { get; private set; }
    public ShippingAddress ShippingAddress { get; private set; } = null!;

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal TotalPrice => _items.Sum(i => i.TotalPrice);

    private Order() { }

    private Order(Guid id, Guid customerId, OrderNumber orderNumber, ShippingAddress shippingAddress)
        : base(id)
    {
        CustomerId = customerId;
        OrderNumber = orderNumber;
        Status = OrderStatus.Pending;
        ShippingAddress = shippingAddress;
    }

    public static Order Create(Guid customerId, OrderNumber orderNumber, ShippingAddress shippingAddress)
    {
        return new Order(Guid.NewGuid(), customerId, orderNumber, shippingAddress);
    }

    public void AddItem(Guid productId, int quantity, decimal unitPrice)
    {
        var item = new OrderItem(Guid.NewGuid(), productId, quantity, unitPrice);
        _items.Add(item);
    }

    public void SetStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }

    public void ChangeShippingAddress(ShippingAddress newAddress)
    {
        ShippingAddress = newAddress;
    }
}
