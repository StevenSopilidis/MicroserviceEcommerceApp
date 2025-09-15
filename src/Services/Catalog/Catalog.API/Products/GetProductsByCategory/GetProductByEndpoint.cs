
namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);

    public class GetProductByEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) => 
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var res = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(res);
            })
            .WithName("GetProductsByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products by Category")
            .WithDescription("Get Products by Category");
        }
    }
}