using Microsoft.EntityFrameworkCore;
using Nava.Api.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// RepositoryBase
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public class RepositoryBase<Entity> : IRepositoryBase<Entity>
        where Entity : EntityBase
    {
        private readonly DatabaseContext context;
        private readonly DbSet<Entity> dbSet;

        /// <summary>
        /// RepositoryBase
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dbSet"></param>
        public RepositoryBase(DatabaseContext context, DbSet<Entity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        /// <summary>
        /// Metodo para ser sobrecarregado...
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DoBeforeCreate(Entity entity) { }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task Create(Entity entity)
        {
            DoBeforeCreate(entity);
            dbSet.Add(entity);            
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Task<Entity> Get(int Id)
        {            
            return dbSet.Where(p => p.Id == Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<Entity>> GetAll()
        {
            return dbSet.ToListAsync();
        }

        /// <summary>
        /// Metodo para ser sobrecarregado...
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DoBeforeRemove(Entity entity) { }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task Remove(Entity entity)
        {
            DoBeforeRemove(entity);
            dbSet.Remove(entity);
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Metodo para ser sobrecarregado...
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DoBeforeUpdate(Entity entity) { }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task Update(Entity entity)
        {
            DoBeforeUpdate(entity);
            context.Update(entity);
            return context.SaveChangesAsync();
        }
    }
}