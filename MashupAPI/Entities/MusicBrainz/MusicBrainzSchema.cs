namespace MashupAPI.Entities.MusicBrainz;

public static class MusicBrainzSchema
{
    public const string Schema = """
                            {
                            "$schema": "https://json-schema.org/draft/2020-12/schema",
                            "title": "MusicBrainz Schema",
                            "description": "",
                            "type": "object",
                            "properties": {
                              "name": {
                                "type": ["string", "null"]
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
                                      "type": ["string", "null"]
                                    },
                                    "target-credit": {
                                      "type": ["string", "null"]
                                    },
                                    "attribute-ids": {
                                      "type": "object",
                                      "properties": {},
                                      "required": []
                                    },
                                    "direction": {
                                      "type": ["string", "null"]
                                    },
                                    "source-credit": {
                                      "type": ["string", "null"]
                                    },
                                    "attributes": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "type-id": {
                                      "type": ["string", "null"]
                                    },
                                    "url": {
                                      "type": "object",
                                      "properties": {
                                        "id": {
                                          "type": ["string", "null"]
                                        },
                                        "resource": {
                                          "type": ["string", "null"]
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
                                      "type": ["string", "null"]
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
                                    "type": ["string", "null"]
                                  },
                                  "ended": {
                                    "type": "boolean"
                                  },
                                  "end": {
                                    "type": ["string", "null"]
                                  }
                                },
                                "required": [
                                  "begin",
                                  "ended",
                                  "end"
                                ]
                              },
                              "disambiguation": {
                                "type": ["string", "null"]
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
                                    "type": ["string", "null"]
                                  },
                                  "sort-name": {
                                    "type": ["string", "null"]
                                  },
                                  "iso-3166-1-codes": {
                                    "type": "array",
                                    "items": {
                                      "required": [],
                                      "properties": {}
                                    }
                                  },
                                  "id": {
                                    "type": ["string", "null"]
                                  },
                                  "disambiguation": {
                                    "type": ["string", "null"]
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
                                "type": ["string", "null"]
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
                                      "type": ["string", "null"]
                                    },
                                    "title": {
                                      "type": ["string", "null"]
                                    },
                                    "secondary-type-ids": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "id": {
                                      "type": ["string", "null"]
                                    },
                                    "first-release-date": {
                                      "type": ["string", "null"]
                                    },
                                    "secondary-types": {
                                      "type": "array",
                                      "items": {
                                        "required": [],
                                        "properties": {}
                                      }
                                    },
                                    "disambiguation": {
                                      "type": ["string", "null"]
                                    },
                                    "primary-type-id": {
                                      "type": ["string", "null"]
                                    }
                                  }
                                }
                              },
                              "type": {
                                "type": ["string", "null"]
                              },
                              "end-area": {
                                "type": ["object", "null"],
                                "properties": {},
                                "required": []
                              },
                              "id": {
                                "type": ["string", "null"]
                              },
                              "country": {
                                "type": ["string", "null"]
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
                                    "type": ["string", "null"]
                                  },
                                  "name": {
                                    "type": ["string", "null"]
                                  },
                                  "type": {
                                    "type": ["object", "null"],
                                    "properties": {},
                                    "required": []
                                  },
                                  "disambiguation": {
                                    "type": ["string", "null"]
                                  },
                                  "id": {
                                    "type": ["string", "null"]
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
                                "type": ["string", "null"]
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