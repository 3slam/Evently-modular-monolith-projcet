using System.Reflection;

namespace Evently.Modules.Events.Application;

public static class ApplicationAssemblyReference
{
    public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
}