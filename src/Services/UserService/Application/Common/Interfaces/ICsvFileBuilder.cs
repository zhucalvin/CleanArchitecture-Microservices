using Services.User.Application.TodoLists.Queries.ExportTodos;

namespace Services.User.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
