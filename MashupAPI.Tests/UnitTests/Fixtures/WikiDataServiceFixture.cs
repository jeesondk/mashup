
namespace MashupAPI.Tests.UnitTests.Fixtures;

public class WikiDataServiceFixture: IDisposable
{
    public string WikiDataResponse { get; private set; }
    
    public WikiDataServiceFixture()
    {
        WikiDataResponse = InitWikiDataResponse();
    }
    
  
    private string InitWikiDataResponse()
    {
        return """
               {
                 "entities": {
                   "Q11649": {
                     "type": "item",
                     "id": "Q11649",
                     "sitelinks": {
                       "afwiki": {
                         "site": "afwiki",
                         "title": "Nirvana (rock-groep)",
                         "badges": []
                       },
                       "angwiki": {
                         "site": "angwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "anwiki": {
                         "site": "anwiki",
                         "title": "Nirvana (grupo)",
                         "badges": []
                       },
                       "arwiki": {
                         "site": "arwiki",
                         "title": "نيرفانا (فرقة موسيقية)",
                         "badges": []
                       },
                       "arzwiki": {
                         "site": "arzwiki",
                         "title": "نيرفانا (فرقة موسيقى)",
                         "badges": []
                       },
                       "astwiki": {
                         "site": "astwiki",
                         "title": "Nirvana (grupu)",
                         "badges": []
                       },
                       "azbwiki": {
                         "site": "azbwiki",
                         "title": "نیروانا (موزیک قروپو)",
                         "badges": []
                       },
                       "azwiki": {
                         "site": "azwiki",
                         "title": "Nirvana (qrup)",
                         "badges": []
                       },
                       "barwiki": {
                         "site": "barwiki",
                         "title": "Nirvana (Band)",
                         "badges": []
                       },
                       "be_x_oldwiki": {
                         "site": "be_x_oldwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "bewiki": {
                         "site": "bewiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "bgwiki": {
                         "site": "bgwiki",
                         "title": "Нирвана (група)",
                         "badges": []
                       },
                       "bnwiki": {
                         "site": "bnwiki",
                         "title": "নিরভানা",
                         "badges": []
                       },
                       "brwiki": {
                         "site": "brwiki",
                         "title": "Nirvana (strollad sonerezh)",
                         "badges": []
                       },
                       "bswiki": {
                         "site": "bswiki",
                         "title": "Nirvana (grupa)",
                         "badges": [
                           "Q17437798"
                         ]
                       },
                       "cawiki": {
                         "site": "cawiki",
                         "title": "Nirvana (grup de música)",
                         "badges": []
                       },
                       "ckbwiki": {
                         "site": "ckbwiki",
                         "title": "نیرڤانا (گرووپ)",
                         "badges": []
                       },
                       "cowiki": {
                         "site": "cowiki",
                         "title": "Nirvana (gruppu)",
                         "badges": []
                       },
                       "csbwiki": {
                         "site": "csbwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "cswiki": {
                         "site": "cswiki",
                         "title": "Nirvana",
                         "badges": [
                           "Q17437796"
                         ]
                       },
                       "cswikiquote": {
                         "site": "cswikiquote",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "cywiki": {
                         "site": "cywiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "dawiki": {
                         "site": "dawiki",
                         "title": "Nirvana (band)",
                         "badges": []
                       },
                       "dewiki": {
                         "site": "dewiki",
                         "title": "Nirvana (US-amerikanische Band)",
                         "badges": []
                       },
                       "diqwiki": {
                         "site": "diqwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "elwiki": {
                         "site": "elwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "emlwiki": {
                         "site": "emlwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "enwiki": {
                         "site": "enwiki",
                         "title": "Nirvana (band)",
                         "badges": [
                           "Q17437796"
                         ]
                       },
                       "enwikiquote": {
                         "site": "enwikiquote",
                         "title": "Nirvana (band)",
                         "badges": []
                       },
                       "eowiki": {
                         "site": "eowiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "eswiki": {
                         "site": "eswiki",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "etwiki": {
                         "site": "etwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "euwiki": {
                         "site": "euwiki",
                         "title": "Nirvana (musika taldea)",
                         "badges": []
                       },
                       "extwiki": {
                         "site": "extwiki",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "fawiki": {
                         "site": "fawiki",
                         "title": "نیروانا (گروه موسیقی)",
                         "badges": []
                       },
                       "fiwiki": {
                         "site": "fiwiki",
                         "title": "Nirvana (yhtye)",
                         "badges": []
                       },
                       "frwiki": {
                         "site": "frwiki",
                         "title": "Nirvana (groupe)",
                         "badges": [
                           "Q17437796"
                         ]
                       },
                       "furwiki": {
                         "site": "furwiki",
                         "title": "Nirvana (clape musicâl)",
                         "badges": []
                       },
                       "fywiki": {
                         "site": "fywiki",
                         "title": "Nirvana (Amerikaanske band)",
                         "badges": []
                       },
                       "gawiki": {
                         "site": "gawiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "glwiki": {
                         "site": "glwiki",
                         "title": "Nirvana (grupo musical)",
                         "badges": []
                       },
                       "gotwiki": {
                         "site": "gotwiki",
                         "title": "𐌽𐌹𐍂𐌱𐌰𐌽𐌰",
                         "badges": []
                       },
                       "hewiki": {
                         "site": "hewiki",
                         "title": "נירוונה (להקה)",
                         "badges": []
                       },
                       "hewikiquote": {
                         "site": "hewikiquote",
                         "title": "נירוונה (להקה)",
                         "badges": []
                       },
                       "hrwiki": {
                         "site": "hrwiki",
                         "title": "Nirvana (sastav)",
                         "badges": []
                       },
                       "hsbwiki": {
                         "site": "hsbwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "huwiki": {
                         "site": "huwiki",
                         "title": "Nirvana (együttes)",
                         "badges": []
                       },
                       "hywiki": {
                         "site": "hywiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "idwiki": {
                         "site": "idwiki",
                         "title": "Nirvana (grup musik)",
                         "badges": []
                       },
                       "iowiki": {
                         "site": "iowiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "iswiki": {
                         "site": "iswiki",
                         "title": "Nirvana (hljómsveit)",
                         "badges": []
                       },
                       "itwiki": {
                         "site": "itwiki",
                         "title": "Nirvana (gruppo musicale)",
                         "badges": []
                       },
                       "itwikiquote": {
                         "site": "itwikiquote",
                         "title": "Nirvana (gruppo musicale)",
                         "badges": []
                       },
                       "jawiki": {
                         "site": "jawiki",
                         "title": "ニルヴァーナ (アメリカ合衆国のバンド)",
                         "badges": []
                       },
                       "jvwiki": {
                         "site": "jvwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "kawiki": {
                         "site": "kawiki",
                         "title": "ნირვანა (ჯგუფი)",
                         "badges": []
                       },
                       "kkwiki": {
                         "site": "kkwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "kmwiki": {
                         "site": "kmwiki",
                         "title": "នើវ៉ាណា",
                         "badges": []
                       },
                       "kowiki": {
                         "site": "kowiki",
                         "title": "너바나",
                         "badges": []
                       },
                       "kwwiki": {
                         "site": "kwwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "kywiki": {
                         "site": "kywiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "lawiki": {
                         "site": "lawiki",
                         "title": "Nirvana (grex)",
                         "badges": []
                       },
                       "ltgwiki": {
                         "site": "ltgwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "ltwiki": {
                         "site": "ltwiki",
                         "title": "Nirvana (amerikiečių grupė)",
                         "badges": []
                       },
                       "lvwiki": {
                         "site": "lvwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "mgwiki": {
                         "site": "mgwiki",
                         "title": "Nirvana (tarika)",
                         "badges": []
                       },
                       "mkwiki": {
                         "site": "mkwiki",
                         "title": "Нирвана (музичка група)",
                         "badges": []
                       },
                       "mlwiki": {
                         "site": "mlwiki",
                         "title": "നിർവാണ",
                         "badges": []
                       },
                       "mnwiki": {
                         "site": "mnwiki",
                         "title": "Нирвана (хамтлаг)",
                         "badges": []
                       },
                       "mswiki": {
                         "site": "mswiki",
                         "title": "Nirvana (kugiran)",
                         "badges": []
                       },
                       "nahwiki": {
                         "site": "nahwiki",
                         "title": "Nirvana (tlacuīcaliztli)",
                         "badges": []
                       },
                       "ndswiki": {
                         "site": "ndswiki",
                         "title": "Nirvana (Grupp)",
                         "badges": []
                       },
                       "newiki": {
                         "site": "newiki",
                         "title": "निर्भाना",
                         "badges": []
                       },
                       "nlwiki": {
                         "site": "nlwiki",
                         "title": "Nirvana (Amerikaanse band)",
                         "badges": []
                       },
                       "nnwiki": {
                         "site": "nnwiki",
                         "title": "Musikkgruppa Nirvana",
                         "badges": []
                       },
                       "nowiki": {
                         "site": "nowiki",
                         "title": "Nirvana (band)",
                         "badges": []
                       },
                       "ocwiki": {
                         "site": "ocwiki",
                         "title": "Nirvana (grop)",
                         "badges": []
                       },
                       "pawiki": {
                         "site": "pawiki",
                         "title": "ਨਿਰਵਾਨਾ (ਬੈਂਡ)",
                         "badges": []
                       },
                       "pcdwiki": {
                         "site": "pcdwiki",
                         "title": "Nirvana (grope)",
                         "badges": []
                       },
                       "pdcwiki": {
                         "site": "pdcwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "plwiki": {
                         "site": "plwiki",
                         "title": "Nirvana",
                         "badges": [
                           "Q17437798"
                         ]
                       },
                       "plwikiquote": {
                         "site": "plwikiquote",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "pmswiki": {
                         "site": "pmswiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "ptwiki": {
                         "site": "ptwiki",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "ptwikiquote": {
                         "site": "ptwikiquote",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "rowiki": {
                         "site": "rowiki",
                         "title": "Nirvana (formație)",
                         "badges": []
                       },
                       "ruwiki": {
                         "site": "ruwiki",
                         "title": "Nirvana",
                         "badges": [
                           "Q17437798"
                         ]
                       },
                       "ruwikinews": {
                         "site": "ruwikinews",
                         "title": "Категория:Nirvana",
                         "badges": []
                       },
                       "ruwikiquote": {
                         "site": "ruwikiquote",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "scnwiki": {
                         "site": "scnwiki",
                         "title": "Nirvana (gruppu musicali)",
                         "badges": []
                       },
                       "scowiki": {
                         "site": "scowiki",
                         "title": "Nirvana (baund)",
                         "badges": []
                       },
                       "scwiki": {
                         "site": "scwiki",
                         "title": "Nirvana (grupu musicale)",
                         "badges": []
                       },
                       "shwiki": {
                         "site": "shwiki",
                         "title": "Nirvana (bend)",
                         "badges": []
                       },
                       "simplewiki": {
                         "site": "simplewiki",
                         "title": "Nirvana (band)",
                         "badges": []
                       },
                       "skwiki": {
                         "site": "skwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "slwiki": {
                         "site": "slwiki",
                         "title": "Nirvana (glasbena skupina)",
                         "badges": []
                       },
                       "sqwiki": {
                         "site": "sqwiki",
                         "title": "Nirvana (grup muzikor)",
                         "badges": []
                       },
                       "srwiki": {
                         "site": "srwiki",
                         "title": "Nirvana (музичка група)",
                         "badges": []
                       },
                       "suwiki": {
                         "site": "suwiki",
                         "title": "Nirvana (grup musik)",
                         "badges": []
                       },
                       "svwiki": {
                         "site": "svwiki",
                         "title": "Nirvana (musikgrupp)",
                         "badges": [
                           "Q17437796"
                         ]
                       },
                       "szlwiki": {
                         "site": "szlwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "thwiki": {
                         "site": "thwiki",
                         "title": "เนอร์วานา",
                         "badges": []
                       },
                       "tlwiki": {
                         "site": "tlwiki",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "trwiki": {
                         "site": "trwiki",
                         "title": "Nirvana (müzik grubu)",
                         "badges": []
                       },
                       "ttwiki": {
                         "site": "ttwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "ukwiki": {
                         "site": "ukwiki",
                         "title": "Nirvana",
                         "badges": []
                       },
                       "uzwiki": {
                         "site": "uzwiki",
                         "title": "Nirvana (guruh)",
                         "badges": [
                           "Q17437798"
                         ]
                       },
                       "viwiki": {
                         "site": "viwiki",
                         "title": "Nirvana (ban nhạc)",
                         "badges": []
                       },
                       "warwiki": {
                         "site": "warwiki",
                         "title": "Nirvana (banda)",
                         "badges": []
                       },
                       "wuuwiki": {
                         "site": "wuuwiki",
                         "title": "涅槃乐队",
                         "badges": []
                       },
                       "xmfwiki": {
                         "site": "xmfwiki",
                         "title": "ნირვანა (ბუნა)",
                         "badges": []
                       },
                       "zh_yuewiki": {
                         "site": "zh_yuewiki",
                         "title": "涅槃樂隊",
                         "badges": []
                       },
                       "zhwiki": {
                         "site": "zhwiki",
                         "title": "涅槃乐队",
                         "badges": []
                       }
                     }
                   }
                 },
                 "success": 1
               }
               """;
    }
    
    public void Dispose()
    {
        WikiDataResponse = string.Empty;
    }
}