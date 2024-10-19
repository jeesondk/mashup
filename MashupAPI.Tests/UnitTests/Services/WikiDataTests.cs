using System.Net;
using FluentAssertions;
using MashupAPI.Entities.WikiData;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RestSharp;

namespace MashupAPI.Tests.UnitTests.Services;

[Trait("Category", "Unit")]
public class WikiDataTests: IClassFixture<WikiDataServiceFixture>
{
    private readonly ILogger<WikiData> _logger;
    private readonly IMashupMemoryCache _cache;
    private readonly IConfiguration _configuration;
    private readonly RestClient _restClient;

    public WikiDataTests(WikiDataServiceFixture fixture)
    {
        _logger = Substitute.For<ILogger<WikiData>>();
        _cache = Substitute.For<IMashupMemoryCache>();
        _cache.TryGetValue(Arg.Any<string>(), out Arg.Any<Sitelink?>()).Returns(false);
        
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Cache:SlidingExpiration", "60"}
        };
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
        
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(fixture.WikiDataResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClientMock = new HttpClient(mockHandler);
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClientMock);

        var httpClient = httpClientFactory.CreateClient("testClient");
        _restClient = new RestClient(httpClient);
    }

    [Theory]
    [InlineData("Q11649", "enwiki", "Nirvana (band)", "en")]
    [InlineData("Q11649", "dewiki", "Nirvana (US-amerikanische Band)", "de")]
    [InlineData("Q11649", "dawiki", "Nirvana (band)", "da")]
    public async Task CanGetWikiDataById(string id, string site, string title, string language)
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetWikiDataById(id, language);

        //Then
        result?.Site.Should().Be(site);
        result?.Title.Should().Be(title);
    }
    
    [Fact]
    public async Task CanHandleNoWikiDataFound()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));

        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetWikiDataById("jkldnrfg", "en");
        
        //Then
        result.Should().BeNull();
    }

    [Fact]
    public async void CanHandleNotFound()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent(string.Empty)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));
        
        var restClient = new RestClient(httpClient);
        
        var client = new WikiData(_logger, _configuration, restClient, validator, _cache);
        
        //When
        var result = await client.GetWikiDataById("Q11649");
        
        //Then
        result.Should().BeNull();
    }

    [Fact]
    public void CanGetUrlEncodedWikipediaLink()
    {
        //Given
        var entity = new Sitelink("enwiki", "Nirvana (band)", []);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        
        //When
        var result = client.GetWikipediaTitle(entity);
        
        //Then
        result.Should().Be("Nirvana+(band)");
    }
    
    [Fact]
    public void CanHandleNoWikipediaTitle()
    {
        //Given
        var entity = new Sitelink("enwiki", "", []);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = client.GetWikipediaTitle(entity);
        
        //Then
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task CanHandleValidationError()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, string.Empty, string.Empty));
        
        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetWikiDataById("Q11649", "en");

        //Then
        result.Should().BeNull();
    }

    [Fact]
    public async Task CanHandleException()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Throws(new Exception("Test"));
        
        var client = new WikiData(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetWikiDataById("Q11649", "en");

        //Then
        result.Should().BeNull();
    }
}