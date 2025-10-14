using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon{ Id = 1, ProductName = "IPHONE X", Description = "IPHONE PHONE", Amount = 150},
                new Coupon{ Id = 2, ProductName = "PHONE X", Description = "PHONE", Amount = 120}
            );
        }

        public DbSet<Coupon> Coupons { get; set; } = default!;
    }
}