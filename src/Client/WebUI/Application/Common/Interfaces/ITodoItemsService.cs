using Client.WebUI.Application.gRPC;


namespace Client.WebUI.Application.Common.Interfaces;
public interface ITodoItemsService
{
    Task<TodoItemsWithPaginationReply> GetTodoItemsWithPaginationAsync(TodoItemsWithPaginationRequest requst);
    Task<EntityIdReply> CreateTodoItemAsync(CreateTodoItemRequest requst);
    Task UpdateTodoItemAsync(UpdateTodoItemRequest requst);
    Task UpdateTodoItemDetailsAsync(UpdateTodoItemDetailsRequest requst);
    Task DeleteTodoItemAsync(EntityIdRequest requst);
}
