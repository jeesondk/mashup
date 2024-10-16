using System.Text.Json;
using MashupAPI.Entities.MusicBrainz;

namespace MashupAPI.Services;

public interface IMusicBrainz
{
    Task<MbResponse?> GetArtist(string artistId);
}

public class MusicBrainz(ILogger<MusicBrainz> logger, HttpClient httpClient) : IMusicBrainz
{
    public async Task<MbResponse?> GetArtist(string artistId)
    {
        var response = await httpClient.GetAsync($"/artist/{artistId}?&fmt=json&inc=url-rels+release-groups");
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Failed to get artist with id {artistId}");
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var artist = JsonSerializer.Deserialize<MbResponse>(content);

        return artist;
    }

    public async Task<string> GetWikiDataId(string artistId)
    {
        throw new NotImplementedException();
    }
}