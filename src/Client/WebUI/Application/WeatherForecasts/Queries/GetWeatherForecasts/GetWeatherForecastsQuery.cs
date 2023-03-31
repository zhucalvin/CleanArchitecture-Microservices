using Client.WebUI.Application.Common.Interfaces;
using MediatR;

namespace Client.WebUI.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>;

public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
{
    private readonly IWeatherForecastService _weatherForecastService;
    public GetWeatherForecastsQueryHandler(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        var reply = _weatherForecastService.GetWeatherForecast();

        var results = new List<WeatherForecast>();

        results.AddRange(reply.WeatherForecasts.Select(r => new WeatherForecast
        {
            Date = r.Date.ToDateTime(),
            TemperatureC = r.TemperatureC ?? 0,
            TemperatureF = r.TemperatureF ?? 0,
            Summary = r.Summary
        }));

        return results;
    }
}
