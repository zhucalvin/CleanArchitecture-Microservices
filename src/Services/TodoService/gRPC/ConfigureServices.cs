using Services.Todo.Application.Common.Interfaces;
using Services.Todo.gRPC.Services;
using Services.Todo.Infrastructure.Persistence;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

        //services.AddControllersWithViews();

        //services.AddRazorPages();

        //services.AddScoped<FluentValidationSchemaProcessor>(provider =>
        //{
        //    var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
        //    var loggerFactory = provider.GetService<ILoggerFactory>();

        //    return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        //});

        //// Customise default API behaviour
        //services.Configure<ApiBehaviorOptions>(options =>
        //    options.SuppressModelStateInvalidFilter = true);

        //services.AddOpenApiDocument((configure, serviceProvider) =>
        //{
        //    var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

        //    // Add the fluent validations schema processor
        //    configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

        //    configure.Title = "CleanArchitecture API";
        //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = OpenApiSecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = OpenApiSecurityApiKeyLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //    });

        //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //});

        return services;
    }
}
