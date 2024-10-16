using System.Text.Json;
using MashupAPI.Entities.MusicBrainz;

namespace MashupAPI.Services;

public interface IMusicBrainz
{
    Task<MbResponse?> GetArtist(string artistId);
    string GetWikiDataRelation(MbResponse entity);
    string GetWikipediaRelation(MbResponse entity);
}

public class MusicBrainz(ILogger<MusicBrainz> logger, HttpClient httpClient) : IMusicBrainz
{
    public async Task<MbResponse?> GetArtist(string artistId)
    {
        var response = await httpClient.GetAsync($"/artist/{artistId}?&fmt=json&inc=url-rels+release-groups");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"Failed to get artist with id {artistId}");
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var artist = JsonSerializer.Deserialize<MbResponse>(content);

        return artist;
    }

    public string GetWikiDataRelation(MbResponse entity)
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

    public string GetWikipediaRelation(MbResponse entity)
    {
        try
        {
            var wikiRelation = entity.Relations.FirstOrDefault(x => x.Type == "wikipedia");
            var id = wikiRelation
                .Url.Resource
                .Split("/")
                .Last();
            return id;
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "No Wikipedia relation found");
            return string.Empty;
        }
    }
    
}