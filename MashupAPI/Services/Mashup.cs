using MashupAPI.Entities.Mashup;

namespace MashupAPI.Services;

public interface IMashup
{
    Task<MashupResponse?> GetMashupByMbid(string mbid);
}

public class Mashup: IMashup
{
    public async Task<MashupResponse?> GetMashupByMbid(string mbid)
    {
        return await Task.FromResult(new MashupResponse(mbid,
            "The Beatles were an English rock band formed in Liverpool in 1960. With a line-up comprising John Lennon, Paul McCartney, George Harrison and Ringo Starr, they are regarded as the most influential band of all time.",
            new List<Album>
            {
                new Album("123", "Abbey Road",
                    "https://coverartarchive.org/release-group/4d9c8b6e-4e0f-3abf-ba6e-8c3f4f5c3d6f/front-250.jpg"),
                new Album("456", "Let It Be",
                    "https://coverartarchive.org/release-group/4d9c8b6e-4e0f-3abf-ba6e-8c3f4f5c3d6f/front-250.jpg")
            }));
    }
}