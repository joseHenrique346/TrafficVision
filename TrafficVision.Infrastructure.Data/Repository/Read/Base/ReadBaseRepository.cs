using Microsoft.EntityFrameworkCore;
using TrafficVision.Domain.Entities.Base;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public abstract class ReadBaseRepository<TEntity> : IReadBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected ReadBaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> GetListByListIdAsync(List<long> listId)
    {
        return await _dbSet
                     .Where(x => listId.Contains(x.Id))
                     .ToListAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
}