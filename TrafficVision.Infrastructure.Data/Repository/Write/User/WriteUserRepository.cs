using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class WriteUserRepository(AppDbContext context) : WriteBaseRepository<User>(context), IWriteUserRepository { }