using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TodoAPI.Data;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService

    {
        public TodoService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            Context = context;
        }

        public IMapper _mapper { get; }
        public DataContext Context { get; }

        public async Task<ServiceResponse<IEnumerable<Todo>>> AddTodo(AddTodoRequestDto todo)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Todo>>();
            var t = _mapper.Map<Todo>(todo);
            if (t is null) { throw new Exception(); }
            await Context.Todos.AddAsync(t);
            await Context.SaveChangesAsync();
            var dbTodos = await Context.Todos.ToListAsync();
            serviceResponse.Data = dbTodos;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Todo>> GetTodoById(int id)
        {
            var serviceResponse = new ServiceResponse<Todo>();
            try
            {
                var dbTodo = await Context.Todos.FirstOrDefaultAsync(x => x.Id == id);
                if (dbTodo is null)
                {
                    throw new ArgumentException($"Could not find todo with id {id}");
                }
                serviceResponse.Data = dbTodo;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<Todo>>> GetTodos()
        {
            var dbTodos = await Context.Todos.ToListAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<Todo>>
            {
                Data = dbTodos
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<Todo>> UpdateTodo(UpdateTodoRequestDto todo)
        {
            var serviceResponse = new ServiceResponse<Todo>();
            try
            {
                var currentTodo = await Context.Todos.FirstOrDefaultAsync(t => t.Id == todo.Id);
                if (currentTodo is null)
                {
                    throw new ArgumentException($"Todo with id {todo.Id} not found!");
                }
                currentTodo.UpdatedDate = DateTime.UtcNow;
                currentTodo.Description = todo.Description;
                currentTodo.Status = todo.Status;
                currentTodo.Title = todo.Title;
                Context.Update(currentTodo);
                await Context.SaveChangesAsync();
                serviceResponse.Data = currentTodo;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
