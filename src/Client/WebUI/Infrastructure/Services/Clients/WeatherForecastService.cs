using Client.WebUI.Application.Common.Interfaces;
using TodoService.gRPC;

namespace Client.WebUI.Infrastructure.Services.Clients;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ForecastService.ForecastServiceClient _client;
    public WeatherForecastService(ForecastService.ForecastServiceClient client)
    {
        _client = client;
    }

    public GetWeatherForecaseReply GetWeatherForecast()
    {
        return _client.GetWeatherForecast(new NonParameters());
    }
}
