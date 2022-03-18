using BlogSample.Core.Configs;
using BlogSample.Core.Domain;
using BlogSample.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace BlogSample.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly string _connectionString;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _connectionString = AppSettings.Configs.GetConnectionString("AppDb");
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddBatch(ICollection<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void UpdateBatch(ICollection<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void DeleteBatch(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T GetByKey(long id) => _dbSet.Find((object)id);

        public virtual IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbSet.AsNoTracking();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbSet.AsNoTracking();

            includeProperties = includeProperties?.Distinct().ToArray();

            if (includeProperties?.Any() == true)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return predicate == null ? query : query.Where(predicate);
        }

        public bool IsExist(Expression<Func<T, bool>> predicate = null) => predicate == null ? this._dbSet.Any() : _dbSet.Any(predicate);
    }
}
