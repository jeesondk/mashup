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
using NSubstitute.ExceptionExtensions;
using RestSharp;

namespace MashupAPI.Tests.UnitTests.Services;

[Trait("Category", "Unit")]
public class CoverArtArchiveTests: IClassFixture<CoverArtArchiveServiceFixture>
{
    private readonly CoverArtArchiveServiceFixture _fixture;
    private readonly ILogger<CoverArtArchive> _logger;
    private readonly RestClient _restClient;
    private readonly IMashupMemoryCache _cache;
    private readonly IConfiguration _configuration;

    public CoverArtArchiveTests(CoverArtArchiveServiceFixture fixture)
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
    public async Task CanGetCoveartById()
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
    public async Task CanHandleNotFound()
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
    public async Task CanHandleMalformedResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.CoverartArchiveMalformedResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", "something else"));
        var restClient = new RestClient(httpClient);
        
        var client = new CoverArtArchive(_logger, _configuration, restClient, validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }

    [Fact]
    public async Task CanHandleEmptyResponse()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.CoverartArchiveEmptyResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
       
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", "something else"));
       var restClient = new RestClient(httpClient);
        
        var client = new CoverArtArchive(_logger, _configuration, restClient, validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task CanHandleNotOkStatus()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent("Not Found")
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", "something else"));
        var restClient = new RestClient(httpClient);
        
        var client = new CoverArtArchive(_logger, _configuration, restClient, validator, _cache);
        
        //When
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
    

    [Fact]
    public async Task CanHandleValidationError()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, string.Empty, string.Empty));
        var client = new CoverArtArchive(_logger, _configuration, _restClient, validator, _cache);
        
        //when
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task CanHandleException()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Throws(new Exception("Test"));
        var client = new CoverArtArchive(_logger, _configuration, _restClient, validator, _cache);
        
        //when
        var result = await client.GetCoverArt("c31a5e2b-0bf8-32e0-8aeb-ef4ba9973932");
        
        //Then
        result.Should().BeNull();
    }
    
}

