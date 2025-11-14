using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
        //await _context.FindAsync(id);
    }

    public async Task AddAsync(User user)
    {
        throw new NotImplementedException();
        //await _context.Users.AddAsync(user);
        //await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
        //_context.Users.Update(user);
        //await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
        //var user = await _context.Users.FindAsync(id);
        //if (user != null)
        //{
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}