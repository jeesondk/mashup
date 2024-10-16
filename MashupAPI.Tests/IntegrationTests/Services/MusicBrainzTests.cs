
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MashupAPI.Tests.IntegrationTests.Services;

[Trait("Category", "Integration")]
public class MusicBrainzTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    public MusicBrainzTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
}