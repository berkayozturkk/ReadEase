using Microsoft.EntityFrameworkCore;
using ReadEase.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadEase.Persistance.Repositories;

public class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
{
    private readonly TContext _context;

    private DbSet<TEntity> Entity;

    public BaseRepository(TContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        await Entity.AddAsync(entity, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
    }

    public async Task AddRangeASync(ICollection<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
        await Entity.AddRangeAsync(entities, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
    }

    public void Delete(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
    {
        TEntity entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        TEntity entity = await Entity.FindAsync(id).ConfigureAwait(continueOnCapturedContext: false);
        Entity.Remove(entity);
    }

    public void DeleteRange(ICollection<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsNoTracking().AsQueryable();
    }

    public TEntity GetByExpression(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.Where(expression).AsNoTracking().FirstOrDefault();
    }

    public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);
    }

    public TEntity GetFirst()
    {
        return Entity.AsNoTracking().FirstOrDefault();
    }

    public async Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await Entity.AsNoTracking().FirstOrDefaultAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.AsNoTracking().Where(expression).AsQueryable();
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        Entity.UpdateRange(entities);
    }
}
