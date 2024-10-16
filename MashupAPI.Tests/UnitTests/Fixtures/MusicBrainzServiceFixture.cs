
namespace MashupAPI.Tests.UnitTests.Fixtures;

public class MusicBrainzServiceFixture: IDisposable
{

    public string MusicBrainzResponse { get; private set; }
    public string MusicBrainzNoRelationsResponse { get; private set; }

    public MusicBrainzServiceFixture()
    {
        MusicBrainzResponse = InitMusicBrainzResponse();
        MusicBrainzNoRelationsResponse = InitMusicBrainzNoRelationsResponse();
    }

    private string InitMusicBrainzNoRelationsResponse()
    {
      return """
               {
                 "end-area": null,
                 "begin-area": {
                   "sort-name": "Aberdeen",
                   "name": "Aberdeen",
                   "type-id": null,
                   "type": null,
                   "id": "a640b45c-c173-49b1-8030-973603e895b5",
                   "disambiguation": ""
                 },
                 "id": "5b11f4ce-a62d-471e-81fc-a69a8278c7da",
                 "type": "Group",
                 "disambiguation": "1980s~1990s US grunge band",
                 "sort-name": "Nirvana",
                 "area": {
                   "type-id": null,
                   "sort-name": "United States",
                   "disambiguation": "",
                   "type": null,
                   "id": "489ce91b-6658-3307-9877-795b68554c98",
                   "name": "United States",
                   "iso-3166-1-codes": [
                     "US"
                   ]
                 },
                 "type-id": "e431f5f6-b5d2-343d-8b36-72607fffb74b",
                 "relations": [],
                 "country": "US",
                 "isnis": [
                   "0000000123486830",
                   "0000000123487390"
                 ],
                 "gender-id": null,
                 "name": "Nirvana",
                 "release-groups": [
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "Bleach",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "f1afec0b-26dd-3db5-9aa1-c91229a74a24",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "1989-06-01"
                   },
                   {
                     "id": "1b022e01-4da6-387b-8658-8678046e4cef",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "1991-09-24",
                     "title": "Nevermind",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "In Utero",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "2a0981fb-9593-3019-864b-ce934d97a16e",
                     "first-release-date": "1993-09-21"
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "01cf1391-141b-3c87-8650-45ade6e59070",
                     "first-release-date": "1992-01-01",
                     "title": "Incesticide",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "title": "Outcesticide Box Set",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "a934bd4b-4c2c-416b-b541-ba54013aa612",
                     "first-release-date": "1996",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Nirvana",
                     "first-release-date": "2002-10-18",
                     "id": "5ab32af4-c62e-3cbf-aa8c-c761581d3b94",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "first-release-date": "2002-10-23",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "0b8fef8c-1cc5-4ce7-b007-05cbd6d5aa0b",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Greatest Hits",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ],
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "d4d28ec1-220a-327c-93c5-ae006be43598",
                     "first-release-date": "2004-11-23",
                     "title": "With the Lights Out",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "title": "Sliver: The Best of the Box",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "e9674d41-d94b-344a-89f5-734736853d5f",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "2005-10-31",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "first-release-date": "2010-08-31",
                     "id": "5cc5dc44-8860-462e-8aa5-2cf9b71af237",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "ICON"
                   },
                   {
                     "first-release-date": "2011",
                     "id": "95563c6a-92e5-456c-9f86-6fe2ff1d148e",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "2 for 1: Incesticide / In Utero",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1",
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Compilation",
                       "Live"
                     ],
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "55fca0ec-17ed-4860-b700-ef366574aa42",
                     "first-release-date": "1994-11-15",
                     "title": "Live! Tonight! Sold Out!!",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1",
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Compilation",
                       "Live"
                     ],
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "249e7835-5c39-3a10-b15b-e2d3470fb40c",
                     "first-release-date": "1996-09-30",
                     "title": "From the Muddy Banks of the Wishkah",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "fb3770f6-83fb-32b7-85c4-1f522a92287e",
                     "first-release-date": "1994-10-31",
                     "title": "MTV Unplugged in New York",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ]
                   },
                   {
                     "title": "Live at Reading",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "48f5d526-0fa6-4ca6-ac59-9b2cf9ef464f",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "first-release-date": "2009-10-30",
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ],
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "e0372c5a-1750-46ec-8f1b-4b76df1fe8e7",
                     "first-release-date": "2011-09-26",
                     "title": "Live at the Paramount",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ],
                     "id": "c171986d-83d9-4659-9644-ce9dc2b30836",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "first-release-date": "2013-09-23",
                     "title": "Live and Loud",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "first-release-date": "2023-05-30",
                     "id": "f1ffa6a7-d060-4798-89cc-885e804c1c63",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Downer",
                     "secondary-types": [
                       "Live"
                     ],
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ]
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "0a1f2f6c-9882-4fc4-a768-72904e50d530",
                     "first-release-date": "2024-04-19",
                     "title": "Greatest Hits Broadcast Collection",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "81598169-0d6c-3bce-b4be-866fa658eda3"
                     ],
                     "secondary-types": [
                       "Demo"
                     ]
                   },
                   {
                     "first-release-date": "1988-11",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "id": "04f53329-d0d0-3b0d-856a-1e2cbcde0e69",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "title": "Love Buzz",
                     "secondary-types": [],
                     "secondary-type-ids": []
                   },
                   {
                     "title": "Sliver",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "disambiguation": "",
                     "primary-type": "Single",
                     "id": "c01d417b-0e34-3723-9ebe-87de4620080c",
                     "first-release-date": "1990-09",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "title": "Candy / Molly’s Lips",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "id": "8c22577f-aaea-3973-9d27-20731751e088",
                     "first-release-date": "1991-01",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "first-release-date": "1991-06",
                     "id": "40f18565-ab15-3a93-8a9a-4ed6be9a112e",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "title": "Here She Comes Now / Venus in Furs",
                     "secondary-types": [],
                     "secondary-type-ids": []
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "Smells Like Teen Spirit",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "id": "03345972-d2f8-36bb-b49a-03a9ceccb7a7",
                     "disambiguation": "",
                     "primary-type": "Single",
                     "first-release-date": "1991-09-10"
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "id": "6970c348-86ce-3902-bee3-d2ebabc2643d",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "first-release-date": "1992-01",
                     "title": "Come as You Are",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9"
                   }
                 ],
                 "gender": null,
                 "ipis": [],
                 "life-span": {
                   "ended": true,
                   "end": "1994-04-05",
                   "begin": "1987"
                 }
               } 
               """;
    }

    private string InitMusicBrainzResponse()
    {
        return """
               {
                 "end-area": null,
                 "begin-area": {
                   "sort-name": "Aberdeen",
                   "name": "Aberdeen",
                   "type-id": null,
                   "type": null,
                   "id": "a640b45c-c173-49b1-8030-973603e895b5",
                   "disambiguation": ""
                 },
                 "id": "5b11f4ce-a62d-471e-81fc-a69a8278c7da",
                 "type": "Group",
                 "disambiguation": "1980s~1990s US grunge band",
                 "sort-name": "Nirvana",
                 "area": {
                   "type-id": null,
                   "sort-name": "United States",
                   "disambiguation": "",
                   "type": null,
                   "id": "489ce91b-6658-3307-9877-795b68554c98",
                   "name": "United States",
                   "iso-3166-1-codes": [
                     "US"
                   ]
                 },
                 "type-id": "e431f5f6-b5d2-343d-8b36-72607fffb74b",
                 "relations": [
                   {
                     "type-id": "6b3e3c85-0002-4f34-aca6-80ace0d7e846",
                     "attribute-ids": {},
                     "url": {
                       "resource": "https://www.allmusic.com/artist/mn0000357406",
                       "id": "4a425cd3-641d-409c-a282-2334935bf1bd"
                     },
                     "attributes": [],
                     "type": "allmusic",
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": true,
                     "begin": null,
                     "type": "BBC Music page",
                     "url": {
                       "resource": "https://www.bbc.co.uk/music/artists/5b11f4ce-a62d-471e-81fc-a69a8278c7da",
                       "id": "627ce98c-0eef-41c7-b28f-cc3387b98aab"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "d028a975-000c-4525-9333-d3c8425e4b54",
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": "2020-11-19"
                   },
                   {
                     "target-type": "url",
                     "target-credit": "",
                     "end": null,
                     "source-credit": "",
                     "attributes": [],
                     "url": {
                       "resource": "http://www.livenirvana.com/bootography/listing85a9.html?listingquery=all",
                       "id": "73a6779b-8aaa-42ff-9833-e550ad974be4"
                     },
                     "type": "discography page",
                     "type-id": "4fb0eeec-a6eb-4ae3-ad52-b55765b94e8f",
                     "attribute-ids": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {}
                   },
                   {
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attribute-values": {},
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "type-id": "4fb0eeec-a6eb-4ae3-ad52-b55765b94e8f",
                     "attribute-ids": {},
                     "type": "discography page",
                     "url": {
                       "resource": "http://www.livenirvana.com/digitalnirvana/discography/index.html",
                       "id": "aa2f9928-f2d0-4ce3-9714-af7566b9df94"
                     },
                     "attributes": []
                   },
                   {
                     "type": "discography page",
                     "url": {
                       "resource": "http://www.nirvanaarchive.com/",
                       "id": "d0498330-0679-4174-a145-273dd974e09e"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "4fb0eeec-a6eb-4ae3-ad52-b55765b94e8f",
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "attribute-values": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward"
                   },
                   {
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {},
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "attribute-ids": {},
                     "type-id": "04a5b104-a4c2-4bac-99a1-7b837c37d9e4",
                     "attributes": [],
                     "url": {
                       "resource": "https://www.discogs.com/artist/125246",
                       "id": "81846eca-af41-43d0-bcae-b62dbf5cfa2f"
                     },
                     "type": "discogs"
                   },
                   {
                     "type": "fanpage",
                     "url": {
                       "id": "74c7fc4f-cb3d-45ef-9c83-f7a1061f0272",
                       "resource": "http://www.livenirvana.com/"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "f484f897-81cc-406e-96f9-cd799a04ee24",
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null,
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false
                   },
                   {
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "type-id": "f484f897-81cc-406e-96f9-cd799a04ee24",
                     "attribute-ids": {},
                     "type": "fanpage",
                     "url": {
                       "resource": "http://www.nirvanaclub.com/",
                       "id": "e42476ce-e923-498e-8e98-d11ae200aebb"
                     },
                     "attributes": [],
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "type": "free streaming",
                     "attributes": [],
                     "url": {
                       "resource": "https://open.spotify.com/artist/6olE6TJLqED3rqDCT0FyPh",
                       "id": "f6a499eb-5959-4861-95f1-13caec960006"
                     },
                     "attribute-ids": {},
                     "type-id": "769085a1-c2f7-4c24-a532-2375a77693bd",
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": ""
                   },
                   {
                     "type-id": "769085a1-c2f7-4c24-a532-2375a77693bd",
                     "attribute-ids": {},
                     "type": "free streaming",
                     "attributes": [],
                     "url": {
                       "resource": "https://www.deezer.com/artist/415",
                       "id": "05fd4bd7-b7c8-44f3-afdd-0f6b6b0b6092"
                     },
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "attribute-values": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward"
                   },
                   {
                     "attribute-ids": {},
                     "type-id": "769085a1-c2f7-4c24-a532-2375a77693bd",
                     "url": {
                       "id": "c29fa499-8e33-455a-aaa0-d93ea088c55f",
                       "resource": "http://www.pandora.com/nirvana"
                     },
                     "attributes": [],
                     "type": "free streaming",
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url",
                     "attribute-values": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward"
                   },
                   {
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null,
                     "type": "image",
                     "attributes": [],
                     "url": {
                       "id": "88867281-e540-4b37-9fce-870dda1bfd8b",
                       "resource": "https://commons.wikimedia.org/wiki/File:Nirvana_around_1992.jpg"
                     },
                     "type-id": "221132e9-e30e-43f2-a741-15afc4c5fa7c",
                     "attribute-ids": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-values": {}
                   },
                   {
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "type": "IMDb",
                     "url": {
                       "id": "85229dcd-cc79-4ce8-a3be-4b0539e9148a",
                       "resource": "https://www.imdb.com/name/nm1110321/"
                     },
                     "attributes": [],
                     "type-id": "94c8b0cc-4477-4106-932c-da60e63de61c",
                     "attribute-ids": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {}
                   },
                   {
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {},
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url",
                     "attribute-ids": {},
                     "type-id": "08db8098-c0df-4b78-82c3-c8697b4bba7f",
                     "url": {
                       "resource": "https://www.last.fm/music/Nirvana",
                       "id": "36dc918b-2a58-4d31-9ccd-10af003e7386"
                     },
                     "attributes": [],
                     "type": "last.fm"
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "type-id": "e4d73442-3762-45a8-905c-401da65544ed",
                     "attribute-ids": {},
                     "type": "lyrics",
                     "attributes": [],
                     "url": {
                       "id": "740505c7-3a30-4482-8ca6-10183b37d308",
                       "resource": "http://muzikum.eu/en/122-4216/nirvana/lyrics.html"
                     },
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-values": {},
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "type": "lyrics",
                     "attributes": [],
                     "url": {
                       "resource": "https://genius.com/artists/Nirvana",
                       "id": "eb2efdf0-05cf-4ea8-bc00-b1b0d2bcdcfb"
                     },
                     "type-id": "e4d73442-3762-45a8-905c-401da65544ed",
                     "attribute-ids": {}
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attributes": [],
                     "url": {
                       "id": "b7863533-0c1f-405a-9ca0-cd5c09f94efd",
                       "resource": "https://www.musixmatch.com/artist/Nirvana"
                     },
                     "type": "lyrics",
                     "type-id": "e4d73442-3762-45a8-905c-401da65544ed",
                     "attribute-ids": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": ""
                   },
                   {
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-values": {},
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "type": "myspace",
                     "url": {
                       "resource": "https://myspace.com/nirvana",
                       "id": "706cb178-5d5c-49e0-a07f-149751b94043"
                     },
                     "attributes": [],
                     "type-id": "bac47923-ecde-4b59-822e-d08f0cd10156",
                     "attribute-ids": {}
                   },
                   {
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "type": "official homepage",
                     "url": {
                       "resource": "https://www.nirvana.com/",
                       "id": "508e1dc5-bd9e-46ee-a48d-0852fb715029"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "fe33d22f-c3b0-4d68-bd53-a856badf2b15",
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attribute-values": {}
                   },
                   {
                     "target-type": "url",
                     "target-credit": "",
                     "end": null,
                     "source-credit": "",
                     "type": "other databases",
                     "attributes": [],
                     "url": {
                       "resource": "http://id.loc.gov/authorities/names/n92011111",
                       "id": "222144c5-b46d-4d67-9f56-e9fb654e2e86"
                     },
                     "attribute-ids": {},
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-values": {}
                   },
                   {
                     "attribute-ids": {},
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attributes": [],
                     "url": {
                       "resource": "http://musicmoz.org/Bands_and_Artists/N/Nirvana/",
                       "id": "21daaa31-4c41-4fc9-b07d-e77b3f01d3e6"
                     },
                     "type": "other databases",
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false
                   },
                   {
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "type": "other databases",
                     "url": {
                       "resource": "https://catalogue.bnf.fr/ark:/12148/cb13944446b",
                       "id": "96d41441-df74-4dda-8a0f-c99462b22a7c"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55"
                   },
                   {
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "url": {
                       "id": "88a3f586-d383-4cd8-9458-f48512533799",
                       "resource": "https://d-nb.info/gnd/10295339-9"
                     },
                     "attributes": [],
                     "type": "other databases",
                     "end": null,
                     "source-credit": "",
                     "target-credit": "",
                     "target-type": "url",
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": false,
                     "begin": null
                   },
                   {
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null,
                     "type": "other databases",
                     "attributes": [],
                     "url": {
                       "resource": "https://imvdb.com/n/nirvana",
                       "id": "984aef79-06a7-471f-96ef-0f2dd1fd20de"
                     },
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {}
                   },
                   {
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "type": "other databases",
                     "url": {
                       "id": "1631d12d-9c1f-4899-a2d4-f54ffe615ca1",
                       "resource": "https://nla.gov.au/nla.party-1179730"
                     },
                     "attributes": [],
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url"
                   },
                   {
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-ids": {},
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "url": {
                       "id": "07a468c6-3ceb-4e44-b0b9-f46cca1151dc",
                       "resource": "https://rateyourmusic.com/artist/nirvana"
                     },
                     "attributes": [],
                     "type": "other databases",
                     "end": null,
                     "source-credit": "",
                     "target-credit": "",
                     "target-type": "url"
                   },
                   {
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attribute-values": {},
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url",
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "url": {
                       "resource": "https://www.45cat.com/artist/nirvana-us",
                       "id": "856db026-ed62-4d4b-b91e-301ab15bc89f"
                     },
                     "attributes": [],
                     "type": "other databases"
                   },
                   {
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url",
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "type": "other databases",
                     "attributes": [],
                     "url": {
                       "id": "059071fd-b921-4ee4-a031-de11e2c8d4d3",
                       "resource": "https://www.livefans.jp/artists/21724"
                     },
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {}
                   },
                   {
                     "type": "other databases",
                     "url": {
                       "id": "902a6503-ed52-4207-ae6e-f1a64dc53888",
                       "resource": "https://www.musik-sammler.de/artist/nirvana/"
                     },
                     "attributes": [],
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null,
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": false,
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "type": "other databases",
                     "attributes": [],
                     "url": {
                       "resource": "https://www.spirit-of-metal.com/en/band/Nirvana",
                       "id": "dc807420-0cd6-4c4f-8c2e-0c70cbe37f64"
                     },
                     "attribute-ids": {},
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": ""
                   },
                   {
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-values": {},
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": "",
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "attributes": [],
                     "url": {
                       "id": "805e0346-cdfb-4eae-a8c4-f27937288cda",
                       "resource": "https://www.whosampled.com/Nirvana/"
                     },
                     "type": "other databases"
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "type-id": "d94fb61c-fa20-4e3c-a19a-71a949fb2c55",
                     "attribute-ids": {},
                     "type": "other databases",
                     "attributes": [],
                     "url": {
                       "id": "2127a8c5-befb-401c-a6f0-057b4f4a4581",
                       "resource": "http://www.worldcat.org/wcidentities/lccn-n92-11111"
                     },
                     "end": null,
                     "source-credit": "",
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "direction": "forward",
                     "ended": true,
                     "begin": null,
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": "2020-10-12",
                     "source-credit": "",
                     "type": "purchase for download",
                     "attributes": [],
                     "url": {
                       "id": "adb16d0b-c38d-471c-b3da-4f715267f620",
                       "resource": "https://play.google.com/store/music/artist?id=Apyli2ev5del3s42qsjpnmqwuue"
                     },
                     "attribute-ids": {},
                     "type-id": "f8319a2f-f824-4617-81c8-be6560b3b203"
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-ids": {},
                     "type-id": "f8319a2f-f824-4617-81c8-be6560b3b203",
                     "url": {
                       "id": "9fc44b9f-8ca9-4079-952f-fcd8a2976dbf",
                       "resource": "https://itunes.apple.com/us/artist/id112018"
                     },
                     "attributes": [],
                     "type": "purchase for download",
                     "end": null,
                     "source-credit": "",
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "type": "purchase for download",
                     "attributes": [],
                     "url": {
                       "resource": "https://us.7digital.com/artist/nirvana",
                       "id": "d1f77e8a-8483-4add-aaf0-ad362795872c"
                     },
                     "type-id": "f8319a2f-f824-4617-81c8-be6560b3b203",
                     "attribute-ids": {},
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-ids": {},
                     "type-id": "f8319a2f-f824-4617-81c8-be6560b3b203",
                     "url": {
                       "resource": "https://www.junodownload.com/artists/Nirvana/releases/",
                       "id": "5b9a913e-3024-4754-bd0b-abafcfa098d8"
                     },
                     "attributes": [],
                     "type": "purchase for download",
                     "end": null,
                     "source-credit": "",
                     "target-credit": "",
                     "target-type": "url"
                   },
                   {
                     "source-credit": "",
                     "end": null,
                     "target-credit": "",
                     "target-type": "url",
                     "type-id": "f8319a2f-f824-4617-81c8-be6560b3b203",
                     "attribute-ids": {},
                     "type": "purchase for download",
                     "attributes": [],
                     "url": {
                       "id": "1a3728c4-3e23-49c7-916e-02b02af4d6b0",
                       "resource": "https://www.qobuz.com/gb-en/interpreter/nirvana/download-streaming-albums"
                     },
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attribute-values": {}
                   },
                   {
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "url": {
                       "id": "7be83207-f706-435b-81f2-5f57f109e652",
                       "resource": "https://www.cdjapan.co.jp/person/700298036"
                     },
                     "attributes": [],
                     "type": "purchase for mail-order",
                     "type-id": "611b1862-67af-4253-a64f-34adba305d1d",
                     "attribute-ids": {}
                   },
                   {
                     "type": "purevolume",
                     "attributes": [],
                     "url": {
                       "id": "61139a11-0318-481d-b305-bf569e400e50",
                       "resource": "http://www.purevolume.com/Nirvana109A"
                     },
                     "type-id": "b6f02157-a9d3-4f24-9057-0675b2dbc581",
                     "attribute-ids": {},
                     "target-type": "url",
                     "target-credit": "",
                     "end": "2018-06-30",
                     "source-credit": "",
                     "attribute-values": {},
                     "ended": true,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "type-id": "79c5b84d-a206-4f4c-9832-78c028c312c3",
                     "attribute-ids": {},
                     "attributes": [],
                     "url": {
                       "id": "5f33ae58-aa56-40bd-ad14-ab7db9b3d3fd",
                       "resource": "https://secondhandsongs.com/artist/169"
                     },
                     "type": "secondhandsongs",
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "attributes": [],
                     "url": {
                       "id": "47616077-74cb-47c6-8bd4-cf34753a9af0",
                       "resource": "https://www.setlist.fm/setlists/nirvana-7bd69ee8.html"
                     },
                     "type": "setlistfm",
                     "type-id": "bf5d0d5e-27a1-4e94-9df7-3cdc67b3b207",
                     "attribute-ids": {},
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-ids": {},
                     "type-id": "99429741-f3f6-484b-84f8-23af51991770",
                     "url": {
                       "id": "f5cfd704-b99a-45fc-9aed-8747257cad03",
                       "resource": "https://twitter.com/Nirvana"
                     },
                     "attributes": [],
                     "type": "social network",
                     "end": null,
                     "source-credit": "",
                     "target-credit": "",
                     "target-type": "url"
                   },
                   {
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-ids": {},
                     "type-id": "99429741-f3f6-484b-84f8-23af51991770",
                     "type": "social network",
                     "attributes": [],
                     "url": {
                       "resource": "https://www.facebook.com/Nirvana",
                       "id": "a9cec2d1-0544-4dc9-a4b2-640751654573"
                     },
                     "source-credit": "",
                     "end": null,
                     "target-type": "url",
                     "target-credit": ""
                   },
                   {
                     "type-id": "89e4a949-0976-440d-bda1-5f772c1e5710",
                     "attribute-ids": {},
                     "url": {
                       "resource": "https://soundcloud.com/nirvana",
                       "id": "14c6ec03-4bd8-4f12-bfef-f2450746adab"
                     },
                     "attributes": [],
                     "type": "soundcloud",
                     "end": null,
                     "source-credit": "",
                     "target-credit": "",
                     "target-type": "url",
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "type": "streaming",
                     "attributes": [],
                     "url": {
                       "resource": "https://music.amazon.com/artists/B001DTD5NQ",
                       "id": "0d12ebdb-3408-4ef7-ae8f-ef1d88c378af"
                     },
                     "attribute-ids": {},
                     "type-id": "63cc5d1f-f096-4c94-a43f-ecb32ea94161",
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null
                   },
                   {
                     "attribute-values": {},
                     "ended": false,
                     "direction": "forward",
                     "begin": null,
                     "attributes": [],
                     "url": {
                       "resource": "https://music.apple.com/us/artist/112018",
                       "id": "930d6ea3-5ce7-4588-8edf-7ef465acca0c"
                     },
                     "type": "streaming",
                     "type-id": "63cc5d1f-f096-4c94-a43f-ecb32ea94161",
                     "attribute-ids": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": ""
                   },
                   {
                     "target-type": "url",
                     "target-credit": "",
                     "end": null,
                     "source-credit": "",
                     "url": {
                       "id": "a39c4986-e579-4c23-85a4-4137a5d0e63e",
                       "resource": "https://tidal.com/artist/19368"
                     },
                     "attributes": [],
                     "type": "streaming",
                     "attribute-ids": {},
                     "type-id": "63cc5d1f-f096-4c94-a43f-ecb32ea94161",
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attribute-values": {}
                   },
                   {
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {},
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "type": "streaming",
                     "url": {
                       "resource": "https://us.napster.com/artist/nirvana",
                       "id": "821d7ca7-1b18-4df9-8cdd-db892caf2cc7"
                     },
                     "attributes": [],
                     "attribute-ids": {},
                     "type-id": "63cc5d1f-f096-4c94-a43f-ecb32ea94161"
                   },
                   {
                     "target-type": "url",
                     "target-credit": "",
                     "source-credit": "",
                     "end": null,
                     "url": {
                       "resource": "http://viaf.org/viaf/138573893",
                       "id": "421a959a-c50f-4a52-99e4-3c603dd37145"
                     },
                     "attributes": [],
                     "type": "VIAF",
                     "type-id": "e8571dcc-35d4-4e91-a577-a3382fd84460",
                     "attribute-ids": {},
                     "begin": null,
                     "direction": "forward",
                     "ended": false,
                     "attribute-values": {}
                   },
                   {
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "end": null,
                     "source-credit": "",
                     "url": {
                       "id": "1221730c-3a48-49fa-8001-beaa6e93c892",
                       "resource": "https://www.wikidata.org/wiki/Q11649"
                     },
                     "attributes": [],
                     "type": "wikidata",
                     "type-id": "689870a4-a1e4-4912-b17f-7b2664215698",
                     "attribute-ids": {}
                   },
                   {
                     "attribute-values": {},
                     "direction": "forward",
                     "ended": false,
                     "begin": null,
                     "attributes": [],
                     "url": {
                       "id": "81772948-8dd5-4959-9bd3-d7c8c26184fb",
                       "resource": "https://en.wikipedia.org/wiki/Nirvana_(band)"
                     },
                     "type": "wikipedia",
                     "type-id": "29651736-fa6d-48e4-aadc-a557c6add1cb",
                     "attribute-ids": {},
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null
                   },
                   {
                     "begin": null,
                     "ended": false,
                     "direction": "forward",
                     "attribute-values": {},
                     "target-credit": "",
                     "target-type": "url",
                     "source-credit": "",
                     "end": null,
                     "url": {
                       "resource": "https://www.youtube.com/user/NirvanaVEVO",
                       "id": "c8d415be-b993-4ade-bd28-d3ab4806fcbd"
                     },
                     "attributes": [],
                     "type": "youtube",
                     "type-id": "6a540e5b-58c6-4192-b6ba-dbc71ec8fcf0",
                     "attribute-ids": {}
                   }
                 ],
                 "country": "US",
                 "isnis": [
                   "0000000123486830",
                   "0000000123487390"
                 ],
                 "gender-id": null,
                 "name": "Nirvana",
                 "release-groups": [
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "Bleach",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "f1afec0b-26dd-3db5-9aa1-c91229a74a24",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "1989-06-01"
                   },
                   {
                     "id": "1b022e01-4da6-387b-8658-8678046e4cef",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "1991-09-24",
                     "title": "Nevermind",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "In Utero",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "2a0981fb-9593-3019-864b-ce934d97a16e",
                     "first-release-date": "1993-09-21"
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "01cf1391-141b-3c87-8650-45ade6e59070",
                     "first-release-date": "1992-01-01",
                     "title": "Incesticide",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "title": "Outcesticide Box Set",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "a934bd4b-4c2c-416b-b541-ba54013aa612",
                     "first-release-date": "1996",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Nirvana",
                     "first-release-date": "2002-10-18",
                     "id": "5ab32af4-c62e-3cbf-aa8c-c761581d3b94",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "first-release-date": "2002-10-23",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "0b8fef8c-1cc5-4ce7-b007-05cbd6d5aa0b",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Greatest Hits",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ],
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "d4d28ec1-220a-327c-93c5-ae006be43598",
                     "first-release-date": "2004-11-23",
                     "title": "With the Lights Out",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "title": "Sliver: The Best of the Box",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "e9674d41-d94b-344a-89f5-734736853d5f",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "first-release-date": "2005-10-31",
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "secondary-types": [
                       "Compilation"
                     ]
                   },
                   {
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ],
                     "first-release-date": "2010-08-31",
                     "id": "5cc5dc44-8860-462e-8aa5-2cf9b71af237",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "ICON"
                   },
                   {
                     "first-release-date": "2011",
                     "id": "95563c6a-92e5-456c-9f86-6fe2ff1d148e",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "2 for 1: Incesticide / In Utero",
                     "secondary-types": [
                       "Compilation"
                     ],
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1",
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Compilation",
                       "Live"
                     ],
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "55fca0ec-17ed-4860-b700-ef366574aa42",
                     "first-release-date": "1994-11-15",
                     "title": "Live! Tonight! Sold Out!!",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "secondary-type-ids": [
                       "dd2a21e1-0c00-3729-a7a0-de60b84eb5d1",
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Compilation",
                       "Live"
                     ],
                     "primary-type": "Album",
                     "disambiguation": "",
                     "id": "249e7835-5c39-3a10-b15b-e2d3470fb40c",
                     "first-release-date": "1996-09-30",
                     "title": "From the Muddy Banks of the Wishkah",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "fb3770f6-83fb-32b7-85c4-1f522a92287e",
                     "first-release-date": "1994-10-31",
                     "title": "MTV Unplugged in New York",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ]
                   },
                   {
                     "title": "Live at Reading",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "id": "48f5d526-0fa6-4ca6-ac59-9b2cf9ef464f",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "first-release-date": "2009-10-30",
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ]
                   },
                   {
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ],
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "e0372c5a-1750-46ec-8f1b-4b76df1fe8e7",
                     "first-release-date": "2011-09-26",
                     "title": "Live at the Paramount",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ],
                     "secondary-types": [
                       "Live"
                     ],
                     "id": "c171986d-83d9-4659-9644-ce9dc2b30836",
                     "disambiguation": "",
                     "primary-type": "Album",
                     "first-release-date": "2013-09-23",
                     "title": "Live and Loud",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc"
                   },
                   {
                     "first-release-date": "2023-05-30",
                     "id": "f1ffa6a7-d060-4798-89cc-885e804c1c63",
                     "primary-type": "Album",
                     "disambiguation": "",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "title": "Downer",
                     "secondary-types": [
                       "Live"
                     ],
                     "secondary-type-ids": [
                       "6fd474e2-6b58-3102-9d17-d6f7eb7da0a0"
                     ]
                   },
                   {
                     "disambiguation": "",
                     "primary-type": "Album",
                     "id": "0a1f2f6c-9882-4fc4-a768-72904e50d530",
                     "first-release-date": "2024-04-19",
                     "title": "Greatest Hits Broadcast Collection",
                     "primary-type-id": "f529b476-6e62-324f-b0aa-1f3e33d313fc",
                     "secondary-type-ids": [
                       "81598169-0d6c-3bce-b4be-866fa658eda3"
                     ],
                     "secondary-types": [
                       "Demo"
                     ]
                   },
                   {
                     "first-release-date": "1988-11",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "id": "04f53329-d0d0-3b0d-856a-1e2cbcde0e69",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "title": "Love Buzz",
                     "secondary-types": [],
                     "secondary-type-ids": []
                   },
                   {
                     "title": "Sliver",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "disambiguation": "",
                     "primary-type": "Single",
                     "id": "c01d417b-0e34-3723-9ebe-87de4620080c",
                     "first-release-date": "1990-09",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "title": "Candy / Molly’s Lips",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "id": "8c22577f-aaea-3973-9d27-20731751e088",
                     "first-release-date": "1991-01",
                     "secondary-type-ids": [],
                     "secondary-types": []
                   },
                   {
                     "first-release-date": "1991-06",
                     "id": "40f18565-ab15-3a93-8a9a-4ed6be9a112e",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "title": "Here She Comes Now / Venus in Furs",
                     "secondary-types": [],
                     "secondary-type-ids": []
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "title": "Smells Like Teen Spirit",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9",
                     "id": "03345972-d2f8-36bb-b49a-03a9ceccb7a7",
                     "disambiguation": "",
                     "primary-type": "Single",
                     "first-release-date": "1991-09-10"
                   },
                   {
                     "secondary-type-ids": [],
                     "secondary-types": [],
                     "id": "6970c348-86ce-3902-bee3-d2ebabc2643d",
                     "primary-type": "Single",
                     "disambiguation": "",
                     "first-release-date": "1992-01",
                     "title": "Come as You Are",
                     "primary-type-id": "d6038452-8ee0-3f68-affc-2de9a1ede0b9"
                   }
                 ],
                 "gender": null,
                 "ipis": [],
                 "life-span": {
                   "ended": true,
                   "end": "1994-04-05",
                   "begin": "1987"
                 }
               } 
               """;
    }

    
    public void Dispose()
    {
        MusicBrainzResponse = string.Empty;
        MusicBrainzNoRelationsResponse = string.Empty;
    }
}