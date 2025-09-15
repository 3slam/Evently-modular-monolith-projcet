namespace Evently.API.Extensions;

public static class ConfigurationExtensions
{
    public static void AddConfiguration(this IConfigurationBuilder configuration, string[] jsonFileNames)
    {
        foreach (var item in jsonFileNames)
        {
            configuration.AddJsonFile($"module.{item}.json", optional: false, reloadOnChange: true);
            configuration.AddJsonFile($"module.{item}.Development.json", optional: false, reloadOnChange: true);
        }
    }
}
