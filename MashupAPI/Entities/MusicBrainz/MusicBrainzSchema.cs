namespace MashupAPI.Entities.MusicBrainz;

public static class MusicBrainzSchema
{
    public const string Schema = """
                            {
                            "$schema": "http://json-schema.org/draft-07/schema#",
                            "title": "Generated schema for Root",
                            "type": "object",
                            "properties": {
                              "end-area": {},
                              "begin-area": {
                                "type": "object",
                                "properties": {
                                  "sort-name": {
                                    "type": "string"
                                  },
                                  "name": {
                                    "type": "string"
                                  },
                                  "type-id": {},
                                  "type": {},
                                  "id": {
                                    "type": "string"
                                  },
                                  "disambiguation": {
                                    "type": "string"
                                  }
                                },
                                "required": [
                                  "sort-name",
                                  "name",
                                  "type-id",
                                  "type",
                                  "id",
                                  "disambiguation"
                                ]
                              },
                              "id": {
                                "type": "string"
                              },
                              "type": {
                                "type": "string"
                              },
                              "disambiguation": {
                                "type": "string"
                              },
                              "sort-name": {
                                "type": "string"
                              },
                              "area": {
                                "type": "object",
                                "properties": {
                                  "type-id": {},
                                  "sort-name": {
                                    "type": "string"
                                  },
                                  "disambiguation": {
                                    "type": "string"
                                  },
                                  "type": {},
                                  "id": {
                                    "type": "string"
                                  },
                                  "name": {
                                    "type": "string"
                                  },
                                  "iso-3166-1-codes": {
                                    "type": "array",
                                    "items": {
                                      "type": "string"
                                    }
                                  }
                                },
                                "required": [
                                  "type-id",
                                  "sort-name",
                                  "disambiguation",
                                  "type",
                                  "id",
                                  "name",
                                  "iso-3166-1-codes"
                                ]
                              },
                              "type-id": {
                                "type": "string"
                              },
                              "relations": {
                                "type": "array",
                                "items": {
                                  "type": "object",
                                  "properties": {
                                    "type-id": {
                                      "type": "string"
                                    },
                                    "attribute-ids": {
                                      "type": "object",
                                      "properties": {},
                                      "required": []
                                    },
                                    "url": {
                                      "type": "object",
                                      "properties": {
                                        "resource": {
                                          "type": "string"
                                        },
                                        "id": {
                                          "type": "string"
                                        }
                                      },
                                      "required": [
                                        "resource",
                                        "id"
                                      ]
                                    },
                                    "attributes": {
                                      "type": "array",
                                      "items": {}
                                    },
                                    "type": {
                                      "type": "string"
                                    },
                                    "source-credit": {
                                      "type": "string"
                                    },
                                    "end": {
                                      "type": "string"
                                    },
                                    "target-type": {
                                      "type": "string"
                                    },
                                    "target-credit": {
                                      "type": "string"
                                    },
                                    "attribute-values": {
                                      "type": "object",
                                      "properties": {},
                                      "required": []
                                    },
                                    "ended": {
                                      "type": "boolean"
                                    },
                                    "direction": {
                                      "type": "string"
                                    },
                                    "begin": {}
                                  },
                                  "required": [
                                    "type-id",
                                    "attribute-ids",
                                    "url",
                                    "attributes",
                                    "type",
                                    "source-credit",
                                    "target-type",
                                    "target-credit",
                                    "attribute-values",
                                    "ended",
                                    "direction",
                                    "begin"
                                  ]
                                }
                              },
                              "country": {
                                "type": "string"
                              },
                              "isnis": {
                                "type": "array",
                                "items": {
                                  "type": "string"
                                }
                              },
                              "gender-id": {},
                              "name": {
                                "type": "string"
                              },
                              "release-groups": {
                                "type": "array",
                                "items": {
                                  "type": "object",
                                  "properties": {
                                    "secondary-type-ids": {
                                      "type": "array",
                                      "items": {
                                        "type": "string"
                                      }
                                    },
                                    "secondary-types": {
                                      "type": "array",
                                      "items": {
                                        "type": "string"
                                      }
                                    },
                                    "title": {
                                      "type": "string"
                                    },
                                    "primary-type-id": {
                                      "type": "string"
                                    },
                                    "id": {
                                      "type": "string"
                                    },
                                    "primary-type": {
                                      "type": "string"
                                    },
                                    "disambiguation": {
                                      "type": "string"
                                    },
                                    "first-release-date": {
                                      "type": "string"
                                    }
                                  },
                                  "required": [
                                    "secondary-type-ids",
                                    "secondary-types",
                                    "title",
                                    "primary-type-id",
                                    "id",
                                    "primary-type",
                                    "disambiguation",
                                    "first-release-date"
                                  ]
                                }
                              },
                              "gender": {},
                              "ipis": {
                                "type": "array",
                                "items": {}
                              },
                              "life-span": {
                                "type": "object",
                                "properties": {
                                  "ended": {
                                    "type": "boolean"
                                  },
                                  "end": {
                                    "type": "string"
                                  },
                                  "begin": {
                                    "type": "string"
                                  }
                                },
                                "required": [
                                  "ended",
                                  "end",
                                  "begin"
                                ]
                              }
                            },
                            "required": [
                              "end-area",
                              "begin-area",
                              "id",
                              "type",
                              "disambiguation",
                              "sort-name",
                              "area",
                              "type-id",
                              "relations",
                              "country",
                              "isnis",
                              "gender-id",
                              "name",
                              "release-groups",
                              "gender",
                              "ipis",
                              "life-span"
                            ]
                          }
                          """;
}