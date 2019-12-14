using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mangos.ToDoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenericController<TEntity, TKey, TContext, TRepo> : ControllerBase
        where TRepo : GenericDatabaseRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        TRepo repository;
        public GenericController(TRepo repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public virtual ActionResult<ICollection<TEntity>> GetAll()
        {
            using (repository)
            {
                return repository.Get().ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(TKey id)
        {
            using (repository)
            {
                return repository.Get(id);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TEntity value)
        {
            if (ModelState.IsValid)
            {
                using (repository)
                {
                    repository.Insert(value);
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(TKey id, [FromBody] TEntity value)
        {
            using (repository)
            {
                repository.Update(id, value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(TKey id)
        {
            using (repository)
            {
                repository.Delete(id);
            }
        }
    }
}
