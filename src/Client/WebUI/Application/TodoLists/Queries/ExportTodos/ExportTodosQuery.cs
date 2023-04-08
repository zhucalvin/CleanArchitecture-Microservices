using AutoMapper;
using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.TodoItems.Extensions;
using MediatR;

namespace Client.WebUI.Application.TodoLists.Queries.ExportTodos;

public record ExportTodosQuery : IRequest<ExportTodosVm>
{
    public int ListId { get; init; }
}

public class ExportTodosQueryHandler : IRequestHandler<ExportTodosQuery, ExportTodosVm>
{
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly ITodoListService _todoListService;

    public ExportTodosQueryHandler(IMapper mapper, ICsvFileBuilder fileBuilder, ITodoListService todoListService)
    {
        _mapper = mapper;
        _fileBuilder = fileBuilder;
        _todoListService = todoListService;
    }

    public async Task<ExportTodosVm> Handle(ExportTodosQuery request, CancellationToken cancellationToken)
    {
        var reply = await _todoListService.GetTodoListRecordsAsync(new gRPC.TodoListRecordRequest { ListId = request.ListId });

        var vm = new ExportTodosVm(
            "TodoItems.csv",
            "text/csv",
            _fileBuilder.BuildTodoItemsFile(reply.Records.ResolveTodoListRecords()));

        return vm;
    }
}
