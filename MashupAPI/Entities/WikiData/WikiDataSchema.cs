namespace MashupAPI.Entities.WikiData;

public static class WikiDataSchema
{
    public const string Schema = """
                                    {
                                   "$schema": "https://json-schema.org/draft/2020-12/schema",
                                   "title": "WikiData Schema",
                                   "type": "object",
                                   "properties": {
                                     "entities": {
                                       "type": "object",
                                       "properties": {
                                         "anyOf": {
                                           "type": "object",
                                           "properties": {
                                             "type": {
                                               "type": "string"
                                             },
                                             "id": {
                                               "type": "string"
                                             },
                                             "sitelinks": {
                                               "type": "object",
                                               "properties": {
                                                 "anyOf": {
                                                   "$dynamicRef": "#genericSitelink"
                                                 }
                                               },
                                               "required": [
                                                 "genericSitelink"
                                               ]
                                             }
                                           },
                                           "required": [
                                             "type",
                                             "id",
                                             "sitelinks"
                                           ]
                                         }
                                       }
                                     },
                                     "success": {
                                       "type": "number"
                                     }
                                   },
                                   "required": [
                                     "entities",
                                     "success"
                                   ],
                                   "$defs": {
                                     "genericEntity": {
                                       "$dynamicAnchor": "genericEntity",
                                       "type": "string"
                                     },
                                     "genericSitelink": {
                                       "$dynamicAnchor": "genericSitelink",
                                       "type": "object",
                                       "properties": {
                                         "site": {
                                           "type": "string"
                                         },
                                         "title": {
                                           "type": "string"
                                         },
                                         "badges": {
                                           "type": "array",
                                           "items": {
                                             "type": "string"
                                           }
                                         }
                                       },
                                       "required": [
                                         "site",
                                         "title",
                                         "badges"
                                       ]
                                     }
                                   }
                                 }
                                 """;
}