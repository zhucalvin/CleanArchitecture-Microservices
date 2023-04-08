using Client.WebUI.Application.gRPC;
using Client.WebUI.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Client.WebUI.Application.WeatherForecasts.Queries.Extensions;
public static class WeatherForecastExtensions
{
    public static WeatherForecast ConvertToDTO(this WeatherForecastContract toConvertContract)
    {
        return toConvertContract != null
            ? new WeatherForecast
            {
                Date = toConvertContract.Date.ToDateTime(),
                TemperatureC = toConvertContract.TemperatureC ?? 0,
                TemperatureF = toConvertContract.TemperatureF ?? 0,
                Summary = toConvertContract.Summary
            }
            : new WeatherForecast();
    }
}
