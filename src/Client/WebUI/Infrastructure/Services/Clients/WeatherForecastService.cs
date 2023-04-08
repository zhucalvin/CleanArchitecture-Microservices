using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.gRPC;

namespace Client.WebUI.Infrastructure.Services.Clients;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ForecastService.ForecastServiceClient _client;
    public WeatherForecastService(ForecastService.ForecastServiceClient client) => _client = client;

    public async Task<GetWeatherForecaseReply> GetWeatherForecastAsync()
    {
        return await _client.GetWeatherForecastAsync(new NonParameters());
    }
}
