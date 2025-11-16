using TrafficVision.Domain.Entities;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class ReadUserRepository(AppDbContext context) : ReadBaseRepository<User>(context) { }