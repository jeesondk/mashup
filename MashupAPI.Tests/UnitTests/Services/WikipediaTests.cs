using System.Net;
using FluentAssertions;
using MashupAPI.Entities.Wikipedia;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Services;

[Trait("Category", "Unit")]
public class WikipediaTests: IClassFixture<WikipediaServiceFixture>
{
    private readonly WikipediaServiceFixture _fixture;
    private readonly ILogger<Wikipedia> _logger;
    private readonly HttpClient _httpClient;
    private readonly IMashupMemoryCache _cache;

    public WikipediaTests(WikipediaServiceFixture fixture)
    {
        _fixture = fixture;
        _logger = Substitute.For<ILogger<Wikipedia>>();
        _cache = Substitute.For<IMashupMemoryCache>();
        _cache.TryGetValue(Arg.Any<string>(), out Arg.Any<WikiResponse?>()).Returns(false);
        
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.WikipediaResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://en.wikipedia.org/w/api.php");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

        _httpClient = httpClientFactory.CreateClient("testClient");
    }
    
    [Fact]
    public async void CanGetWikipediaPageByTitle()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new Wikipedia(_logger, _httpClient, validator, _cache);
        
        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.Should().NotBeNull();
        result?.batchcomplete.Should().Be("");
        result?.query.pages[0]?.title.Should().Be("Nirvana (band)");
    }

    [Fact]
    public async void CanHandleMalformedResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.WikipediaMalformedResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://en.wikipedia.org/w/api.php");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));
        
        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"), validator, _cache);
        
        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public async void CanHandleErrorResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent(string.Empty)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://en.wikipedia.org/w/api.php");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));

        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"), validator, _cache);

        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.Should().BeNull();
    }

    [Fact]
    public async void CanHandleNotFound()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.WikipediaNoContentResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://en.wikipedia.org/w/api.php");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, string.Empty, string.Empty));

        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"), validator, _cache);

        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.Should().BeNull();
    }
}