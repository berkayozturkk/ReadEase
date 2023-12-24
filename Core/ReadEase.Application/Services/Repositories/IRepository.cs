﻿using System.Linq.Expressions;

namespace ReadEase.Application.Services.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression);

    Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default(CancellationToken));

    TEntity GetByExpression(Expression<Func<TEntity, bool>> expression);

    TEntity GetFirst();

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task AddRangeASync(ICollection<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    void Update(TEntity entity);

    void UpdateRange(ICollection<TEntity> entities);

    Task DeleteByIdAsync(string id);

    Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    void Delete(TEntity entity);

    void DeleteRange(ICollection<TEntity> entities);
}
