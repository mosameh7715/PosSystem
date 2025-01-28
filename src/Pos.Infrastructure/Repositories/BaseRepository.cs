using System.Linq.Expressions;

namespace Pos.Infrastructure.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    public readonly PosDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(PosDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.FirstOrDefaultAsync(e => EF.Property<TKey>(e, "Id").Equals(id));
    }

    public async Task<(IEnumerable<TEntity> Data, int TotalCount)> GetAllAsync(
        int pageIndex,
        int pageSize,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        int totalCount = await query.CountAsync();

        var data = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (data, totalCount);
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}
