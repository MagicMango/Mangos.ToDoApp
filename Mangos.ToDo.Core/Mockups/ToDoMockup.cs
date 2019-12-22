using Mangos.ToDo.Entities;
using Mangos.ToDo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mangos.ToDo.Core.Mockups
{
    public class ToDoMockup : ICrud<ToDoList, Guid>
    {
        private static List<ToDoList> database = new List<ToDoList>(
            new[]{ new ToDoList(){ Deleted = false,
                LastUpdated = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "First List",
                ToDoItems = new List<ToDoItem>(new []{ new ToDoItem() {
                    Deleted = false,
                    Id = Guid.NewGuid(),
                    LastUpdated = DateTime.Now.AddDays(-3),
                    Todo = "Todo"
                } })
            }
            }
            );

        public bool Delete(Guid id)
        {
            return true;
        }

        public void Dispose()
        {
            
        }

        public ICollection<ToDoList> Get()
        {
            return database.ToList();
        }

        public ToDoList Get(Guid id)
        {
            return database.SingleOrDefault(x => x.Id == id);
        }

        public bool Insert(ToDoList entitie)
        {
            database.Add(entitie);
            return true;
        }

        public bool Update(Guid id, ToDoList entity)
        {
            return true;
        }
    }
}
