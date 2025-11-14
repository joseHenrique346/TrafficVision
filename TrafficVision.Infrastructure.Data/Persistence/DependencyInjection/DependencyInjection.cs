using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrafficVision.Infrastructure.Data.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}