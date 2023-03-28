using Services.Todo.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

// Add Grpc Reflection for Postman service reflection
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<TodoItemsService>();
app.MapGrpcService<TodoListService>();
app.MapGrpcService<WeatherForecastService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Mapping Grpc Reflection in Development environment only for Postman service reflection
IWebHostEnvironment env = app.Environment;
if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();
