using Evently.API.Extensions;
using Evently.API.Middlewares;
using Evently.Common.Application;
using Evently.Common.Infrastructure;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Users.Application;
using Evently.Modules.Users.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using EventsApplicationAssemblyReference = Evently.Modules.Events.Application.ApplicationAssemblyReference;
using UsersApplicationAssemblyReference = Evently.Modules.Users.Application.ApplicationAssemblyReference;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Evently API", Version = "v1" }));

builder.Configuration.AddConfiguration(["event"]);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
 

// Common
ApplicationServiceRegister.Register(builder.Services, [
    EventsApplicationAssemblyReference.Assembly,
    UsersApplicationAssemblyReference.Assembly
]);
InfrastructureServiceRegister.Register(builder.Services, builder.Configuration);

// Modules
EventsModuleServiceRegister.Register(builder.Services, builder.Configuration);
UsersModuleServiceRegister.Register(builder.Services, builder.Configuration);


builder.Services
    .AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Cache")!);
 
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Evently API V1");
    options.RoutePrefix = string.Empty;
    app.ApplyMigrations();
});
 
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();


PresentationServiceRegister.MapEndpoints(app);

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
