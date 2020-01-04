using Mangos.ToDo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mangos.ToDo.Core.Repository
{
    public class GenericDatabaseRepository<TEntity, TKey, TContext>: IDisposable , ICrud<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TContext: DbContext
    {
        private TContext context;
        public GenericDatabaseRepository(TContext context)
        {
            this.context = context;
        }
        public virtual bool Delete(TKey id)
        {
            try
            {
                context.Remove(context.Find<TEntity>(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                //ToDo logging!
                return false;
            }
        }

        public virtual ICollection<TEntity> Get(string[] includes = null)
        {
            try
            {
                var entities = context.Set<TEntity>().AsQueryable();
                foreach (var include in (includes ?? new string[0]))
                {
                    entities = entities.Include(include);
                }
                return entities.Where(x=>!x.Deleted).ToList();
            }
            catch
            {
                //Todo loggin
                return default;
            }
        }

        public virtual TEntity Get(TKey id, string[] includes = null)
        {
            try
            {
                var entities = context.Set<TEntity>().AsQueryable();
                foreach (var include in (includes ?? new string[0]))
                {
                    entities = entities.Include(include);
                }
                return entities.SingleOrDefault(x=>x.Id.Equals(id));
            }
            catch
            {
                //Todo loggin
                return default;
            }
        }

        public virtual bool Insert(TEntity entitie)
        {
            try
            {
                context.Set<TEntity>().Add(entitie);
                context.SaveChanges();
                return true;
            }
            catch
            {
                //Todo loggin
                return false;
            }
        }

        public virtual bool Update(TKey id, TEntity entity)
        {
            try
            {
                context.Entry(context.Set<TEntity>().Find(id)).CurrentValues.SetValues(entity);
                context.SaveChanges();
                return true;
            }
            catch
            {
                //Todo loggin
                return false;
            }
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public bool Save()
        {
            try
            {
                return context.SaveChanges() > 0;
            }
            catch
            {
                //ToDo logging!
                return false;
            }
        }

        public ICollection<TEntity> Where(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>().Where(where).ToList();
        }
    }
}
