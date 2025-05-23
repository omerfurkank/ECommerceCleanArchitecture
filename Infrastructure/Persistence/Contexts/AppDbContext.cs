using Application.Abstractions.Persistence;
using Domain.Common;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<DomainEvent>();
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            Console.WriteLine($"Entry: {entry.Entity?.GetType().Name}, State: {entry.State}");

            if (entry.Entity is not null && entry.State is EntityState.Added or EntityState.Modified)
            {
                var createdAtProp = entry.Entity.GetType().GetProperty("CreatedAt");
                var lastModifiedProp = entry.Entity.GetType().GetProperty("LastModified");

                if (entry.State == EntityState.Added && createdAtProp is not null)
                    createdAtProp.SetValue(entry.Entity, DateTime.UtcNow);

                if (entry.State == EntityState.Modified && lastModifiedProp is not null)
                    lastModifiedProp.SetValue(entry.Entity, DateTime.UtcNow);
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

}
