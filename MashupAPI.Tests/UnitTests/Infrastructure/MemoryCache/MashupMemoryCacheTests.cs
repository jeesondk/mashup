using System.Text.Json;
using FluentAssertions;
using MashupAPI.Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Infrastructure.MemoryCache;

public class MashupMemoryCacheTests
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<MashupMemoryCache> _logger;

    public MashupMemoryCacheTests()
    {
        _logger = Substitute.For<ILogger<MashupMemoryCache>>();
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Cache:SlidingExpiration", "60"}
        };
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
    }
    
    [Fact]
    public void CanGetCacheInstance()
    {
        //Given
        
        //When
        var cache = new MashupMemoryCache(_logger, _configuration);
        
        //Then
        cache.Should().NotBeNull();
    }
    
    [Fact]
    public void CanSetCacheValue()
    {
        //Given
        var cache = new MashupMemoryCache(_logger, _configuration);
        
        //When
        var act = () => cache.Set("test", JsonSerializer.Serialize(new TestItem()));
        cache.TryGetValue("test", out TestItem? _);
        
        //Then
        act.Should().NotThrow();
    }
    
    [Fact]
    public void CanGetCacheValue()
    {
        //Given
        var cache = new MashupMemoryCache(_logger, _configuration);
        cache.Set("test", JsonSerializer.Serialize(new TestItem()));
        
        //When
        Action act = () => cache.TryGetValue("test", out TestItem? _);
        cache.TryGetValue("test", out TestItem? result);
        
        //Then
        act.Should().NotThrow();
        result.Should().BeEquivalentTo(new TestItem());
    }

    private class TestItem
    {
#pragma warning disable CS0414 // Field is assigned but its value is never used
        public string Topic = "test";
#pragma warning restore CS0414 // Field is assigned but its value is never used
    }
}
