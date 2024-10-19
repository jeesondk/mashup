using FluentAssertions;
using MashupAPI.Infrastructure.Policies;

namespace MashupAPI.Tests.UnitTests.Infrastructure.Policies;

public class PoliciesTests
{
    [Fact]
    public void ShouldHaveCorrectPolicies()
    {
        //Given
        /*
         * Redundant in the test as we are marshaling a static class, but it's a good practice to have it here
         */
        
        //When
        var polices = HttpClientPolicies.GetRetryPolicy();
        
        //Then
        polices.Should().NotBeNull();
    }
}