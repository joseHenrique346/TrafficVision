using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Infrastructure.Data.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<ReportRegistration> ReportRegistration { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
