using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Entities.Mashup;
using MashupAPI.Entities.MusicBrainz;
using MashupAPI.Entities.WikiData;
using MashupAPI.Entities.Wikipedia;

namespace MashupAPI.Services;

public interface IMashup
{
    Task<MashupResponse?> GetMashupByMbid(string mbid);
}

public class Mashup(ILogger<Mashup> logger, IMusicBrainz musicBrainz, IWikiData wikiData, ICoverArtArchive coverArtArchive, IWikipedia wikipedia): IMashup
{
    
    public async Task<MashupResponse?> GetMashupByMbid(string id)
    {
        var musicBrainzEntity = await GetMusicBrainz(id);
        if(musicBrainzEntity == null)
        {
            logger.LogInformation("No MusicBrainz data found for {id}", id);
            return null;
        }
        
        var wikipediaLink = await GetWikiData(musicBrainz.GetWikiDataRelation(musicBrainzEntity));
        var wikipediaData = await GetWikipedia(musicBrainz.GetWikipediaRelation(musicBrainzEntity));
        var description = wikipediaData?.query.pages[0]?.extract ?? string.Empty;
        
        var albums = await BuildAlbums(musicBrainzEntity.ReleaseGroups);

        var response = new MashupResponse(id, description, albums);
        return response;
    }
    
    private async Task<List<Album>> BuildAlbums(IReadOnlyList<ReleaseGroup> releaseGroups)
    {
        var albums = new List<Album>();

        foreach (var release in releaseGroups)
        {
            var coverArt = await GetCoverArtArchive(release.Id);
            albums.Add(new Album(release.Id, release.Title, coverArt?.Images[0].ImageUrl ?? string.Empty));
        }

        return albums;
    }
    
    private async Task<MusicBrainzResponse?> GetMusicBrainz(string id)
    {
        return await musicBrainz.GetArtist(id);   
    }
    
    private async Task<Sitelink?> GetWikiData(string id)
    {
        return await wikiData.GetWikiDataById(id, "en");
    }
    
    private async Task<WikiResponse?> GetWikipedia(string title)
    {
        return await wikipedia.GetWikipediaPageByTitle(title);
    }
    
    private async Task<CoverArtResponse?> GetCoverArtArchive(string id)
    {
        return await coverArtArchive.GetCoverArt(id);
    }
}