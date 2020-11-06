﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// RepositoryBase
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public class RepositoryBase<Entity> : IRepositoryBase<Entity>
        where Entity : class
    {
        private readonly DatabaseContext context;
        private readonly DbSet<Entity> entities;

        /// <summary>
        /// RepositoryBase
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        public RepositoryBase(DatabaseContext context, DbSet<Entity> entities)
        {
            this.context = context;
            this.entities = entities;
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
            entities.Add(entity);
            context.SaveChangesAsync();
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual ValueTask<Entity> Get(long Id)
        {
            return entities.FindAsync(Id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<Entity>> GetAll()
        {
            return entities.ToListAsync();
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task Remove(Entity entity)
        {
            entities.Remove(entity);
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task Update(Entity entity)
        {
            context.Update(entity);
            return context.SaveChangesAsync();
        }
    }
}