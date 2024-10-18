using System.Text.Json;
using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Infrastructure.Cache;
using MashupAPI.Infrastructure.Validator;
using RestSharp;

namespace MashupAPI.Services;

public interface ICoverArtArchive
{
    Task<CoverArtResponse?> GetCoverArt(string id);
}

public class CoverArtArchive(ILogger<CoverArtArchive> logger, IConfiguration configuration, RestClient client, IJsonValidator jsonValidator, IMashupMemoryCache cache) : ICoverArtArchive
{
    public async Task<CoverArtResponse?> GetCoverArt(string id)
    {
        try
        {
            var isCached = cache.TryGetValue($"CoverArt:{id}", out CoverArtResponse? cachedCoverArt);
            if (isCached) return cachedCoverArt;
            
            var baseUrl = new Uri(configuration.GetValue<string>("APIEndpoints:CoverArtArchive") ?? "https://coverartarchive.org");
            var request = new RestRequest($"{baseUrl}release-group/{id}", Method.Get);
            
            var response = await client.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogInformation($"Failed to get cover art for release with id {id}");
                return null;
            }

            var content = response.Content ?? string.Empty;
            var (result, details, errors) = jsonValidator.ValidateJson(CoverartSchema.Schema, content);
            
            if(!result)
            {
                logger.LogInformation($"Failed to validate JSON: {details} {errors}");
                return null;
            }
            cache.Set($"CoverArt:{id}",content);
            return JsonSerializer.Deserialize<CoverArtResponse>(content);
        }
        catch(Exception e)
        {
            logger.LogInformation(e, "Failed to get cover art");
            return null;
        }
        
    }
}