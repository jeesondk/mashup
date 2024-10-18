using System.Net;
using FluentAssertions;
using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using RestSharp;

namespace MashupAPI.Tests.UnitTests.Services;

[Trait("Category", "Unit")]
public class CoverArtArchiveTests: IClassFixture<CoverartArchiveServiceFixture>
{
    private readonly CoverartArchiveServiceFixture _fixture;
    private readonly ILogger<CoverArtArchive> _logger;
    private readonly RestClient _restClient;
    private readonly IMashupMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public CoverArtArchiveTests(CoverartArchiveServiceFixture fixture)
    {
        _fixture = fixture;
        _logger = Substitute.For<ILogger<CoverArtArchive>>();
        _cache = Substitute.For<IMashupMemoryCache>();
        _cache.TryGetValue(Arg.Any<string>(), out Arg.Any<CoverArtResponse?>()).Returns(false);
        
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Cache:SlidingExpiration", "60"}
        };
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
        
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.CoverartArchiveResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        _restClient = new RestClient(httpClient);
    }

    [Fact]
    public async void CanGetCoveartById()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        var client = new CoverArtArchive(_logger, _configuration, _restClient, validator, _cache);
        
        //when
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result?.Images[0].ImageUrl.Should().Be("http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075.png");
    }
    
    [Fact]
    public async void CanHandleNotFound()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent("Not Found")
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://coverartarchive.org");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));

        var client = new CoverArtArchive(_logger, _configuration, _restClient,validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public async void CanHandleMalformedResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.CoverartArchiveMalformedResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://coverartarchive.org");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", "something else"));

        var client = new CoverArtArchive(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }

    [Fact]
    public async void CanHandleEmptyResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.CoverartArchiveEmptyResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://coverartarchive.org");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", "something else"));
        
        var client = new CoverArtArchive(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
}

