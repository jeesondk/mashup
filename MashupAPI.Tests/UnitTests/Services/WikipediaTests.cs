using System.Net;
using FluentAssertions;
using MashupAPI.Entities.Wikipedia;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Services;

public class WikipediaTests: IClassFixture<WikiDataServiceFixture>
{
    private readonly WikipediaServiceFixture _fixture;
    private readonly ILogger<Wikipedia> _logger;
    private readonly HttpClient _httpClient;

    public WikipediaTests()
    {
        _fixture = new WikipediaServiceFixture();
        _logger = Substitute.For<ILogger<Wikipedia>>();
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
        var client = new Wikipedia(_logger, _httpClient);
        
        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.batchcomplete.Should().Be("");
        result.query.pages[0]?.title.Should().Be("Nirvana (band)");
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
        
        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"));
        
        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.batchcomplete.Should().Be("");
        result.query.pages[0]?.extract.Should().Be(string.Empty);
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

        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"));

        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.Should().BeEquivalentTo(new WikiResponse(string.Empty, new Warnings(new Extracts(string.Empty)), new Query([])));
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

        var client = new Wikipedia(_logger, httpClientFactory.CreateClient("MalformedResponse"));

        //When
        var result = await client.GetWikipediaPageByTitle("Nirvana+(band)");

        //Then
        result.batchcomplete.Should().Be("");
        result.query.pages[0]?.pageid.Should().Be(0);
    }
}