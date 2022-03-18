using BlogSample.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogSample.Core.Domain
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        void AddBatch(ICollection<T> entities);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// UpdateBatch
        /// </summary>
        /// <param name="entities"></param>
        void UpdateBatch(ICollection<T> entities);

        /// <summary>
        /// DeleteBatch
        /// </summary>
        /// <param name="entities"></param>
        void DeleteBatch(ICollection<T> entities);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns>IQueryable</returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// CheckCodeIsExist
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> predicate = null);

        T GetByKey(long id);
    }
}
