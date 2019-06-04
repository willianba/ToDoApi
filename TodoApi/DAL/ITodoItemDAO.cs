using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public interface ITodoItemDAO
    {
        Task<int> DeleteTodoItem(TodoItem item);
        Task<int> PutTodoItem(TodoItem item);
        Task<int> CreateTodoItem(TodoItem item);
        Task<TodoItem> GetTodoItem(long id);
        Task<List<TodoItem>> GetAllTodoItems();
    }
}
