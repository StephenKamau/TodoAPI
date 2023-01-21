# TodoAPI

This is a simple dotnet web api for managing Todos.

## Schema

` Todo schema `

``` C#
    public class Todo
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

