

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        public ITodoService _TodoService;

        public TodoController(ITodoService todoService)
        {
            _TodoService = todoService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Todo>>>> GetTodo() { return Ok(await _TodoService.GetTodos()); }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Todo>>> GetTodo(int id) { return Ok(await _TodoService.GetTodoById(id)); }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Todo>>>> AddTodo(Todo todo)
        {
            return Ok(await _TodoService.AddTodos(todo));
        }
    }
}
