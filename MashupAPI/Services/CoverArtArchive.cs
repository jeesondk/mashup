using System.Text.Json;
using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Infrastructure.Validator;

namespace MashupAPI.Services;

public interface ICoverArtArchive
{
    Task<CoverartResponse?> GetCoverArt(string id);
}

public class CoverArtArchive(ILogger<CoverArtArchive> logger, HttpClient httpClient, IJsonValidator jsonValidator) : ICoverArtArchive
{
    public async Task<CoverartResponse?> GetCoverArt(string id)
    {
        try
        {
            var response = await httpClient.GetAsync($"/release-group//{id}");
            if (!response.IsSuccessStatusCode)
            {
                logger.LogInformation($"Failed to get cover art for release with id {id}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var (result, details, errors) = jsonValidator.ValidateJson(CoverartSchema.Schema, content);
            
            if(!result)
            {
                logger.LogInformation($"Failed to validate JSON: {details} {errors}");
                return null;
            }
            
            var coverArt = JsonSerializer.Deserialize<CoverartResponse>(content);

            return coverArt;    
        }
        catch(Exception e)
        {
            logger.LogInformation(e, "Failed to get cover art");
            return null;
        }
        
    }
}