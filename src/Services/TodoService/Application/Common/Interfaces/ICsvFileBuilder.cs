using Services.Todo.Application.TodoLists.Queries.ExportTodos;

namespace Services.Todo.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
