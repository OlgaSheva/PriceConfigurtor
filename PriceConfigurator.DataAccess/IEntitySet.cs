﻿using System.Linq;

namespace PriceConfigurator.DataAccess
{
    /// <summary>
    /// Represents a queryable set of <typeparamref name="TEntity"/> that allows add and remove operations.
    /// </summary>
    /// <typeparam name="TEntity">An entity.</typeparam>
    public interface IEntitySet<TEntity> : IQueryable<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Adds a new entity to the set.
        /// </summary>
        /// <param name="entity">An entity to add.</param>
        /// <returns>Added entity.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Removes the existed entity from the set.
        /// </summary>
        /// <param name="entity">An entity to remove.</param>
        /// <returns>Removed entity.</returns>
        TEntity Remove(TEntity entity);

        /// <summary>
        /// Removes the existed entities from the set.
        /// </summary>
        /// <param name="entities">Antities to remove.</param>
        void RemoveRange(params TEntity[] entities);
    }
}
