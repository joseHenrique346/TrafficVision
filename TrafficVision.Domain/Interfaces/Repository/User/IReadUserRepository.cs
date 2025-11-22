using TrafficVision.Domain.Entities;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IReadUserRepository : IReadBaseRepository<User> 
{ 
    public Task<User> GetByEmailAsync(string email);
}