namespace MashupAPI.Tests.UnitTests.Fixtures;

public class CoverArtArchiveServiceFixture: IDisposable
{
    public string CoverartArchiveResponse { get; private set; }
    public string CoverartArchiveMalformedResponse { get; private set; }
    public string CoverartArchiveEmptyResponse { get; private set; }

    public CoverArtArchiveServiceFixture()
    {
        CoverartArchiveResponse = InitCoverartArchiveResponse();
        CoverartArchiveMalformedResponse = InitCoverartArchiveMalformedResponse();
        CoverartArchiveEmptyResponse = InitCoverartArchiveEmptyResponse();
    }

    private string InitCoverartArchiveEmptyResponse()
    {
        return """
                { }
               """;
    }

    private string InitCoverartArchiveMalformedResponse()
    {
        return """
                {
                   "release":"https://musicbrainz.org/release/f268b8bc-2768-426b-901b-c7966e76de29",
                   "images":[
                       {
                           "edit":37284546,
                           "id":"12750224075",
                           "image":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075.png",
                           "thumbnails":{
                           },
                           "comment":"",
                           "approved":true,
                           "front":false,
                           "types":[
                               "Back"
                           ],
                           "back":blue
                       }
                   ]
               }
               """;
    }

    private string InitCoverartArchiveResponse()
    {
        return """
                {
                   "release":"https://musicbrainz.org/release/f268b8bc-2768-426b-901b-c7966e76de29",
                   "images":[
                       {
                           "edit":37284546,
                           "id":"12750224075",
                           "image":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075.png",
                           "thumbnails":{
                               "250":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075-250.jpg",
                               "500":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075-500.jpg",
                               "1200":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075-1200.jpg",
                               "small":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075-250.jpg",
                               "large":"http://coverartarchive.org/release/f268b8bc-2768-426b-901b-c7966e76de29/12750224075-500.jpg"
                           },
                           "comment":"",
                           "approved":true,
                           "front":false,
                           "types":[
                               "Back"
                           ],
                           "back":true
                       }
                   ]
               }
               """;
    }
    
    public void Dispose()
    {
        
    }

    
}