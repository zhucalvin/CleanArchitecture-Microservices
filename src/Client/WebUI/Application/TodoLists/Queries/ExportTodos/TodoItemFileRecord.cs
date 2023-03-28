using Client.WebUI.Application.Common.Mappings;
using Client.WebUI.Domain.Entities;

namespace Client.WebUI.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
