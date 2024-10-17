using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;

namespace MashupAPI.Infrastructure.Validator;

public interface IJsonValidator
{
    (bool result, string details, string errors) ValidateJson(string schema, string json);
}

public class JsonValidator(ILogger<JsonValidator> logger) : IJsonValidator
{
    public (bool result, string details, string errors) ValidateJson(string schema, string json)
    {
        try
        {
            var jsonSchema = JsonSchema.FromText(schema);
            var jsonNode = JsonNode.Parse(json);
            var validationResult = jsonSchema.Evaluate(jsonNode, new EvaluationOptions { OutputFormat = OutputFormat.Hierarchical});

            if (validationResult.IsValid)
            {
                return (result: true, details: string.Empty, string.Empty);
            }

            logger.LogInformation("JSON validation failed");
            var sb = new StringBuilder();

            var details = validationResult.Details;
            var errors = validationResult.Errors ?? new Dictionary<string, string>();

            return (false, JsonSerializer.Serialize(details), JsonSerializer.Serialize(errors));
        }
        catch (Exception e)
        {
            logger.LogInformation($"Failed to run JSON validation: {e.Message}");
            return (false, string.Empty, e.Message);
        }
        
    }
}