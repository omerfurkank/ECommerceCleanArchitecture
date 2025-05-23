using Application.Abstractions.Persistence;
using Domain.Products;
using Domain.Products.ValueObjects;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Repositories;

public sealed class EfProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await context.Products
            .FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<bool> SkuExistsAsync(SKU sku, CancellationToken ct = default) =>
        await context.Products.AnyAsync(p => p.Sku.Value == sku.Value, ct);

    public async Task AddAsync(Product product, CancellationToken ct = default) =>
        await context.Products.AddAsync(product, ct);
}
