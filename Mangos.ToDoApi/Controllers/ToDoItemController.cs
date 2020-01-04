using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using Mangos.ToDo.Interfaces;
using Mangos.ToDoApi.Queue;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mangos.ToDoApi.Controllers
{
    public class ToDoItemController: GenericController<ToDoItem, Guid, ToDoContext, GenericDatabaseRepository<ToDoItem, Guid, ToDoContext>>
    {
        public ToDoItemController(ICrud<ToDoItem, Guid> repo, IEntitiePublisher<IEntity<Guid>> publisher) : base(repo, publisher) { }

        [HttpPost]
        public void MarkAsDone([FromBody] Guid value)
        {
            if (ModelState.IsValid)
            {
                using (repository)
                {
                    var entity = repository.Get(value, null);
                    entity.Done = true;
                    repository.Save();
                    publisher?.Emit(entity, "Done." + value.GetType().Name);
                }
            }
        }
    }
}
