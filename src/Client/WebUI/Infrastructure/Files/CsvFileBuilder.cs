using System.Globalization;
using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.TodoLists.Queries.ExportTodos;
using Client.WebUI.Infrastructure.Files.Maps;
using CsvHelper;

namespace Client.WebUI.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
