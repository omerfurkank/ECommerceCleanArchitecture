using Domain.Common;
using Domain.Products.Entities;
using Domain.Products.Events;
using Domain.Products.ValueObjects;

namespace Domain.Products;

public class Product : Aggregate<Guid>
{
    public ProductName Name { get; private set; } = null!;
    public ProductDescription Description { get; private set; } = null!;
    public SKU Sku { get; private set; } = null!;
    public Price Price { get; private set; } = null!;

    public Guid CategoryId { get; private set; }
    public Guid BrandId { get; private set; }

    private readonly List<ProductImage> _images = new();
    public IReadOnlyCollection<ProductImage> Images => _images.AsReadOnly();

    private readonly List<ProductReview> _reviews = new();
    public IReadOnlyCollection<ProductReview> Reviews => _reviews.AsReadOnly();

    public bool IsActive { get; private set; } = true;

    private Product() { } // EF için

    private Product(
        Guid id,
        ProductName name,
        ProductDescription description,
        SKU sku,
        Price price,
        Guid categoryId,
        Guid brandId)
        : base(id)
    {
        Name = name;
        Sku = sku;
        Price = price;
        CategoryId = categoryId;
        BrandId = brandId;

        AddDomainEvent(new ProductCreatedEvent(Id));
    }

    public static Product Create(
        ProductName name,
        ProductDescription description,
        SKU sku,
        Price price,
        Guid categoryId,
        Guid brandId)
    {
        var product = new Product(
            Guid.NewGuid(),
            name,
            description,
            sku,
            price,
            categoryId,
            brandId);

        return product;
    }

    public void UpdatePrice(Price newPrice)
    {
        Price = newPrice;
        // AddDomainEvent(new ProductPriceChangedEvent(...));
    }

    public void AddImage(string url, int order = 0)
    {
        var image = new ProductImage(Guid.NewGuid(), url, order);
        _images.Add(image);
    }

    public void AddReview(int rating, string comment, Guid customerId)
    {
        var review = new ProductReview(Guid.NewGuid(), rating, comment, customerId);
        _reviews.Add(review);
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
    public void SetCategory(Guid categoryId) => CategoryId = categoryId;
}
