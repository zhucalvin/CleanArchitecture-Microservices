using Client.WebUI.Application.Common.Mappings;
using Client.WebUI.Domain.Entities;

namespace Client.WebUI.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
