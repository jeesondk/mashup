using System.Text.Json;
using FluentAssertions;
using MashupAPI.Entities.CoverartArchive;
using MashupAPI.Entities.MusicBrainz;
using MashupAPI.Entities.Wikipedia;
using MashupAPI.Services;
using MashupAPI.Tests.UnitTests.Fixtures;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace MashupAPI.Tests.UnitTests.Services;

public class MashupTests: IClassFixture<MusicBrainzServiceFixture>, IClassFixture<CoverArtArchiveServiceFixture>
{
    private readonly IMusicBrainz _musicBrainz;
    private readonly ICoverArtArchive _coverArtArchive;
    private readonly IWikipedia _wikipedia;
    private readonly Mashup _mashup;
    private readonly MusicBrainzServiceFixture _musicBrainzFixture;
    private readonly CoverArtArchiveServiceFixture _coverArtArchiveFixture;

    public MashupTests(MusicBrainzServiceFixture musicBrainzFixture, CoverArtArchiveServiceFixture coverArtArchiveFixture)
    {
        var logger = Substitute.For<ILogger<Mashup>>();
        _musicBrainz = Substitute.For<IMusicBrainz>();
        var wikiData = Substitute.For<IWikiData>();
        _coverArtArchive = Substitute.For<ICoverArtArchive>();
        _wikipedia = Substitute.For<IWikipedia>();
        _musicBrainzFixture = musicBrainzFixture;
        _coverArtArchiveFixture = coverArtArchiveFixture;
        
        _mashup = new Mashup(logger, _musicBrainz, wikiData, _coverArtArchive, _wikipedia);
    }

    [Fact]
    public async Task GetMashupByMbidWithUnknowdMbid()
    {
        // Arrange
        const string id = "5b11f4ce-a62d-471e-81fc-a69a8278c7ff";
        _musicBrainz.GetArtist(id).Returns((MusicBrainzResponse?)null);

        // Act
        var result = await _mashup.GetMashupByMbid(id);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CanGetMashupByMbid()
    {
        // Arrange
        const string id = "5b11f4ce-a62d-471e-81fc-a69a8278c7da";
        const string extract =
            "\"<p class=\\\"mw-empty-elt\\\">\\n\\n\\n\\n</p>\\n\\n<p><b>Nirvana</b> was an American rock band formed in Aberdeen, Washington, in 1987. Founded by lead singer and guitarist Kurt Cobain and bassist Krist Novoselic, the band went through a succession of drummers, most notably Chad Channing, before recruiting Dave Grohl in 1990. Nirvana's success popularized alternative rock, and they were often referenced as the figurehead band of Generation X. Despite a short mainstream career spanning only three years, their music maintains a popular following and continues to influence modern rock culture.\\n</p><p>In the late 1980s, Nirvana established itself as part of the Seattle grunge scene, releasing its first album, <i>Bleach</i>, for the independent record label Sub Pop in 1989. They developed a sound that relied on dynamic contrasts, often between quiet verses and loud, heavy choruses. After signing to the major label DGC Records in 1991, Nirvana found unexpected mainstream success with \\\"Smells Like Teen Spirit\\\", the first single from their landmark second album <i>Nevermind</i> (1991). A cultural phenomenon of the 1990s, <i>Nevermind</i> was certified Diamond by the Recording Industry Association of America (RIAA) and is credited for ending the dominance of hair metal.\\n</p><p>Characterized by their punk aesthetic, Nirvana's fusion of pop melodies with noise, combined with their themes of abjection and social alienation, brought them global popularity. Following extensive tours and the 1992 compilation album <i>Incesticide</i> and EP <i>Hormoaning</i>, the band released their highly anticipated third studio album, <i>In Utero</i> (1993). The album topped both the US and UK album charts, and was acclaimed by critics. Nirvana disbanded following Cobain's suicide in April 1994. Further releases have been overseen by Novoselic, Grohl, and Cobain's widow, Courtney Love. The live album <i>MTV Unplugged in New York</i> (1994) won Best Alternative Music Performance at the 1996 Grammy Awards.\\n</p><p>Nirvana is one of the best-selling bands of all time, having sold more than 75\u00a0million records worldwide. During their three years as a mainstream act, Nirvana received an American Music Award, Brit Award, and Grammy Award, as well as seven MTV Video Music Awards and two NME Awards. They achieved five number-one hits on the <i>Billboard</i> Alternative Songs chart and four number-one albums on the <i>Billboard</i> 200. In 2004, <i>Rolling Stone</i> named Nirvana among the 100 greatest artists of all time. They were inducted into the Rock and Roll Hall of Fame in their first year of eligibility in 2014.\\n</p>\"";
        var musicBrainzEntity = JsonSerializer.Deserialize<MusicBrainzResponse>(_musicBrainzFixture.MusicBrainzResponse);
        
        _musicBrainz.GetArtist(id).Returns(musicBrainzEntity);
        _musicBrainz.GetWikipediaRelation(musicBrainzEntity!).Returns("wikipedia-link");
        _musicBrainz.GetWikiDataRelation(musicBrainzEntity!).Returns("wikidata-id");
        
        _wikipedia.GetWikipediaPageByTitle("wikipedia-link")!.Returns(Task.FromResult(new WikiResponse("", new Warnings(new Extracts("")), new Query([new Page(123, 1, "Nirvana (Band)", extract)]))));
        _coverArtArchive.GetCoverArt("release-id").Returns(Task.FromResult(JsonSerializer.Deserialize<CoverArtResponse>(_coverArtArchiveFixture.CoverartArchiveResponse)));

        // Act
        var result = await _mashup.GetMashupByMbid(id);

        // Assert
        result.Should().NotBeNull();
        result?.MbId.Should().Be(id);
        result?.Description.Length.Should().BeGreaterThan(10);
        result?.Albums.Should().HaveCountGreaterThan(2);
    }
    
}