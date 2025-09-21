using Evently.Common.Application.Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace Evently.Common.Infrastructure.Caching;

internal class CacheService(IDistributedCache distributedCache) : ICacheService
{
    public async Task<T?> GetAsync<T>(string key,CancellationToken cancellationToken = default)
    {
        var result = await distributedCache.GetAsync(key, cancellationToken);

        return Deserialize<T>(result);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(key, cancellationToken);
    }

    public async Task SetAsync<T>(
        string key,
        T value,
        long? expirationInMinutes = null,
        CancellationToken cancellationToken = default)
    {
        var bytes = Serialize(value);
        await distributedCache.SetAsync(
            key,
            bytes,
            expirationInMinutes.HasValue ? CacheOptions.CreateOptions(expirationInMinutes.Value)  : CacheOptions.Default,
            cancellationToken);
    }

    private byte[] Serialize<T>(T value)
    {
        if (value is null)
            return Array.Empty<byte>();
        var json = System.Text.Json.JsonSerializer.Serialize(value);
        return System.Text.Encoding.UTF8.GetBytes(json);
    }
    private T? Deserialize<T>(byte[]? bytes)
    {
        if (bytes is null || bytes.Length == 0)
            return default(T);
        var json = System.Text.Encoding.UTF8.GetString(bytes);
        return System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }

    
}