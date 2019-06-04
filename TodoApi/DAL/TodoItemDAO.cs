using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public class TodoItemDAO : ITodoItemDAO
    {
        private readonly TodoContext context;

        public TodoItemDAO(TodoContext context)
        {
            this.context = context;
            if (context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                context.Add(new TodoItem { Name = "Item1" });
                context.SaveChanges();
            }
        }

        public Task<List<TodoItem>> GetAllTodoItems() => context.TodoItems.ToListAsync();

        public Task<TodoItem> GetTodoItem(long id) => context.TodoItems.FindAsync(id);

        public Task<int> CreateTodoItem(TodoItem item)
        {
            context.TodoItems.Add(item);
            return context.SaveChangesAsync();
        }

        public Task<int> PutTodoItem(TodoItem item)
        {
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteTodoItem(TodoItem item)
        {
            context.TodoItems.Remove(item);
            return context.SaveChangesAsync();
        }
    }
}
