using Application.Abstractions.Persistence;
using Domain.Products;
using Domain.Products.ValueObjects;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Sku,
    decimal Price,
    Guid CategoryId,
    Guid BrandId,
    string Description
) : IRequest<Guid>;

file sealed class CreateProductHandler(IProductRepository productRepository,IApplicationDbContext dbContext) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken ct)
    {
        if (await productRepository.SkuExistsAsync(new SKU(request.Sku), ct))
            throw new ApplicationException("Bu SKU zaten mevcut.");

        var product = Product.Create(
            new ProductName(request.Name),
            new ProductDescription(request.Description),
            new SKU(request.Sku),
            new Price(request.Price),
            request.CategoryId,
            request.BrandId
        );

        await productRepository.AddAsync(product, ct);
        await dbContext.SaveChangesAsync(ct);

        return product.Id;
    }
}