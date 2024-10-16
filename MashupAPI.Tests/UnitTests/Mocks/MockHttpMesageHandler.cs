namespace MashupAPI.Tests.UnitTests.Mocks;

public class MockHttpMessageHandler(HttpResponseMessage responseMessage) : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(responseMessage);
    }
}