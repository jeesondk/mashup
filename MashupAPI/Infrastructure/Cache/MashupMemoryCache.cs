using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Caching.Memory;

namespace MashupAPI.Infrastructure.Cache;

public interface IMashupMemoryCache
{
    void Set(string key, string value);
    bool TryGetValue<T>(string key, out T? value);
}

/// <summary>
/// Memory cache implementation for MashupAPI
/// </summary>
/// <param name="logger"></param>
/// <param name="configuration"></param>
public class MashupMemoryCache(ILogger<MashupMemoryCache> logger, IConfiguration configuration) : IMashupMemoryCache
{
    private MemoryCache Cache { get; } = new (new MemoryCacheOptions());
    
    /// <summary>
    /// Set a value in the cache, with a sliding expiration.
    /// input must be a JSON string
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Set(string key, string value)
    {
        var jsonNode = JsonNode.Parse(value);
        
        if(jsonNode == null)
        {
            logger.LogInformation("Failed to parse JSON for {key}", key);
            return;
        }
        
        var slidingExpiration = configuration.GetValue<int>("Cache:SlidingExpiration");
        Cache.Set(key, value, new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromSeconds(slidingExpiration)});
        logger.LogInformation("Added {key} to cache", key);
    }
    
    /// <summary>
    /// Try to get a value from the cache
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Object of Type T</returns>
    public bool TryGetValue<T>(string key, out T? value)
    {
        Cache.TryGetValue(key, out string? cached);
        if(cached == null)
        {   
            value = default;
            logger.LogInformation("Cache miss for {key}", key);
            return false;
        }
        value = JsonSerializer.Deserialize<T>(cached)!;
        logger.LogInformation("Cache hit for {key}", key);
        return true;
    }
}