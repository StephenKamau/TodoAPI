# TodoAPI

This is a simple dotnet web api for managing Todos.

## Schema

` Todo schema `


``` C#
<<<<<<< HEAD
    public class Todo
=======
public class Todo
>>>>>>> e1d0d30d634c14711da9f2a86050d80ebf337379
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public Todo(int id, string title, string description, DateTime createdDate, DateTime updatedDate, string status)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Status = status;
        }

        public Todo() { }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
 ```

