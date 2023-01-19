using AutoMapper;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService

    {
        public TodoService(IMapper mapper)
        {
            _Mapper = mapper;
        }
        public List<Todo> todos = new();

        public IMapper _Mapper { get; }

        public async Task<ServiceResponse<IEnumerable<Todo>>> AddTodos(AddTodoRequestDto todo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Todo>>();
            var t = _Mapper.Map<Todo>(todo);
            t.Id = todos.Count > 0 ? todos.Max(x => x.Id) + 1 : 1;
            todos.Add(t);
            serviceResponse.Data = todos;
            return serviceResponse;
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
            serviceResponse.Data = todos;
            return serviceResponse;
        }
    }
}
