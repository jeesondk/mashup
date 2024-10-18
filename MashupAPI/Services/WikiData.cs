using System.Text.Json;
using System.Text.Json.Nodes;
using MashupAPI.Entities.WikiData;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using RestSharp;
using static System.Net.WebUtility;

namespace MashupAPI.Services;

public interface IWikiData
{
    Task<Sitelink?> GetWikiDataById(string id, string language = "en");
    string GetWikipediaTitle(Sitelink entity);
}

public class WikiData(ILogger<WikiData> logger, IConfiguration configuration, RestClient client, IJsonValidator validator, IMashupMemoryCache cache) : IWikiData
{
    public async Task<Sitelink?> GetWikiDataById(string id, string language = "en")
    {
        var isCached = cache.TryGetValue($"WikiData:{id}", out Sitelink? cachedWikiData);
        if (isCached) return cachedWikiData;
        
        var baseUrl = new Uri(configuration.GetValue<string>("APIEndpoints:WikiData") ?? "https://www.wikidata.org/w/api.php");
        var request = new RestRequest($"{baseUrl}?action=wbgetentities&format=json&ids={id}&props=sitelinks", Method.Get);
        
        var response = await client.GetAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"Failed to get artist with id {id}");
            return null;
        }
        var content = response.Content ?? string.Empty;
        var (result, details, errors) = validator.ValidateJson(WikiDataSchema.Schema, content);
        
        if(!result)
        {
            logger.LogInformation($"Failed to validate JSON: {details} {errors}");
            return null;
        }
        
        var siteLink = ParseWikiData(content, id, language);
        cache.Set($"WikiData:{id}", JsonSerializer.Serialize(siteLink));
        return siteLink;
    }
    
    private Sitelink? ParseWikiData(string json, string id, string language) 
    {
        try
        {
            var jsonNode = JsonNode.Parse(json);
            var siteLinks = jsonNode!["entities"]![id]!["sitelinks"]?.AsObject();
            var link = siteLinks?
                .Where(x => x.Key == $"{language}wiki")
                .Select(pair => pair.Value.Deserialize<Sitelink>())
                .First();
            return link;    
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error parsing WikiData JSON");
            return null;
        }
    }

    public string GetWikipediaTitle(Sitelink entity)
    {
        return UrlEncode(entity.Title);
    }
}