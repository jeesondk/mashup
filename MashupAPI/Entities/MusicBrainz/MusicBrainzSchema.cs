namespace MashupAPI.Entities.MusicBrainz;

public static class MusicBrainzSchema
{
    public const string Schema = """
                            {
                            "$schema": "https://json-schema.org/draft/2020-12/schema",
                            "description": "",
                            "type": "object",
                            "properties": {
                              "name": {
                                "type": "string",
                                "minLength": 1
                              },
                              "relations": {
                                "type": "array",
                                "uniqueItems": true,
                                "minItems": 1,
                                "items": {
                                  "required": [
                                    "target-type",
                                    "target-credit",
                                    "direction",
                                    "source-credit",
                                    "type-id",
                                    "ended",
                                    "type"
                                  ],
                                  "properties": {
                                    "target-type": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "target-credit": {
                                      "type": "string"
                                    },
                                    "attribute-ids": {
                                      "type": "object",
                                      "properties": {},
                                      "required": []
                                    },
                                    "direction": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "source-credit": {
                                      "type": "string"
                                    },
                                    "attributes": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "type-id": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "url": {
                                      "type": "object",
                                      "properties": {
                                        "id": {
                                          "type": "string",
                                          "minLength": 1
                                        },
                                        "resource": {
                                          "type": "string",
                                          "minLength": 1
                                        }
                                      },
                                      "required": [
                                        "id",
                                        "resource"
                                      ]
                                    },
                                    "end": {
                                      "type": ["string", "null"],
                                      "properties": {},
                                      "required": []
                                    },
                                    "ended": {
                                      "type": "boolean"
                                    },
                                    "type": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "begin": {
                                      "type": ["string", "null"],
                                      "properties": {},
                                      "required": []
                                    },
                                    "attribute-values": {
                                      "type": "object",
                                      "properties": {},
                                      "required": []
                                    }
                                  }
                                }
                              },
                              "life-span": {
                                "type": "object",
                                "properties": {
                                  "begin": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "ended": {
                                    "type": "boolean"
                                  },
                                  "end": {
                                    "type": "string",
                                    "minLength": 1
                                  }
                                },
                                "required": [
                                  "begin",
                                  "ended",
                                  "end"
                                ]
                              },
                              "disambiguation": {
                                "type": "string",
                                "minLength": 1
                              },
                              "isnis": {
                                "type": "array",
                                "items": {
                                  "required": [],
                                  "properties": {}
                                }
                              },
                              "area": {
                                "type": "object",
                                "properties": {
                                  "type": {
                                    "type": ["object", "null"],
                                    "properties": {},
                                    "required": []
                                  },
                                  "name": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "sort-name": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "iso-3166-1-codes": {
                                    "type": "array",
                                    "items": {
                                      "required": [],
                                      "properties": {}
                                    }
                                  },
                                  "id": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "disambiguation": {
                                    "type": "string"
                                  },
                                  "type-id": {
                                    "type": ["object", "null"],
                                    "properties": {},
                                    "required": []
                                  }
                                },
                                "required": [
                                  "type",
                                  "name",
                                  "sort-name",
                                  "iso-3166-1-codes",
                                  "id",
                                  "disambiguation",
                                  "type-id"
                                ]
                              },
                              "sort-name": {
                                "type": "string",
                                "minLength": 1
                              },
                              "release-groups": {
                                "type": "array",
                                "uniqueItems": true,
                                "minItems": 1,
                                "items": {
                                  "required": [
                                    "primary-type",
                                    "title",
                                    "id",
                                    "first-release-date",
                                    "disambiguation",
                                    "primary-type-id"
                                  ],
                                  "properties": {
                                    "primary-type": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "title": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "secondary-type-ids": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "id": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "first-release-date": {
                                      "type": "string",
                                      "minLength": 1
                                    },
                                    "secondary-types": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "disambiguation": {
                                      "type": "string"
                                    },
                                    "primary-type-id": {
                                      "type": "string",
                                      "minLength": 1
                                    }
                                  }
                                }
                              },
                              "type": {
                                "type": "string",
                                "minLength": 1
                              },
                              "end-area": {
                                "type": ["object", "null"],
                                "properties": {},
                                "required": []
                              },
                              "id": {
                                "type": "string",
                                "minLength": 1
                              },
                              "country": {
                                "type": "string",
                                "minLength": 1
                              },
                              "gender-id": {
                                "type": ["object", "null"],
                                "properties": {},
                                "required": []
                              },
                              "ipis": {
                                "type": "array",
                                "items": {
                                  "required": [],
                                  "properties": {}
                                }
                              },
                              "gender": {
                                "type": ["object", "null"],
                                "properties": {},
                                "required": []
                              },
                              "begin-area": {
                                "type": "object",
                                "properties": {
                                  "sort-name": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "name": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "type": {
                                    "type": ["object", "null"],
                                    "properties": {},
                                    "required": []
                                  },
                                  "disambiguation": {
                                    "type": "string"
                                  },
                                  "id": {
                                    "type": "string",
                                    "minLength": 1
                                  },
                                  "type-id": {
                                    "type": ["object", "null"],
                                    "properties": {},
                                    "required": []
                                  }
                                },
                                "required": [
                                  "sort-name",
                                  "name",
                                  "type",
                                  "disambiguation",
                                  "id",
                                  "type-id"
                                ]
                              },
                              "type-id": {
                                "type": "string",
                                "minLength": 1
                              }
                            },
                            "required": [
                              "name",
                              "relations",
                              "life-span",
                              "disambiguation",
                              "isnis",
                              "area",
                              "sort-name",
                              "release-groups",
                              "type",
                              "end-area",
                              "id",
                              "country",
                              "gender-id",
                              "ipis",
                              "gender",
                              "begin-area",
                              "type-id"
                            ]
                          }
                          """;
}