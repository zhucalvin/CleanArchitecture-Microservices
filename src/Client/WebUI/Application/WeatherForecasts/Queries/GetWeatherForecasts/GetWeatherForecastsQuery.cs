using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.WeatherForecasts.Queries.Extensions;
using MediatR;

namespace Client.WebUI.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetWeatherForecastsQuery : IRequest<List<WeatherForecast>>;

public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, List<WeatherForecast>>
{
    private readonly IWeatherForecastService _weatherForecastService;
    public GetWeatherForecastsQueryHandler(IWeatherForecastService weatherForecastService)
    => _weatherForecastService = weatherForecastService;

    public async Task<List<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        var results = new List<WeatherForecast>();

        var reply = await _weatherForecastService.GetWeatherForecastAsync();
        if (reply != null)
        {
            results.AddRange(reply.WeatherForecasts.Select(r => r.ConvertToDTO()));
        }

        return results;
    }
}
