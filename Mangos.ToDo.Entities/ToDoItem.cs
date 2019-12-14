using Mangos.ToDo.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.ToDo.Entities
{
    public class ToDoItem : IEntity<Guid>
    {
        public ToDoItem()
        {
            Id = Guid.NewGuid();
        }
        [Column(TypeName = "char(36)")]
        public Guid Id { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public bool Deleted { get; set; }
        public string Todo { get; set; }

    }
}
