using Microsoft.EntityFrameworkCore;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public abstract class BaseReadRepository<TEntity, TDto>
        where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseReadRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public abstract Task<TDto?> GetById(long id);
    public abstract Task<List<TDto>> GetAll();
}