using FluentAssertions;
using MashupAPI.Controllers;
using MashupAPI.Entities.Mashup;
using MashupAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Controllers;

public class MashupControllerTests
{
    [Fact]
    public async Task CanGetMashupById()
    {
        //Given
        const string id = "5b11f4ce-a62d-471e-81fc-a69a8278c7da";
        var mashupService = Substitute.For<IMashup>();
        mashupService.GetMashupByMbid(id).Returns(new MashupResponse(id, "description", new List<Album>()));

        var controller = new MashupController(mashupService);

        //When
        var result = await controller.Get(id) as OkObjectResult;

        //Then
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        result?.Value.Should().BeOfType<MashupResponse>();
        result?.Value.As<MashupResponse>().MbId.Should().Be(id);
        result?.Value.As<MashupResponse>().Description.Should().Be("description");
    }
}