using Common.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer
{
    public record class GetOrdersByCustomerQuery(Guid CustomerId)
        : IQuery<GetOrdersByCustomerResult>;

    public record class GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
}