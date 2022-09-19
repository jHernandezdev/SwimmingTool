using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingTool.Domain;

public interface IAsyncRepository<T, TIdentity> 
    where T : Entity<TIdentity> 
    where TIdentity : notnull
{
    Task<T> GetByIdAsync(TIdentity id, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListByExpressionAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
