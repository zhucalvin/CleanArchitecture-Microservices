using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly ITodoItemsService _todoItemsService;

    public CreateTodoItemCommandHandler(ITodoItemsService todoItemsService)
    => _todoItemsService = todoItemsService;

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var reply = await _todoItemsService.CreateTodoItemAsync(new gRPC.CreateTodoItemRequest
        {
            Title = request.Title,
            ListId = request.ListId
        });

        return reply.Id ?? 0;
    }
}
