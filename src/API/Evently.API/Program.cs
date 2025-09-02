using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Events.Presentation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Evently API",
        Version = "v1",
        Description = "API for managing events",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
});

EventsModuleServiceRegister.AddEventsModule(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Evently API V1");
        options.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

EventsEndpoints.MapEndpoints(app);

app.Run();
