using System.Text.Json;

namespace TodoAPI.Dtos
{
    public class AddTodoRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

        public AddTodoRequestDto( string title, string description, DateTime updatedDate, string status)
        {           
            Title = title;
            Description = description;
            UpdatedDate = updatedDate;
            Status = status;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
