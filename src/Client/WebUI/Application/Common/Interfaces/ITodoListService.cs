using Client.WebUI.Application.gRPC;


namespace Client.WebUI.Application.Common.Interfaces;
public interface ITodoListService
{
    Task<GetTodoListReply> GetTodoListAsync();
    Task<TodoListRecordReply> GetTodoListRecordsAsync(TodoListRecordRequest request);
    Task<EntityIdReply> CreateTodoListAsync(CreateTodoListRequest request);
    Task UpdateTodoListAsync(UpdateTodoListRequest request);
    Task DeleteTodoListAsync(EntityIdRequest request);
}
