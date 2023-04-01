using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.gRPC;
using Client.WebUI.Domain.Enums;
using MediatR;

namespace Client.WebUI.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly ITodoItemsService _todoItemsService;
    public UpdateTodoItemDetailCommandHandler(ITodoItemsService todoItemsService)
    => _todoItemsService = todoItemsService;

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        await _todoItemsService.UpdateTodoItemDetailsAsync(new gRPC.UpdateTodoItemDetailsRequest
        {
            Id = request.Id,
            ListId = request.ListId,
            Priority = (PriorityLevelContract)Enum.Parse(typeof(PriorityLevelContract), request.Priority.ToString(), true),
            Note = request.Note,
        });
    }
}
