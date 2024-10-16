using System.Text.Json;
using System.Text.Json.Nodes;
using MashupAPI.Entities.WikiData;
using static System.Net.WebUtility;

namespace MashupAPI.Services;

public class WikiData(ILogger<WikiData> logger, HttpClient httpClient)
{
    public async Task<Sitelink?> GetWikiDataById(string id, string language = "en")
    {
        var response = await httpClient.GetAsync($"?action=wbgetentities&format=json&ids={id}&props=sitelinks");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"Failed to get artist with id {id}");
            return null;
        }
        var content = await response.Content.ReadAsStringAsync();
        
        return ParseWikiData(content, id, language);
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