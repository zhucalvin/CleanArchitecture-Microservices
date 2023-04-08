using Client.WebUI.Application.Common.Interfaces;
using Client.WebUI.Application.gRPC;
using Client.WebUI.Infrastructure.Files;
using Client.WebUI.Infrastructure.Identity;
using Client.WebUI.Infrastructure.Persistence;
using Client.WebUI.Infrastructure.Persistence.Interceptors;
using Client.WebUI.Infrastructure.Services;
using Client.WebUI.Infrastructure.Services.Clients;
using gRPC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        services.AddTransient<ITodoItemsService, TodoItemsService>();
        services.AddTransient<ITodoListService, TodoListService>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }

    // https://learn.microsoft.com/en-us/aspnet/core/grpc/clientfactory?view=aspnetcore-7.0
    public static IServiceCollection RegisterGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<ForecastService.ForecastServiceClient>(o =>
        {
            o.Address = new Uri(configuration.GetValue<string>("TodoServiceEndpoint"));
        });

        services.AddGrpcClient<TodoItemList.TodoItemListClient>(o =>
        {
            o.Address = new Uri(configuration.GetValue<string>("TodoServiceEndpoint"));
        });

        services.AddGrpcClient<Greeter.GreeterClient>(o =>
        {
            o.Address = new Uri(configuration.GetValue<string>("TodoServiceEndpoint"));
        });


        return services;
    }
}
