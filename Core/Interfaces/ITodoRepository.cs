using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITodoRepository 
    {
         Task<TodoItem> GetTodoByIdAsync (int id);
         Task<IReadOnlyList<TodoItem>> GetTodosAsync(); //we don't need the functionality of a normal list, therefore we are using IReadOnlyList
         Task AddTodoAsync(TodoItem todo);
         Task <TodoItem> DeleteTodoAsync (int id);
         Task <TodoItem> EditTodoAsync (TodoItem todo);
    }
}