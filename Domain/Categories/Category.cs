using Domain.Categories.ValueObjects;
using Domain.Common;

namespace Domain.Categories;

public class Category : Aggregate<Guid>
{
    public CategoryName Name { get; private set; } = null!;
    public Guid? ParentCategoryId { get; private set; }

    private Category() { }

    private Category(Guid id, CategoryName name, Guid? parentCategoryId)
        : base(id)
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
    }

    public static Category Create(CategoryName name, Guid? parentCategoryId = null)
    {
        return new Category(Guid.NewGuid(), name, parentCategoryId);
    }

    public void Rename(CategoryName newName)
    {
        Name = newName;
    }

    public void MoveToParent(Guid? newParentId)
    {
        ParentCategoryId = newParentId;
    }
}
