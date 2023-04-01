using Grpc.Core;
using MediatR;
using Services.Todo.Application.TodoItems.Commands.CreateTodoItem;
using Services.Todo.Application.TodoItems.Commands.DeleteTodoItem;
using Services.Todo.Application.TodoItems.Commands.UpdateTodoItem;
using Services.Todo.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Services.Todo.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Services.Todo.gRPC.Extensions;
using Services.Todo.gRPC.TodoService;

namespace Services.Todo.gRPC.Services;

public class TodoItemsService : TodoItemList.TodoItemListBase
{
    private readonly ISender _mediator;
    public TodoItemsService(ISender mediator)
    {
        _mediator = mediator;
    }

    public override async Task<TodoItemsWithPaginationReply> GetTodoItemsWithPagination(TodoItemsWithPaginationRequest request, ServerCallContext context)
    {
        var results = await _mediator.Send(new GetTodoItemsWithPaginationQuery
        {
            ListId = request.ListId ?? 0,
            PageNumber = request.PageNumber ?? 0,
            PageSize = request.PageSize ?? 0
        });
        return await Task.FromResult(results.ResolveTodoItemsWithPaginationReply());
    }

    public override async Task<EntityIdReply> CreateTodoItem(CreateTodoItemRequest request, ServerCallContext context)
    {
        var resultId = await _mediator.Send(new CreateTodoItemCommand
        {
            ListId = request.ListId ?? 0,
            Title = request.Title
        });
        return await Task.FromResult(new EntityIdReply { Id = resultId });
    }

    public override async Task<Empty> UpdateTodoItem(UpdateTodoItemRequest request, ServerCallContext context)
    {
        await _mediator.Send(new UpdateTodoItemCommand
        {
            Id = request.Id ?? 0,
            Title = request.Title,
            Done = request.Done ?? false
        });
        return await Task.FromResult(new Empty());
    }

    public override async Task<Empty> UpdateTodoItemDetails(UpdateTodoItemDetailsRequest request, ServerCallContext context)
    {
        await _mediator.Send(new UpdateTodoItemDetailCommand
        {
            Id = request.Id ?? 0,
            ListId = request.ListId ?? 0,
            Priority = (Domain.Enums.PriorityLevel)request.Priority,
            Note = request.Note
        });
        return await Task.FromResult(new Empty());
    }

    public override async Task<Empty> DeleteTodoItem(EntityIdRequest request, ServerCallContext context)
    {
        await _mediator.Send(new DeleteTodoItemCommand(request.Id ?? 0));
        return await Task.FromResult(new Empty());
    }
}
