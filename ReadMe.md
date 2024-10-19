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
```
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
```

### Language

- C# 12, .NET 8

### Frameworks

- ASP.NET Core MVC


### Tools & Pacakages

#### Application Tools & Packages

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

### Solution Description

#### High-level design
![MashupAPI Overview](img\MashupAPI.Overview.svg "MashupAPI Overview")


#### Steps & Flows
![MashupAPI FLow](img\MashupAPI.Flow.svg "MashupAPI Flow")

#### Thoughts and Strategies

Based on the requirements my take on this task is to create a solution, using a layered solution architecture.
I have seperated the code into Controller, Entities, Services and Infrastructure.

**General**
I have tried to ensure that no layer inherits more than one layer deep, this is to keep maintainability high and reduce cognitiv complexity

**Infrastructure**
This layer contains non-business logic related items such as Cache provider, Http Retry policies etc. My intetion here is to decouple the technical components from Presentation, Persistance and Business Logic

*Cahcing*
The MemoryCache are wrapped in my own interface and class, this allows the Cache provide to be exchange with i.e.: Redis, with a minimal impact to the rest of the solution, as long as the interface are intact.

The caching strategy is "look-thorugh", meaning that I always check the cache first, before calling an external API, this is done to speed up performance as well as to mitigate ratelimit constains.

Cache expire time is set in the appsetting.json file.

*HttpRetryPolicies*
I have added a retry policy that handles trasient HTTP Errors to add risilience to the rest client, the policy is to retry 3 times and add the retry count to the power of 0.5 as delay.

**Service**
This layer contains the business logic as well as the orchestration

On the Wikipedia and WikiData Service, I have used JsonNode to help pars the documents as the data came back with non-generic keys for some of the lists. This could have been solved in a number of ways, but as the data I needed from the response was limited, I opted for JsonNode to cherry pick data from the json payloads and deserialize only parts of the payload.

*Wikipedia*
In this service the Cache key is based on a Base64 encoded string, the reason for that is that "title" used to query Wikipedia, is a string that contains spaces, special chars, etc. To ensure key uniqueness and simplify key generation, I chose to Base64 encode the "title" as key

*CoverArt*
As noted in the top of this document, Cover Art Archive seems to be down as the result og several DDOS attacks, I still did the implementation with data exampled from their API documentation but calling the API returns "Name or service not known" as it redirects to Internet Archive on HTTP/GET requests.

This is not handeld by the cache, I specifically opted for not caching empty results, at the cost of the API performance, My reasoning here is, that I don't know when it's back up and if I cache data for 1 day, that will then add 1 day from when the service is back up, before cached items will expire and the real date be fetched.

*Mashup*
The Mashup service is the one that binds it all together and serves as orchestrator, this is also the service that produces the repsonse for the rest API.

I chose to use parallel task execution for fetching Cover Art, the reasoning behind this is, that fetching data for artists with a lot of albums, like Metallica, will take significantly longer if this is done sequential. 

**Entites**
This layer contains Data models (Reponses) as well as JsonScheames used for validating Json payloads from the external API's comsumed

**Testing**
I followd TDD practices while coding, starting with a failing test, adding simples implementation and working from there, the general code coverage I see in Rider is 70% for the integration tests and 90% for unit tests.
I have used Xunit's Trait to set a Category that I can then filter on when running the tests.

#### Further Improvements

##### Testing

- Additional Integration tests

##### Code

- Add telemetry using OTEL
- Use a Redis Cache over Memory cache as Redis scales better for production
- Add Tracing
- Improve logging

##### Documentation

- Change to C4 model diagrams
- Use Sequence diagrams to explain flow


## Building solution
```bash
donet build
```

## Testing Solution

### Run Unit test suite

```bash
dotnet test /p:CollectCoverage=true /p:ExcludeByFile="**/Program.cs" --filter "Category=Unit"
```

### Run Integration test suite

This test suite requires that you have intenet access!
```bash
dotnet test /p:CollectCoverage=true /p:ExcludeByFile="**/Program.cs" --filter "Category=Integration"
```

## Running Solution

### Configurations

#### Release build

appsettings.json
```
...
  "APIEndpoints": {
    "MusicBrainz": "https://musicbrainz.org/ws/2",
    "CoverArtArchive": "https://coverartarchive.org",
    "Wikipedia": "https://en.wikipedia.org/w/api.php",
    "WikiData": "https://www.wikidata.org/w/api.php"
  },
  "Cache": {
    "SlidingExpiration": 86400 //Time in seconds
  }
...
```

#### Development build

appsettings.development.json
```
...
  "APIEndpoints": {
    "MusicBrainz": "https://musicbrainz.org/ws/2",
    "CoverArtArchive": "https://coverartarchive.org",
    "Wikipedia": "https://en.wikipedia.org/w/api.php",
    "WikiData": "https://www.wikidata.org/w/api.php"
  },
  "Cache": {
    "SlidingExpiration": 120 //Time in seconds
  }
...
```

### Running from shell

```bash
dotnet run --project .\MashupAPI\MashupAPI.csproj
```

### Building Container image

To build the docker image directly from source, please use one of the following two options

#### Docker

```bash
docker build -t mashup-api:latest
```

#### Podman
```bash
podman build -t mashup-api:latest
```

### Running the Container image

### Docker

#### Production mode

NB! This does not have a swagger endpoint

```bash
docker run -e ASPNETCORE_ENVIRONMENT=Production -p 8080:8080 mashup-api:latest
```
##### Call API
```bash
curl -X GET "http://localhost:8080/api/v1.0/Mashup?mbid=a466c2a2-6517-42fb-a160-1087c3bafd9f"
```

#### Development mode

```bash
docker run -e ASPNETCORE_ENVIRONMENT=Development -p 8080:8080 mashup-api:latest
```

##### Open Swagger

[Mashup API Swagger](http://localhost:8080/swagger/index.html)


### Podman


#### Production mode

NB! This does not have a swagger endpoint

```bash
podman run -e ASPNETCORE_ENVIRONMENT=Production -p 8080:8080 mashup-api:latest
```
##### Call API
```bash
curl -X GET "http://localhost:8080/api/v1.0/Mashup?mbid=a466c2a2-6517-42fb-a160-1087c3bafd9f"
```

#### Development mode

```bash
podman run -e ASPNETCORE_ENVIRONMENT=Development -p 8080:8080 mashup-api:latest
```

##### Open Swagger

[Mashup API Swagger](http://localhost:8080/swagger/index.html)


### Running with Compose file

The compose file in this project build the code and package the docker image before starting the container

#### Setting ASPNETCORE_ENVIRONMENT

The compose file already sets the ASPNETCORE_ENVIRONMENT to Production, this disabled the Swagger endpoint.
To change this to Development and enable the swagger endpoint please update the file docker-compose.yml from this

```yaml
...
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
...
```
to this

```yaml
...
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
...
```
Remember to tear down previous version with "docker-compose" down or "podman compose down"

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