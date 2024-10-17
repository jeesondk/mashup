using System.Text.Json.Serialization;

namespace MashupAPI.Entities.Mashup;

public record MashupResponse(
    [property:JsonPropertyName("mbid")]string MbId,
    [property:JsonPropertyName("description")]string Description,
    [property:JsonPropertyName("albums")]IReadOnlyList<Album> Albums);
    
public record Album(
    [property:JsonPropertyName("id")]string Id,
    [property:JsonPropertyName("title")]string Title,
    [property:JsonPropertyName("image")]string Image
);