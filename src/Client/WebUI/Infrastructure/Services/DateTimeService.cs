using Client.WebUI.Application.Common.Interfaces;

namespace Client.WebUI.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
