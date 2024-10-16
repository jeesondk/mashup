using System.Text.Json.Serialization;

namespace MashupAPI.Entities.WikiData;
public record Sitelink(
    [property: JsonPropertyName("site")] string Site,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("badges")] IReadOnlyList<string> Badges
);

