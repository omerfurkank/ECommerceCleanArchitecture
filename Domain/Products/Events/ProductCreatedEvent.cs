using Domain.Common;


namespace Domain.Products.Events;

public class ProductCreatedEvent : DomainEvent
{
    public Guid ProductId { get; }

    public ProductCreatedEvent(Guid productId)
    {
        ProductId = productId;
    }
}
