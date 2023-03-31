using Grpc.Core;
using MediatR;
using Services.Todo.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Services.Todo.gRPC.Extensions;
using TodoService.gRPC;

namespace Services.Todo.gRPC.Services;

public class WeatherForecastService : ForecastService.ForecastServiceBase
{
    private readonly ISender _mediator;
    public WeatherForecastService(ISender mediator)
    {
        _mediator = mediator;
    }

    public override async Task<GetWeatherForecaseReply> GetWeatherForecast(NonParameters request, ServerCallContext context)
    {
        var result = await _mediator.Send(new GetWeatherForecastsQuery());
        return await Task.FromResult(result.ResolveWeatherForecaseReply());
    }
}
