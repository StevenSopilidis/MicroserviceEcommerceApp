using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            var connString = configuration.GetConnectionString("Database");

            // services.AddDbContext<ApplicationD bContext>(opts => 
            // {
                // opts.UseSqlServer(connString);
            // });
            // services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}