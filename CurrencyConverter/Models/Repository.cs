using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Models
{
    public interface IRepositoryGet<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    }

    public interface IRepositoryModify<TEntity>
        where TEntity : class
    {
        public Task AddAsync(TEntity entity);
        public void DeleteAsync(TEntity entityToDelete);
        public void Update(TEntity entityToUpdate);
        public void Save();
        public Task SaveAsync();
    }
    public abstract class Repository<TEntity> : IRepositoryModify<TEntity>, IRepositoryGet<TEntity>
        where TEntity : class
    {
        protected CancellationToken CancellationToken { get; private set; }
        protected ApplicationDbContext Context { get; private set; }
        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            CancellationToken = httpContextAccessor?.HttpContext?.RequestAborted ?? CancellationToken.None;
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        async Task<IEnumerable<TEntity>> IRepositoryGet<TEntity>.GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync(CancellationToken);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity, CancellationToken);
        }
        public void DeleteAsync(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entityToDelete);
            }

            Context.Set<TEntity>().Remove(entityToDelete);
        }
        public void Update(TEntity entityToUpdate)
        {

            Context.Set<TEntity>().Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void Save()
        {
            Context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
