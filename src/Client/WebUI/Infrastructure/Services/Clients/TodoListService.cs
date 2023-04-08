using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.gRPC;

namespace Client.WebUI.Infrastructure.Services.Clients;
public class TodoListService : ITodoListService
{
    private readonly TodoItemList.TodoItemListClient _client;
    public TodoListService(TodoItemList.TodoItemListClient client) => _client = client;

    public async Task<EntityIdReply> CreateTodoListAsync(CreateTodoListRequest request)
    {
        return await _client.CreateTodoListAsync(request);
    }

    public async Task DeleteTodoListAsync(EntityIdRequest request) =>
        await _client.DeleteTodoListAsync(request);

    public async Task<GetTodoListReply> GetTodoListAsync()
    {
        return await _client.GetTodoListAsync(new Empty());
    }

    public async Task<TodoListRecordReply> GetTodoListRecordsAsync(TodoListRecordRequest request)
    {
        return await _client.GetTodoListRecordsAsync(request);
    }

    public async Task UpdateTodoListAsync(UpdateTodoListRequest request) =>
        await _client.UpdateTodoListAsync(request);
}
