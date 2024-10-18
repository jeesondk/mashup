namespace MashupAPI.Entities.Wikipedia;

public static class WikipediaSchema
{
    public const string Schema = """
                                    {
                                   "$schema": "https://json-schema.org/draft/2020-12/schema",
                                   "title": "Wikipedia Schema",
                                   "type": "object",
                                   "properties": {
                                     "batchcomplete": {
                                       "type": "string"
                                     },
                                     "warnings": {
                                       "type": "object",
                                       "properties": {
                                         "extracts": {
                                           "type": "object",
                                           "properties": {
                                             "*": {
                                               "type": "string"
                                             }
                                           },
                                           "required": [
                                             "*"
                                           ]
                                         }
                                       },
                                       "required": [
                                         "extracts"
                                       ]
                                     },
                                     "query": {
                                       "type": "object",
                                       "properties": {
                                         "pages": {
                                           "type": "object",
                                           "properties": {
                                             "anyOf": {
                                               "type": "object",
                                               "properties": {
                                                 "pageid": {
                                                   "type": "integer"
                                                 },
                                                 "ns": {
                                                   "type": "integer"
                                                 },
                                                 "title": {
                                                   "type": "string"
                                                 },
                                                 "extract": {
                                                   "type": "string"
                                                 }
                                               },
                                               "required": [
                                                 "pageid",
                                                 "ns",
                                                 "title",
                                                 "extract"
                                               ]
                                             }
                                           }
                                         }
                                       },
                                       "required": [
                                         "pages"
                                       ]
                                     }
                                   },
                                   "required": [
                                     "batchcomplete",
                                     "warnings",
                                     "query"
                                   ]
                                 }
                                 """;
}