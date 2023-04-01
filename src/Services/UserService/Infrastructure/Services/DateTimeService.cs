using Services.User.Application.Common.Interfaces;

namespace Services.User.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
