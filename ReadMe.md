# Mashup - API

## Notes

Cover Art Archive, that are based on Internet Archive are not fully available due to a series of DDOS attacks, 
please see more: [https://www.theregister.com/2024/10/16/internet_archive_recovery/](https://www.theregister.com/2024/10/16/internet_archive_recovery/)
The solution has the implementation to pull cover images, but will return empty strings as long as the API retuens a redirect or error.

I looked for free alternativs to implement, that would not deviate from the approach of using rest API,
Unfortunately I was not able to find a solution that I could implement without a huge re-design and that were free to use.

My code is based on the task assignment provided, with the needed error handling to make it work.

## Systems design

### High-level design
<Add diagramm>



### Steps & Flows
<Add Sequence diagram>


### Tools
- Microsoft.Extensions.Caching.Memory
- RestSharp
- Polly
- JsonSchema.NET


#### Test Tools
- Nsubstitute - Mocks, Fakes & Stubs
- FluentAssertions - Test result assertions
- Coverlet.Collector
- Coverlet.MsBuild


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