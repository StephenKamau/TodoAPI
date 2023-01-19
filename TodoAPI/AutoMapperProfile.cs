using AutoMapper;
using TodoAPI.Dtos;
using TodoAPI.Models;

namespace TodoAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddTodoRequestDto, Todo>();
        }
    }
}
