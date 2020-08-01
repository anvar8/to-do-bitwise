using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TodoRepository : ITodoRepository
    {
        
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
            
        }

        public async Task AddTodoAsync(TodoItem todo)
        {
            await _context.Todos.AddAsync(todo);
            _context.SaveChanges();
        }

        public async Task<TodoItem> DeleteTodoAsync (int id) {
            var deletedItem = await _context.Todos.FindAsync(id);
            if (deletedItem == null) {
              return null;
            }
            _context.Todos.Remove(deletedItem);
            _context.SaveChanges();
            return deletedItem;
        }

        public async Task<TodoItem> EditTodoAsync(TodoItem todo)
        {
            var todoToEdit = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);
            if (todoToEdit == null) {
                return null;
            }
            todo.DateUpdated = DateTime.Now;
            _context.Entry(todoToEdit).CurrentValues.SetValues(todo);
            _context.SaveChanges();
            return todo;
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IReadOnlyList<TodoItem>> GetTodosAsync()
        {
            return await _context.Todos.ToListAsync(); 
        }
    }
}