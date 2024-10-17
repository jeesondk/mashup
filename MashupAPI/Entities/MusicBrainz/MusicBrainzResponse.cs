using System.Text.Json.Serialization;

namespace MashupAPI.Entities.MusicBrainz;

public record Area(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("sort-name")] string SortName,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("iso-3166-1-codes")] IReadOnlyList<string> Iso31661Codes,
        [property: JsonPropertyName("disambiguation")] string Disambiguation,
        [property: JsonPropertyName("type-id")] object TypeId
    );

    public record BeginArea(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("type")] object Type,
        [property: JsonPropertyName("sort-name")] string SortName,
        [property: JsonPropertyName("disambiguation")] string Disambiguation,
        [property: JsonPropertyName("type-id")] object TypeId
    );

    public record LifeSpan(
        [property: JsonPropertyName("ended")] bool Ended,
        [property: JsonPropertyName("end")] string End,
        [property: JsonPropertyName("begin")] string Begin
    );

    public record Relation(
        [property: JsonPropertyName("target-credit")] string Targetcredit,
        [property: JsonPropertyName("direction")] string Direction,
        [property: JsonPropertyName("ended")] bool Ended,
        [property: JsonPropertyName("begin")] string Begin,
        [property: JsonPropertyName("url")] Url Url,
        [property: JsonPropertyName("source-credit")] string SourceCredit,
        [property: JsonPropertyName("target-type")] string TargetType,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("attributes")] IReadOnlyList<string> Attributes,
        [property: JsonPropertyName("type-id")] string TypeId,
        [property: JsonPropertyName("end")] string End
    );

    public record ReleaseGroup(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("first-release-date")] string FirstReleaseDate,
        [property: JsonPropertyName("secondary-types")] IReadOnlyList<string> SecondaryTypes,
        [property: JsonPropertyName("primary-type-id")] string PrimaryTypeId,
        [property: JsonPropertyName("disambiguation")] string Disambiguation,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("primary-type")] string PrimaryType,
        [property: JsonPropertyName("secondary-type-ids")] IReadOnlyList<string> SecondaryTypeIds
    );

    public record MusicBrainzResponse(
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("gender")] string Gender,
        [property: JsonPropertyName("area")] Area Area,
        [property: JsonPropertyName("end-area")] string EndArea,
        [property: JsonPropertyName("isnis")] IReadOnlyList<string> IsnIs,
        [property: JsonPropertyName("life-span")] LifeSpan LifeSpan,
        [property: JsonPropertyName("sort-name")] string SortName,
        [property: JsonPropertyName("ipis")] IReadOnlyList<string> IpIs,
        [property: JsonPropertyName("disambiguation")] string Disambiguation,
        [property: JsonPropertyName("type-id")] string TypeId,
        [property: JsonPropertyName("gender-id")] object GenderId,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("begin-area")] BeginArea BeginArea,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("relations")] IReadOnlyList<Relation> Relations,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("release-groups")] IReadOnlyList<ReleaseGroup> ReleaseGroups
    );

    public record Url(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("resource")] string Resource
    );