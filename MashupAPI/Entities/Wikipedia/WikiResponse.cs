using System.Text.Json.Serialization;

namespace MashupAPI.Entities.Wikipedia;

public record Page(
    [property: JsonPropertyName("pageid")] int pageid,
    [property: JsonPropertyName("ns")] int ns,
    [property: JsonPropertyName("title")] string title,
    [property: JsonPropertyName("extract")] string extract
);

public record Extracts(
    [property: JsonPropertyName("*")] string note
);

public record Query(
    [property: JsonPropertyName("pages")] Page?[] pages
);

public record WikiResponse(
    [property: JsonPropertyName("batchcomplete")] string batchcomplete,
    [property: JsonPropertyName("warnings")] Warnings warnings,
    [property: JsonPropertyName("query")] Query query
);

public record Warnings(
    [property: JsonPropertyName("extracts")] Extracts extracts
);
