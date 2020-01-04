using System;
using System.Collections.Generic;

namespace Mangos.ToDo.Interfaces
{
    public interface ICrud<TEntity, TKey>: IDisposable
        where TEntity : class, IEntity<TKey>
    {
        ICollection<TEntity> Get(string[] includes);
        TEntity Get(TKey id, string[] includes);
        ICollection<TEntity> Where(Func<TEntity, bool> where);
        bool Insert(TEntity entitie);
        bool Update(TKey id, TEntity entity);
        bool Delete(TKey id);
        bool Save();
    }
}
