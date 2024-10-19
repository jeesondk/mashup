using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using MashupAPI.Entities.Wikipedia;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using RestSharp;

namespace MashupAPI.Services;

public interface IWikipedia
{
    Task<WikiResponse?> GetWikipediaPageByTitle(string title);
}

public class Wikipedia(ILogger<Wikipedia> logger, IConfiguration configuration, RestClient client, IJsonValidator validator, IMashupMemoryCache cache) : IWikipedia
{
    public async Task<WikiResponse?> GetWikipediaPageByTitle(string title)
    {
        try
        {
            var cacheKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(title));
            var isCached = cache.TryGetValue($"Wiki:{cacheKey}", out WikiResponse? cachedWiki);
            if (isCached) return cachedWiki;
        
            var baseUrl = new Uri(configuration.GetValue<string>("APIEndpoints:Wikipedia") ?? "https://en.wikipedia.org/w/api.php");
            var request = new RestRequest($"{baseUrl}?action=query&format=json&prop=extracts&exintro=true&redirects=true&titles={title}", Method.Get);
        
            var response = await client.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogInformation($"Failed to get wikipage with title: {title}");
                return null;
            }
            var content = response.Content ?? string.Empty;
            var (result, details, errors) = validator.ValidateJson(WikipediaSchema.Schema, content);
        
            if(!result)
            {
                logger.LogInformation($"Failed to validate JSON: {details} {errors}");
                return null;
            }
        
            var wikiData = ParseWikiData(content);
            cache.Set($"Wiki:{cacheKey}", JsonSerializer.Serialize(wikiData));
            return wikiData;   
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "Failed to get wikipage");
            return null;
        }
    }
    
    private WikiResponse ParseWikiData(string json) 
    {
        try
        {
            var jsonNode = JsonNode.Parse(json);
            var pagesJson = jsonNode!["query"]!["pages"]?.AsObject();
            var pages = pagesJson?.Select(pair => pair.Value.Deserialize<Page>()).ToList();
            
            var resp =  new WikiResponse(
                jsonNode!["batchcomplete"]!.ToString(), 
                jsonNode["warnings"].Deserialize<Warnings>() ?? new Warnings(new Extracts(string.Empty)),
                new Query(pages?.ToArray() ?? []));
            
            return resp;
        }
        catch (Exception e)
        {
            logger.LogInformation(e, "Error parsing WikiData JSON");
            return new WikiResponse(string.Empty, new Warnings(new Extracts(string.Empty)), new Query([]));
        }
    }
}