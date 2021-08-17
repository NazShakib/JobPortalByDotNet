using JobPortal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetListByFilterAsync(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Table { get; }
    }
}
