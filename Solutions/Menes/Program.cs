// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes
{
    using System.Linq;
    using System.Text.Json;
    using AdditionalItemsFeature.AdditionalItemsAsFalseWithoutItems;
    using Menes.Json;

    class Program
    {
        static void Main(string[] args)
        {
            Schema schema = JsonAny.Parse(@"[ 1, 2, 3, 4, 5 ]");

            var valid = schema.Validate();

            bool isValid = valid.IsValid;

////            Schema schema = JsonAny.Parse(@"{
////                    ""$id"": ""http://localhost:1234/root"",
////                    ""$ref"": ""http://localhost:1234/nested.json#/$defs/B"",
////                    ""$defs"": {
////                ""A"": {
////                    ""$id"": ""nested.json"",
////                            ""$defs"": {
////                        ""B"": {
////                            ""$id"": ""#"",
////                                    ""type"": ""integer""
////                                }
////                    }
////                }
////            }
////        }");

////            var validated = schema.Validate();

////            schema = schema.WithAdditionalItems(true);

////            schema = schema.WithType(SimpleTypesEntity.EnumValues.Array);

////            bool isApplicator = schema.IsApplicator;

////            Schema anotherSchema = Schema.Create(
////                id: "https://endjin.com/api/schema/example",
////                items: Schema.Create(
////                    type: SimpleTypesEntity.EnumValues.String,
////                    format: "uuid"),
////                minItems: 1,
////                maxItems: 10
////                );


////            OpenApi.Schema openApiSchema = JsonAny.Parse(@"{
////                    ""openapi"": ""3.0.0"",
////                    ""info"": {
////                ""version"": ""1.0.0"",
////                      ""title"": ""Swagger Petstore"",
////                      ""license"": {
////                    ""name"": ""MIT""
////                      }
////            },
////                    ""servers"": [
////                      {
////                ""url"": ""http://petstore.swagger.io/v1""
////                      }
////                    ],
////                    ""paths"": {
////                ""/pets"": {
////                    ""get"": {
////                        ""summary"": ""List all pets"",
////                          ""operationId"": ""listPets"",
////                          ""tags"": [
////                            ""pets""
////                          ],
////                          ""parameters"": [
////                            {
////                            ""name"": ""limit"",
////                              ""in"": ""query"",
////                              ""description"": ""How many items to return at one time (max 100)"",
////                              ""required"": false,
////                              ""schema"": {
////                                ""type"": ""integer"",
////                                ""format"": ""int32""
////                              }
////                        }
////                          ],
////                          ""responses"": {
////                            ""200"": {
////                                ""description"": ""A paged array of pets"",
////                              ""headers"": {
////                                    ""x-next"": {
////                                        ""description"": ""A link to the next page of responses"",
////                                  ""schema"": {
////                                            ""type"": ""string""
////                                  }
////                                    }
////                                },
////                              ""content"": {
////                                    ""application/json"": {
////                                        ""schema"": {
////                                            ""$ref"": ""#/components/schemas/Pets""
////                                        }
////                                    }
////                                }
////                            },
////                            ""default"": {
////                                ""description"": ""unexpected error"",
////                              ""content"": {
////                                    ""application/json"": {
////                                        ""schema"": {
////                                            ""$ref"": ""#/components/schemas/Error""
////                                        }
////                                    }
////                                }
////                            }
////                        }
////                    },
////                        ""post"": {
////                        ""summary"": ""Create a pet"",
////                          ""operationId"": ""createPets"",
////                          ""tags"": [
////                            ""pets""
////                          ],
////                          ""responses"": {
////                            ""201"": {
////                                ""description"": ""Null response""
////                            },
////                            ""default"": {
////                                ""description"": ""unexpected error"",
////                              ""content"": {
////                                    ""application/json"": {
////                                        ""schema"": {
////                                            ""$ref"": ""#/components/schemas/Error""
////                                        }
////                                    }
////                                }
////                            }
////                        }
////                    }
////                },
////                      ""/pets/{petId}"": {
////                    ""get"": {
////                        ""summary"": ""Info for a specific pet"",
////                          ""operationId"": ""showPetById"",
////                          ""tags"": [
////                            ""pets""
////                          ],
////                          ""parameters"": [
////                            {
////                            ""name"": ""petId"",
////                              ""in"": ""path"",
////                              ""required"": true,
////                              ""description"": ""The id of the pet to retrieve"",
////                              ""schema"": {
////                                ""type"": ""string""
////                              }
////                        }
////                          ],
////                          ""responses"": {
////                            ""200"": {
////                                ""description"": ""Expected response to a valid request"",
////                              ""content"": {
////                                    ""application/json"": {
////                                        ""schema"": {
////                                            ""$ref"": ""#/components/schemas/Pet""
////                                        }
////                                    }
////                                }
////                            },
////                            ""default"": {
////                                ""description"": ""unexpected error"",
////                              ""content"": {
////                                    ""application/json"": {
////                                        ""schema"": {
////                                            ""$ref"": ""#/components/schemas/Error""
////                                        }
////                                    }
////                                }
////                            }
////                        }
////                    }
////                }
////            },
////                    ""components"": {
////                ""schemas"": {
////                    ""Pet"": {
////                        ""type"": ""object"",
////                          ""required"": [
////                            ""id"",
////                            ""name""
////                          ],
////                          ""properties"": {
////                            ""id"": {
////                                ""type"": ""integer"",
////                              ""format"": ""int64""
////                            },
////                            ""name"": {
////                                ""type"": ""string""
////                            },
////                            ""tag"": {
////                                ""type"": ""string""
////                            }
////                        }
////                    },
////                        ""Pets"": {
////                        ""type"": ""array"",
////                          ""items"": {
////                            ""$ref"": ""#/components/schemas/Pet""
////                          }
////                    },
////                        ""Error"": {
////                        ""type"": ""object"",
////                          ""required"": [
////                            ""code"",
////                            ""message""
////                          ],
////                          ""properties"": {
////                            ""code"": {
////                                ""type"": ""integer"",
////                              ""format"": ""int32""
////                            },
////                            ""message"": {
////                                ""type"": ""string""
////                            }
////                        }
////                    }
////                }
////            }
////        }
////");

////            var result = 
////                openApiSchema.Paths.EnumerateObject()
////                    .ToDictionary(
////                        k => k.Name,
////                        v => v.Value.EnumerateObject()
////                            .ToDictionary(k => k.Name, v => v.ValueAs<OpenApi.Schema.PathItemValue>()));

////            var validation = openApiSchema.Validate(level: ValidationLevel.Flag);
        }
    }
}
