using Services.User.Application.Common.Mappings;
using Services.User.Domain.Entities;

namespace Services.User.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
