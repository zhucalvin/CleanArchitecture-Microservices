using Client.WebUI.Application.gRPC;

namespace Client.WebUI.Application.Common.Interfaces;
public interface IWeatherForecastService
{
    Task<GetWeatherForecaseReply> GetWeatherForecastAsync();
}
