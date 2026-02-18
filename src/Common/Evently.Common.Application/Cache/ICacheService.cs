namespace Evently.Common.Application.Cache;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key,CancellationToken cancellationToken = default);
    Task SetAsync<T>(
        string key,
        T value,
        long? expirationInMinutes = null,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
 