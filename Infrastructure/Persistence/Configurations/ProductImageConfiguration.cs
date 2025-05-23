using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Products.Entities;

namespace Infrastructure.Persistence.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Url)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.SortOrder)
            .HasDefaultValue(0);

    }
}
