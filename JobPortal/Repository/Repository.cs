using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _applicationContext;
        private DbSet<TEntity> _entities;
        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
           // _entities = applicationContext.Set<TEntity>();
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entity">Entities</param>
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Remove(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(await GetFullErrorTextAndRollbackEntityChangesAsync (ex), ex);
            }
        }

        /// <summary>
        /// Get List by filtering
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetListByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.Where(filter).ToListAsync();
        }

        /// <summary>
        /// Get all list from table
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Entities.AsQueryable().ToListAsync();
        }

        /// <summary>
        /// Get Item by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.SingleOrDefaultAsync(filter);
        }

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entity">Entities</param>
        public async Task InsertAsync(TEntity entity)
        {
           if(entity==null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Add(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(await GetFullErrorTextAndRollbackEntityChangesAsync (ex),ex);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Update(entity);
                //var enties = _applicationContext.Entry(entity);
                //enties.State = EntityState.Modified;
                await _applicationContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(await GetFullErrorTextAndRollbackEntityChangesAsync(ex), ex);
            }
        }

        /// <summary>
        /// Get Table
        /// </summary>
        public IQueryable<TEntity> Table => Entities;


        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected DbSet<TEntity> Entities 
        {
            get 
            {
                if (_entities==null)
                    _entities = _applicationContext.Set<TEntity>();
                
                return _entities;
            
            }
                
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Error message</returns>
        protected async Task<string> GetFullErrorTextAndRollbackEntityChangesAsync(DbUpdateException ex)
        {
            if (_applicationContext is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }
            try
            {
                await _applicationContext.SaveChangesAsync();
                return ex.ToString();
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}
