using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Repository;

namespace TrafficVision.Infrastructure.Data.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IWriteReportRegistrationRepository, WriteReportRegistrationRepository>();
        services.AddScoped<IReadReportRegistrationRepository, ReadReportRegistrationRepository>();

        services.AddScoped<IWriteUserRepository, WriteUserRepository>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();

        services.AddScoped<IWriteVehicleRepository, WriteVehicleRepository>();

        return services;
    }
}