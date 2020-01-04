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
        [Column(TypeName = "TINYINT(4)")]
        public bool Deleted { get; set; }
        [Column(TypeName = "TINYINT(4)")]
        public bool Done { get; set; }
        public string Todo { get; set; }

    }
}
