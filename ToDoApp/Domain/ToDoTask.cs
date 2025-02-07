using System.Text.Json.Serialization;

namespace Domain;

public class ToDoTask
{
    public required int Id { get; set; }
    public required string Title { get; set; }

    public string? Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }

    public int? ParentId { get; set; }
    [JsonIgnore]
    public ToDoTask? Parent { get; set; }
    [JsonIgnore]
    public List<ToDoTask> SubTodos { get; set; } = [];
}