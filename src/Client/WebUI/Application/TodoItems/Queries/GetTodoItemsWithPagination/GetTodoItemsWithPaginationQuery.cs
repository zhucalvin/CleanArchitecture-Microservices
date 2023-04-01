using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.Common.Models;
using Client.WebUI.Application.gRPC;
using Client.WebUI.Application.TodoItems.Extensions;
using MediatR;

namespace Client.WebUI.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
{
    private readonly ITodoItemsService _todoItemsService;

    public GetTodoItemsWithPaginationQueryHandler(ITodoItemsService todoItemsService)
    => _todoItemsService = todoItemsService;

    public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var reply = await _todoItemsService.GetTodoItemsWithPaginationAsync(new TodoItemsWithPaginationRequest
        {
            ListId = request.ListId,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        });

        return reply.ResolvePaginatedList();
    }
}
