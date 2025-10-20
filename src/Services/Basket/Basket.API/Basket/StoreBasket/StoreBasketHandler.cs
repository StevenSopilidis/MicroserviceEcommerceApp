using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketResult(string Username);
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.Username).NotNull().WithMessage("username is required");
        }
    }

    public class StoreBasketCommandHandler
        (IBasketRepository repository, 
        DiscountProtoService.DiscountProtoServiceClient discountServiceClient)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.Cart, cancellationToken);
            await repository.StoreBasket(command.Cart, cancellationToken);
            return new StoreBasketResult(command.Cart.Username);
        }

        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken) 
        {
            foreach (var item in cart.Items)
            {
                var coupon = await discountServiceClient.GetDiscountAsync(new GetDiscountRequest{
                    ProductName= item.ProductName
                }, cancellationToken: cancellationToken);

                item.Price -= coupon.Amount;  
            }
        }
    }
}