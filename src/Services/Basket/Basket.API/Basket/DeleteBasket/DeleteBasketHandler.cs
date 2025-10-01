

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketResult(bool IsSuccess);
    public record DeleteBasketCommand(string Username) : ICommand<DeleteBasketResult>;

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username required");
        }
    }

    public class DeleteBasketCommandHandler(IBasketRepository repository)
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            var res = await repository.DeleteBasket(command.Username, cancellationToken);
            return new DeleteBasketResult(res);
        }
    }
}