using MashupAPI.Entities.WikiData;

namespace MashupAPI.Services;

public class WikiData(ILogger<WikiData> logger, HttpClient httpClient)
{
    public Sitelink GetWikiDataById(string id, string language = "en")
    {
        throw new NotImplementedException();
    }
}