using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoItemsService _todoItemsService;

    public DeleteTodoItemCommandHandler(ITodoItemsService todoItemsService)
    => _todoItemsService = todoItemsService;

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        await _todoItemsService.DeleteTodoItemAsync(new gRPC.EntityIdRequest
        {
            Id = request.Id
        });
    }
}
