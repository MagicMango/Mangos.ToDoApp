using Mangos.ToDo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.ToDo.Entities
{
    public class ToDoList : IEntity<Guid>
    {
        public ToDoList()
        {
            Id = Guid.NewGuid();
            ToDoItems = new HashSet<ToDoItem>();
        }
        [Column(TypeName = "char(36)")]
        public Guid Id { get; set; }
        public DateTime LastUpdated { get; set; }
        [Column(TypeName = "TINYINT(4)")]
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
