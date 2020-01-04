using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using Mangos.ToDo.Interfaces;
using Mangos.ToDoApi.Queue;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Mangos.ToDoApi.Controllers
{
    public class ToDoListController : GenericController<ToDoList, Guid, ToDoContext, GenericDatabaseRepository<ToDoList, Guid, ToDoContext>>
    {
        public ToDoListController(ICrud<ToDoList, Guid> repo, IEntitiePublisher<IEntity<Guid>> publisher) : base(repo, publisher) { }

        [HttpGet]
        public override ActionResult<ICollection<ToDoList>> GetAll()
        {
            return repository.Get(new[] { "ToDoItems" }).ToList();
        }

        [HttpGet("{id}")]
        public override ActionResult<ToDoList> Get(Guid id)
        {
            return repository.Get(id, new[] { "ToDoItems" });
        }
    }
}
