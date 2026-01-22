using System.Windows.Input;
using Common.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order)
        : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(c => c.Order.Id).NotEmpty().WithMessage("Id is required");   
            RuleFor(c => c.Order.OrderName).NotEmpty().WithMessage("OrderName is required");   
            RuleFor(c => c.Order.CustomerId).NotEmpty().WithMessage("CustomerId  is required");   
        }
    }
}