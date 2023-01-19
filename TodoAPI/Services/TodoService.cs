using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService

    {
        public List<Todo> todos = new();
        public async Task<ServiceResponse<IEnumerable<Todo>>> AddTodos(Todo todo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Todo>>();
            todos.Add(todo);
            serviceResponse.Data=todos;
            return  serviceResponse;
        }

        public async Task<ServiceResponse<Todo>> GetTodoById(int id)
        {
            var serviceResponse = new ServiceResponse<Todo>();
            var todo = todos.FirstOrDefault(x => x.Id == id);
            if (todo is null)
            {
                throw new ArgumentException("Could not find todo with the id provided");
            }
            serviceResponse.Data = todo;
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<Todo>>> GetTodos()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Todo>>();
            serviceResponse.Data=todos;
            return serviceResponse;
        }
    }
}
