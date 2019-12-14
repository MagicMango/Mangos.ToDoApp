using Mangos.ToDo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mangos.ToDo.Core.Context
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=RabbitCorePi;Database=ToDoDB;Uid=ToDoUser;Pwd=123456;oldguids=true");
        }
    }
}
