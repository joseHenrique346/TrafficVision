using Microsoft.EntityFrameworkCore;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class ReadUserRepository(AppDbContext context) : ReadBaseRepository<User>(context), IReadUserRepository
{
    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.UserEmail.Value == email);
    }
}