using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using Mangos.ToDo.Interfaces;
using Mangos.ToDoApi.Queue;
using System;

namespace Mangos.ToDoApi.Controllers
{
    public class ToDoListController : GenericController<ToDoList, Guid, ToDoContext, GenericDatabaseRepository<ToDoList, Guid, ToDoContext>>
    {
        public ToDoListController(ICrud<ToDoList, Guid> repo, IEntitiePublisher<IEntity<Guid>> publisher) : base(repo, publisher) { }
    }
}
