using System.Globalization;
using Services.User.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace Services.User.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
