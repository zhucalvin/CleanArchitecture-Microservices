using Services.Todo.Application.Common.Mappings;
using Services.Todo.Domain.Entities;

namespace Services.Todo.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
