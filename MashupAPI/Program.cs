using MashupAPI.Services;
using MashupAPI.Infrastructure.Policies;
using MashupAPI.Infrastructure.Validator;

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

// Add services to the container.
builder.Services.AddHttpClient<IMusicBrainz, MusicBrainz>(client =>
        client.BaseAddress =
            new Uri(builder.Configuration["APIEndpoints:MusicBrainz"] ?? "https://musicbrainz.org/ws/2/"))
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());
builder.Services.AddHttpClient<IWikiData, WikiData>(client =>
        client.BaseAddress =
        new Uri(builder.Configuration["APIEndpoints:WikiData"] ?? "https://www.wikidata.org/w/api.php"))
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());
builder.Services.AddHttpClient<IWikiData, WikiData>(client =>
        client.BaseAddress =
            new Uri(builder.Configuration["APIEndpoints:Wikipedia"] ?? "https://en.wikipedia.org/w/api.php"))
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());
builder.Services.AddHttpClient<ICoverArtArchive, CoverArtArchive>(client =>
        client.BaseAddress =
            new Uri(builder.Configuration["APIEndpoints:CoverartArchive"] ?? "https://coverartarchive.org"))
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());

builder.Services.AddTransient<IJsonValidator, JsonValidator>();
builder.Services.AddTransient<IMusicBrainz, MusicBrainz>();
builder.Services.AddTransient<IWikiData, WikiData>();
builder.Services.AddTransient<IWikipedia, Wikipedia>();
builder.Services.AddTransient<ICoverArtArchive, CoverArtArchive>();
builder.Services.AddTransient<IMashup, Mashup>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();