# Mashup - API

## Notes

Cover Art Archive, that are based on Internet Archive are not fully available due to a series of DDOS attacks, 
please see more: [https://www.theregister.com/2024/10/16/internet_archive_recovery/](https://www.theregister.com/2024/10/16/internet_archive_recovery/)
The solution has the implementation to pull cover images, but will return empty strings as long as the API retuens a redirect or error.

I looked for free alternativs to implement, that would not deviate from the approach of using rest API,
Unfortunately I was not able to find a solution that I could implement without a huge re-design and that were free to use.

As a way to handle this, the code return "" instead of the image URL when the RestCall fails


## Task

Build a REST API that consumes and combines information from:
- MusicBrainz
- Wikidata
- Wikipedia
- Cover Art Archive

## Requirements

### Functional
- The API should accept an MBID (MusicBrainz Identifier) and respond with a json object
containing:
 - The MBID of the artist
 - A description of the artist as provided by Wikipedia. Note that wikipedia does not have any notion about MBIDs. This relation is provided by MusicBrainz.
 - A list of all the albums that the artist has released together with an url for the cover image of each album. The list of albums is provided by MusicBrainz, but all the images are provided by Cover Art


### Non-functional requirements
- The API should respond with all of the data as quickly as possible. This can be
challenging because some of the external APIs can be slow. Some of them even enforce rate limits.
Solution should be production ready
- Document areas of improvement if any
- The code should follow best practices
- The code should be maintainable
- A README must be included and contain examples of how the application is built, installed, run and used

## Systems design

### Solution Layout

MashupAPI
|- Controllers          #Rest Controllers
|-  Entities            #Data models & JsonSchemas
    |- CoverArtArchive
    |- Mashup
    |- MusicBrainz
    |- WikiData
    |- Wikipedia
|- Infrastructure
    |- Cache            #MemoryCache
    |- Policies         #Http Retry Policy
    |- Validators       #JsonSchame validation
|- Services             #Buisness logic


### Language

- C# 12, .NET 8

### Frameworks

- ASP.NET Core MVC


### High-level design
<Add diagramm>



### Steps & Flows
<Add Sequence diagram>


### Tools & Pacakages

### Application Tools & Packages

- Microsoft.Extensions.Caching.Memory
- Microsoft.Extensions.Http
- Microsoft.Extensions.Http.Polly
- RestSharp
- Polly
- Polly.Extensions
- JsonSchema.NET
- Swashbuckle.AspNetCore

#### Test Tools & Packages

- Coverlet.Collector
- Coverlet.MsBuild
- FluentAssertions
- Microsoft.AspNetCore.Mvc.Testing
- Microsoft.NET.Test.Sdk
- Nsubstitute
- xunit
- xunit.runner.visualstudio



## Building solution
```bash
donet build
```

## Testing Solution

### Run Unit test suite

```bash
dotnet test /p:CollectCoverage=true /p:ExcludeByFile="**/Program.cs" /p:Exclude="[MashupAPI.Tests.*]*" --filter "Category=Unit"
```

### Run Integration test suite

This test suite requires that you have intenet access!
```bash
dotnet test /p:CollectCoverage=true /p:ExcludeByFile="**/Program.cs" /p:Exclude="[MashupAPI.Tests.*]*" --filter "Category=Integration"
```

## Running Solution

### Configurations

#### Release build

appsettings.json
```json
...
  "APIEndpoints": {
    "MusicBrainz": "https://musicbrainz.org/ws/2",
    "CoverArtArchive": "https://coverartarchive.org",
    "Wikipedia": "https://en.wikipedia.org/w/api.php",
    "WikiData": "https://www.wikidata.org/w/api.php"
  },
  "Cache": {
    "SlidingExpiration": 86400 //Time in seconds
  },
  "DisableCoverArt": true, //Cover Art workaround, this flag allows the code to skip getting the image URL's from Covera Art Archive and will return "" as image URL. 
...
```

#### Development build

appsettings.development.json
```json
...
  "APIEndpoints": {
    "MusicBrainz": "https://musicbrainz.org/ws/2",
    "CoverArtArchive": "https://coverartarchive.org",
    "Wikipedia": "https://en.wikipedia.org/w/api.php",
    "WikiData": "https://www.wikidata.org/w/api.php"
  },
  "Cache": {
    "SlidingExpiration": 120 //Time in seconds
  },
  "DisableCoverArt": true, //Cover Art workaround, this flag allows the code to skip getting the image URL's from Covera Art Archive and will return "" as image URL. 
...
```

### Running from shell

```bash
dotnet run --project .\MashupAPI\MashupAPI.csproj
```

### Running with Docker Compose

```bash
docker-compose up
```

#### Tearing down Compose
```bash
docker-compose down
```

### Running with Podman Compose
```bash
podman compose up
```

#### Tearing down Compose
```bash
podman compose down
```