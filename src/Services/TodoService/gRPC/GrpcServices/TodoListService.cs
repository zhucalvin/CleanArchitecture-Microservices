using Grpc.Core;
using MediatR;
using Services.Todo.Application.TodoLists.Commands.DeleteTodoList;
using Services.Todo.Application.TodoLists.Commands.UpdateTodoList;
using Services.Todo.Application.TodoLists.Queries.GetTodos;
using Services.Todo.gRPC.Extensions;
using TodoService.gRPC;

namespace Services.Todo.gRPC.Services;

public class TodoListService : TodoItemList.TodoItemListBase
{
    private readonly ISender _mediator;
    public TodoListService(ISender mediator)
    {
        _mediator = mediator;
    }

    public override async Task<GetTodoListReply> GetTodoList(Empty request, ServerCallContext context)
    {
        var results = await _mediator.Send(new GetTodosQuery());
        return await Task.FromResult(results.ResolveGetTodoListReply());
    }

    public override async Task<Empty> UpdateTodoList(UpdateTodoListRequest request, ServerCallContext context)
    {
        await _mediator.Send(new UpdateTodoListCommand
        {
            Id = request.Id ?? 0,
            Title = request.Title
        });
        return await Task.FromResult(new Empty());
    }

    public override async Task<Empty> DeleteTodoList(EntityIdRequest request, ServerCallContext context)
    {
        await _mediator.Send(new DeleteTodoListCommand(request.Id ?? 0));
        return await Task.FromResult(new Empty());
    }
}
