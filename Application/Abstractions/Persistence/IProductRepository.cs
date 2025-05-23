using Domain.Products.ValueObjects;
using Domain.Products;
using System.Collections.Generic;

namespace Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> SkuExistsAsync(SKU sku, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
}
