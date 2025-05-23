using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Persistence;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
