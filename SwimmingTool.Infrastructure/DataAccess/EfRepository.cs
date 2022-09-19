using Microsoft.EntityFrameworkCore;
using SwimmingTool.Domain;
using System.Linq.Expressions;
namespace SwimmingTool.Infrastructure.DataAccess;

public class EfRepository<T, TIdentity> : IAsyncRepository<T, TIdentity>
    where T : Entity<TIdentity>
    where TIdentity : notnull
{
    protected readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Set<T>()
            .FirstOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListByExpressionAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>()
            .Where(filter)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IReadOnlyList<T>> ListAllAsync(int perPage,int page,CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().Skip(perPage * (page - 1)).Take(perPage).ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
