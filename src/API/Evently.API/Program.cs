using Evently.API.Extensions;
using Evently.API.Middlewares;
using Evently.Common.Application;
using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Events.Presentation;
using Microsoft.OpenApi.Models;
using Serilog;
using EventsApplicationAssemblyReference = Evently.Modules.Events.Application.ApplicationAssemblyReference;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Evently API", Version = "v1" }));

builder.Configuration.AddConfiguration(["event"]);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

ApplicationServiceRegister.Register(builder.Services, [EventsApplicationAssemblyReference.Assembly]);
EventsModuleServiceRegister.Register(builder.Services, builder.Configuration);

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

EventsModuleEndpoints.Map(app);
 
app.Run();
