
using System.Net;
using System.Text.Json;
using FluentAssertions;
using MashupAPI.Entities.Mashup;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MashupAPI.Tests.IntegrationTests.Services;

[Trait("Category", "Integration")]
public class MusicBrainzTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("5b11f4ce-a62d-471e-81fc-a69a8278c7da", "Nirvana")]
    [InlineData("a74b1b7f-71a5-4011-9441-d0b5e4122711", "Radiohead")]
    [InlineData("0383dadf-2a4e-4d10-a46a-e9e041da8eb3", "Queen")]
    [InlineData("a466c2a2-6517-42fb-a160-1087c3bafd9f", "Slipknot")]
    [InlineData("65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab", "Metallica")]
    public async Task CanGetMusicBrainzById(string id, string expected)
    {
        //Given
        var client = factory.CreateClient();
        
        //When
        var response = await client.GetAsync($"/api/v1.0/Mashup?mbid={id}");
        var content = await response.Content.ReadAsStringAsync();
        var responseEntity = JsonSerializer.Deserialize<MashupResponse>(content);
        
        //Then
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().NotBeNullOrEmpty();
        responseEntity?.MbId.Should().Be(id);
        responseEntity?.Description.Should().Contain(expected);
        responseEntity?.Albums.Should().HaveCountGreaterThan(1);
    }
}