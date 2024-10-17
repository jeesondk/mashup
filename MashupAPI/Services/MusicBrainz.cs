using System.Text.Json;
using MashupAPI.Entities.MusicBrainz;
using MashupAPI.Infrastructure.Validator;

namespace MashupAPI.Services;

public interface IMusicBrainz
{
    Task<MusicBrainzResponse?> GetArtist(string artistId);
    string GetWikiDataRelation(MusicBrainzResponse entity);
    string GetWikipediaRelation(MusicBrainzResponse entity);
}

public class MusicBrainz(ILogger<MusicBrainz> logger, HttpClient httpClient, IJsonValidator jsonValidator) : IMusicBrainz
{
    public async Task<MusicBrainzResponse?> GetArtist(string artistId)
    {
        var response = await httpClient.GetAsync($"/artist/{artistId}?&fmt=json&inc=url-rels+release-groups");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"Failed to get artist with id {artistId}");
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var (result, details, errors) = jsonValidator.ValidateJson(MusicBrainzSchema.Schema, content);
        if(!result)
        {
            logger.LogInformation($"Failed to validate JSON: {details} {errors}");
            return null;
        }
        
        var artist = JsonSerializer.Deserialize<MusicBrainzResponse>(content);

        return artist;
    }

    public string GetWikiDataRelation(MusicBrainzResponse entity)
    {
        try
        {
            var wikiRelation = entity.Relations.First(x => x.Type == "wikidata");
            var id = wikiRelation
                .Url
                .Resource
                .Split("/")
                .Last();
            return id;   
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "No WikiData relation found");
            return string.Empty;
        }
    }

    public string GetWikipediaRelation(MusicBrainzResponse entity)
    {
        try
        {
            var wikiRelation = entity.Relations.FirstOrDefault(x => x.Type == "wikipedia");
            var id = wikiRelation?.Url.Resource
                .Split("/")
                .Last();
            return id ?? string.Empty;
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "No Wikipedia relation found");
            return string.Empty;
        }
    }
    
}