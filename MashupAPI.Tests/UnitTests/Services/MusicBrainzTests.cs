using System.Net;
using System.Text.Json;
using FluentAssertions;
using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Entities.MusicBrainz;
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
public class MusicBrainzTests: IClassFixture<MusicBrainzServiceFixture>
{
    private readonly MusicBrainzServiceFixture _fixture;
    private readonly ILogger<MusicBrainz> _logger;
    private readonly RestClient _restClient;
    private readonly IMashupMemoryCache _cache;
    private readonly IConfigurationRoot _configuration;

    public MusicBrainzTests(MusicBrainzServiceFixture fixture)
    {
        _fixture = fixture;
        _logger = Substitute.For<ILogger<MusicBrainz>>();
        _cache = Substitute.For<IMashupMemoryCache>();
        _cache.TryGetValue(Arg.Any<string>(), out Arg.Any<MusicBrainzResponse?>()).Returns(false);
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Cache:SlidingExpiration", "60"}
        };
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
        
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.MusicBrainzResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        _restClient = new RestClient(httpClient);
    }

    [Fact]
    public async Task CanGetArtistById()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetArtist("5b11f4ce-a62d-471e-81fc-a69a8278c7da");
        
        //Then
        result.Should().NotBeNull();
        result?.Name.Should().Be("Nirvana");
        result?.Name.Should().Be("Nirvana");
    }
    
    [Fact]
    public async Task CanHandleNotSuccessFullGetArtist()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent("Not Found")
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClientMock = new HttpClient(mockHandler);
        
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClientMock);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));

        var httpClient = httpClientFactory.CreateClient("FailingTestClient");
        var restClient = new RestClient(httpClient);
        
        var client = new MusicBrainz(_logger, _configuration, restClient, validator, _cache);
        
        //When
        var result = await client.GetArtist("5b11f4ce-a62d-471e-81fc-a69a8278c7da");
        
        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public void CanGetWikiDataRelation()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzResponse);
        
        //When
        var result = client.GetWikiDataRelation(entity!);
        
        //Then
        result.Should().NotBeNullOrEmpty();
        result.Should().Be("Q11649");
    }
    
    [Fact]
    public void CanHandleNoWikiDataRelations()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzNoRelationsResponse);
        
        //When
        var result = client.GetWikiDataRelation(entity!);
        
        //Then
        result.Should().BeEmpty();
    }
    

    [Fact]
    public void GetWikipediaRelation()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzResponse);
        
        //When
        var result = client.GetWikipediaRelation(entity!);
        
        //Then
        result.Should().NotBeNullOrEmpty();
        result.Should().Be("Nirvana_(band)");
    }
    
    [Fact]
    public void CanHandleNoWikipediaRelations()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzNoRelationsResponse);
        
        //When
        var result = client.GetWikipediaRelation(entity!);
        
        //Then
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task CanHandleValidationError()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzNoRelationsResponse);
        
        //When
        var result = await client.GetArtist("5b11f4ce-a62d-471e-81fc-a69a8278c7da");
        
        //Then
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task CanHandleException()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Throws(new Exception("test"));
        var client = new MusicBrainz(_logger, _configuration, _restClient, validator, _cache);
        
        //When
        var result = await client.GetArtist("5b11f4ce-a62d-471e-81fc-a69a8278c7da");
        
        //Then
        result.Should().BeNull();
    }
}