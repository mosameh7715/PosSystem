using System.Linq.Expressions;

namespace Pos.Application.Contracts;

public interface IBaseRepository<TEntity, TKey> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
    Task<(IEnumerable<TEntity> Data, int TotalCount)> GetAllAsync(int pageIndex,int pageSize,params Expression<Func<TEntity, object>>[] includes);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

}
