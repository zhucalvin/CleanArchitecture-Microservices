using Services.Todo.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using TodoService.gRPC;

namespace Services.Todo.gRPC.Extensions;

public static class WeatherForecastExtensions
{
    public static GetWeatherForecaseReply ResolveWeatherForecaseReply(this IEnumerable<WeatherForecast> toResolveForecasts)
    {
        GetWeatherForecaseReply resolvedReply = new();
        resolvedReply.WeatherForecasts.AddRange(toResolveForecasts.Select(toResolveForecast => new WeatherForecastContract
        {
            Date = toResolveForecast.Date.ConvertToTimestamp(),
            TemperatureC = toResolveForecast.TemperatureC,
            TemperatureF = toResolveForecast.TemperatureF,
            Summary = toResolveForecast.Summary
        }));

        return resolvedReply;
    }
}
