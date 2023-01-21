

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Dtos;
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
        public async Task<ActionResult<ServiceResponse<Todo>>> GetTodo(int id)
        {
            var response = await _TodoService.GetTodoById(id);
            if (response.Data == null) { return NotFound(response); }
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Todo>>>> AddTodo(AddTodoRequestDto todo)
        {
            return Ok(await _TodoService.AddTodo(todo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Todo>>> UpdateCharacter(UpdateTodoRequestDto updateTodo)
        {
            var response = await _TodoService.UpdateTodo(updateTodo);
            if (response.Data is null) { return NotFound(response); }
            return Ok(response);
        }
    }
}
