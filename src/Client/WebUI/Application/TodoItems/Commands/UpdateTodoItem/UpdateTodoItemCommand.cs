using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemsService _todoItemsService;
    public UpdateTodoItemCommandHandler(ITodoItemsService todoItemsService)
    => _todoItemsService = todoItemsService;

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        await _todoItemsService.UpdateTodoItemAsync(new gRPC.UpdateTodoItemRequest
        {
            Id = request.Id,
            Title = request.Title,
            Done = request.Done
        });
    }
}
