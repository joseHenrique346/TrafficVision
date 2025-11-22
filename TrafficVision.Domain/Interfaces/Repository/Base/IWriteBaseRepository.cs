using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IWriteBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(long id);
}