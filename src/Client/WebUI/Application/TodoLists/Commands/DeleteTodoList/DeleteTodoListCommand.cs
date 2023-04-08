using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly ITodoListService _todoListService;

    public DeleteTodoListCommandHandler(ITodoListService todoListService)
    => _todoListService = todoListService;

    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        await _todoListService.DeleteTodoListAsync(new gRPC.EntityIdRequest
        {
            Id = request.Id
        });
    }
}
