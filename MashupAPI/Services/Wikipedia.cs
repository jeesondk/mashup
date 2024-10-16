using System.Text.Json;
using System.Text.Json.Nodes;
using MashupAPI.Entities.Wikipedia;

namespace MashupAPI.Services;

public class Wikipedia(ILogger<Wikipedia> logger, HttpClient httpClient)
{
    public async Task<WikiResponse> GetWikipediaPageByTitle(string title)
    {
        var response = await httpClient.GetAsync($"?action=query&format=json&prop=extracts&exintro=true&redirects=true&titles={title}");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogInformation($"Failed to get wikipage with title: {title}");
            return new WikiResponse(string.Empty, new Warnings(new Extracts(string.Empty)), new Query([]));
        }
        var content = await response.Content.ReadAsStringAsync();

        return ParseWikiData(content);
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