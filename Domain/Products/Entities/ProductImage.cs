using Domain.Common;

namespace Domain.Products.Entities;

public class ProductImage : Entity<Guid>
{
    public string Url { get; private set; } = null!;
    public int SortOrder { get; private set; } = default!;

    private ProductImage() { } // EF için

    public ProductImage(Guid id, string url, int sortOrder = 0)
    {
        Id = id;
        Url = url ?? throw new ArgumentNullException(nameof(url));
        SortOrder = sortOrder;
    }

    public void UpdateSortOrder(int newOrder)
    {
        SortOrder = newOrder;
    }
}