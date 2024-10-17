using System.Text.Json.Serialization;

namespace MashupAPI.Entities.CoverartArchive;

public record Image(
    [property: JsonPropertyName("edit")] int Edit,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("image")] string ImageUrl,
    [property: JsonPropertyName("thumbnails")] Thumbnails Thumbnails,
    [property: JsonPropertyName("comment")] string Comment,
    [property: JsonPropertyName("approved")] bool Approved,
    [property: JsonPropertyName("front")] bool Front,
    [property: JsonPropertyName("types")] IReadOnlyList<string> Types,
    [property: JsonPropertyName("back")] bool Back
);

public record CoverartResponse(
    [property: JsonPropertyName("release")] string Release,
    [property: JsonPropertyName("images")] IReadOnlyList<Image> Images
);

public record Thumbnails(
    [property: JsonPropertyName("250")] string Px250,
    [property: JsonPropertyName("500")] string Px500,
    [property: JsonPropertyName("1200")] string Px1200,
    [property: JsonPropertyName("small")] string Small,
    [property: JsonPropertyName("large")] string Large
);