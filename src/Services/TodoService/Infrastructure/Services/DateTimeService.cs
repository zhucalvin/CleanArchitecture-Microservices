using Services.Todo.Application.Common.Interfaces;

namespace Services.Todo.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
