using Client.WebUI.Application.Common.Models;
using Client.WebUI.Application.gRPC;
using Client.WebUI.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Client.WebUI.Application.TodoLists.Queries.ExportTodos;
using Google.Protobuf.Collections;

namespace Client.WebUI.Application.TodoItems.Extensions;
public static class TodoItemsExtensions
{
    public static PaginatedList<TodoItemBriefDto> ResolvePaginatedList(this TodoItemsWithPaginationReply toResolveReply)
    {
        return new PaginatedList<TodoItemBriefDto>(toResolveReply.TodoItems.ResolveTodoItemBriefDTOs(), toResolveReply.TotalCount ?? 0, toResolveReply.TotalPages ?? 0, toResolveReply.PageNumber ?? 0);
    }

    public static List<TodoItemRecord> ResolveTodoListRecords(this RepeatedField<TodoListRecordContract> toResolveRecords)
    {
        List<TodoItemRecord> resolvedRecords = new();

        resolvedRecords.AddRange(toResolveRecords.Select(r => new TodoItemRecord
        {
            Title = r.Title,
            Done = r.Done ?? false
        }));

        return resolvedRecords;
    }


    public static List<TodoItemBriefDto> ResolveTodoItemBriefDTOs(this RepeatedField<TodoItemBriefContract> toResolveContracts)
    {
        List<TodoItemBriefDto> results = new();

        if (toResolveContracts != null)
        {
            results.AddRange(toResolveContracts.Select(contract => new TodoItemBriefDto
            {
                Id = contract.Id ?? 0,
                ListId = contract.ListId ?? 0,
                Title = contract.Title,
                Done = contract.Done ?? false
            }));
        }

        return results;
    }

}
