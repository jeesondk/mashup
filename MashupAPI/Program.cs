using MashupAPI.Infrastructure.Cache;
using MashupAPI.Services;
using MashupAPI.Infrastructure.Policies;
using MashupAPI.Infrastructure.Validator;
using Microsoft.OpenApi.Models;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build());

builder.Services.AddLogging(logger =>
{
    logger.AddConfiguration(builder.Configuration.GetSection("Logging"));
    logger.AddConsole();
    logger.AddDebug();
});

builder.Services.AddHttpClient("RestSharpClient")
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());

builder.Services.AddSingleton<IMashupMemoryCache, MashupMemoryCache>();
builder.Services.AddSingleton<RestClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("RestSharpClient");
    var client = new RestClient(httpClient);
    client.AddDefaultHeader("User-Agent", "MashupAPI");
    client.AddDefaultHeader("Accept", "application/json");
    return client;
});

builder.Services.AddTransient<IJsonValidator, JsonValidator>();
builder.Services.AddTransient<IMusicBrainz, MusicBrainz>();
builder.Services.AddTransient<IWikiData, WikiData>();
builder.Services.AddTransient<IWikipedia, Wikipedia>();
builder.Services.AddTransient<ICoverArtArchive, CoverArtArchive>();
builder.Services.AddTransient<IMashup, Mashup>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MashupAPI",
        Version = "v1",
        Description = "A simple API to get information about artists and their music, based on MusicBrainz, WikiData, Wikipedia and Cover Art Archive."
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

// Used for integration tests
public partial class Program { }