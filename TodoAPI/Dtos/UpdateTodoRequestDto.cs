using System.Text.Json;

namespace TodoAPI.Dtos
{
    public class UpdateTodoRequestDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public UpdateTodoRequestDto(int id, string title, string description, string status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
