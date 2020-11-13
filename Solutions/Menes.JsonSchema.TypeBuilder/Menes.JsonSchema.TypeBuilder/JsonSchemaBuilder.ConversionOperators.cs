// <copyright file="JsonSchemaBuilder.ConversionOperators.cs" company="Endjin Limited">
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
                    this.AddBooleanConversionOperators(format, typeDeclaration);
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
                    Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
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
                    Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                    TargetType = TypeDeclarations.ClrInt64TypeDeclaration,
                });
            }

            if (formatString is not string || formatString == "double")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = TypeDeclarations.ClrDoubleTypeDeclaration,
                });
            }

            if (formatString is not string || formatString == "single")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                    TargetType = TypeDeclarations.ClrFloatTypeDeclaration,
                });
            }

            if (formatString is not string || formatString == "decimal")
            {
                typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                    TargetType = TypeDeclarations.ClrDecimalTypeDeclaration,
                });
            }
        }

        private void AddBooleanConversionOperators(JsonElement format, TypeDeclaration typeDeclaration)
        {
            typeDeclaration.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                    TargetType = TypeDeclarations.ClrBoolTypeDeclaration,
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
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrDateTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "datetime")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrDateTimeTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "date")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrDateTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "time")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrTimeTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "duration")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrDurationTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "email")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.EmailTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "idn-email")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.EmailTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "hostname")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.HostnameTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "idn-hostname")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.HostnameTypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "ipv4")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.IpV4TypeDeclaration,
                    });
            }
            else if (formatString is string && formatString == "ipv6")
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.IpV6TypeDeclaration,
                    });
            }
            else
            {
                typeDeclaration.AddConversionOperator(
                    new ConversionOperatorDeclaration
                    {
                        Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                        Direction = ConversionOperatorDeclaration.ConversionDirection.FromImplicit,
                        TargetType = TypeDeclarations.ClrStringTypeDeclaration,
                    });
            }
        }
    }
}