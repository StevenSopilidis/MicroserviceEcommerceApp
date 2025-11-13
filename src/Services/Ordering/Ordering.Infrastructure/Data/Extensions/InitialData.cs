using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers => [];
        public static IEnumerable<Product> Products => [];
        public static IEnumerable<Order> OrdersWithItems => [];
    }
}