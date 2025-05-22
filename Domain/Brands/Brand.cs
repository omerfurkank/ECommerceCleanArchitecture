using Domain.Brands.ValueObjects;
using Domain.Common;

namespace Domain.Brands;

public class Brand : Aggregate<Guid>
{
    public BrandName Name { get; private set; } = null!;
    public string? Description { get; private set; }

    private Brand() { }

    private Brand(Guid id, BrandName name, string? description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static Brand Create(BrandName name, string? description = null)
    {
        return new Brand(Guid.NewGuid(), name, description);
    }

    public void Rename(BrandName newName)
    {
        Name = newName;
    }

    public void UpdateDescription(string? newDescription)
    {
        Description = newDescription;
    }
}
