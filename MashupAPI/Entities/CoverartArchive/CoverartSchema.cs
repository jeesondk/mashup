namespace MashupAPI.Entities.CoverartArchive;

public static class CoverartSchema
{
    public const string Schema = """
                                    {
                                   "$schema": "http://json-schema.org/draft-07/schema#",
                                   "title": "Generated schema for Root",
                                   "type": "object",
                                   "properties": {
                                     "release": {
                                       "type": "string"
                                     },
                                     "images": {
                                       "type": "array",
                                       "items": {
                                         "type": "object",
                                         "properties": {
                                           "edit": {
                                             "type": "number"
                                           },
                                           "id": {
                                             "type": "string"
                                           },
                                           "image": {
                                             "type": "string"
                                           },
                                           "thumbnails": {
                                             "type": "object",
                                             "properties": {
                                               "250": {
                                                 "type": "string"
                                               },
                                               "500": {
                                                 "type": "string"
                                               },
                                               "1200": {
                                                 "type": "string"
                                               },
                                               "small": {
                                                 "type": "string"
                                               },
                                               "large": {
                                                 "type": "string"
                                               }
                                             },
                                             "required": [
                                               "250",
                                               "500",
                                               "1200",
                                               "small",
                                               "large"
                                             ]
                                           },
                                           "comment": {
                                             "type": "string"
                                           },
                                           "approved": {
                                             "type": "boolean"
                                           },
                                           "front": {
                                             "type": "boolean"
                                           },
                                           "types": {
                                             "type": "array",
                                             "items": {
                                               "type": "string"
                                             }
                                           },
                                           "back": {
                                             "type": "boolean"
                                           }
                                         },
                                         "required": [
                                           "edit",
                                           "id",
                                           "image",
                                           "thumbnails",
                                           "comment",
                                           "approved",
                                           "front",
                                           "types",
                                           "back"
                                         ]
                                       }
                                     }
                                   },
                                   "required": [
                                     "release",
                                     "images"
                                   ]
                                 }
                                 """;
}