namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResponse(ShoppingCart Cart);

    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) => 
            {
                var result = await sender.Send(new GetBasketQuery(username));
                var res = result.Adapt<GetBasketResult>();
                return Results.Ok(res); 
            })
            .WithName("GetBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get basket")
            .WithDescription("Get basket");
        }
    }
}