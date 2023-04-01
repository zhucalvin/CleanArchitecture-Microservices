using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.gRPC;

namespace Client.WebUI.Infrastructure.Services.Clients;
public class TodoItemsService : ITodoItemsService
{
    private readonly TodoItemList.TodoItemListClient _client;
    public TodoItemsService(TodoItemList.TodoItemListClient client)
    => _client = client;

    public async Task<EntityIdReply> CreateTodoItemAsync(CreateTodoItemRequest requst)
    {
        return await _client.CreateTodoItemAsync(requst);
    }

    public async Task DeleteTodoItemAsync(EntityIdRequest requst)
    => await _client.DeleteTodoItemAsync(requst);

    public async Task<TodoItemsWithPaginationReply> GetTodoItemsWithPaginationAsync(TodoItemsWithPaginationRequest requst)
    {
        return await _client.GetTodoItemsWithPaginationAsync(requst);
    }

    public async Task UpdateTodoItemAsync(UpdateTodoItemRequest requst)
    => await _client.UpdateTodoItemAsync(requst);

    public async Task UpdateTodoItemDetailsAsync(UpdateTodoItemDetailsRequest requst)
    => await _client.UpdateTodoItemDetailsAsync(requst);
}
