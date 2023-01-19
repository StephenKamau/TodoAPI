using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public interface ITodoService
    {
        Task<ServiceResponse<IEnumerable<Todo>>> GetTodos();
        Task<ServiceResponse<Todo>> GetTodoById(int id);
        Task<ServiceResponse<IEnumerable<Todo>>> AddTodos(AddTodoRequestDto todo);
    }
}
