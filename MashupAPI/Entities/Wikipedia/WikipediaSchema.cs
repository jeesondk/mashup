namespace MashupAPI.Entities.Wikipedia;

public static class WikipediaSchema
{
    public const string Schema = """
                                    {
                                   "$schema": "http://json-schema.org/draft-07/schema#",
                                   "title": "Generated schema for Root",
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
                                             "21231": {
                                               "type": "object",
                                               "properties": {
                                                 "pageid": {
                                                   "type": "number"
                                                 },
                                                 "ns": {
                                                   "type": "number"
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
                                           },
                                           "required": [
                                             "21231"
                                           ]
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