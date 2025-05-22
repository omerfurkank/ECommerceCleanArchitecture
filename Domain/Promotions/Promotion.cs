using Domain.Common;
using Domain.Promotions.ValueObjects;

namespace Domain.Promotions;

public class Promotion : Aggregate<Guid>
{
    public string Title { get; private set; } = null!;
    public Discount Discount { get; private set; } = null!;
    public DateRange ValidityPeriod { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public Guid? ProductId { get; private set; }
    public Guid? CategoryId { get; private set; }

    private Promotion() { }

    private Promotion(Guid id, string title, Discount discount, DateRange validity, Guid? productId, Guid? categoryId)
        : base(id)
    {
        Title = title;
        Discount = discount;
        ValidityPeriod = validity;
        ProductId = productId;
        CategoryId = categoryId;
        IsActive = true;
    }

    public static Promotion Create(
        string title,
        Discount discount,
        DateRange validity,
        Guid? productId = null,
        Guid? categoryId = null)
    {
        return new Promotion(Guid.NewGuid(), title, discount, validity, productId, categoryId);
    }

    public bool IsCurrentlyActive(DateTime now) => IsActive && ValidityPeriod.IsActive(now);

    public void Deactivate() => IsActive = false;
}
