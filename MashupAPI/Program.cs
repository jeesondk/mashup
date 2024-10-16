using MashupAPI.Services;
using MashupAPI.Infrastructure.Policies;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build());

// Add services to the container.
builder.Services.AddHttpClient<IMusicBrainz, MusicBrainz>(client =>
        client.BaseAddress =
            new Uri(builder.Configuration["RestEndpoints:MusicBrainz"] ?? "https://musicbrainz.org/ws/2/"))
    .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());


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