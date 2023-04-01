namespace Client.WebUI.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public readonly record struct WeatherForecast(DateTime Date, int TemperatureC, int TemperatureF, string? Summary);
