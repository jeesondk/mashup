using System.Text.Json;
using MashupAPI.Entities.MusicBrainz;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using RestSharp;

namespace MashupAPI.Services;

public interface IMusicBrainz
{
    Task<MusicBrainzResponse?> GetArtist(string artistId);
    string GetWikiDataRelation(MusicBrainzResponse entity);
    string GetWikipediaRelation(MusicBrainzResponse entity);
}

public class MusicBrainz(ILogger<MusicBrainz> logger, IConfiguration configuration, IJsonValidator jsonValidator, IMashupMemoryCache cache) : IMusicBrainz
{
    public async Task<MusicBrainzResponse?> GetArtist(string artistId)
    {
        try
        {
            var isCached = cache.TryGetValue($"Artist:{artistId}", out MusicBrainzResponse? cachedArtist);
            if (isCached) return cachedArtist;
            
            var restClient = new RestClient();
            var baseUrl = new Uri(configuration.GetValue<string>("APIEndpoints:MusicBrainz") ?? "https://musicbrainz.org/ws/2");
            
            var request = new RestRequest($"{baseUrl}/artist/{artistId}?&fmt=json&inc=url-rels+release-groups", Method.Get);
            request.AddHeader("User-Agent", "MashupAPI");
            request.AddHeader("Accept", "application/json");
            
            var response = await restClient.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogInformation($"Failed to get artist with id {artistId}");
                return null;
            }
            
            var content = response.Content ?? string.Empty;
            
            var (result, details, errors) = jsonValidator.ValidateJson(MusicBrainzSchema.Schema, content);
            if (!result)
            {
                logger.LogInformation($"Failed to validate JSON: {details} {errors}");
                return null;
            }
            cache.Set($"Artist:{artistId}", content);
            return JsonSerializer.Deserialize<MusicBrainzResponse>(content);
            
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "Failed to get artist");
            return null;
        }
        
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