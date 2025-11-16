using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Interfaces.Repository;

public interface IReadBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(long id);
    Task<List<TEntity>> GetListByListIdAsync(List<long> listId);
    Task<List<TEntity>> GetAll();
}