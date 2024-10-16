# Mashup - API

## Systems design

### High-level design
<Add diagramm>



### Steps & Flows
<Add Sequence diagram>


### Tools
- Microsoft.Extensions.Caching.Memory
- RestSharp
- Polly


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