using Polly;
using Polly.Extensions.Http;

namespace MashupAPI.Infrastructure.Policies;

public static class HttpClientPolicies
{
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(0.5, retryAttempt)));
    }
}