using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoLists.Commands.UpdateTodoList;

public record UpdateTodoListCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
{
    private readonly ITodoListService _todoListService;

    public UpdateTodoListCommandHandler(ITodoListService todoListService)
    => _todoListService = todoListService;

    public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        await _todoListService.UpdateTodoListAsync(new gRPC.UpdateTodoListRequest
        {
            Id = request.Id,
            Title = request.Title
        });
    }
}
