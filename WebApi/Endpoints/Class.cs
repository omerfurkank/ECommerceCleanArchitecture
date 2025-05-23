using Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace WebApi.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/products", async (
            CreateProductCommand command,
            ISender sender) =>
        {
            var productId = await sender.Send(command);
            return Results.Created($"/products/{productId}", new { id = productId });
        })
        .WithName("CreateProduct")
        .WithOpenApi();

        // İleride diğerleri: GetAll, GetById, Delete vs

        return endpoints;
    }
}
