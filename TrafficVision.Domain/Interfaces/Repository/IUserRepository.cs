using TrafficVision.Domain.Entities;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task<User> GetByIdAsync(long id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(long id);
}