using TodoService.gRPC;

namespace Client.WebUI.Application.Common.Interfaces;
public interface IWeatherForecastService
{
    GetWeatherForecaseReply GetWeatherForecast();
}
