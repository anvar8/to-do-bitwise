using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class TodoController : BaseApiController
    {

        private readonly ITodoRepository _repo;
        public TodoController(ITodoRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TodoItem>>> GetTodos()
        {
            var todos = await _repo.GetTodosAsync();
            return Ok(todos.OrderByDescending(x => x.Priority));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var product = await _repo.GetTodoByIdAsync(id);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return product;
        }
        [HttpPost("addtodo")]
        public async Task<ActionResult<TodoItem>> AddTodo([FromBody] TodoItem newTodo)
        {
            var todosFromContext = await _repo.GetTodosAsync();
            if (todosFromContext.Any(x => x.Title == newTodo.Title))
            {
                return BadRequest(new ApiResponse(400, "Item already exists"));
            }
            await _repo.AddTodoAsync(newTodo);
            return Ok(newTodo);
        }
        [HttpDelete("deletetodo/{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodo(int id)
        {
            var deletedTodo = await _repo.DeleteTodoAsync(id);
            if (deletedTodo == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(deletedTodo);
        }
        [HttpPut("updatetodo/{id}")]
        public async Task<ActionResult<TodoItem>> UpdateTodo(int id, TodoItem todo)
        {
            var updatedTodo = await _repo.EditTodoAsync(todo);
            if (updatedTodo == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(updatedTodo);
        }
    }
}
