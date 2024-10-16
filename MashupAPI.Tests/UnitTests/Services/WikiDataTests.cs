using System.Net;
using FluentAssertions;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Services;

public class WikiDataTests: IClassFixture<WikiDataServiceFixture>
{
    private readonly WikiDataServiceFixture _fixture;
    private readonly ILogger<WikiData> _logger;
    private readonly HttpClient _httpClient;

    public WikiDataTests(WikiDataServiceFixture fixture)
    {
        _fixture = fixture;
        _logger = Substitute.For<ILogger<WikiData>>();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.WikiDataResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://www.wikidata.org/w/api.php");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

        _httpClient = httpClientFactory.CreateClient("testClient");
    }

    [Theory]
    [InlineData("Q11649", "enwiki", "Nirvana (band)", "en")]
    [InlineData("Q11649", "dewiki", "Nirvana (US-amerikanische Band)", "de")]
    [InlineData("Q11649", "dawiki", "Nirvana (band)", "da")]
    public void CanGetWikiDataById(string id, string site, string title, string language)
    {
        //Given
        var client = new WikiData(_logger, _httpClient);
        
        //When
        var result = client.GetWikiDataById(id, language);

        //Then
        result.Site.Should().Be(site);
        result.Title.Should().Be(title);
    }
}