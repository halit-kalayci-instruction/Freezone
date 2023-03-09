using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Freezone.Core.Persistence.Paging;
using Freezone.Core.Persistence.Dynamic;
using System.Drawing;

namespace Freezone.Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                                         IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true,
                                         CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().Where(i=>i.Status != 0).AsQueryable();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }
    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                           null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null,
                                                       int index = 0, int size = 10, bool enableTracking = true,
                                                       CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                Func<IQueryable<TEntity>,
                                                                        IIncludableQueryable<TEntity, object>>?
                                                                    include = null,
                                                                int index = 0, int size = 10,
                                                                bool enableTracking = true,
                                                                CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0).AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entityList)
    {
        foreach (TEntity entityItem in entityList)
        {
            Context.Entry(entityItem).State = EntityState.Added;
        }
        await Context.SaveChangesAsync();
        return entityList;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entityList)
    {
        foreach (TEntity entityItem in entityList)
        {
            Context.Entry(entityItem).State = EntityState.Modified;
        }
        await Context.SaveChangesAsync();
        return entityList;
    }
    public TEntity Delete(TEntity entity)
    {
        //Context.Entry(entity).State = EntityState.Deleted;
        Context.Entry(entity).Entity.Status = 0;
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }
    public List<TEntity> DeleteRange(List<TEntity> entity)
    {
        //Context.RemoveRange(entity);
        foreach (var item in entity)
        {
            Context.Entry(item).Entity.Status = 0;
            Context.Entry(item).State = EntityState.Modified;
        }
        Context.SaveChanges();
        return entity;
    }
    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).Entity.Status = 0;
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entity)
    {
        foreach (TEntity entityItem in entity)
        {
            Context.Entry(entityItem).Entity.Status = 0;
            Context.Entry(entityItem).State = EntityState.Modified;
        }
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                       IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0).AsQueryable();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable);
        return queryable.ToList();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToListAsync();
        return await queryable.ToListAsync();
    }
    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                      int index = 0, int size = 10,
                                      bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                   include = null, int index = 0, int size = 10,
                                               bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().Where(i => i.Status != 0).AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return queryable.ToPaginate(index, size);
    }

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }
    public List<TEntity> AddRange(List<TEntity> entity)
    {
        Context.AddRange(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }
    public List<TEntity> UpdateRange(List<TEntity> entity)
    {
        Context.UpdateRange(entity);
        Context.SaveChanges();
        return entity;
    }

  
}