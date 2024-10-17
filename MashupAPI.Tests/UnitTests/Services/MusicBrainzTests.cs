using System.Net;
using System.Text.Json;
using FluentAssertions;
using MashupAPI.Entities.MusicBrainz;
using MashupAPI.Infrastructure.Validator;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using MashupAPI.Tests.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Services;

[Trait("Category", "Unit")]
public class MusicBrainzTests: IClassFixture<MusicBrainzServiceFixture>
{
    private readonly MusicBrainzServiceFixture _fixture;
    private readonly ILogger<MusicBrainz> _logger;
    private readonly HttpClient _httpClient;
    public MusicBrainzTests(MusicBrainzServiceFixture fixture)
    {
        _fixture = fixture;
        _logger = Substitute.For<ILogger<MusicBrainz>>();
        
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_fixture.MusicBrainzResponse)
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://musicbrainz.org/ws/2");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

        _httpClient = httpClientFactory.CreateClient("testClient");
    }

    [Fact]
    public async void CanGetArtistById()
    {
        //Given
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((true, string.Empty, string.Empty));
        var client = new MusicBrainz(_logger, _httpClient, validator);
        
        //When
        var result = await client.GetArtist("5b11f4ce-a62d-471e-81fc-a69a8278c7da");
        
        //Then
        result.Should().NotBeNull();
        result?.Name.Should().Be("Nirvana");
        result?.Name.Should().Be("Nirvana");
    }
    
    [Fact]
    public async void CanHandleNotSuccessFullGetArtist()
    {
        //Given
        var response = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent("Not Found")
        };
        var mockHandler = new MockHttpMessageHandler(response);
        var httpClient = new HttpClient(mockHandler);
        httpClient.BaseAddress = new Uri("https://musicbrainz.org/ws/2");
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        var validator = Substitute.For<IJsonValidator>();
        validator.ValidateJson(Arg.Any<string>(), Arg.Any<string>()).Returns((false, "something", string.Empty));
        
        var client = new MusicBrainz(_logger, httpClientFactory.CreateClient("FailingTestClient"), validator);
        
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
        
        var client = new MusicBrainz(_logger, _httpClient, validator);
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
        
        var client = new MusicBrainz(_logger, _httpClient, validator);
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
        
        var client = new MusicBrainz(_logger, _httpClient, validator);
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
        var client = new MusicBrainz(_logger, _httpClient, validator);
        var entity = JsonSerializer.Deserialize<MusicBrainzResponse>(_fixture.MusicBrainzNoRelationsResponse);
        
        //When
        var result = client.GetWikipediaRelation(entity!);
        
        //Then
        result.Should().BeEmpty();
    }
}