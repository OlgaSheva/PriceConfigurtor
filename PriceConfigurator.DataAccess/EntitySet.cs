using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PriceConfigurator.DataAccess
{
    internal class EntitySet<TEntity> : EntitySetBase<TEntity>
        where TEntity : class
    {
        public EntitySet(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }

        internal DbSet<TEntity> DbSet { get; }

        protected override IQueryable<TEntity> Queryable => DbSet;

        public override TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public override TEntity Remove(TEntity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public override void RemoveRange(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
