using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericReposAndUnitOfWorkPattern.Repositories
{
    public interface IRepository<T> where T: class
    {
        DbSet<T> DbSet { get; }
        DbContext DbContext { get; set; }

        #region Sync Methods
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll(bool allowTracking = true);

        /// <summary>
        /// Get entities by lambda expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate, bool allowTracking = true);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        T GetById(int id, bool allowTracking = true);

        /// <summary>
        /// Get entity by lambda expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate, bool allowTracking = true);

        /// <summary>
        /// Get entities from sql string
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        IEnumerable<T> FromSqlQuery(string sql, bool allowTracking = true);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete the entities
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        #endregion

        #region Async Methods
        /// <summary>
        /// Get all entities async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true);

        /// <summary>
        /// Get entities lambda expression async
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true);

        /// <summary>
        /// Get entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id, bool allowTracking = true);

        /// <summary>
        /// Get entity by lambda expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool allowTracking = true);

        /// <summary>
        /// Get entities from sql string async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> FromSqlQueryAsync(string sql, bool allowTracking = true);

        #endregion
    }
}
