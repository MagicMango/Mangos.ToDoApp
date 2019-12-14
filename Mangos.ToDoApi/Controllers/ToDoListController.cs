using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using System;

namespace Mangos.ToDoApi.Controllers
{
    public class ToDoListController : GenericController<ToDoList, Guid, ToDoContext, GenericDatabaseRepository<ToDoList, Guid, ToDoContext>>
    {
        public ToDoListController(GenericDatabaseRepository<ToDoList, Guid, ToDoContext> repo) : base(repo) { }
    }
}
