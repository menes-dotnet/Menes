// <copyright file="JsonSchemaBuilder.CreateDeclarations.ConversionOperators.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Text.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void AddConversionOperatorsFor(string typeString, JsonElement format, TypeDeclaration typeDeclaration)
        {
            switch (typeString)
            {
                case "string":
                    this.AddStringConversionOperators(format, typeDeclaration);
                    break;
                case "boolean":
                    this.AddBooleanConversionOperators(typeDeclaration);
                    break;
                case "number":
                    this.AddNumberConversionOperators(format, typeDeclaration);
                    break;
                case "integer":
                    this.AddIntegerConversionOperators(format, typeDeclaration);
                    break;
                default:
                    break;
            }
        }

        private void AddIntegerConversionOperators(JsonElement format, TypeDeclaration typeDeclaration)
        {
            string? formatString = format.ValueKind == JsonValueKind.String ? format.GetString() : null;

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.IntegerTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.NumberTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt64RawTypeDeclaration,
                    Via = TypeDeclarations.IntegerTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt32RawTypeDeclaration,
                    Via = TypeDeclarations.IntegerTypeDeclaration,
                });

            if (formatString is not string || formatString == "int32")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt32TypeDeclaration,
                });
            }

            if (formatString is not string || formatString == "int64")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt64TypeDeclaration,
                });
            }
        }

        private void AddNumberConversionOperators(JsonElement format, TypeDeclaration typeDeclaration)
        {
            string? formatString = format.ValueKind == JsonValueKind.String ? format.GetString() : null;

            if (formatString is not string)
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt32TypeDeclaration,
                });
            }

            if (formatString is not string)
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt64TypeDeclaration,
                });
            }

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.NumberTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt32RawTypeDeclaration,
                    Via = TypeDeclarations.NumberTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrInt64RawTypeDeclaration,
                    Via = TypeDeclarations.NumberTypeDeclaration,
                });

            if (formatString is not string || formatString == "double")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrDoubleTypeDeclaration,
                });

                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDoubleRawTypeDeclaration,
                        Via = TypeDeclarations.NumberTypeDeclaration,
                    });

                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrFloatRawTypeDeclaration,
                        Via = TypeDeclarations.NumberTypeDeclaration,
                    });
            }

            if (formatString is not string || formatString == "single")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrFloatTypeDeclaration,
                });

                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDoubleRawTypeDeclaration,
                        Via = TypeDeclarations.NumberTypeDeclaration,
                    });

                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrFloatRawTypeDeclaration,
                        Via = TypeDeclarations.NumberTypeDeclaration,
                    });
            }
        }

        private void AddBooleanConversionOperators(TypeDeclaration typeDeclaration)
        {
            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrBoolTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrBoolRawTypeDeclaration,
                    Via = TypeDeclarations.ClrBoolTypeDeclaration,
                });
        }

        private void AddStringConversionOperators(JsonElement format, TypeDeclaration typeDeclaration)
        {
            string? formatString = format.ValueKind == JsonValueKind.String ? format.GetString() : null;

            if (formatString is string && formatString == "date")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDateTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "date-time")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDateTimeTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "date")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDateTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "time")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrTimeTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "duration")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrDurationTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "email")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.EmailTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "idn-email")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.EmailTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "hostname")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.HostnameTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "idn-hostname")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.HostnameTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "ipv4")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.IpV4TypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "ipv6")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.IpV6TypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "uuid")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrGuidTypeDeclaration,
                    });
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrGuidRawTypeDeclaration,
                        Via = TypeDeclarations.ClrGuidTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "uri")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrUriTypeDeclaration,
                    });
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrUriRawTypeDeclaration,
                        Via = TypeDeclarations.ClrUriTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "uri-reference")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrUriReferenceTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "uri-template")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrUriTemplateTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "iri")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrIriTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "iri-reference")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrIriReferenceTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "json-pointer")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrJsonPointerTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "relative-json-pointer")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                        TargetType = TypeDeclarations.ClrRelativeJsonPointerTypeDeclaration,
                    });
            }

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrStringTypeDeclaration,
                });

            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.Cast,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrStringRawTypeDeclaration,
                    Via = TypeDeclarations.ClrStringTypeDeclaration,
                });
        }
    }
}