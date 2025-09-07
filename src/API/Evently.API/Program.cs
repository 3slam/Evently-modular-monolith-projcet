using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Evently API", Version = "v1" }));

EventsModuleServiceRegister.AddEventsModule(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Evently API V1");
    options.RoutePrefix = string.Empty;
});
 
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<EventsDbContext>();
dbContext.Database.Migrate();


app.UseHttpsRedirection();
 
EventsEndpoints.MapEndpoints(app);



app.Run();
