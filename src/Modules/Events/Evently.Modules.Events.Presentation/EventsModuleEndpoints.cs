using Evently.Modules.Events.Presentation.Categories;
using Evently.Modules.Events.Presentation.TicketTypes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Evently.Modules.Events.Presentation;

public static class EventsModuleEndpoints
{
    public static void AddEndpoints(this IServiceCollection serviceCollection)
    {
        serviceCollection.RegisterAllClassesThatImplementIEndpoint(EventsPresentationAssemblyReference.Assembly);
    }

}
public static class EventsPresentationAssemblyReference
{
    public static readonly Assembly Assembly = typeof(EventsPresentationAssemblyReference).Assembly;
}