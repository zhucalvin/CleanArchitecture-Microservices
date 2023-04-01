using Google.Protobuf.Collections;
using Services.Todo.Application.Common.Models;
using Services.Todo.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Services.Todo.Application.TodoLists.Queries.ExportTodos;
using Services.Todo.Application.TodoLists.Queries.GetTodos;
using Services.Todo.gRPC.TodoService;

namespace Services.Todo.gRPC.Extensions;

public static class TodoListItemExtensions
{
    public static GetTodoListReply ResolveGetTodoListReply(this TodosVm toResolveReply)
    {
        GetTodoListReply resolvedReply = new();
        resolvedReply.PriorityLevels.AddRange(toResolveReply.PriorityLevels.ResolvePriorityLevelContracts());
        resolvedReply.Lists.AddRange(toResolveReply.Lists.ResolveToDoListContracts());

        return resolvedReply;
    }

    public static RepeatedField<TodoListRecordContract> ResolveTodoListRecordContracts(this List<TodoItemRecord> toResolveRecords)
    {
        RepeatedField<TodoListRecordContract> resolvedRecords = new();

        resolvedRecords.AddRange(toResolveRecords.Select(r => new TodoListRecordContract
        {
            Title = r.Title,
            Done = r.Done
        }));

        return resolvedRecords;
    }

    public static RepeatedField<TodoListContract> ResolveToDoListContracts(this IReadOnlyCollection<TodoListDto> toResolveDTO)
    {
        RepeatedField<TodoListContract> resolvedList = new();

        toResolveDTO.ToList().ForEach(result =>
        {
            var converted = new TodoListContract
            {
                Id = result.Id,
                Title = result.Title,
                Colour = result.Colour
            };
            converted.Items.AddRange(result.Items.ResolveToDoItemContracts());
            resolvedList.Add(converted);
        });

        return resolvedList;
    }

    public static RepeatedField<TodoItemContract> ResolveToDoItemContracts(this IReadOnlyCollection<TodoItemDto> toResolveDTO)
    {
        RepeatedField<TodoItemContract> resolvedContracts = new();

        resolvedContracts.AddRange(toResolveDTO.Select(result => new TodoItemContract
        {
            Id = result.Id,
            ListId = result.ListId,
            Title = result.Title,
            Done = result.Done,
            Priority = (PriorityLevelContract)result.Priority,
            Note = result.Note
        }));

        return resolvedContracts;
    }

    public static RepeatedField<LookupItemContract> ResolvePriorityLevelContracts(this IReadOnlyCollection<PriorityLevelDto> toResolveLookups)
    {
        RepeatedField<LookupItemContract> lookups = new();

        lookups.AddRange(toResolveLookups.Select(result => new LookupItemContract
        {
            Value = result.Value,
            Name = result.Name
        }));

        return lookups;
    }

    public static TodoItemsWithPaginationReply ResolveTodoItemsWithPaginationReply(this PaginatedList<TodoItemBriefDto> toResolveList)
    {
        var reply = new TodoItemsWithPaginationReply
        {
            PageNumber = toResolveList.PageNumber,
            TotalPages = toResolveList.TotalPages,
            TotalCount = toResolveList.TotalCount
        };
        reply.TodoItems.AddRange(toResolveList.Items.ResolveTodoItemBriefContracts());

        return reply;
    }

    public static RepeatedField<TodoItemBriefContract> ResolveTodoItemBriefContracts(this IReadOnlyCollection<TodoItemBriefDto> toResolveDTOs)
    {
        RepeatedField<TodoItemBriefContract> results = new();

        results.AddRange(toResolveDTOs.Select(result => new TodoItemBriefContract
        {
            Id = result.Id,
            ListId = result.ListId,
            Title = result.Title,
            Done = result.Done
        }));

        return results;
    }
}
