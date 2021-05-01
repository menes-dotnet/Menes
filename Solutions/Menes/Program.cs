﻿// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable

namespace Menes
{
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Marain.LineOfBusiness;

    using Menes.Json;
    using Menes.OpenApi;
    using UnevaluatedItemsDraft202012Feature.UnevaluatedItemsAndContainsInteractToControlItemDependencyRelationship;

    ////using UnevaluatedItemsDraft202012Feature.ItemIsEvaluatedInAnUncleSchemaToUnevaluatedItems;

    class Program
    {
        static async Task Main(string[] args)
        {

            Schema schema = JsonAny.Parse(@"[ ""a"", ""b"", ""a"", ""b"", ""a"" ]");

            var result = schema.Validate();

            PersonResource personResource = PersonResource.Create(
                links: PersonResource.LinksValue.Create(
                    self: Link.Create("https://endjin.com/person/bar"),
                    primaryName: Link.Create("https://endjin.com/names/foo")),
                embedded: PersonResource.EmbeddedValue.Create(
                    primaryName: PersonNameResource.Create(
                        links: LinksProperty.Create(
                            self: Link.Create("https://endjin.com/names/foo")),
                        familyName: "Silver",
                        givenName: "John",
                        otherNames: JsonArray.Empty)));

            PersonResource personResource2 = PersonResource.Create(
                links: PersonResource.LinksValue.Create(
                    self: Link.Create("https://endjin.com/person/bat"),
                    primaryName: Link.Create("https://endjin.com/names/baz")),
                embedded: PersonResource.EmbeddedValue.Create(
                    primaryName: PersonNameResource.Create(
                        links: LinksProperty.Create(
                            self: Link.Create("https://endjin.com/names/baz")),
                        familyName: "Pugwash",
                        givenName: "Arthur",
                        otherNames: JsonArray.From("Willam", "Henry"))));

            var personListResource = PersonListResource.Create(
                links: PagedListResource.LinksValue.Create(
                    items: LinkArray.From(personResource.Links.Self, personResource2.Links.Self),
                    self: Link.Create("https://endjin.com/people"),
                    next: Link.Create("https://endjin.com/people?continuationToken=2342fsjdvbawe==")),
                embedded: PersonListResource.EmbeddedValue.Create(
                    PersonListResource.PersonResourceArray.From(personResource, personResource2)));

            using JsonDocument doc = JsonDocument.Parse(@"
{
   ""openapi"": ""3.0.1"",
   ""info"": {
      ""title"": ""Marain Line of Business People API"",
      ""description"": ""An API for storing information about people."",
      ""license"": {
         ""name"": ""MIT""
      },
      ""version"": ""1.0.0""
   },
   ""servers"": [
      {
         ""url"": ""/""
      }
   ],
   ""paths"": {
      ""/{tenantId}/marain/people/"": {
         ""get"": {
            ""summary"": ""Get a list of people, optionally expanding particular relationship types and embedding certain relationships."",
            ""operationId"": ""getPeople"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/rel""
               },
               {
                  ""$ref"": ""#/components/parameters/embed""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/maxEmbedded""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/PersonListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Create a person"",
            ""operationId"": ""createPerson"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               }
            ],
            ""requestBody"": {
               ""description"": ""the details of the person to create"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/CreatePersonRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}"": {
         ""get"": {
            ""summary"": ""Get a person"",
            ""operationId"": ""getPerson"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/rel""
               },
               {
                  ""$ref"": ""#/components/parameters/embed""
               },
               {
                  ""$ref"": ""#/components/parameters/maxEmbedded""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/PersonResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/related/people"": {
         ""get"": {
            ""summary"": ""Get people related to this person, optionally filtering to particular relationship types, and/or particular target person hrefs."",
            ""operationId"": ""getPersonToPersonRelationships"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/rel""
               },
               {
                  ""$ref"": ""#/components/parameters/href""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/RelatedPeopleListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""delete"": {
            ""summary"": ""Delete a specific relationship between two people"",
            ""operationId"": ""deletePersonToPersonRelationship"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/requiredRel""
               },
               {
                  ""$ref"": ""#/components/parameters/requiredHref""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Add a relationship to another person"",
            ""operationId"": ""addPersonToPersonRelationship"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/requiredRel""
               },
               {
                  ""$ref"": ""#/components/parameters/requiredHref""
               }
            ],
            ""requestBody"": {
               ""description"": ""Additional properties for the relationship"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""uniqueItems"": true,
                        ""type"": ""object""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/telephoneNumbers"": {
         ""get"": {
            ""summary"": ""Get a person's telephone numbers"",
            ""operationId"": ""getPersonTelephoneNumbers"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/TelephoneNumberListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Add a telephone number for the person"",
            ""operationId"": ""addPersonTelephoneNumber"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               }
            ],
            ""requestBody"": {
               ""description"": ""The telephone number to add"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/AddTelephoneNumberRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/telephoneNumbers/{telephoneNumberId}"": {
         ""get"": {
            ""summary"": ""Get a particular telephone number"",
            ""operationId"": ""getPersonTelephoneNumber"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/telephoneNumberId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/TelephoneNumberResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""put"": {
            ""summary"": ""Replace a telephone number for the person"",
            ""operationId"": ""replacePersonTelephoneNumber"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/telephoneNumberId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""requestBody"": {
               ""description"": ""The telephone number with which to replace the given number"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/ReplaceTelephoneNumberRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""delete"": {
            ""summary"": ""Delete a telephone number for the person"",
            ""operationId"": ""deletePersonTelephoneNumber"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/telephoneNumberId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/names"": {
         ""get"": {
            ""summary"": ""Get a person's names"",
            ""operationId"": ""getPersonNames"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/PersonNameListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Add a name for the person"",
            ""operationId"": ""addPersonName"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               }
            ],
            ""requestBody"": {
               ""description"": ""The name to add"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/AddPersonNameRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/names/{personNameId}"": {
         ""get"": {
            ""summary"": ""Get a particular name"",
            ""operationId"": ""getPersonName"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/personNameId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/PersonNameResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""put"": {
            ""summary"": ""Replace a name for the person"",
            ""operationId"": ""replacePersonName"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/personNameId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""requestBody"": {
               ""description"": ""The name with which to replace the given name"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/ReplacePersonNameRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""delete"": {
            ""summary"": ""Delete a name for the person"",
            ""operationId"": ""deletePersonName"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/personNameId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/addresses"": {
         ""get"": {
            ""summary"": ""Get a person's addresses"",
            ""operationId"": ""getPersonAddresses"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/AddressListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Add an address for the person"",
            ""operationId"": ""addPersonAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               }
            ],
            ""requestBody"": {
               ""description"": ""The address to add"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/AddAddressRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/addresses/{addressId}"": {
         ""get"": {
            ""summary"": ""Get a particular address"",
            ""operationId"": ""getPersonAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/addressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/AddressResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""put"": {
            ""summary"": ""Replace an address for the person"",
            ""operationId"": ""replacePersonAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/addressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""requestBody"": {
               ""description"": ""The address with which to replace the given address"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/ReplaceAddressRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""delete"": {
            ""summary"": ""Delete an address for the person"",
            ""operationId"": ""deletePersonAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/addressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/emailAddresses"": {
         ""get"": {
            ""summary"": ""Get a person's email addresses"",
            ""operationId"": ""getPersonEmailAddresses"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/continuationToken""
               },
               {
                  ""$ref"": ""#/components/parameters/maxItems""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/EmailAddressListResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""post"": {
            ""summary"": ""Add an email address for the person"",
            ""operationId"": ""addPersonEmailAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               }
            ],
            ""requestBody"": {
               ""description"": ""The email address to add"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/AddEmailAddressRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      },
      ""/{tenantId}/marain/people/{personId}/contactDetails/emailAddresses/{emailAddressId}"": {
         ""get"": {
            ""summary"": ""Get a particular email address"",
            ""operationId"": ""getPersonEmailAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/emailAddressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifNoneMatch""
               }
            ],
            ""responses"": {
               ""200"": {
                  ""description"": ""OK"",
                  ""headers"": {
                     ""ETag"": {
                        ""$ref"": ""#/components/schemas/ETag""
                     }
                  },
                  ""content"": {
                     ""application/json"": {
                        ""schema"": {
                           ""$ref"": ""#/components/schemas/EmailAddressResource""
                        }
                     }
                  }
               },
               ""304"": {
                  ""description"": ""Not modified""
               },
               ""400"": {
                  ""$ref"": ""#/components/responses/BadRequest""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""404"": {
                  ""description"": ""Not found""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""put"": {
            ""summary"": ""Replace an email address for the person"",
            ""operationId"": ""replacePersonEmailAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/emailAddressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""requestBody"": {
               ""description"": ""The email address with which to replace the given email address"",
               ""content"": {
                  ""application/json"": {
                     ""schema"": {
                        ""$ref"": ""#/components/schemas/ReplaceEmailAddressRequest""
                     }
                  }
               }
            },
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         },
         ""delete"": {
            ""summary"": ""Delete an email address for the person"",
            ""operationId"": ""deletePersonEmailAddress"",
            ""parameters"": [
               {
                  ""$ref"": ""#/components/parameters/tenantId""
               },
               {
                  ""$ref"": ""#/components/parameters/personId""
               },
               {
                  ""$ref"": ""#/components/parameters/emailAddressId""
               },
               {
                  ""$ref"": ""#/components/parameters/ifMatch""
               }
            ],
            ""responses"": {
               ""202"": {
                  ""description"": ""Accepted"",
                  ""headers"": {
                     ""Location"": {
                        ""description"": ""the URL of the Marain.OperationsStatus API for this operation."",
                        ""schema"": {
                           ""type"": ""string"",
                           ""format"": ""url""
                        }
                     }
                  }
               },
               ""400"": {
                  ""description"": ""Bad request""
               },
               ""403"": {
                  ""description"": ""Forbidden""
               },
               ""default"": {
                  ""$ref"": ""#/components/responses/UnexpectedError""
               }
            }
         }
      }
   },
   ""components"": {
      ""schemas"": {
         ""AddPersonNameRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""personName"": {
                  ""$ref"": ""#/components/schemas/PersonName""
               }
            },
            ""description"": ""A person name to add""
         },
         ""ReplacePersonNameRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""personName"": {
                  ""$ref"": ""#/components/schemas/PersonName""
               }
            },
            ""description"": ""A person name to replace""
         },
         ""AddEmailAddressRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""emailAddress"": {
                  ""$ref"": ""#/components/schemas/EmailAddress""
               }
            },
            ""description"": ""An email address to add""
         },
         ""ReplaceEmailAddressRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""emailAddress"": {
                  ""$ref"": ""#/components/schemas/EmailAddress""
               }
            },
            ""description"": ""An email address to replace""
         },
         ""AddTelephoneNumberRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""telephoneNumber"": {
                  ""$ref"": ""#/components/schemas/TelephoneNumber""
               }
            },
            ""description"": ""A telephone number to add""
         },
         ""ReplaceTelephoneNumberRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""telephoneNumber"": {
                  ""$ref"": ""#/components/schemas/TelephoneNumber""
               }
            },
            ""description"": ""A telephone number to replace""
         },
         ""AddAddressRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""address"": {
                  ""$ref"": ""#/components/schemas/Address""
               }
            },
            ""description"": ""An address to add""
         },
         ""ReplaceAddressRequest"": {
            ""type"": ""object"",
            ""properties"": {
               ""address"": {
                  ""$ref"": ""#/components/schemas/Address""
               }
            },
            ""description"": ""An address to replace""
         },
         ""CreatePersonRequest"": {
            ""required"": [
               ""primaryName""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""wellKnownId"": {
                  ""maxLength"": 100,
                  ""minLength"": 1,
                  ""type"": ""string""
               },
               ""primaryName"": {
                  ""$ref"": ""#/components/schemas/PersonName""
               }
            }
         },
         ""Resource"": {
            ""required"": [
               ""_links""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""contentType"": {
                  ""type"": ""string"",
                  ""description"": ""The media type of the resource""
               },
               ""_links"": {
                  ""$ref"": ""#/components/schemas/LinksProperty""
               },
               ""_embedded"": {
                  ""$ref"": ""#/components/schemas/EmbeddedProperty""
               }
            }
         },
         ""LinksProperty"": {
            ""title"": ""Hyperlinks"",
            ""required"": [
               ""self""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""self"": {
                  ""$ref"": ""#/components/schemas/Link""
               }
            },
            ""additionalProperties"": {
               ""$ref"": ""#/components/schemas/LinkProperty""
            },
            ""description"": ""Represents a hyperlink from the containing resource to a URI.""
         },
         ""EmbeddedProperty"": {
            ""type"": ""object"",
            ""additionalProperties"": {
               ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
            }
         },
         ""Link"": {
            ""required"": [
               ""href""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""href"": {
                  ""title"": ""URI of the target resource"",
                  ""type"": ""string"",
                  ""description"": ""Either a URI [RFC3986] or URI Template [RFC6570] of the target resource.""
               },
               ""templated"": {
                  ""title"": ""URI Template"",
                  ""type"": ""boolean"",
                  ""description"": ""Is true when the link object's href property is a URI Template. Defaults to false."",
                  ""default"": false
               },
               ""type"": {
                  ""title"": ""Media type indication of the target resource"",
                  ""pattern"": ""^(application|audio|example|image|message|model|multipart|text|video)\\\\/[a-zA-Z0-9!#\\\\$&\\\\.\\\\+-\\\\^_]{1,127}$"",
                  ""type"": ""string"",
                  ""description"": ""When present, used as a hint to indicate the media type expected when dereferencing the target resource.""
               },
               ""name"": {
                  ""title"": ""Secondary key"",
                  ""type"": ""string"",
                  ""description"": ""When present, may be used as a secondary key for selecting link objects that contain the same relation type.""
               },
               ""profile"": {
                  ""title"": ""Additional semantics of the target resource"",
                  ""type"": ""string"",
                  ""description"": ""A URI that, when dereferenced, results in a profile to allow clients to learn about additional semantics (constraints, conventions, extensions) that are associated with the target resource representation, in addition to those defined by the HAL media type and relations."",
                  ""format"": ""uri""
               },
               ""description"": {
                  ""title"": ""Human-readable identifier"",
                  ""type"": ""string"",
                  ""description"": ""When present, is used to label the destination of a link such that it can be used as a human-readable identifier (e.g. a menu entry) in the language indicated by the Content-Language header (if present).""
               },
               ""hreflang"": {
                  ""title"": ""Language indication of the target resource [RFC5988]"",
                  ""pattern"": ""^([a-zA-Z]{2,3}(-[a-zA-Z]{3}(-[a-zA-Z]{3}){0,2})?(-[a-zA-Z]{4})?(-([a-zA-Z]{2}|[0-9]{3}))?(-([a-zA-Z0-9]{5,8}|[0-9][a-zA-Z0-9]{3}))*([0-9A-WY-Za-wy-z](-[a-zA-Z0-9]{2,8}){1,})*(x-[a-zA-Z0-9]{2,8})?)|(x-[a-zA-Z0-9]{2,8})|(en-GB-oed)|(i-ami)|(i-bnn)|(i-default)|(i-enochian)|(i-hak)|(i-klingon)|(i-lux)|(i-mingo)|(i-navajo)|(i-pwn)|(i-tao)|(i-tay)|(i-tsu)|(sgn-BE-FR)|(sgn-BE-NL)|(sgn-CH-DE)|(art-lojban)|(cel-gaulish)|(no-bok)|(no-nyn)|(zh-guoyu)|(zh-hakka)|(zh-min)|(zh-min-nan)|(zh-xiang)$"",
                  ""type"": ""string"",
                  ""description"": ""When present, is a hint in RFC5646 format indicating what the language of the result of dereferencing the link should be.  Note that this is only a hint; for example, it does not override the Content-Language header of a HTTP response obtained by actually following the link.""
               }
            }
         },
         ""LinkCollection"": {
            ""type"": ""array"",
            ""items"": {
               ""$ref"": ""#/components/schemas/Link""
            },
            ""description"": ""a collection of links""
         },
         ""ResourceCollection"": {
            ""type"": ""array"",
            ""items"": {
               ""$ref"": ""#/components/schemas/Resource""
            },
            ""description"": ""a collection of resources""
         },
         ""PagedListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               }
            ],
            ""required"": [
               ""_links""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_links"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/LinksProperty""
                     }
                  ],
                  ""title"": ""Hyperlinks"",
                  ""required"": [
                     ""items""
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""$ref"": ""#/components/schemas/LinkProperty""
                     },
                     ""next"": {
                        ""$ref"": ""#/components/schemas/Link""
                     },
                     ""prev"": {
                        ""$ref"": ""#/components/schemas/Link""
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/LinkProperty""
                  },
                  ""description"": ""Represents a hyperlink from the containing resource to a URI.""
               }
            },
            ""description"": ""A resource representation of a paged list""
         },
         ""ETag"": {
            ""type"": ""string"",
            ""description"": ""The ETAG for a response header"",
            ""format"": ""ETAG""
         },
         ""PersonName"": {
            ""required"": [
               ""givenName"",
               ""familyName"",
               ""otherNames""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""title"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string"",
                  ""description"": ""The person's title or honorific""
               },
               ""givenName"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string"",
                  ""description"": ""The person's given or first name""
               },
               ""familyName"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string"",
                  ""description"": ""The person's family or last name""
               },
               ""suffix"": {
                  ""type"": ""string"",
                  ""description"": ""The suffix to the person's name""
               },
               ""otherNames"": {
                  ""maxItems"": 10,
                  ""minItems"": 0,
                  ""type"": ""array"",
                  ""items"": {
                     ""maxLength"": 50,
                     ""minLength"": 0,
                     ""type"": ""string""
                  },
                  ""description"": ""Middle/additional names for the person""
               }
            },
            ""description"": ""The name of a person""
         },
         ""PersonNameListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/PersonNameResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of names related to some source entity.""
         },
         ""PersonNameResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               },
               {
                  ""$ref"": ""#/components/schemas/PersonName""
               }
            ],
            ""description"": ""A person name""
         },
         ""PersonListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/PersonResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of people.""
         },
         ""RelatedPeopleListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/RelatedPersonResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of people related to some source person.""
         },
         ""RelatedPersonResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PersonResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""rel"": {
                  ""type"": ""string"",
                  ""description"": ""The relationship with the given person""
               },
               ""properties"": {
                  ""uniqueItems"": true,
                  ""type"": ""object""
               }
            }
         },
         ""LinkProperty"": {
            ""uniqueItems"": true,
            ""anyOf"": [
               {
                  ""$ref"": ""#/components/schemas/Link""
               },
               {
                  ""$ref"": ""#/components/schemas/LinkCollection""
               }
            ]
         },
         ""EmbeddedResourceProperty"": {
            ""uniqueItems"": true,
            ""anyOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               },
               {
                  ""$ref"": ""#/components/schemas/ResourceCollection""
               }
            ]
         },
         ""PersonResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_links"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/LinksProperty""
                     }
                  ],
                  ""title"": ""Hyperlinks"",
                  ""required"": [
                     ""primaryName""
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""primaryName"": {
                        ""$ref"": ""#/components/schemas/Link""
                     },
                     ""names"": {
                        ""$ref"": ""#/components/schemas/LinkCollection""
                     },
                     ""addresses"": {
                        ""$ref"": ""#/components/schemas/LinkCollection""
                     },
                     ""telephoneNumbers"": {
                        ""$ref"": ""#/components/schemas/LinkCollection""
                     },
                     ""emailAddresses"": {
                        ""$ref"": ""#/components/schemas/LinkCollection""
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/LinkProperty""
                  },
                  ""description"": ""Represents hyperlinks from the containing resource to a URI.""
               },
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""required"": [
                     ""primaryName""
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""primaryName"": {
                        ""$ref"": ""#/components/schemas/PersonNameResource""
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            }
         },
         ""ProblemDetails"": {
            ""required"": [
               ""status"",
               ""detail""
            ],
            ""properties"": {
               ""status"": {
                  ""type"": ""integer"",
                  ""format"": ""int32""
               },
               ""detail"": {
                  ""type"": ""string""
               },
               ""description"": {
                  ""type"": ""string""
               },
               ""instance"": {
                  ""type"": ""string"",
                  ""format"": ""url""
               },
               ""type"": {
                  ""type"": ""string"",
                  ""format"": ""url""
               },
               ""validationErrors"": {
                  ""type"": ""array"",
                  ""items"": {
                     ""anyOf"": [
                        {
                           ""type"": ""array""
                        },
                        {
                           ""type"": ""boolean""
                        },
                        {
                           ""type"": ""integer""
                        },
                        {
                           ""type"": ""number""
                        },
                        {
                           ""type"": ""object""
                        },
                        {
                           ""type"": ""string""
                        }
                     ]
                  }
               }
            }
         },
         ""TelephoneNumber"": {
            ""required"": [
               ""countryCode"",
               ""nationalDestinationCode"",
               ""subscriberNumber""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""countryCode"": {
                  ""maxLength"": 3,
                  ""minLength"": 1,
                  ""pattern"": ""^[+]?\\d{1,2}$"",
                  ""type"": ""string""
               },
               ""nationalDestinationCode"": {
                  ""maxLength"": 4,
                  ""minLength"": 1,
                  ""pattern"": ""^d{1,4}$"",
                  ""type"": ""string""
               },
               ""subscriberNumber"": {
                  ""maxLength"": 13,
                  ""minLength"": 8,
                  ""pattern"": ""^d{8,13}$"",
                  ""type"": ""string""
               },
               ""timeZone"": {
                  ""type"": ""string""
               }
            },
            ""description"": ""A telephone number compliant with the E.164 numbering plan""
         },
         ""TelephoneNumberListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/TelephoneNumberResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of telephone numbers""
         },
         ""TelephoneNumberResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               },
               {
                  ""$ref"": ""#/components/schemas/TelephoneNumber""
               }
            ],
            ""description"": ""A resource representation of a telephone number""
         },
         ""Address"": {
            ""required"": [
               ""addressLine1"",
               ""townOrCity"",
               ""postalCode""
            ],
            ""type"": ""object"",
            ""properties"": {
               ""addressLine1"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string""
               },
               ""addressLine2"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string""
               },
               ""townOrCity"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string""
               },
               ""region"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string""
               },
               ""timeZone"": {
                  ""type"": ""string""
               },
               ""location"": {
                  ""$ref"": ""#/components/schemas/LatLongPoint""
               }
            },
            ""description"": ""A postal address""
         },
         ""AddressListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/AddressResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of addresses""
         },
         ""AddressResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               },
               {
                  ""$ref"": ""#/components/schemas/Address""
               }
            ],
            ""description"": ""A resource representation of an address""
         },
         ""LatLongPoint"": {
            ""properties"": {
               ""type"": {
                  ""enum"": [
                     ""point""
                  ],
                  ""type"": ""string""
               },
               ""coordinates"": {
                  ""maxItems"": 2,
                  ""minItems"": 2,
                  ""type"": ""array"",
                  ""items"": {
                     ""type"": ""number""
                  }
               }
            },
            ""description"": ""A point defined by latitude and longitude in geojson format.""
         },
         ""EmailAddress"": {
            ""required"": [
               ""address""
            ],
            ""properties"": {
               ""address"": {
                  ""pattern"": ""^((?!\\.)[\\w-_.]*[^.])(@\\w+)(\\.\\w+(\\.\\w+)?[^.\\W])$"",
                  ""type"": ""string"",
                  ""format"": ""email""
               }
            },
            ""description"": ""An email address in standard foo@bar.com format.""
         },
         ""EmailAddressListResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/PagedListResource""
               }
            ],
            ""type"": ""object"",
            ""properties"": {
               ""_embedded"": {
                  ""allOf"": [
                     {
                        ""$ref"": ""#/components/schemas/EmbeddedProperty""
                     }
                  ],
                  ""type"": ""object"",
                  ""properties"": {
                     ""items"": {
                        ""type"": ""array"",
                        ""items"": {
                           ""$ref"": ""#/components/schemas/EmailAddressResource""
                        }
                     }
                  },
                  ""additionalProperties"": {
                     ""$ref"": ""#/components/schemas/EmbeddedResourceProperty""
                  }
               }
            },
            ""description"": ""A resource representation of a list of email addresses""
         },
         ""EmailAddressResource"": {
            ""allOf"": [
               {
                  ""$ref"": ""#/components/schemas/Resource""
               },
               {
                  ""$ref"": ""#/components/schemas/EmailAddress""
               }
            ],
            ""description"": ""A resource representation of an email address""
         }
      },
      ""responses"": {
         ""UnexpectedError"": {
            ""description"": ""Unexpected error"",
            ""content"": {
               ""application/json"": {
                  ""schema"": {
                     ""$ref"": ""#/components/schemas/ProblemDetails""
                  }
               },
               ""application/problem+json"": {
                  ""schema"": {
                     ""$ref"": ""#/components/schemas/ProblemDetails""
                  }
               }
            }
         },
         ""BadRequest"": {
            ""description"": ""Unexpected error"",
            ""content"": {
               ""application/json"": {
                  ""schema"": {
                     ""$ref"": ""#/components/schemas/ProblemDetails""
                  }
               },
               ""application/problem+json"": {
                  ""schema"": {
                     ""$ref"": ""#/components/schemas/ProblemDetails""
                  }
               }
            }
         }
      },
      ""parameters"": {
         ""rel"": {
            ""name"": ""rel"",
            ""in"": ""query"",
            ""description"": ""the optional relationship types for a relationship-related query"",
            ""style"": ""form"",
            ""schema"": {
               ""type"": ""array"",
               ""items"": {
                  ""maxLength"": 50,
                  ""minLength"": 1,
                  ""type"": ""string""
               }
            }
         },
         ""href"": {
            ""name"": ""href"",
            ""in"": ""query"",
            ""description"": ""The URL for the target organizational unit in the relationship"",
            ""schema"": {
               ""type"": ""array"",
               ""items"": {
                  ""type"": ""string""
               },
               ""format"": ""url""
            }
         },
         ""requiredRel"": {
            ""name"": ""rel"",
            ""in"": ""query"",
            ""description"": ""the type of the relationship"",
            ""required"": true,
            ""style"": ""form"",
            ""schema"": {
               ""maxLength"": 50,
               ""minLength"": 1,
               ""type"": ""string""
            }
         },
         ""requiredHref"": {
            ""name"": ""href"",
            ""in"": ""query"",
            ""description"": ""The URL for the target person in the relationship"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string"",
               ""format"": ""url""
            }
         },
         ""tenantId"": {
            ""name"": ""tenantId"",
            ""in"": ""path"",
            ""description"": ""the ID of the tenant making the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""personId"": {
            ""name"": ""personId"",
            ""in"": ""path"",
            ""description"": ""the ID of the person related to the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""addressId"": {
            ""name"": ""addressId"",
            ""in"": ""path"",
            ""description"": ""the ID of the address related to the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""emailAddressId"": {
            ""name"": ""emailAddressId"",
            ""in"": ""path"",
            ""description"": ""the ID of the email address related to the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""personNameId"": {
            ""name"": ""personNameId"",
            ""in"": ""path"",
            ""description"": ""the ID of the person name related to the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""telephoneNumberId"": {
            ""name"": ""telephoneNumberId"",
            ""in"": ""path"",
            ""description"": ""the ID of the telephone number related to the request"",
            ""required"": true,
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""embed"": {
            ""name"": ""embed"",
            ""in"": ""query"",
            ""description"": ""the optional relationship types to include as embedded resources"",
            ""style"": ""form"",
            ""schema"": {
               ""maxLength"": 50,
               ""minLength"": 1,
               ""type"": ""string""
            }
         },
         ""continuationToken"": {
            ""name"": ""continuationToken"",
            ""in"": ""query"",
            ""description"": ""the optional continuation token for the paged API"",
            ""schema"": {
               ""maxLength"": 1024,
               ""minLength"": 1,
               ""type"": ""string""
            }
         },
         ""maxItems"": {
            ""name"": ""maxItems"",
            ""in"": ""query"",
            ""description"": ""the optional maximum number of items for the paged API"",
            ""schema"": {
               ""maximum"": 500,
               ""minimum"": 1,
               ""type"": ""integer"",
               ""default"": 10
            }
         },
         ""maxEmbedded"": {
            ""name"": ""maxEmbedded"",
            ""in"": ""query"",
            ""description"": ""the optional maximum number of items to embed if expanding embedded resources."",
            ""schema"": {
               ""maximum"": 500,
               ""minimum"": 1,
               ""type"": ""integer"",
               ""default"": 10
            }
         },
         ""ifMatch"": {
            ""name"": ""If-Match"",
            ""in"": ""header"",
            ""description"": ""Conditionally execute if the resource's ETAG matches one of the supplied values"",
            ""schema"": {
               ""type"": ""string""
            }
         },
         ""ifNoneMatch"": {
            ""name"": ""If-None-Match"",
            ""in"": ""header"",
            ""description"": ""Conditionally execute if the resource's ETAG does not match any of the supplied values"",
            ""schema"": {
               ""type"": ""string""
            }
         }
      }
   }
}");

            ////Schema schema = JsonAny.Parse(@"[ 1, 2, 3, 4, 5 ]");

            ////var valid = schema.Validate();


            ////Schema schema = JsonAny.Parse(@"{
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

            ////var validated = schema.Validate();

            ////schema = schema.WithAdditionalItems(true);

            ////schema = schema.WithType(Validation.SimpleTypesEntity.EnumValues.Array);

            ////bool isApplicator = schema.IsApplicator;

            ////Schema anotherSchema = Schema.Create(
            ////    id: "https://endjin.com/api/schema/example",
            ////    items: Schema.Create(
            ////        type: Validation.SimpleTypesEntity.EnumValues.String,
            ////        format: "uuid"),
            ////    minItems: 1,
            ////    maxItems: 10
            ////    );


            ////OpenApi.Document openApiSchema = JsonAny.Parse(@"{
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

            ////var result =
            ////    openApiSchema.Paths.EnumerateObject()
            ////        .ToDictionary(
            ////            k => k.Name,
            ////            v => v.Value.EnumerateObject()
            ////                .ToDictionary(k => k.Name, v => v.ValueAs<OpenApi.Document.PathItemValue>()));

            ////var validation = openApiSchema.Validate(level: ValidationLevel.Flag);
        }
    }
}
