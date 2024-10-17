using FluentAssertions;
using MashupAPI.Infrastructure.Validator;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Infrastructure.Validator;

[Trait("Category", "Unit")]
public class JsonValidatorTests
{
    private readonly ILogger<JsonValidator> _logger;
    private readonly JsonValidator _validator;

    public JsonValidatorTests()
    {
        _logger = Substitute.For<ILogger<JsonValidator>>();
        _validator = new JsonValidator(_logger);
    }

    [Fact]
    public void CanValidateJson()
    {
        //Given
        var schema = """
            {
                "$schema": "http://json-schema.org/draft-07/schema#",
                "type": "object",
                "properties": {
                    "name": { "type": "string" },
                    "age": { "type": "integer", "minimum": 0 }
                },
                "required": ["name", "age"]
            }
        """;
        var json = """{ "name": "John", "age": 30 }""";

        //When
        var result = _validator.ValidateJson(schema, json);

        //Then
        result.result.Should().BeTrue();
        result.details.Should().BeEmpty();
        result.errors.Should().BeEmpty();
    }

    [Fact]
    public void CanHandleInvalidJson()
    {
        //Given
        var schema = """
            {
                "$schema": "http://json-schema.org/draft-07/schema#",
                "type": "object",
                "properties": {
                    "name": { "type": "string" },
                    "age": { "type": "integer", "minimum": 0 }
                },
                "required": ["name", "age"]
            }
        """;
        var json = """{ "name": "John", "age": -5 }""";

        //When
        var result = _validator.ValidateJson(schema, json);

        //Then
        result.result.Should().BeFalse();
        result.details.Should().Contain("age");
        result.errors.Should().Be("{}");
    }


    [Fact] public void CanHandleMissingRequiresProp()
    {
        //Given
        var schema = """
            {
                "$schema": "http://json-schema.org/draft-07/schema#",
                "type": "object",
                "properties": {
                    "name": { "type": "string" },
                    "age": { "type": "integer", "minimum": 0 }
                },
                "required": ["name", "age"]
            }
        """;
        var json = """{ "name": "John" }""";

        //When
        var result = _validator.ValidateJson(schema, json);

        //Then
        result.result.Should().BeFalse();
        result.details.Should().Contain("name");
        result.errors.Should().Contain("age");
        
    }
}