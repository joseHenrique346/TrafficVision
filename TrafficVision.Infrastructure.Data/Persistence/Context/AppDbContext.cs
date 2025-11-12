using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace TrafficVision.Infrastructure.Data.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<ReportRegistrationEntity> ReportRegistration { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
