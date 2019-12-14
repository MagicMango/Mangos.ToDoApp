using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using System;

namespace Mangos.ToDoApi.Controllers
{
    public class ToDoItemController: GenericController<ToDoItem, Guid, ToDoContext, GenericDatabaseRepository<ToDoItem, Guid, ToDoContext>>
    {
        public ToDoItemController(GenericDatabaseRepository<ToDoItem, Guid, ToDoContext> repo) : base(repo) { }
    }
}
