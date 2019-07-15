using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dominos.Data.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public EfRepository(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;
        private DbSet<TEntity> _entities;

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }

                return _entities;
            }
        }

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return Entities.FirstOrDefault(filter);
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.FirstOrDefaultAsync(filter);
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            return Entities.Where(filter).ToList();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.Where(filter).ToListAsync();
        }

        public long Count(Expression<Func<TEntity, bool>> filter)
        {
            return Entities.Count(filter);
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.CountAsync(filter);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public void InsertMany(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.AddRange(entities);
            _context.SaveChanges();
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.SaveChangesAsync();
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _context.SaveChanges();
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}