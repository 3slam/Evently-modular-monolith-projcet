using Evently.API.Extensions;
using Evently.Common.Application;
using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Events.Presentation;
using Microsoft.OpenApi.Models;
using EventsApplicationAssemblyReference = Evently.Modules.Events.Application.ApplicationAssemblyReference;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Evently API", Version = "v1" }));

builder.Configuration.AddConfiguration(["event"]);

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

EventsModuleEndpoints.Map(app);
 
app.Run();
