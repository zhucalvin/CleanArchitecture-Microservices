using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
{
    private readonly ITodoListService _todoListService;
    public CreateTodoListCommandHandler(ITodoListService todoListService)
    => _todoListService = todoListService;

    public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var reply = await _todoListService.CreateTodoListAsync(new gRPC.CreateTodoListRequest
        {
            Title = request.Title
        });

        return reply.Id ?? 0;
    }
}
