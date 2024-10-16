﻿namespace MashupAPI.Tests.UnitTests.Fixtures;

public class WikipediaServiceFixture: IDisposable
{
    public string WikipediaResponse { get; private set; }
    public string WikipediaNoContentResponse { get; private set; }

    public WikipediaServiceFixture()
    {
        WikipediaResponse = InitWikipediaResponse();
        WikipediaNoContentResponse = InitWikipediaNoContentResponse();
    }

    private string InitWikipediaResponse()
    {
        return  """
                {
                  "batchcomplete": "",
                  "warnings": {
                    "extracts": {
                      "*": "HTML may be malformed and/or unbalanced and may omit inline images. Use at your own risk. Known problems are listed at https://www.mediawiki.org/wiki/Special:MyLanguage/Extension:TextExtracts#Caveats."
                    }
                  },
                  "query": {
                    "pages": {
                      "21231": {
                        "pageid": 21231,
                        "ns": 0,
                        "title": "Nirvana (band)",
                        "extract": "<p class=\"mw-empty-elt\">\n\n\n\n</p>\n\n<p><b>Nirvana</b> was an American rock band formed in Aberdeen, Washington, in 1987. Founded by lead singer and guitarist Kurt Cobain and bassist Krist Novoselic, the band went through a succession of drummers, most notably Chad Channing, before recruiting Dave Grohl in 1990. Nirvana's success popularized alternative rock, and they were often referenced as the figurehead band of Generation X. Despite a short mainstream career spanning only three years, their music maintains a popular following and continues to influence modern rock culture.\n</p><p>In the late 1980s, Nirvana established itself as part of the Seattle grunge scene, releasing its first album, <i>Bleach</i>, for the independent record label Sub Pop in 1989. They developed a sound that relied on dynamic contrasts, often between quiet verses and loud, heavy choruses. After signing to the major label DGC Records in 1991, Nirvana found unexpected mainstream success with \"Smells Like Teen Spirit\", the first single from their landmark second album <i>Nevermind</i> (1991). A cultural phenomenon of the 1990s, <i>Nevermind</i> was certified Diamond by the Recording Industry Association of America (RIAA) and is credited for ending the dominance of hair metal.\n</p><p>Characterized by their punk aesthetic, Nirvana's fusion of pop melodies with noise, combined with their themes of abjection and social alienation, brought them global popularity. Following extensive tours and the 1992 compilation album <i>Incesticide</i> and EP <i>Hormoaning</i>, the band released their highly anticipated third studio album, <i>In Utero</i> (1993). The album topped both the US and UK album charts, and was acclaimed by critics. Nirvana disbanded following Cobain's suicide in April 1994. Further releases have been overseen by Novoselic, Grohl, and Cobain's widow, Courtney Love. The live album <i>MTV Unplugged in New York</i> (1994) won Best Alternative Music Performance at the 1996 Grammy Awards.\n</p><p>Nirvana is one of the best-selling bands of all time, having sold more than 75 million records worldwide. During their three years as a mainstream act, Nirvana received an American Music Award, Brit Award, and Grammy Award, as well as seven MTV Video Music Awards and two NME Awards. They achieved five number-one hits on the <i>Billboard</i> Alternative Songs chart and four number-one albums on the <i>Billboard</i> 200. In 2004, <i>Rolling Stone</i> named Nirvana among the 100 greatest artists of all time. They were inducted into the Rock and Roll Hall of Fame in their first year of eligibility in 2014.\n</p>"
                      }
                    }
                  }
                }    
                """;
    }
    
    private string InitWikipediaNoContentResponse()
    {
      return """
              {
               "batchcomplete": "",
               "query": {
                 "normalized": [
                   {
                     "from": "sdkjfg",
                     "to": "Sdkjfg"
                   }
                 ],
                 "pages": {
                   "-1": {
                     "ns": 0,
                     "title": "Sdkjfg",
                     "missing": ""
                   }
                 }
               }
             }
             """;
    }
    
    public void Dispose()
    {
      WikipediaResponse = string.Empty;
      WikipediaNoContentResponse = string.Empty;
    }
}