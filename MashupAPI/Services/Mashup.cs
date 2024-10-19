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
        
        var description = await GetDescription(musicBrainz.GetWikipediaRelation(musicBrainzEntity), musicBrainz.GetWikiDataRelation(musicBrainzEntity));
        
        
        var albums = await BuildAlbums(musicBrainzEntity.ReleaseGroups);

        var response = new MashupResponse(id, description, albums);
        return response;
    }

    private async Task<string> GetDescription(string wikipediaLink, string wikiDataId)
    {
        WikiResponse? wikiResponse;
        if (wikipediaLink == string.Empty && wikiDataId != string.Empty)
        {
            var siteLink = await GetWikiData(wikiDataId);
            wikiResponse = await GetWikipedia(siteLink?.Title ?? string.Empty);
            return wikiResponse?.query?.pages[0]?.extract ?? string.Empty;
        }
        wikiResponse = await GetWikipedia(wikipediaLink);
        return wikiResponse?.query?.pages[0]?.extract ?? string.Empty;
    }

    private async Task<List<Album>> BuildAlbums(IReadOnlyList<ReleaseGroup> releaseGroups)
    {
        var coverArtTasks = releaseGroups.Select( release => GetCoverArtArchive(release.Id)).ToArray();
        await Task.WhenAll(coverArtTasks);
        
        var coverArts = coverArtTasks.Select( result => result.Result).ToList();

        var albums = (from release in releaseGroups 
            let coverArt = coverArts.FirstOrDefault(art => art?.Release == release.Id) 
            select new Album(release.Id, release.Title, coverArt?.Images[0].ImageUrl ?? string.Empty))
            .ToList();

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