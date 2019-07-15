using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominos.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        TEntity First(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter);

        long Count(Expression<Func<TEntity, bool>> filter);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter);

        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);

        void InsertMany(IEnumerable<TEntity> entities);
        Task InsertManyAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void UpdateMany(IEnumerable<TEntity> entities);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        void DeleteMany(IEnumerable<TEntity> entities);
        Task DeleteManyAsync(IEnumerable<TEntity> entities);
    }
}