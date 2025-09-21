using Microsoft.Extensions.Caching.Distributed;

namespace Evently.Common.Infrastructure.Caching;

public static class CacheOptions
{
    public static DistributedCacheEntryOptions Default => new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
    };

    public static DistributedCacheEntryOptions CreateOptions(long minutes) => new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes)
    };
}
