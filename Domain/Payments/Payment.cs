using Domain.Common;
using Domain.Payments.Enums;
using Domain.Payments.ValueObjects;
namespace Domain.Payments;

public class Payment : Aggregate<Guid>
{
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public PaymentMethod Method { get; private set; } = null!;

    private Payment() { }

    private Payment(Guid id, Guid orderId, decimal amount, PaymentMethod method)
        : base(id)
    {
        OrderId = orderId;
        Amount = amount;
        Method = method;
        Status = PaymentStatus.Pending;
    }

    public static Payment Create(Guid orderId, decimal amount, PaymentMethod method)
    {
        return new Payment(Guid.NewGuid(), orderId, amount, method);
    }

    public void MarkAsCompleted() => Status = PaymentStatus.Completed;
    public void MarkAsFailed() => Status = PaymentStatus.Failed;
    public void MarkAsRefunded() => Status = PaymentStatus.Refunded;
}
