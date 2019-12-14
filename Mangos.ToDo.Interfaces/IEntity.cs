using System;

namespace Mangos.ToDo.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime LastUpdated { get; set; }
        bool Deleted { get; set; }
    }
}
